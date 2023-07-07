namespace edc_popover_dotnet.src
{
    public interface IHttpRestRequest
    {
        void PostData(string url, string routePath, string data);
    }
}
