namespace start_maui.pagea;

public partial class Form_base : ContentPage
{
	public event Action<string, DateTime>? OnFormSubmitted;
	public Form_base()
	{
		InitializeComponent();
	}

	private void Return_button_Clicked(object sender, EventArgs e)
	{
		string text_box = NameOfTag.Text;
		DateTime date_picked = datepicker.Date;

		date_picked = date_picked.AddHours(timepicker.Time.Hours);
		date_picked = date_picked.AddMinutes(timepicker.Time.Minutes);

		OnFormSubmitted?.Invoke(text_box, date_picked);

		Navigation.PopAsync();

	}
}