namespace Shared.Contracts.Requests.News;

public record UpdateNewsRequest(
    [Required] int CategoryId,
    UploadRequest? ImageTitleUploadRequest,
    [Required] string Title,
    [Required] string Content);