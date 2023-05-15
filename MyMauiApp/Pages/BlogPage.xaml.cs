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

    #endregion Public Properties
}
