namespace Shared.Contracts.Requests.Identity;

public record ToggleUserStatusRequest(
    [Required] bool ActivateUser);