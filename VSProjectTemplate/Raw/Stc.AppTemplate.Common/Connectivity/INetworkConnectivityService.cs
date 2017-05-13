namespace $safeprojectname$.Connectivity
{
    public interface INetworkConnectivityService
    {
        bool IsInternetAvailable { get; }
    }
}