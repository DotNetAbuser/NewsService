namespace Client.Handlers;

public class AuthorizationHeaderHandler(
    ITokenManager _tokenManager)
    : DelegatingHandler
{
    private bool isRefreshing;
    
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, 
        CancellationToken cancellationToken)
    {
        var token = await _tokenManager.GetJwtAsync();

        if (!string.IsNullOrWhiteSpace(token))
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await base.SendAsync(request, cancellationToken);
        if (isRefreshing || string.IsNullOrWhiteSpace(token) ||
            response.StatusCode != HttpStatusCode.Unauthorized)
            return response;
        try
        {
            isRefreshing = true;
            var result = await _tokenManager.RefreshAsync();
            if (result.Succeeded)
            {
                token = await _tokenManager.GetJwtAsync();
                if (!string.IsNullOrWhiteSpace(token))
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                response = await base.SendAsync(request, cancellationToken);
            }
        }
        finally
        {
            isRefreshing = false;
        }
        return response;
    }
}