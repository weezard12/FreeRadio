using FreeRadio.Logic;
using Plugin.Maui.Audio;
using System.Timers;
using System;
using Microsoft.Maui.Dispatching; // For MainThread

namespace FreeRadio.Views;

public partial class RadioPage : ContentPage
{
    private RadioStation radioStation;

    private System.Timers.Timer timer;
    private Random random = new Random();
    private int barCount = 64;

    // Field to hold the current audio levels for sliding animation
    private float[] currentLevels;


    private bool isPlaying = true;

    public RadioPage(RadioStation radioStation)
    {
        InitializeComponent();

        this.radioStation = radioStation;

        MediaPlayer.Source = radioStation.URL;
        RadioName.Text = radioStation.Name;
        RadioImage.Source = radioStation.IconPath;

        // Initialize the currentLevels array (starting with zeros)
        currentLevels = new float[barCount];
        for (int i = 0; i < barCount; i++)
        {
            currentLevels[i] = 0f;
        }

        // Start a timer to update audio levels every 200ms
        timer = new System.Timers.Timer(80);
        timer.Elapsed += Timer_Elapsed;
        timer.Start();
    }

    private void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        // Slide the audio data: shift currentLevels left by one index
        Array.Copy(currentLevels, 1, currentLevels, 0, barCount - 1);
        // Generate a new random level for the rightmost bar
        currentLevels[barCount - 1] = (float)random.NextDouble();

        if (!isPlaying)
            return;

        // Update the visualizer on the main thread
        MainThread.BeginInvokeOnMainThread(() =>
        {
            AudioVisualizer.UpdateAudioLevels(currentLevels);
        });
    }

    private void MediaAction_Clicked(object sender, EventArgs e)
    {
        if (isPlaying)
        {
            MediaPlayer.Pause();
            MediaActionButton.Source = "play_icon.png";
        }
        else
        {
            MediaPlayer.Play();
            MediaActionButton.Source = "pause_icon.png";
            
        }

        isPlaying = !isPlaying;
    }

    private void SkipToEnd_Clicked(object sender, EventArgs e)
    {
        var currentSource = MediaPlayer.Source;
        MediaPlayer.Source = null;
        MediaPlayer.Source = currentSource;

        MediaPlayer.Play();
        MediaActionButton.Source = "pause_icon.png";
        isPlaying = true;
    }
}
