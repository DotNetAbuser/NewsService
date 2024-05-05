namespace Shared.Contracts.Requests.News;

public record UpdateCategoryRequest(
    [Required] string Name,
    [Required] string Description);