using System.Diagnostics;
using System.Threading.Tasks;
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

	private async void OnAddRectangleClicked(object sender, EventArgs e)
	{
		Form_base form_Base = new();
		form_Base.OnFormSubmitted += Handle_form;
		await Navigation.PushAsync(form_Base);
	}
	private class Rectangle_checkbox_combo
	{
		private readonly Border rectangle;
		public Rectangle_checkbox_combo(string name_of_tag, DateTime dateAndTime)
		{
			var hasValue = Application.Current.Resources.TryGetValue("Primary", out object primaryColor) && Application.Current.Resources.TryGetValue("PrimaryDark", out object Background);
			Debug.Assert(hasValue);
			var rectangle = new Border
			{
				Margin = new Thickness(1),
				HeightRequest = 120,
				StrokeShape = new RoundRectangle
				{
					CornerRadius = new CornerRadius(20),
				},
				Stroke = (Color)Application.Current.Resources["Primary"],
				StrokeThickness = 2,
				BackgroundColor = (Color)Application.Current.Resources["PrimaryDark"],
				HorizontalOptions = LayoutOptions.Fill,

			};

			CheckBox checkbox = new()
			{
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
			Label date_text = new()
			{
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				FontSize = 30,
				Text = dateAndTime.ToString("yyyy-MM-dd, HH:mm")

			};
			Grid.SetRow(base_text, 0);
			Grid.SetRow(date_text, 1);


			Grid center_grid = new()
			{
				RowDefinitions = {
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star)},
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star)}
				},
				Margin = new Thickness(0),
				Children = { base_text, date_text }

			};

			Grid.SetColumn(checkbox, 0);
			Grid.SetColumn(center_grid, 1);




			Grid grid_layout = new()
			{
				ColumnDefinitions = {
					new ColumnDefinition { Width = new GridLength(20, GridUnitType.Absolute) }, // First column
					new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) }, // Second column
					new ColumnDefinition { Width = new GridLength(20, GridUnitType.Absolute) } // Filler column
					},

				Margin = new Thickness(20),
				Children = { checkbox, center_grid }
			};
			TapGestureRecognizer rectangletapper = new();
			rectangletapper.Tapped += (s, e) =>
			{
				checkbox.IsChecked = !checkbox.IsChecked;
				HapticFeedback.Default.Perform(HapticFeedbackType.Click);
			};
			rectangle.Content = grid_layout;
			rectangle.GestureRecognizers.Add(rectangletapper);

			this.rectangle = rectangle;


		}

		public Border Rect { get => rectangle; }
	}

	private void Handle_form(string text_of_user, DateTime dateAndTime)
	{
		CubeContainer.Children.Add(new Rectangle_checkbox_combo(text_of_user, dateAndTime).Rect);
	}
	private string GetUserinputAsync()
	{
		return "test";
	}
	protected override void OnSizeAllocated(double width, double height)
	{
		base.OnSizeAllocated(width, height);
		// This ensures proper layout when the screen size changes
	}
}