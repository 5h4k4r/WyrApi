using WyrApi.Services;

namespace WyrApi.Extensions;

public static partial class StartupConfigurations
{
  public static IServiceCollection ConfigureDependencies(this IServiceCollection services)
  {
    return services.AddScoped<PostService>();
  }
}