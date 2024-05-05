namespace Shared.Contracts.Responses.News;

public record CreateLikeRequest(
    [Required] string UserId);