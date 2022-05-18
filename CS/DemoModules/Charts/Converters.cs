using System;
using System.Globalization;
using DemoCenter.Maui.Charts.ViewModels;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui {
    class AreaTypeToImageSourceConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is AreaType type))
                return null;

            switch (type) {
                case AreaType.Range: return "demochartsrangearea";
                case AreaType.Simple: return "demochartsarea";
                case AreaType.Stacked: return "demochartsstackedarea";
                case AreaType.FullStacked: return "demochartsfullstackedarea";
                case AreaType.Step: return "demochartssteparea";
                default: throw new ArgumentException("The selector cannot handle the passed AreaType value.");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    class BarTypeToImageSourceConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is BarType type))
                return null;

            switch (type) {
                case BarType.SideBySideRange: return "demochartssidebysiderangebar";
                case BarType.Range: return "demochartsrangebar";
                case BarType.Simple: return "demochartsbar";
                case BarType.PopulationPyramid: return "demochartspopulationpyramid";
                case BarType.Stacked: return "demochartsstackedbar";
                case BarType.SideBySideStacked: return "demochartssidebysidestackedbar";
                case BarType.FullStacked: return "demochartsfullstackedbar";
                case BarType.SideBySideFullStacked: return "demochartssidebysidefullstackedbar";
                case BarType.RotatedStacked: return "demochartsrotatedstackedbar";
                case BarType.RotatedSideBySide: return "demochartsrotatedsidebysidestackedbar";
                default: throw new ArgumentException("The selector cannot handle the passed BarType value.");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    class LineTypeToImageSourceConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is LineType type))
                return null;

            switch (type) {
                case LineType.Simple: return "demochartsline";
                case LineType.Scatter: return "demochartsscatter";
                case LineType.Step: return "demochartsstepline";
                case LineType.Spline: return "demochartsspline";
                default: throw new ArgumentException("The selector cannot handle the passed LineType value.");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    class PieTypeToImageSourceConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is PieType type))
                return null;

            switch (type) {
                case PieType.Donut: return "demochartsdonut";
                case PieType.Pie: return "demochartspie";
                default: throw new ArgumentException("The selector cannot handle the passed PieType value.");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    class PointTypeToImageSourceConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is PointType type))
                return null;

            switch (type) {
                case PointType.Point: return "demochartspoint";
                case PointType.Bubble: return "demochartsbubble";
                default: throw new ArgumentException("The selector cannot handle the passed PointType value.");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    class ColorizerTypeToImageSourceConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is CustomAppearanceType type))
                return null;

            switch (type) {
                case CustomAppearanceType.Bubble: return "demochartscolorizerbubble";
                case CustomAppearanceType.Bar: return "demochartscolorizerbar";
                case CustomAppearanceType.GradientSegmentColorizer: return "demochartslightspector";
                case CustomAppearanceType.OperationSurfaceTemperature: return "demochartssurfacetemperature";
                case CustomAppearanceType.AreaGradientFillEffect: return "demochartsareagradientfill";
                default: throw new ArgumentException("The selector cannot handle the passed PointType value.");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    class LabelModeTypeToImageSourceConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is AxisLabelOptionsType type))
                return null;

            switch (type) {
                case AxisLabelOptionsType.RotatedAndStaggered: return "demochartsrotatedlabels";
                case AxisLabelOptionsType.CryptocurrencyPortfolio: return "demochartscryptocurrencyportfolio";
                default:
                    throw new ArgumentException("The selector cannot handle the passed PointType value.");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

}