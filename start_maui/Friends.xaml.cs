namespace start_maui;

public partial class Friends : ContentPage
{
	public Friends()
	{
		InitializeComponent();
		RefreshDataInFile();

	}
	public void TableDrop(object sender, EventArgs e)
	{
		FileHandler.TableDrop();
	}
	public void RefreshDataInFile()
	{
		NewContainers.Children.Clear();

		var Data = FileHandler.GetAllData();
		foreach (var data in Data)
		{
			NewContainers.Children.Add(new Label { Text = data.ToString() });
		}
	}
	public void RefreshDataInFile(object sender, EventArgs e)
	{
		RefreshDataInFile();
	}
}