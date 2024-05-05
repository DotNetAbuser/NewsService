namespace Shared.Contracts.Responses.News;

public record UpdateCommentRequest(
    [Required] string Content);