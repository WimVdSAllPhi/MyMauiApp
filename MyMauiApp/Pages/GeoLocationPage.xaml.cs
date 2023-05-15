namespace MyMauiApp.Pages;

public partial class GeoLocationPage : ContentPage
{
    #region Public Constructors

    public GeoLocationPage()
    {
        InitializeComponent();
        GPSTimer = new Timer(GetCurrentLocation, null, 100, 500);
    }

    #endregion Public Constructors

    #region Private Fields

    private CancellationTokenSource _cancelTokenSource;
    private bool _isCheckingLocation;
    private Timer GPSTimer;

    #endregion Private Fields

    #region Public Methods

    public void GetCurrentLocation(Object stateInfo)
    {
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            try
            {
                _isCheckingLocation = true;

                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

                _cancelTokenSource = new CancellationTokenSource();

                Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

                if (location != null)
                {
                    GeoLocationLabel.Text = ($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
            }
            // Catch one of the following exceptions: FeatureNotSupportedException
            // FeatureNotEnabledException PermissionException
            catch (Exception ex)
            {
                // Unable to get location
            }
            finally
            {
                _isCheckingLocation = false;
            }
        });
    }

    public void CancelRequest()
    {
        if (_isCheckingLocation && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
            _cancelTokenSource.Cancel();
    }

    #endregion Public Methods
}
