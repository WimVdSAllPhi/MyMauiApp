namespace MyMauiApp.Pages;

public partial class BlogPage : ContentPage
{
    #region Public Constructors

    public BlogPage()
    {
        InitializeComponent();
        BindingContext = this;
        BlogDataManager.GetBlogPosts();
    }

    #endregion Public Constructors

    #region Public Properties

    public List<BlogPost> BlogPosts => BlogDataManager.BlogPosts;

    public int Column2Width => Convert.ToInt32(AppState.Width) - 180;
    public int ContentWidth => Convert.ToInt32(AppState.Width) - 100;

    #endregion Public Properties
}
