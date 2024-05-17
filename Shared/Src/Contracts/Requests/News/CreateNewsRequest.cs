namespace Shared.Contracts.Requests.News;

public record CreateNewsRequest(
    [Required] int CategoryId,
    UploadRequest? ImageTitleUploadRequest,
    [Required] string Title,
    [Required] string Content);