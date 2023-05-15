using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MyMauiApp.ViewModels;

public class BlogPostOldViewModel : INotifyPropertyChanged
{
    #region Private Fields

    private BlogPost _blogPost;

    private DateTime _publishDate;

    private string _author;

    private string _title;

    private string _description;

    private string _content;

    private string _message;

    private ICommand _saveCommand;

    #endregion Private Fields

    #region Public Events

    public event PropertyChangedEventHandler PropertyChanged;

    #endregion Public Events

    #region Public Properties

    public DateTime PublishDate
    {
        get => _publishDate;
        set => Set(ref _publishDate, value);
    }

    public string Author
    {
        get => _author;
        set => Set(ref _author, value);
    }

    public string Title
    {
        get => _title;
        set => Set(ref _title, value);
    }

    public string Description
    {
        get => _description;
        set => Set(ref _description, value);
    }

    public string Content
    {
        get => _content;
        set => Set(ref _content, value);
    }

    public string Message
    {
        get => _message;
        set => Set(ref _message, value);
    }

    public ICommand SaveCommand => _saveCommand ??= new Command(() =>
    {
        _blogPost.PublishDate = PublishDate;
        _blogPost.Author = Author;
        _blogPost.Title = Title;
        _blogPost.Description = Description;
        _blogPost.Content = Content;

        // Save stuff here

        Message = $"Saved at {DateTime.Now.ToLongTimeString()}";
    });

    #endregion Public Properties

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

    private bool Set<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
    {
        if (!EqualityComparer<T>.Default.Equals(field, newValue))
        {
            field = newValue;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }

        return false;
    }

    #endregion Private Methods
}
