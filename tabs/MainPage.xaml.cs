namespace tabs;

public partial class MainPage : ContentPage
{
	private bool _loaded = false;

	public MainPage()
	{
		InitializeComponent();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

		if(!_loaded)
		{
			_loaded = true;

			// !!! Currently selecting and showing content but not updating tab visual state.
            Tabs.SelectPage(Tabs.TabPages[0]);
        }
    }
}

