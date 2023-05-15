namespace MyMauiApp.Models;

public class BlogPost
{
    #region Public Properties

    public DateTime PublishDate { get; set; }
    public string Author { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    #endregion Public Properties
}
