namespace MyMauiApp.Pages;

public partial class SwipePage : ContentPage
{
    #region Public Constructors

    public SwipePage()
    {
        InitializeComponent();
    }

    #endregion Public Constructors

    #region Private Methods

    private void OnSwiped(object sender, SwipedEventArgs e)
    {
        switch (e.Direction)
        {
            case SwipeDirection.Left:
                SwipeLabel.Text = "Swipe Direction: Left";
                SwipeBoxView.Color = Colors.Red;
                break;

            case SwipeDirection.Right:
                SwipeLabel.Text = "Swipe Direction: Right";
                SwipeBoxView.Color = Colors.Green;
                break;

            case SwipeDirection.Up:
                SwipeLabel.Text = "Swipe Direction: Up";
                SwipeBoxView.Color = Colors.Blue;
                break;

            case SwipeDirection.Down:
                SwipeLabel.Text = "Swipe Direction: Down";
                SwipeBoxView.Color = Colors.Yellow;
                break;
        }
    }

    #endregion Private Methods
}
