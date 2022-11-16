using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Hosting;
using DevExpress.Maui;
using DevExpress.Maui.Core;
using Microsoft.Maui.Controls.Compatibility.Hosting;

namespace DemoCenter.Maui {
	public static class MauiProgram {
		public static MauiApp CreateMauiApp() {
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.UseDevExpress()
				.ConfigureFonts(fonts => {
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("roboto-bold.ttf", "Roboto-Bold");
					fonts.AddFont("roboto-medium.ttf", "Roboto-Medium");
					fonts.AddFont("roboto-regular.ttf", "Roboto");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
			return builder.Build();
		}
	}
}
