using System.Diagnostics.CodeAnalysis;
using Clean.DDD.Architecture.Infrastructure.Registration;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Clean.DDD.Architecture.WebAPI.Swagger
{
    [ExcludeFromCodeCoverage]
    public static class SwaggerBuilder
    {
        public static IApplicationBuilder AddSwaggerApp(this IApplicationBuilder app)
        {
            var enabled = Convert.ToBoolean(ConfigManager.SwaggerEnabled);
            if (enabled)
            {
                app.UseSwagger();
                app.UseSwaggerUI(x =>
                {
                    x.DocumentTitle = $"{ConfigManager.WebAPIName} Swagger";
                    x.HeadContent = @"
                    <script type='text/javascript'>
                        (function() {
                            var links = document.querySelectorAll(""link[rel~='icon']"");
                            for (var link of links) {
                                link.parentNode.removeChild(link);
                            }
                            var link = document.createElement('link');
                            link.rel = 'icon';
                            link.type = 'image/ico';
                            link.href = '/images/favicon.ico';
                            document.getElementsByTagName('head')[0].appendChild(link);
                        })();
                    </script>";

                    x.SwaggerEndpoint("/swagger/v1/swagger.json", $"{ConfigManager.WebAPIName} v1");
                    x.InjectStylesheet("/css/swagger-custom.css");
                    x.DefaultModelRendering(ModelRendering.Example);
                    x.DocExpansion(DocExpansion.None);
                    x.EnableFilter();
                    x.ShowExtensions();
                    x.ShowCommonExtensions();
                    x.EnablePersistAuthorization();
                    x.DisplayRequestDuration();
                });
            }

            return app;
        }
    }
}
