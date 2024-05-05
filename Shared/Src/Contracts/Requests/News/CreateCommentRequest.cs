namespace Shared.Contracts.Responses.News;

public record CreateCommentRequest(
    [Required] string UserId,
    [Required] string Content);