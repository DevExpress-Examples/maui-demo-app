
using System;
using System.Threading;
using System.Threading.Tasks;
using DemoCenter.Maui.DemoModules.Grid.ViewModels;
using DevExpress.Drawing.Printing;
using DevExpress.Maui.DataGrid;
using DevExpress.Maui.DataGrid.Export;

namespace DemoCenter.Maui.DemoModules.Grid.Models;

public class Exporter {
    object lockObject = new object();
    CancellationTokenSource cancellationTokenSource;
    public bool IsInExport => this.cancellationTokenSource != null;

    Action onStartExport;
    Action<Exception> onEndExport;
    Action onCancelExport;

    public Exporter(Action onStartExport, Action<Exception> onEndExport, Action onCancelExport) {
        this.onStartExport = onStartExport;
        this.onEndExport = onEndExport;
        this.onCancelExport = onCancelExport;
    }

    public void Export(DataGridView grid, string path, ExportFormat format, PaperSize paperSize, bool isLandscape) {
        Task.Factory.StartNew(() => {
            try {
                lock (this.lockObject) {
                    if (IsInExport) {
                        return;
                    }

                    this.cancellationTokenSource = new CancellationTokenSource();
                }

                this.onStartExport?.Invoke();

                CancellationToken token = this.cancellationTokenSource.Token;
                token.Register(this.onCancelExport);

                DataGridExportLink exportLink = grid.GetExportLink();
                exportLink.PaperKind = paperSize switch {
                    PaperSize.A3 => DXPaperKind.A3,
                    PaperSize.A4 => DXPaperKind.A4,
                    PaperSize.A5 => DXPaperKind.A5,
                    _ => DXPaperKind.A4
                };
                exportLink.Landscape = isLandscape;

                token.ThrowIfCancellationRequested();

                exportLink.CreateDocument();

                token.ThrowIfCancellationRequested();

                switch (format) {
                    case ExportFormat.Pdf:
                        exportLink.ExportToPdf(path);
                        break;
                    case ExportFormat.Xlsx:
                        exportLink.ExportToXlsx(path);
                        break;
                    case ExportFormat.Docx:
                        exportLink.ExportToDocx(path);
                        break;
                }

                token.ThrowIfCancellationRequested();

                lock (this.lockObject) {
                    this.cancellationTokenSource = null;
                }

                this.onEndExport?.Invoke(null);
            } catch (Exception ex) {
                lock (this.lockObject) {
                    this.cancellationTokenSource = null;
                }

                this.onEndExport?.Invoke(ex);
            }
        });
    }
    public void Cancel() {
        lock (this.lockObject) {
            if (IsInExport) {
                this.cancellationTokenSource.Cancel();
                this.cancellationTokenSource = null;
            }
        }
    }
}