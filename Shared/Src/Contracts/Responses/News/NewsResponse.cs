namespace Shared.Contracts.Responses.News;

public record NewsResponse(
    [Required] string ID,
    [Required] string Category,
    [Required] string AuthorProfilePictureUrl,
    [Required] string AuthorLastName,
    [Required] string AuthorFirstName,
    [Required] string AuthorMiddleName,
    [Required] string ImageTitleUrl,
    [Required] string Title,
    [Required] string Content,
    int ViewsCount,
    int LikesCount,
    int CommentsCount,
    bool IsViewed,
    bool IsLiked,
    bool IsBookMarked,
    [Required] DateTime Created);