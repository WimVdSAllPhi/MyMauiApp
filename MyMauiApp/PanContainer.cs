namespace MyMauiApp;

public class PanContainer : ContentView
{
    #region Private Fields

    private double _x, _y;

    #endregion Private Fields

    #region Public Constructors

    public PanContainer()
    {
        // Set PanGestureRecognizer.TouchPoints to control the number of touch points needed to pan
        var panGesture = new PanGestureRecognizer();
        panGesture.PanUpdated += OnPanUpdated;
        GestureRecognizers.Add(panGesture);
    }

    #endregion Public Constructors

    #region Private Methods

    private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
    {
        switch (e.StatusType)
        {
            case GestureStatus.Running:
                // Translate and ensure we don't pan beyond the wrapped user interface element bounds.
                Content.TranslationX = Math.Max(Math.Min(0, _x + e.TotalX), -Math.Abs(Content.Width - DeviceDisplay.MainDisplayInfo.Width));
                Content.TranslationY = Math.Max(Math.Min(0, _y + e.TotalY), -Math.Abs(Content.Height - DeviceDisplay.MainDisplayInfo.Height));
                break;

            case GestureStatus.Completed:
                // Store the translation applied during the pan
                _x = Content.TranslationX;
                _y = Content.TranslationY;
                break;
        }
    }

    #endregion Private Methods
}
