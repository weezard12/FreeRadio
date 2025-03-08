using FreeRadio.Logic;
using Plugin.Maui.Audio;

namespace FreeRadio.Views;

public partial class RadioPage : ContentPage
{
    private RadioStation radioStation;
    public RadioPage(RadioStation radioStation)
	{
		InitializeComponent();

        this.radioStation = radioStation;

        MediaPlayer.Source = radioStation.URL;
        RadioName.Text = radioStation.Name;
        RadioImage.Source = radioStation.IconPath;
    }

}