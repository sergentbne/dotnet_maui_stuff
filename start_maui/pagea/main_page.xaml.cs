using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Layouts;

namespace start_maui.pagea;

public partial class Main_page : ContentPage
{
	public Main_page()
	{
		InitializeComponent();
	}

	private void OnAddRectangleClicked(object sender, EventArgs e)
	{
		// Create a new rounded rectangle


		//try get resources

		var rectangle = new Border
		{
			Margin = new Thickness(1),
			HeightRequest = 120,
			StrokeShape = new RoundRectangle
			{
				CornerRadius = new CornerRadius(20),
				// HorizontalOptions = LayoutOptions.Fill,
			},
			Stroke = (Color)Application.Current.Resources["Primary"],
			StrokeThickness = 2,
			BackgroundColor = (Color)Application.Current.Resources["PrimaryDark"],
			HorizontalOptions = LayoutOptions.Fill,
			Content = new AbsoluteLayout
			{
				// Children =
				// {
				// 	new CheckBox
				// 	{
				// 		// HorizontalOptions = LayoutOptions.Start,
				// 		Margin = new Thickness(20),
				// 		HeightRequest = 10
				// 	},

				// 	new Label
				// 	{
				// 		Text = "test",
				// 		VerticalOptions= LayoutOptions.Center,
				// 		HorizontalOptions = LayoutOptions.Center
				// 	}


			}
			// Content = new CheckBox
			// {
			// 	HorizontalOptions = LayoutOptions.Start,
			// 	HeightRequest = 10

			// }

		};

		CheckBox checkbox = new CheckBox
		{
			// HorizontalOptions = LayoutOptions.Start,
			Margin = new Thickness(20),
			HeightRequest = 10
		};
		AbsoluteLayout.SetLayoutBounds(checkbox, new Rect(0.2, 0.5, 0.2, 0.2));
		AbsoluteLayout.SetLayoutFlags(checkbox, AbsoluteLayoutFlags.All);

		Label base_text = new()
		{
			Text = "test"
		};
		AbsoluteLayout.SetLayoutBounds(base_text, new Rect(0.5, 0.5, 0.4, 0.4));
		AbsoluteLayout.SetLayoutFlags(base_text, AbsoluteLayoutFlags.All);

		AbsoluteLayout abs_layout = new AbsoluteLayout
		{
			Margin = new Thickness(20),
			Children = { checkbox, base_text }
		};

		rectangle.Content = abs_layout;
		CubeContainer.Children.Add(rectangle);


	}

	protected override void OnSizeAllocated(double width, double height)
	{
		base.OnSizeAllocated(width, height);
		// This ensures proper layout when the screen size changes
	}
}