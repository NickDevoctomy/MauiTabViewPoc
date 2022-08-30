using CommunityToolkit.Mvvm.ComponentModel;

namespace tabs.Controls
{
    public partial class TabViewPage : ObservableObject
    {
        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private double width = 60d;

        [ObservableProperty]
        private Type contentType;
    }
}
