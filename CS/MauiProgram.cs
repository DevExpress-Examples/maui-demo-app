using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Hosting;
using DevExpress.Maui;
using Microsoft.Maui.Controls;

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
                })
				.ConfigureMauiHandlers(handlers => {
					handlers.AddHandler<Shell, CustomShellRenderer>();
				} );
			DevExpress.Maui.Charts.Initializer.Init();
			DevExpress.Maui.CollectionView.Initializer.Init();
			DevExpress.Maui.Controls.Initializer.Init();
			DevExpress.Maui.Editors.Initializer.Init();
			DevExpress.Maui.DataGrid.Initializer.Init();
			DevExpress.Maui.Scheduler.Initializer.Init();
			return builder.Build();
		}
	}
}
