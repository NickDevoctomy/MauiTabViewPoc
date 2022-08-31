namespace tabs;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
        Tabs.SelectPage(Tabs.TabPages[0]);
    }
}

