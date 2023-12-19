
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using DevExpress.Maui.Controls;
using DevExpress.Maui.DataGrid;
using Microsoft.Maui.ApplicationModel.DataTransfer;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
#if PaidDemoModules
using DemoCenter.Maui.DemoModules.Grid.Models;
#endif

namespace DemoCenter.Maui.DemoModules.Grid.ViewModels;

public enum ExportFormat {
    Pdf, Xlsx, Docx
}

public enum Orientation {
    Portrait, Landscape
}

public enum PaperSize {
    A4, A3, A5
}

public class ExportViewModel : BindableObject {
#if PaidDemoModules
    Exporter exporter;
#endif
    bool isLandscape;
    BottomSheetState bottomSheetState;
    string fileName;

    public ExportViewModel() {
        this.fileName = "SampleExport";
        this.bottomSheetState = BottomSheetState.Hidden;
        this.isLandscape = true;
#if PaidDemoModules
        this.exporter = new Exporter(OnStartExport, OnEndExport, OnCancelExport);
#endif
        SelectedFormat = ExportFormat.Pdf;
        SelectedPaperSize = PaperSize.A4;
    }

    public ExportFormat SelectedFormat { get; set; }
    public PaperSize SelectedPaperSize { get; set; }

    public bool PortraitSelected {
        get => !this.isLandscape;
        set {
            if (value) {
                this.isLandscape = false;

                OnPropertyChanged(nameof(LandscapeSelected));
            } else {
                OnPropertyChanged(nameof(PortraitSelected));
            }
        }
    }

    public bool LandscapeSelected {
        get => this.isLandscape;
        set {
            if (value) {
                this.isLandscape = true;

                OnPropertyChanged(nameof(PortraitSelected));
            } else {
                OnPropertyChanged(nameof(LandscapeSelected));
            }
        }
    }

    public BottomSheetState BottomSheetState {
        get => this.bottomSheetState;
        set {
            this.bottomSheetState = value;
            OnPropertyChanged();
        }
    }

#if PaidDemoModules
    public bool IsInExport => this.exporter.IsInExport;
#else
    public bool IsInExport => false;
#endif
    public ICommand ExportCommand => new Command<DataGridView>(PerformExport);
    public ICommand CancelExportCommand => new Command(CancelExport);

    string ExportFilePath => Path.Combine(FileSystem.CacheDirectory, this.fileName + $".{SelectedFormat}".ToLower());

    void OnStartExport() {
        OnPropertyChanged(nameof(IsInExport));
    }

    void OnEndExport(Exception ex) {
        
        if (ex is null) {
            Dispatcher.Dispatch(() => {
                CloseBottomSheet();
                OpenShareDialog(ExportFilePath);
            });
        }
        OnPropertyChanged(nameof(IsInExport));
    }

    void OnCancelExport() {
        OnPropertyChanged(nameof(IsInExport));
    }

    void PerformExport(DataGridView grid) {
#if PaidDemoModules
        this.exporter.Export(grid, ExportFilePath, SelectedFormat, SelectedPaperSize, LandscapeSelected);
#endif
    }

    void CancelExport() {
#if PaidDemoModules
        this.exporter.Cancel();
#endif
    }

    void CloseBottomSheet() {
        BottomSheetState = BottomSheetState.Hidden;
    }

    async void OpenShareDialog(string path) {
        await Task.Delay(1000);
        await Share.Default.RequestAsync(new ShareFileRequest {
            Title = "Share exported file",
            File = new ShareFile(path)
        });
    }
}
