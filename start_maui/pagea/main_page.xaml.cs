using AuthenticationServices;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.HotReload;
using Microsoft.Maui.Layouts;
using Microsoft.VisualBasic;

namespace start_maui.pagea;

public partial class Main_page : ContentPage
{


	public Main_page()
	{
		InitializeComponent();
	}

	private void OnAddRectangleClicked(object sender, EventArgs e)
	{
		CubeContainer.Children.Add(new Rectangle_checkbox_combo("test").rect);

	}
	private class Rectangle_checkbox_combo
	{
		private readonly Border rectangle;
		public Rectangle_checkbox_combo(string name_of_tag)
		{
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
			};

			CheckBox checkbox = new()
			{
				// HorizontalOptions = LayoutOptions.Start,
				Margin = new Thickness(20),
				HeightRequest = 10,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Start,
			};


			Label base_text = new()
			{
				Text = name_of_tag,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				FontSize = 30
			};

			Grid.SetColumn(checkbox, 0);
			Grid.SetColumn(base_text, 1);



			Grid grid_layout = new()
			{
				ColumnDefinitions = {
			new ColumnDefinition { Width = new GridLength(20, GridUnitType.Absolute) }, // First column
			new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) }, // Second column
			new ColumnDefinition { Width = new GridLength(20, GridUnitType.Absolute) } // Filler column
			},

				Margin = new Thickness(20),
				Children = { checkbox, base_text }
			};
			TapGestureRecognizer rectangletapper = new();
			rectangletapper.Tapped += (s, e) =>
			{
				checkbox.IsChecked = !checkbox.IsChecked;
			};
			rectangle.Content = grid_layout;
			rectangle.GestureRecognizers.Add(rectangletapper);
			this.rectangle = rectangle;
		}
		public Border rect { get => rectangle; }
	}
	protected override void OnSizeAllocated(double width, double height)
	{
		base.OnSizeAllocated(width, height);
		// This ensures proper layout when the screen size changes
	}
}