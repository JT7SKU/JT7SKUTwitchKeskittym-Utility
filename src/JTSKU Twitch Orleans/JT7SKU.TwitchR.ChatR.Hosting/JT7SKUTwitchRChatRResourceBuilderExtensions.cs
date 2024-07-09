using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspire.Hosting.ApplicationModel;
namespace Aspire.Hosting;

    public static class JT7SKUTwitchRChatRResourceBuilderExtensions
    {
    /// <summary>
    /// Adds the <see cref="JT7SKUTwitchRChatRResource"/> to the given
    /// <paramref name="builder"/> instance. Uses the "2.0.2" tag.
    /// </summary>
    /// <param name="builder">The <see cref="IDistributedApplicationBuilder"/>.</param>
    /// <param name="name">The name of the resource.</param>
    /// <param name="httpPort">The HTTP port.</param>
    /// <param name="wssPort">The SMTP port.</param>
    /// <returns>
    /// An <see cref="IResourceBuilder{JT7SKUTwitchRChatRResource}"/> instance that
    /// represents the added JT7SKUTwitchBotsR resource.
    /// </returns>
    public static IResourceBuilder<JT7SKUTwitchRChatRResource> AddKhattiR(
        this IDistributedApplicationBuilder builder,
        string name,
        int? httpPort = null,
        int? wssPort = null)
    {
        // The AddResource method is a core API within .NET Aspire and is
        // used by resource developers to wrap a custom resource in an
        // IResourceBuilder<T> instance. Extension methods to customize
        // the resource (if any exist) target the builder interface.
        var resource = new JT7SKUTwitchRChatRResource(name);

        return builder.AddResource(resource)
                      .WithImage(JT7SKUTwitchRChatRContainerImageTags.Image)
                      .WithImageRegistry(JT7SKUTwitchRChatRContainerImageTags.Registry)
                      .WithImageTag(JT7SKUTwitchRChatRContainerImageTags.Tag)
                      .WithHttpEndpoint(
                          targetPort: 1080,
                          port: httpPort,
                          name: JT7SKUTwitchRChatRResource.HttpEndpointName)
                      .WithEndpoint(
                          targetPort: 1025,
                          port: wssPort,
                          name: JT7SKUTwitchRChatRResource.WssEndpointName);
    }

}
internal static class JT7SKUTwitchRChatRContainerImageTags
{
    internal const string Registry = "docker.io";

    internal const string Image = "JT7SKUTwitchRChatR/JT7SKUTwitchRChatR";

    internal const string Tag = "2.0.2";
}
