namespace Shared.Contracts.Responses.News;

public record CommentResponse(
    [Required] int ID,
    [Required] string AuthorLastName,
    [Required] string AuthorFirstName,
    [Required] string AuthorMiddleName,
    [Required] string Content,
    DateTime Created,
    DateTime? Updated);