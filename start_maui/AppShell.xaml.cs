namespace start_maui;



public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(pagea.Main_page), typeof(pagea.Main_page));
		Routing.RegisterRoute(nameof(Settings), typeof(Settings));
		Routing.RegisterRoute(nameof(Friends), typeof(Friends));

	}
}
