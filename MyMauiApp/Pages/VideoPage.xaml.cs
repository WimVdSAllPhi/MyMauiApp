namespace MyMauiApp.Pages;

public partial class VideoPage : ContentPage
{
    #region Public Constructors

    public VideoPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    #endregion Public Constructors

    #region Public Properties

    public double VideoWidth => AppState.Width - 40;

    public double VideoHeight
    {
        get
        {
#if WINDOWS || MACCATALYST
            return AppState.Height - 100;
#else
            return 300;
#endif
        }
    }

    #endregion Public Properties
}
