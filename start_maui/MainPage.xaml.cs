namespace start_maui;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object? sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);

	}

	private void Checkboxes_Changed(object sender, CheckedChangedEventArgs e)
	{
		if (e.Value == true)
		{
			Color new_color = new Color(200, 200, 200);
			CounterBtn.TextColor = new_color;
			CounterBtn.IsEnabled = !(CounterBtn.IsEnabled & true);

		}
		else
		{
			Color new_color = new Color(200, 0, 200);

			CounterBtn.TextColor = new_color;
			CounterBtn.IsEnabled = !(CounterBtn.IsEnabled & true);


		}
	}
}
