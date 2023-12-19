using DevExpress.Drawing;
using DevExpress.Pdf;
using SkiaSharp.Views.Maui.Controls;
using SkiaSharp;
using System.Windows.Input;
using DevExpress.Maui.Core;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Maui.Storage;

namespace DemoCenter.Maui.DemoModules.OfficeFileAPI.ViewModels;

public class FillPDFMainPageViewModel : BindableBase {
    #region fields
    ImageSource pdfPreview;
    const string defaultDocumentName = "arrivalform.pdf";
    string document;
    bool isLoading;
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
    public string Document {
        get {
            return document;
        }
        set {
            document = value;
            RaisePropertyChanged();
        }
    }
    public bool Loading {
        get => isLoading;
        set {
            isLoading = value;
            RaisePropertyChanged();
        }
    }
    public ICommand EditDocumentFieldsCommand {
        get;
        set;
    }
    public ICommand OpenFileCommand {
        get;
        set;
    }
    #endregion properties
    public FillPDFMainPageViewModel() {
        InitFiles().Wait();
        EditDocumentFieldsCommand = new Command(EditDocumentFields);
        OpenFileCommand = new Command(OpenFile);
    }
    async void EditDocumentFields() {
        var navigationParameter = new Dictionary<string, object> { { "Document", Document } };
        await Shell.Current.GoToAsync("editFieldsPage", navigationParameter);
    }
    private async Task InitFiles() {
        string resultPath = await CopyWorkingFilesToAppData(defaultDocumentName);
        Document = resultPath;
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

    public void UpdatePreview() {
        using Stream pdfStream = System.IO.File.OpenRead(Document);

        using var processor = new PdfDocumentProcessor();
        processor.RenderingEngine = PdfRenderingEngine.Skia;
        processor.LoadDocument(pdfStream);

        DXBitmap image = processor.CreateDXBitmap(1, 1200);

        using MemoryStream previewImageStream = new MemoryStream();
        image.Save(previewImageStream, DXImageFormat.Png);
        previewImageStream.Seek(0, SeekOrigin.Begin);

        var img = SKBitmap.Decode(previewImageStream);

        PdfPreview = (SKBitmapImageSource)img;
        processor.CloseDocument();
    }

    private async void OpenFile() {
        try {
            var result = await FilePicker.Default.PickAsync(new PickOptions { PickerTitle = "Select a PDF file", FileTypes = FilePickerFileType.Pdf });
            if (result != null)
                Document = result.FullPath;
        } catch {
            
        }
        UpdatePreview();
    }
}