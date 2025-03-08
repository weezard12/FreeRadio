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
        Children.Add(new AboutMePage() { Title = "About" });
        Children.Add(new RadioPage(new RadioStation("KAN 88", "http://kanliveicy.media.kan.org.il/icy/kan88_mp3", "kan_88.png","#552586","#B589D6")) { Title = "KAN 88"});
        Children.Add(new RadioPage(new RadioStation("GALGALATZ", "http://glzwizzlv.bynetcdn.com/glglz_mp3", "galgalatz.png", "#60339B", "#DFB12F")) { Title = "GALGALATZ" });
        Children.Add(new RadioPage(new RadioStation("GALEY ISREAL", "https://cdn.cybercdn.live/Galei_Israel/Live/icecast.audio", "galey_israel.png", "#30c4ff", "#fddb98")) { Title = "GALEY ISREAL" });
        Children.Add(new RadioPage(new RadioStation("KAN RESHET BET", "http://kanliveicy.media.kan.org.il/icy/kanbet_mp3", "kan_bet.png", "#000000", "#00f7ff")) { Title = "KAN BET" });
        Children.Add(new RadioPage(new RadioStation("RADIO DAROM", "https://cdn.cybercdn.live/Darom_97FM/Live/icecast.audio", "radio_darom.jpeg", "#2c67f2", "#62cff4")) { Title = "RADIO DAROM" });

        CurrentPage = Children[1];
    }
}
