using DevExpress.Drawing;
using DevExpress.Pdf;
using SkiaSharp.Views.Maui.Controls;
using SkiaSharp;
using System.Windows.Input;
using DevExpress.Maui.Core;
using DevExpress.Office.DigitalSignatures;
using System.IO;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Maui.Storage;
using System;
using System.Linq;

namespace DemoCenter.Maui.DemoModules.OfficeFileAPI.ViewModels;

public class SignatureDemoViewModel : BindableBase {
    #region fields
    ImageSource pdfPreview;
    const string defaultDocumentName = "arrivalform.pdf";
    const string defaultCertificateName = "pfxCertificate.pfx";
    const string defaultCertificatePassword = "123";
    string certificateFullPath;
    string documentFullPath;
    bool isSignatureViewOpened;
    #endregion fields
    #region properties
    public ImageSource PdfPreview {
        get {
            return pdfPreview;
        }
        set {
            pdfPreview = value;
            RaisePropertyChanged();
        }
    }
    public bool IsSignatureViewOpened {
        get {
            return isSignatureViewOpened;
        }
        set {
            isSignatureViewOpened = value;
            RaisePropertyChanged();
        }
    }
    public ICommand SignPdfCommand {
        get;
        set;
    }
    public ICommand OpenFileCommand {
        get;
        set;
    }
    public ICommand OpenSignatureViewCommand {
        get;
        set;
    }
    public ICommand CloseSignatureViewCommand {
        get;
        set;
    }
    #endregion properties
    public SignatureDemoViewModel() {
        InitFiles().Wait();
        UpdatePreview();
        SignPdfCommand = new Command<byte[]>(SignPdf);
        OpenFileCommand = new Command(OpenFile);
        OpenSignatureViewCommand = new Command(OpenSignatureView);
        CloseSignatureViewCommand = new Command(CloseSignatureView);
    }

    private void OpenSignatureView() {
        IsSignatureViewOpened = true;
    }
    private void CloseSignatureView() {
        IsSignatureViewOpened = false;
    }

    private async Task InitFiles() {
        certificateFullPath = await CopyWorkingFilesToAppData(defaultCertificateName);
        documentFullPath = await CopyWorkingFilesToAppData(defaultDocumentName);
    }
    public async Task<string> CopyWorkingFilesToAppData(string fileName) {
        using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(fileName);
        string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, fileName);
        if (File.Exists(targetFile)) {
            File.Delete(targetFile);
        }
        using FileStream outputStream = File.OpenWrite(targetFile);
        fileStream.CopyTo(outputStream);
        return targetFile;
    }
    async void SignPdf(byte[] signatureImage) {
        CloseSignatureView();
        string signedPdfFullName = Path.Combine(FileSystem.Current.AppDataDirectory, Path.GetFileNameWithoutExtension(documentFullPath) + "_Signed1.pdf");
        IEnumerable<PdfFormFieldFacade> fields = GetDocumentFields();
        using var signer = new PdfDocumentSigner(documentFullPath);
        string signatureFieldName = null;
        var signatureField = fields.FirstOrDefault(f => f.Type == PdfFormFieldType.Signature) as PdfSignatureFormFieldFacade;
        if (signatureField == null)
            await Shell.Current.DisplayAlert("No Signature Fields Found", "A new signature field with a default position will be created", "OK");
        else {
            signatureFieldName = signatureField.FullName;
            signer.ClearSignatureField(signatureFieldName);
        }
        if (File.Exists(signedPdfFullName))
            File.Delete(signedPdfFullName);
        signer.SaveDocument(signedPdfFullName, CreateUserSignature(signatureFieldName, defaultCertificatePassword, "USA", "Jane Cooper", "Acknowledgement", signatureImage));
        documentFullPath = signedPdfFullName;
        UpdatePreview();
    }
    IEnumerable<PdfFormFieldFacade> GetDocumentFields() {
        using var processor = new PdfDocumentProcessor();
        processor.LoadDocument(documentFullPath);
        PdfDocumentFacade documentFacade = processor.DocumentFacade;
        PdfAcroFormFacade acroForm = documentFacade.AcroForm;
        return acroForm.GetFields();
    }
    PdfSignatureBuilder CreateUserSignature(string signatureFieldName, string password, string location, string contactInfo, string reason, byte[] signatureImage) {
        Pkcs7Signer pkcs7Signature = new Pkcs7Signer(certificateFullPath, password, HashAlgorithmType.SHA256);
        PdfSignatureBuilder userSignature;
        if (signatureFieldName == null)
            userSignature = new PdfSignatureBuilder(pkcs7Signature, new PdfSignatureFieldInfo(1) { SignatureBounds = new PdfRectangle(394, 254, 482, 286) });
        else
            userSignature = new PdfSignatureBuilder(pkcs7Signature, signatureFieldName);
        userSignature.Location = location;
        userSignature.Name = contactInfo;
        userSignature.Reason = reason;
        if (signatureImage != null) {
            userSignature.SetImageData(signatureImage);
        }
        return userSignature;
    }
    private void UpdatePreview() {
        using Stream pdfStream = File.OpenRead(documentFullPath);
        var processor = new PdfDocumentProcessor() { RenderingEngine = PdfRenderingEngine.Skia };
        processor.LoadDocument(pdfStream);
        DXBitmap image = processor.CreateDXBitmap(1, 1200);

        using MemoryStream previewImageStream = new MemoryStream();
        image.Save(previewImageStream, DXImageFormat.Png);
        previewImageStream.Seek(0, SeekOrigin.Begin);
        var img = SKBitmap.Decode(previewImageStream);

        PdfPreview = (SKBitmapImageSource)img;
    }
    private async void OpenFile() {
        await PickAndShow(new PickOptions {
            PickerTitle = "Select a PDF file",
            FileTypes = FilePickerFileType.Pdf
        });
    }

    public async Task PickAndShow(PickOptions options) {
        try {
            var result = await FilePicker.Default.PickAsync(options);
            if (result != null) {
                if (result.FileName.EndsWith("pdf", StringComparison.OrdinalIgnoreCase)) {
                    var stream = await result.OpenReadAsync();
                    documentFullPath = result.FullPath;
                    UpdatePreview();
                }
            }
        } catch {
            
        }

    }
}