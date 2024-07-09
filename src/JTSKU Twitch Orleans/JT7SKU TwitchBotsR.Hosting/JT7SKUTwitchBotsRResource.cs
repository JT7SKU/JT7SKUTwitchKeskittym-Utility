// For ease of discovery, resource types should be placed in
// the Aspire.Hosting.ApplicationModel namespace. If there is
// likelihood of a conflict on the resource name consider using
// an alternative namespace.
namespace Aspire.Hosting.ApplicationModel;

public sealed class JT7SKUTwitchBotsRResource(string name) : ContainerResource(name), IResourceWithConnectionString
{
    // Constants used to refer to well known-endpoint names, this is specific
    // for each resource type. BottiR exposes an Wss endpoint and a HTTP
    // endpoint.
    internal const string WssEndpointName = "wss";
    internal const string HttpEndpointName = "http";

    // An EndpointReference is a core .NET Aspire type used for keeping
    // track of endpoint details in expressions. Simple literal values cannot
    // be used because endpoints are not known until containers are launched.
    private EndpointReference? _wssReference;

    public EndpointReference WssEndpoint =>
        _wssReference ??= new(this, WssEndpointName);

    // Required property on IResourceWithConnectionString. Represents a connection
    // string that applications can use to access the BottiR server. In this case
    // the connection string is composed of the WssEndpoint endpoint reference.
    public ReferenceExpression ConnectionStringExpression =>
        ReferenceExpression.Create(
            $"wss://{WssEndpoint.Property(EndpointProperty.Host)}:{WssEndpoint.Property(EndpointProperty.Port)}"
        );
}