﻿namespace MyMauiApp.Pages;

public partial class GyroPage : ContentPage
{
    #region Public Constructors

    public GyroPage()
    {
        InitializeComponent();
    }

    #endregion Public Constructors

    #region Private Methods

    private void ToggleGyroscope(object sender, EventArgs e)
    {
        if (Gyroscope.Default.IsSupported)
        {
            if (!Gyroscope.Default.IsMonitoring)
            {
                // Turn on gyroscope
                Gyroscope.Default.ReadingChanged += Gyroscope_ReadingChanged;
                Gyroscope.Default.Start(SensorSpeed.UI);
            }
            else
            {
                // Turn off gyroscope
                Gyroscope.Default.Stop();
                Gyroscope.Default.ReadingChanged -= Gyroscope_ReadingChanged;
                GyroscopeLabel.TextColor = Colors.Black;
                GyroscopeLabel.Text = "Gyroscope";
            }
        }
    }

    private void Gyroscope_ReadingChanged(object sender, GyroscopeChangedEventArgs e)
    {
        // Update UI Label with gyroscope state
        GyroscopeLabel.TextColor = Colors.Green;
        GyroscopeLabel.Text = $"Gyroscope: {e.Reading}";
    }

    #endregion Private Methods
}
