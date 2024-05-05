namespace Shared.Contracts.Responses.News;

public record CategoryResponse(
    [Required] int ID,
    [Required] string Name,
    [Required] string Description);