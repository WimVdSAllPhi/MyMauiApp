namespace MyMauiApp;

public class PinchToZoomContainer : ContentView
{
    #region Private Fields

    private double _currentScale = 1;
    private double _startScale = 1;
    private double _xOffset = 0;
    private double _yOffset = 0;

    #endregion Private Fields

    #region Public Constructors

    public PinchToZoomContainer()
    {
        var pinchGesture = new PinchGestureRecognizer();
        pinchGesture.PinchUpdated += OnPinchUpdated;
        GestureRecognizers.Add(pinchGesture);
    }

    #endregion Public Constructors

    #region Private Methods

    private void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
    {
        if (e.Status == GestureStatus.Started)
        {
            // Store the current scale factor applied to the wrapped user interface element, and
            // zero the components for the center point of the translate transform.
            _startScale = Content.Scale;
            Content.AnchorX = 0;
            Content.AnchorY = 0;
        }
        if (e.Status == GestureStatus.Running)
        {
            // Calculate the scale factor to be applied.
            _currentScale += (e.Scale - 1) * _startScale;
            _currentScale = Math.Max(1, _currentScale);

            // The ScaleOrigin is in relative coordinates to the wrapped user interface element, so
            // get the X pixel coordinate.
            double renderedX = Content.X + _xOffset;
            double deltaX = renderedX / Width;
            double deltaWidth = Width / (Content.Width * _startScale);
            double originX = (e.ScaleOrigin.X - deltaX) * deltaWidth;

            // The ScaleOrigin is in relative coordinates to the wrapped user interface element, so
            // get the Y pixel coordinate.
            double renderedY = Content.Y + _yOffset;
            double deltaY = renderedY / Height;
            double deltaHeight = Height / (Content.Height * _startScale);
            double originY = (e.ScaleOrigin.Y - deltaY) * deltaHeight;

            // Calculate the transformed element pixel coordinates.
            double targetX = _xOffset - (originX * Content.Width) * (_currentScale - _startScale);
            double targetY = _yOffset - (originY * Content.Height) * (_currentScale - _startScale);

            // Apply translation based on the change in origin.
            Content.TranslationX = Math.Clamp(targetX, -Content.Width * (_currentScale - 1), 0);
            Content.TranslationY = Math.Clamp(targetY, -Content.Height * (_currentScale - 1), 0);

            // Apply scale factor
            Content.Scale = _currentScale;
        }
        if (e.Status == GestureStatus.Completed)
        {
            // Store the translation delta's of the wrapped user interface element.
            _xOffset = Content.TranslationX;
            _yOffset = Content.TranslationY;
        }
    }

    #endregion Private Methods
}
