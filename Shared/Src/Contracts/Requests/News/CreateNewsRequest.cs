namespace Shared.Contracts.Requests.News;

public record CreateNewsRequest(
    [Required] int CategoryId,
    [Required] UploadRequest? ImageTitleUploadRequest,
    [Required] string Title,
    [Required] string Content);