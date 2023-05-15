namespace MyMauiApp.Pages;

public partial class MVVMPage : ContentPage
{
    #region Public Constructors

    public MVVMPage()
    {
        InitializeComponent();

        // instantiate and initialize the ViewModel

        ViewModel = new BlogPostOldViewModel();

        var blogPost = new BlogPost()
        {
            PublishDate = DateTime.Now,
            Author = "Carl Franklin",
            Title = "The MVVM Community Toolkit Rocks!",
            Description = "Less code is better",
            Content = "The MVVM Community Toolkit lets " +
                "you easily create ViewModels that" +
                "with code generation and no " +
                "INotifyPropertyChanged goo!"
        };
        ViewModel.Initialize(blogPost);

        // Set the page's Binding Context
        BindingContext = ViewModel;
    }

    #endregion Public Constructors

    #region Public Properties

    public BlogPostOldViewModel ViewModel { get; private set; }

    #endregion Public Properties
}
