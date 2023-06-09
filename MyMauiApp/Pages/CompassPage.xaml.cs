﻿namespace MyMauiApp.Pages;

public partial class CompassPage : ContentPage
{
    #region Public Constructors

    public CompassPage()
    {
        InitializeComponent();
    }

    #endregion Public Constructors

    #region Private Methods

    private void ToggleCompass(object sender, EventArgs e)
    {
        if (Compass.Default.IsSupported)
        {
            if (!Compass.Default.IsMonitoring)
            {
                // Turn on compass
                Compass.Default.ReadingChanged += Compass_ReadingChanged;
                Compass.Default.Start(SensorSpeed.UI);
            }
            else
            {
                // Turn off compass
                Compass.Default.Stop();
                Compass.Default.ReadingChanged -= Compass_ReadingChanged;
            }
        }
    }

    private void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
    {
        // Update UI Label with compass state
        CompassLabel.TextColor = Colors.Green;
        CompassLabel.Text = $"Compass: {e.Reading}";
    }

    #endregion Private Methods
}
