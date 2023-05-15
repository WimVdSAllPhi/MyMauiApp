namespace MyMauiApp.ViewModels;

public partial class BlogPostNewViewModel : ObservableObject
{
    #region Private Fields

    private BlogPost _blogPost;

    [ObservableProperty]
    private DateTime _publishDate;

    [ObservableProperty]
    private string _author;

    [ObservableProperty]
    private string _title;

    [ObservableProperty]
    private string _description;

    [ObservableProperty]
    private string _content;

    [ObservableProperty]
    private string _message;

    #endregion Private Fields

    #region Public Methods

    public void Initialize(BlogPost blogPost)
    {
        PublishDate = blogPost.PublishDate;
        Author = blogPost.Author;
        Title = blogPost.Title;
        Description = blogPost.Description;
        Content = blogPost.Content;
        _blogPost = blogPost;
    }

    #endregion Public Methods

    #region Private Methods

    [RelayCommand]
    private void Save()
    {
        _blogPost.PublishDate = PublishDate;
        _blogPost.Author = Author;
        _blogPost.Title = Title;
        _blogPost.Description = Description;
        _blogPost.Content = Content;

        // Save stuff here

        Message = $"Saved at {DateTime.Now.ToLongTimeString()}";
    }

    #endregion Private Methods
}
