using System;
using System.Globalization;
using DevExpress.Maui.Controls;
using DevExpress.Maui.Editors;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace DemoCenter.Maui.DemoModules.Editors.Converters {
    class BoxModeToImageSourceConverterExtension : IMarkupExtension<BoxModeToImageSourceConverter> {
        public ImageSource Filled { get; set; }
        public ImageSource Outlined { get; set; }

        public BoxModeToImageSourceConverter ProvideValue(IServiceProvider serviceProvider) => new BoxModeToImageSourceConverter {
            Filled = Filled,
            Outlined = Outlined
        };
        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
    }

    public class BoxModeToImageSourceConverter : IValueConverter {
        public ImageSource Filled { get; set; }
        public ImageSource Outlined { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is BoxMode boxMode) || targetType != typeof(ImageSource)) return null;
            switch (boxMode) {
                case BoxMode.Filled:
                    return Filled;
                case BoxMode.Outlined:
                    return Outlined;
                default:
                    throw new NotSupportedException();
            }

        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotSupportedException();
        }
    }

    class CharacterCasingToImageSourceConverterExtension : IMarkupExtension<CharacterCasingToImageSourceConverter> {
        public ImageSource Normal { get; set; }
        public ImageSource Uppercase { get; set; }
        public ImageSource Lowercase { get; set; }

        public CharacterCasingToImageSourceConverter ProvideValue(IServiceProvider serviceProvider) => new CharacterCasingToImageSourceConverter {
            Normal = Normal,
            Uppercase = Uppercase,
            Lowercase = Lowercase
        };
        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
    }

    public class CharacterCasingToImageSourceConverter : IValueConverter {
        public ImageSource Normal { get; set; }
        public ImageSource Uppercase { get; set; }
        public ImageSource Lowercase { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is CharacterCasing casing) || targetType != typeof(ImageSource))
                return null;
            switch (casing) {
                case CharacterCasing.Normal:
                    return Normal;
                case CharacterCasing.Upper:
                    return Uppercase;
                case CharacterCasing.Lower:
                    return Lowercase;
                default:
                    throw new NotSupportedException();
            }

        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotSupportedException();
        }
    }

    class CornerModeToImageSourceConverterExtension : IMarkupExtension<CornerModeToImageSourceConverter> {
        public ImageSource Cut { get; set; }
        public ImageSource Round { get; set; }

        public CornerModeToImageSourceConverter ProvideValue(IServiceProvider serviceProvider) => new CornerModeToImageSourceConverter {
            Cut = Cut,
            Round = Round
        };
        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
    }

    public class CornerModeToImageSourceConverter : IValueConverter {
        public ImageSource Cut { get; set; }
        public ImageSource Round { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is CornerMode cornerMode) || targetType != typeof(ImageSource)) return null;
            switch (cornerMode) {
                case CornerMode.Cut:
                    return Cut;
                case CornerMode.Round:
                    return Round;
                default:
                    throw new NotSupportedException();
            }

        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotSupportedException();
        }
    }

    class BoxModeToImageNameConverterExtension : IMarkupExtension<BoxModeToImageNameConverter> {
        public string Filled { get; set; }
        public string Outlined { get; set; }

        public BoxModeToImageNameConverter ProvideValue(IServiceProvider serviceProvider) => new BoxModeToImageNameConverter {
            Filled = Filled,
            Outlined = Outlined
        };
        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
    }

    public class BoxModeToImageNameConverter : IValueConverter {
        public string Filled { get; set; }
        public string Outlined { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is BoxMode boxMode) || targetType != typeof(string)) return null;
            switch (boxMode) {
                case BoxMode.Filled:
                    return Filled;
                case BoxMode.Outlined:
                    return Outlined;
                default:
                    throw new NotSupportedException();
            }

        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotSupportedException();
        }
    }

    class CornerModeToImageNameConverterExtension : IMarkupExtension<CornerModeToImageNameConverter> {
        public string Cut { get; set; }
        public string Round { get; set; }

        public CornerModeToImageNameConverter ProvideValue(IServiceProvider serviceProvider) => new CornerModeToImageNameConverter {
            Cut = Cut,
            Round = Round
        };
        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
    }

    public class CornerModeToImageNameConverter : IValueConverter {
        public string Cut { get; set; }
        public string Round { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is CornerMode cornerMode) || targetType != typeof(string)) return null;
            switch (cornerMode) {
                case CornerMode.Cut:
                    return Cut;
                case CornerMode.Round:
                    return Round;
                default:
                    throw new NotSupportedException();
            }

        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotSupportedException();
        }
    }
}
