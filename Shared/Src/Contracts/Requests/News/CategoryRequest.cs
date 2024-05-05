namespace Shared.Contracts.Requests.News;

public record CategoryRequest(
    [Required]string Name, 
    [Required]string Description);