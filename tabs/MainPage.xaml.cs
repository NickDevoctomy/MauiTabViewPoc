using System.Diagnostics;

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

    private void Tabs_SelectedTabViewPageChanged(object sender, Controls.SelectedTabViewPageChangedEventArgs e)
    {
        Debug.WriteLine($"Page changed to {e.SelectedTabViewPage.Title}");
    }
}

