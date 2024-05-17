namespace Shared.Contracts.Requests.News;

public record AcceptOrDeclineNewsRequest(
    bool IsAccept);