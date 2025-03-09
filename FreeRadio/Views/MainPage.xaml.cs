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
        Children.Add(new RadioPage(new RadioStation("GALGALATZ", "http://glzwizzlv.bynetcdn.com/glglz_mp3", "galgalatz.png", "#60339B", "#DFB12F")) { Title = "GALGALATZ" });
        Children.Add(new RadioPage(new RadioStation("KAN RESHET BET", "https://23543.live.streamtheworld.com/KAN_BET.mp3", "kan_bet.png", "#000000", "#00f7ff")) { Title = "KAN BET" });
        Children.Add(new RadioPage(new RadioStation("KAN 88", "https://25543.live.streamtheworld.com/KAN_88.mp3", "kan_88.png","#552586","#B589D6")) { Title = "KAN 88"});
        Children.Add(new RadioPage(new RadioStation("GALEY ISREAL", "https://cdn.cybercdn.live/Galei_Israel/Live/icecast.audio", "galey_israel.png", "#30c4ff", "#fddb98")) { Title = "GALEY ISREAL" });
        Children.Add(new RadioPage(new RadioStation("RADIO DAROM", "https://cdn.cybercdn.live/Darom_97FM/Live/icecast.audio", "radio_darom.jpeg", "#2c67f2", "#62cff4")) { Title = "RADIO DAROM" });
        Children.Add(new RadioPage(new RadioStation("KAN GIMEL", "https://25453.live.streamtheworld.com/KAN_GIMMEL.mp3", "kan_gimel.jpeg", "#fca311", "#ffffff")) { Title = "KAN GIMEL" });
        Children.Add(new RadioPage(new RadioStation("ECHO 99FM", "http://eco01.livecdn.biz/ecolive/99fm/icecast.audio", "echo99.png", "#0b91a6", "#ffffff")) { Title = "ECHO 99" });
        Children.Add(new RadioPage(new RadioStation("RADIUS 100FM", "https://cdn.cybercdn.live/Radios_100FM/Audio/icecast.audio", "radius100.png", "#ffe659", "#62cdff")) { Title = "RADIUS 100FM" });
        Children.Add(new RadioPage(new RadioStation("RADIO TEL AVIV", "https://cdn88.mediacast.co.il/102fm-tlv/102fm_aac/icecast.audio", "tel_aviv.jpg", "#b50110", "#ffffff")) { Title = "RADIO TEL AVIV" });

        CurrentPage = Children[1];
    }
}
