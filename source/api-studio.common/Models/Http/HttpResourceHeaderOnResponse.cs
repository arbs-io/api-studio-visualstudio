namespace ApiStudioIO
{
    public enum HttpResourceHeaderOnResponse
    {
		OnAlways = 0,
		OnInformation = 1,
        OnSuccess = 2,
		OnRedirection = 3,
		OnClientError = 4,
        OnServerError = 5		
    };
}