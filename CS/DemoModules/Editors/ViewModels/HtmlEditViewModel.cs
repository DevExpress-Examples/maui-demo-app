using System.IO;
using System.Threading.Tasks;
using DevExpress.Maui.Core;
using Microsoft.Maui.Storage;

namespace DemoCenter.Maui.DemoModules.Editors.ViewModels;

public class HtmlEditViewModel : BindableBase {

    public string Text { get => GetValue<string>(); set => SetValue(value); }
    public string FileName {
        get => GetValue<string>();
        set => SetValue(value, changedCallback: async () => {
            await LoadData(FileName);
        });
    }

    async Task LoadData(string fileName) {
        using Stream stream = await FileSystem.Current.OpenAppPackageFileAsync(fileName);
        using StreamReader reader = new StreamReader(stream);
        string html = await reader.ReadToEndAsync();
        Text = html;
    }
}