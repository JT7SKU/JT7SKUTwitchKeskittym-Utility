using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aspire.Hosting.ApplicationModel;

// Put extensions in the Aspire.Hosting namespace to ease discovery as referencing
// the .NET Aspire hosting package automatically adds this namespace.
namespace Aspire.Hosting;

public static class JT7SKUTwitchBotsRResourceBuilderExtensions
{
    /// <summary>
    /// Adds the <see cref="JT7SKUTwitchBotsRResource"/> to the given
    /// <paramref name="builder"/> instance. Uses the "2.0.2" tag.
    /// </summary>
    /// <param name="builder">The <see cref="IDistributedApplicationBuilder"/>.</param>
    /// <param name="name">The name of the resource.</param>
    /// <param name="httpPort">The HTTP port.</param>
    /// <param name="smtpPort">The SMTP port.</param>
    /// <returns>
    /// An <see cref="IResourceBuilder{JT7SKUTwitchBotsRResource}"/> instance that
    /// represents the added JT7SKUTwitchBotsR resource.
    /// </returns>
    public static IResourceBuilder<JT7SKUTwitchBotsRResource> AddMailDev(
        this IDistributedApplicationBuilder builder,
        string name,
        int? httpPort = null,
        int? smtpPort = null)
    {
        // The AddResource method is a core API within .NET Aspire and is
        // used by resource developers to wrap a custom resource in an
        // IResourceBuilder<T> instance. Extension methods to customize
        // the resource (if any exist) target the builder interface.
        var resource = new JT7SKUTwitchBotsRResource(name);

        return builder.AddResource(resource)
                      .WithImage(JT7SKUTwitchBotsRContainerImageTags.Image)
                      .WithImageRegistry(JT7SKUTwitchBotsRContainerImageTags.Registry)
                      .WithImageTag(JT7SKUTwitchBotsRContainerImageTags.Tag)
                      .WithHttpEndpoint(
                          targetPort: 1080,
                          port: httpPort,
                          name: JT7SKUTwitchBotsRResource.HttpEndpointName)
                      .WithEndpoint(
                          targetPort: 1025,
                          port: smtpPort,
                          name: JT7SKUTwitchBotsRResource.SmtpEndpointName);
    }
}

// This class just contains constant strings that can be updated periodically
// when new versions of the underlying container are released.
internal static class JT7SKUTwitchBotsRContainerImageTags
{
    internal const string Registry = "docker.io";

    internal const string Image = "JT7SKUTwitchBotsR/JT7SKUTwitchBotsR";

    internal const string Tag = "2.0.2";
}