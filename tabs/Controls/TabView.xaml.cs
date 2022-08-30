using System.Windows.Input;

namespace tabs.Controls;

public partial class TabView : ContentView
{
    public event EventHandler<SelectedTabViewPageChangedEventArgs> SelectedTabViewPageChanged;

    public static BindableProperty TabHeightProperty = BindableProperty.Create(
        nameof(TabHeight),
        typeof(double),
        typeof(TabView),
        64d);

    public static BindableProperty TabPagesProperty = BindableProperty.Create(
        nameof(TabPages),
        typeof(IList<TabViewPage>),
        typeof(TabView),
        new List<TabViewPage>());

    public static BindableProperty TabAccentColourProperty = BindableProperty.Create(
        nameof(TabPages),
        typeof(Color),
        typeof(TabView),
        Colors.Red);

    public static BindableProperty SelectedTabAccentColourProperty = BindableProperty.Create(
        nameof(TabPages),
        typeof(Color),
        typeof(TabView),
        Colors.Blue);

    public double TabHeight
    {
        get
        {
            return (double)GetValue(TabHeightProperty);
        }
        set
        {
            SetValue(TabHeightProperty, value);
        }
    }

    public IList<TabViewPage> TabPages
    {
        get
        {
            return (IList<TabViewPage>)GetValue(TabPagesProperty);
        }
        set
        {
            SetValue(TabPagesProperty, value);
        }
    }

    public Color TabAccentColour
    {
        get
        {
            return (Color)GetValue(TabAccentColourProperty);
        }
        set
        {
            SetValue(TabAccentColourProperty, value);
        }
    }

    public Color SelectedTabAccentColour
    {
        get
        {
            return (Color)GetValue(SelectedTabAccentColourProperty);
        }
        set
        {
            SetValue(SelectedTabAccentColourProperty, value);
        }
    }

    public TabViewPage SelectedTabViewPage
    {
        get
        {
            return _selectedTabViewPage;
        }
        set
        {
            if(_selectedTabViewPage != value)
            {
                OnPropertyChanging(nameof(SelectedTabViewPage));
                _selectedTabViewPage = value;
                UpdateContentView();
                SelectedTabViewPageChanged?.Invoke(
                    this,
                    new SelectedTabViewPageChangedEventArgs
                    {
                        SelectedTabViewPage = value
                    });
                OnPropertyChanged(nameof(SelectedTabViewPage));
            }
        }
    }

    public ICommand SelectionChangedCommand { get; }

    private TabViewPage _selectedTabViewPage;
    private object _selectedItem;

    public TabView()
	{
        InitializeComponent();
	}

    public void SelectPage(TabViewPage tabViewPage)
    {
        SelectedTabViewPage = tabViewPage;
        TabPageCollection.SelectedItems.Clear();
        TabPageCollection.SelectedItems.Add(tabViewPage);
        TabPageCollection.UpdateSelectedItems(new List<object> { tabViewPage });
    }

    private void UpdateContentView()
    {
        if(SelectedTabViewPage != null && SelectedTabViewPage.ContentType != null)
        {
            // !!! Here we should use the container service provider to create instance of the view
            // but for the sake of this demo app, this works.
            var content = (View)Activator.CreateInstance(SelectedTabViewPage.ContentType);
            TabContent.Content = content;
        }
        else
        {
            TabContent.Content = null;
        }
    }

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        SelectedTabViewPage = e.CurrentSelection.Count == 0 ? null : (TabViewPage)e.CurrentSelection[0];
    }
}