namespace MyMauiApp.Pages;

public partial class OrientationPage : ContentPage
{
    #region Public Constructors

    public OrientationPage()
    {
        InitializeComponent();
    }

    #endregion Public Constructors

    #region Private Methods

    private void ToggleOrientation(object sender, EventArgs e)
    {
        if (OrientationSensor.Default.IsSupported)
        {
            if (!OrientationSensor.Default.IsMonitoring)
            {
                // Turn on orientation
                OrientationSensor.Default.ReadingChanged += Orientation_ReadingChanged;
                OrientationSensor.Default.Start(SensorSpeed.UI);
            }
            else
            {
                // Turn off orientation
                OrientationSensor.Default.Stop();
                OrientationSensor.Default.ReadingChanged -= Orientation_ReadingChanged;
                OrientationLabel.TextColor = Colors.Black;
                OrientationLabel.Text = "Orientation";
            }
        }
    }

    private void Orientation_ReadingChanged(object sender, OrientationSensorChangedEventArgs e)
    {
        // Update UI Label with orientation state
        OrientationLabel.TextColor = Colors.Green;
        if (!IsPortrait(e.Reading))
            OrientationLabel.Text = "Landscape";
        else
            OrientationLabel.Text = "Portrait";
    }

    private bool IsPortrait(OrientationSensorData orientationSensorData)
    {
        var q = orientationSensorData.Orientation;

        // Convert quaternion to Euler angles
        var sinr_cosp = +2.0 * (q.W * q.X + q.Y * q.Z);
        var cosr_cosp = +1.0 - 2.0 * (q.X * q.X + q.Y * q.Y);
        var roll = Math.Atan2(sinr_cosp, cosr_cosp);

        var sinp = +2.0 * (q.W * q.Y - q.Z * q.X);
        var pitch = 0.0;
        if (Math.Abs(sinp) >= 1)
            pitch = Math.CopySign(Math.PI / 2, sinp); // use 90 degrees if out of range
        else
            pitch = Math.Asin(sinp);

        var siny_cosp = +2.0 * (q.W * q.Z + q.X * q.Y);
        var cosy_cosp = +1.0 - 2.0 * (q.Y * q.Y + q.Z * q.Z);
        var yaw = Math.Atan2(siny_cosp, cosy_cosp);

        // Convert pitch to degrees for easier understanding
        pitch = pitch * 180.0 / Math.PI;

        // The device is considered in landscape mode if it's tilted horizontally, meaning the pitch
        // is closer to 0 or 180.
        if ((pitch <= 45 && pitch >= -45) || pitch >= 135 || pitch <= -135)
            return true;  // Landscape
        else
            return false; // Portrait
    }

    #endregion Private Methods
}
