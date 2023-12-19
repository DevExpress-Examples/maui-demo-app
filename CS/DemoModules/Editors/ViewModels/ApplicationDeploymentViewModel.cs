using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DemoCenter.Maui.Demo;
using DemoCenter.Maui.ViewModels;
using DevExpress.Maui.DataForm;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.DemoModules.Editors.ViewModels {
    public class ApplicationDeploymentViewModel : NotificationObject {
        public ApplicationInfo Model { get; } = new ApplicationInfo();

        Dictionary<string, int> verticalFieldNamesToRowOrder = new Dictionary<string, int>() {
            { nameof(ApplicationInfo.Name), 1 },
            { nameof(ApplicationInfo.Version), 2 },
        };

        Dictionary<string, int> horizontalFieldNamesToRowOrder = new Dictionary<string, int>() {
            { nameof(ApplicationInfo.Name), 0 },
            { nameof(ApplicationInfo.Version), 1 },
        };

        bool isVertical = true;

        public void Rotate(DataFormView dataForm, PageOrientation orientation) {
            var newIsVertical = (orientation == PageOrientation.Portrait);
            if (newIsVertical == isVertical || dataForm.Items == null)
                return;

            isVertical = newIsVertical;
            var itemPositionPair = isVertical ? verticalFieldNamesToRowOrder : horizontalFieldNamesToRowOrder;
            var dataFormItemsToReorder = dataForm.Items.Where(item => itemPositionPair.ContainsKey(item.FieldName) || item.FieldName == nameof(ApplicationInfo.AppIcon));
            foreach (var item in dataFormItemsToReorder) {
                if (item.FieldName == nameof(ApplicationInfo.AppIcon))
                    SetPhotoItemProperties(item);
                else
                    item.RowOrder = itemPositionPair[item.FieldName];
            }
        }

        void SetPhotoItemProperties(DataFormItem item) {
            item.RowSpan = isVertical ? 1 : horizontalFieldNamesToRowOrder.Count;
        }
    }

    public class ApplicationInfo : IDataErrorInfo {
        static string[] AllApplicationTags = {
            "Business", "Hobby", "Travel", "Study", "Development", "Humor", "Game", "Offline", "Puzzle", "Multiplayer", "Singleplayer"
        };
        public List<Language> Languages => new List<Language>(Language.GetLanguages());
        public List<string> Tags => ApplicationInfo.AllApplicationTags.Order().ToList();

        public ImageSource AppIcon { get; set; }

        [Required(ErrorMessage = "Enter the application name.")]
        [StringLength(64, MinimumLength = 2, ErrorMessage = "The name should contain at least two characters.")]
        public string Name { get; set; } = ".NET MAUI Gallery";

        [Required(ErrorMessage = "Specify the application version.")]
        [RegularExpression(@"^(\d{1,}[.]{0,1}){1,4}$", ErrorMessage = "Invalid version format.")]
        public string Version { get; set; } = "1.0.0";

        [Required(ErrorMessage = "Enter the application identifier.")]
        [RegularExpression(@"^([a-zA-Z]{2,4}.([a-zA-Z.]){1,})$", ErrorMessage = "Invalid identifier format.")]
        public string Id { get; set; } = "com.devexpress.mauigallery";

        public ObservableCollection<Language> SupportedLanguages { get; set; } = new(Language.GetLanguages().Where(x => x.EnglishName == "English"));
        public ObservableCollection<string> SelectedApplicationTags { get; set; } = new(AllApplicationTags.Where(x => x is "Business" or "Study" or "Development" or "Offline"));

        public string this[string columnName] => String.Empty;
        public string Error => String.Empty;
    }

    public class Language {
        static List<Language> languages = new() {
            new Language { EnglishName = "Chinese",     NativeName = "简化字" },
            new Language { EnglishName = "Spanish",     NativeName = "Español" },
            new Language { EnglishName = "English",     NativeName = "English" },
            new Language { EnglishName = "Hindi",       NativeName = "हिंदी"},
            new Language { EnglishName = "Bengali",     NativeName = "বাংলা"},
            new Language { EnglishName = "Portuguese",  NativeName = "Português" },
            new Language { EnglishName = "Russian",     NativeName = "Русский" },
            new Language { EnglishName = "Japanese",    NativeName = "日本語" },
            new Language { EnglishName = "Vietnamese",  NativeName = "Tiếng Việt" },
            new Language { EnglishName = "Turkish",     NativeName = "Türkçe" },
            new Language { EnglishName = "Korean",      NativeName = "한국어" },
            new Language { EnglishName = "Ukranian",    NativeName = "Украї́нська" },
            new Language { EnglishName = "French",      NativeName = "Français" },
            new Language { EnglishName = "German",      NativeName = "Deutsch" },
            new Language { EnglishName = "Italian",     NativeName = "Italiano" },
            new Language { EnglishName = "Armenian",    NativeName = "հայերէն" },
            new Language { EnglishName = "Arabic",      NativeName = "اَلْعَرَبِيَّةُ‎" },
            new Language { EnglishName = "Greek",       NativeName = "Ελληνικά" }
        };
        public static IEnumerable<Language> GetLanguages() {
            return languages.OrderBy(x => x.EnglishName);
        }

        public string EnglishName { get; init; }
        public string NativeName { get; init; }
    }
}

