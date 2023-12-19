using System;
using System.Collections.Generic;
using System.Linq;
using DemoCenter.Maui.Models;
using DemoCenter.Maui.Views;

namespace DemoCenter.Maui.Data {
    public class OfficeFileAPIData : IDemoData {
        public static DemoItem GetItem(Type module) {
            IEnumerable<DemoItem> items = demoItems.Where((d) => d.Module == module);
            return items.Any() ? items.Last() : null;
        }

        static readonly List<DemoItem> demoItems;

        static OfficeFileAPIData() {
            demoItems = new List<DemoItem>() {
                new DemoItem() {
                    Title = "Pdf Viewer",
                    Description="The DevExpress Pdf Viewer allow you to view and search through PDF Document",
                    Module = typeof(PdfViewerPage),
                    Icon = "pdfviewer",
                    DemoItemStatus = DemoItemStatus.New
                },
                new DemoItem() {
                    Title = "Sign PDF Files",
                    Description = "Sign a PDF File with a certificate and add a hand-drawn signature.",
                    Module = typeof(SignatureDemo),
                    Icon = "editing",
                },
                new DemoItem() {
                    Title = "Fill Out PDF Forms",
                    Description = "Use the DataForm Control to fill out form fields in a PDF document.",
                    Module = typeof(FillPDFMainPage),
                    Icon = "editors",
                },
                new DemoItem() {
                    Title = "Convert Files",
                    Description = "Convert DOC/DOCX, XLS/XLSX, and HTML documents to PDF, HTML, or DOCX.",
                    Module = typeof(ConverterDemo),
                    Icon = "pulltorefresh",
                }
            };
        }
        public List<DemoItem> DemoItems => demoItems;
        public string Title => TitleData.OfficeFileAPIDataTitle;
    }
}
