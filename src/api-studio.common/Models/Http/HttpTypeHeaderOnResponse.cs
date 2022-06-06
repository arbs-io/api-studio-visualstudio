namespace ApiStudioIO.Common.Models.Http
{
    public enum HttpTypeHeaderOnResponse
    {
		OnAlways = 0,
		OnInformation = 1,
        OnSuccess = 2,
		OnRedirection = 3,
		OnClientError = 4,
        OnServerError = 5		
    };
}