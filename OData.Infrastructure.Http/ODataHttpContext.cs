namespace OData.Infrastructure.Http;

public interface IODataHttpContext
{
    string CorrelationId { get; }

    string SessionId { get; }
}
public class ODataHttpContext : IODataHttpContext
{
    public string CorrelationId { get; }
    public string SessionId { get; }

    public ODataHttpContext()
    {
            
    }
}