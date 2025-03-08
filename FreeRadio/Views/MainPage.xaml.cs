using FreeRadio.Logic;

namespace FreeRadio.Views;

public partial class MainPage : TabbedPage
{

    public MainPage()
    {
        InitializeComponent();

        SetupRadioPages();
    }
    private void SetupRadioPages()
    {
        Children.Add(new RadioPage(new RadioStation(" KAN 88 Radio", "http://kanliveicy.media.kan.org.il/icy/kan88_mp3", "kan_88.png")) { Title="KAN 88"});
    }
}
