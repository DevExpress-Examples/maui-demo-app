using DevExpress.Maui.Core;
using DevExpress.Spreadsheet;
using DevExpress.XtraPrinting;
using DevExpress.XtraRichEdit;
using Microsoft.Maui.ApplicationModel.DataTransfer;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCenter.Maui.DemoModules.OfficeFileAPI.ViewModels;

public class ConverterViewModel : BindableBase {

    #region properties
    private readonly List<FileFormat> allFormats;
    private FileResult selectedFile;

    private IEnumerable<FileFormat> availableTargetFormats;
    public IEnumerable<FileFormat> AvailableTargetFormats {
        get => availableTargetFormats;
        set {
            availableTargetFormats = value;
            RaisePropertyChanged();
        }
    }

    FileFormat selectedTargetFormat;
    public FileFormat SelectedTargetFormat {
        get => selectedTargetFormat;
        set {
            selectedTargetFormat = value;
            RaisePropertiesChanged();
            ConvertFileCommand.ChangeCanExecute();
        }
    }

    bool isFileSelected;
    public bool IsFileSelectedInvert => !isFileSelected;
    public bool IsFileSelected {
        get => isFileSelected;
        set {
            isFileSelected = value;
            RaisePropertiesChanged();
            ConvertFileCommand.ChangeCanExecute();
        }
    }

    FileFormat selectedSourceFormat;
    public FileFormat SelectedSourceFormat {
        get => selectedSourceFormat;
        set {
            selectedSourceFormat = value;
            RaisePropertiesChanged();
            ConvertFileCommand.ChangeCanExecute();
        }
    }

    string selectedFileName;
    public string SelectedFileName {
        get => selectedFileName;
        set {
            selectedFileName = value;
            RaisePropertyChanged();
        }
    }

    public Command SelectFileCommand { get; set; }
    public Command ConvertFileCommand { get; set; }
    #endregion properties

    public ConverterViewModel() {
        SelectFileCommand = new Command(async () => await SelectFile());
        ConvertFileCommand = new Command(async () => await ConvertFile(), () => SelectedSourceFormat != null && SelectedTargetFormat != null);

        var pdf = new FileFormat { Extension = ".pdf", Image = "pdf_image" };
        var xls = new FileFormat { Extension = ".xls", Image = "xls_image" };
        var xlsx = new FileFormat { Extension = ".xlsx", Image = "xlsx_image" };
        var html = new FileFormat { Extension = ".html", Image = "html_image" };
        var doc = new FileFormat { Extension = ".doc", Image = "doc_image" };
        var docx = new FileFormat { Extension = ".docx", Image = "docx_image" };
        var rtf = new FileFormat { Extension = ".rtf", Image = "rft_image" };

        doc.AvailableExports = new List<Export>() {
            new Export { Target = pdf, ConvertDelegate = ConvertDocToPDF },
            new Export { Target = html, ConvertDelegate = ConvertDocToHTML }
        };
        docx.AvailableExports = new List<Export>() {
            new Export { Target = pdf, ConvertDelegate = ConvertDocToPDF },
            new Export { Target = html, ConvertDelegate = ConvertDocToHTML }
        };
        rtf.AvailableExports = new List<Export>() {
            new Export { Target = pdf, ConvertDelegate = ConvertDocToPDF },
            new Export { Target = html, ConvertDelegate = ConvertDocToHTML }
        };
        html.AvailableExports = new List<Export>() {
            new Export { Target = pdf, ConvertDelegate = ConvertHTMLToPDF },
            new Export { Target = docx, ConvertDelegate = ConvertHTMlToDoc },
        };
        xls.AvailableExports = new List<Export>() {
            new Export { Target = pdf, ConvertDelegate = ConvertExcelToPDF }
        };
        xlsx.AvailableExports = new List<Export>() {
            new Export { Target = pdf, ConvertDelegate = ConvertExcelToPDF }
        };

        allFormats = new List<FileFormat>() { pdf, xls, xlsx, html, doc, docx, rtf };
        AvailableTargetFormats = allFormats;
    }

    private async Task SelectFile() {
        var options = new PickOptions() { PickerTitle = "Select a File to Convert" };
        var result = await FilePicker.Default.PickAsync(options);
        if (result == null)
            return;

        selectedFile = result;
        IsFileSelected = true;
        SelectedFileName = result.FileName;
        SelectedSourceFormat = allFormats.FirstOrDefault(f => f.Extension == Path.GetExtension(result.FileName));
        UpdateTargetFormatsFilter();
    }
    public async Task ShareFile(string convertedFile) {
        string file = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, convertedFile);
        if (!File.Exists(file))
            return;
        await Share.Default.RequestAsync(new ShareFileRequest {
            Title = "Share file",
            File = new ShareFile(file)
        });
    }

    public async Task ConvertFile() {
        string outputFile = Path.Combine(FileSystem.Current.AppDataDirectory, SelectedFileName + SelectedTargetFormat.Extension);

        if (SelectedSourceFormat == null)
            return;

        var convertDelegate = SelectedSourceFormat.AvailableExports?.FirstOrDefault(e => e.Target == SelectedTargetFormat)?.ConvertDelegate;
        if (convertDelegate == null)
            return;

        await convertDelegate.Invoke(outputFile);
        await ShareFile(outputFile);
    }
    void UpdateTargetFormatsFilter() {
        if (SelectedSourceFormat == null) {
            AvailableTargetFormats = null;
            return;
        }
        AvailableTargetFormats = SelectedSourceFormat.AvailableExports?.Select(e => e.Target);
        SelectedTargetFormat = AvailableTargetFormats?.FirstOrDefault();
    }


    #region Converter
    async Task ConvertDocToPDF(string outputFile) {
        RichEditDocumentServer server = new RichEditDocumentServer();
        var sourceFileStream = await selectedFile.OpenReadAsync();
        sourceFileStream.Seek(0, SeekOrigin.Begin);
        server.LoadDocument(sourceFileStream, DevExpress.XtraRichEdit.DocumentFormat.OpenXml);
        using FileStream outputStream = System.IO.File.OpenWrite(outputFile);
        server.ExportToPdf(outputStream, CreatePdfExportOptions());
    }
    async Task ConvertExcelToPDF(string outputFile) {
        using Workbook workbook = new Workbook();
        var sourceFileStream = await selectedFile.OpenReadAsync();
        sourceFileStream.Seek(0, SeekOrigin.Begin);
        workbook.LoadDocument(sourceFileStream);
        workbook.ExportToPdf(outputFile);
    }
    async Task ConvertDocToHTML(string outputFile) {
        RichEditDocumentServer server = new RichEditDocumentServer();
        var sourceFileStream = await selectedFile.OpenReadAsync();
        sourceFileStream.Seek(0, SeekOrigin.Begin);
        server.LoadDocument(sourceFileStream, DevExpress.XtraRichEdit.DocumentFormat.OpenXml);
        using FileStream outputStream = System.IO.File.OpenWrite(outputFile);
        server.SaveDocument(outputStream, DevExpress.XtraRichEdit.DocumentFormat.Html);
    }
    async Task ConvertHTMlToDoc(string outputFile) {
        RichEditDocumentServer server = new RichEditDocumentServer();
        var sourceFileStream = await selectedFile.OpenReadAsync();
        sourceFileStream.Seek(0, SeekOrigin.Begin);
        server.LoadDocument(sourceFileStream);
        server.SaveDocument(outputFile, DevExpress.XtraRichEdit.DocumentFormat.OpenXml);
    }
    async Task ConvertHTMLToPDF(string outputFile) {
        RichEditDocumentServer server = new RichEditDocumentServer();
        var sourceFileStream = await selectedFile.OpenReadAsync();
        sourceFileStream.Seek(0, SeekOrigin.Begin);
        server.LoadDocument(sourceFileStream);
        server.ExportToPdf(outputFile, CreatePdfExportOptions());
    }
    PdfExportOptions CreatePdfExportOptions() {
        PdfExportOptions options = new PdfExportOptions();
        options.DocumentOptions.Author = "Test User";
        options.Compressed = false;
        options.ImageQuality = PdfJpegImageQuality.Highest;
        return options;
    }
    #endregion Converter
}


public class FileFormat {
    public string Extension { get; set; }
    public string Image { get; set; }
    public List<Export> AvailableExports { get; set; }
}

public class Export {
    public FileFormat Target { get; set; }
    public Func<string, Task> ConvertDelegate { get; set; }
}