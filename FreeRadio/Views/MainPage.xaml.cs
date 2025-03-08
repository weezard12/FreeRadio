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
        Children.Add(new AboutMePage());
        Children.Add(new RadioPage(new RadioStation("KAN 88 Radio", "http://kanliveicy.media.kan.org.il/icy/kan88_mp3", "kan_88.png","#552586","#B589D6")) { Title = "KAN 88"});
        Children.Add(new RadioPage(new RadioStation("GALGALATZ Radio", "http://glzwizzlv.bynetcdn.com/glglz_mp3", "galgalatz.png", "#60339B", "#DFB12F")) { Title = "GALGALATZ" });
        Children.Add(new RadioPage(new RadioStation("GALEY ISREAL Radio", "https://cdn.cybercdn.live/Galei_Israel/Live/icecast.audio", "galgalatz.png", "#30c4ff", "#fddb98")) { Title = "GALEY ISREAL" });

        
    }
}
