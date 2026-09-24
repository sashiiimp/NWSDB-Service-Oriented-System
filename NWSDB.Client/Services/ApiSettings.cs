namespace NWSDB.Client.Services;

// Single place to change where the client finds NWSDB.Server.
// http://localhost:5074 is the "http" profile in NWSDB.Server/Properties/launchSettings.json
// (the "https" profile also listens on https://localhost:7058).
public static class ApiSettings
{
    public const string BaseUrl = "http://localhost:5074/";

    public static readonly TimeSpan RequestTimeout = TimeSpan.FromSeconds(15);
}
