namespace Stc.AppTemplate.Common.Connectivity
{
    public interface INetworkConnectivityService
    {
        bool IsInternetAvailable { get; }
    }
}