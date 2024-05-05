namespace Shared.Contracts.Responses.News;

public record CreateBookMarkRequest(
    [Required] string UserId);