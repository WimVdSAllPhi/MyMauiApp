namespace MyMauiApp;

public partial class MainPage : ContentPage
{
    #region Private Fields

    private int _count = 0;

    #endregion Private Fields

    #region Public Constructors

    public MainPage()
    {
        InitializeComponent();
    }

    #endregion Public Constructors

    #region Private Methods

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        _count++;

        if (_count == 1)
            CounterBtn.Text = $"Clicked {_count} time";
        else
            CounterBtn.Text = $"Clicked {_count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);

        // Copy the button text to the clipboard
        await Clipboard.Default.SetTextAsync(CounterBtn.Text);

        // read and examine the text in the clipboard:
        var text = await Clipboard.Default.GetTextAsync();
        if (text == "Clicked 3 times")
        {
            CounterBtn.TextColor = Colors.Red;
        }
    }

    #endregion Private Methods
}
