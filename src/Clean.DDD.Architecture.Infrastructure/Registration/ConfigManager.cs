using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;

namespace Clean.DDD.Architecture.Infrastructure.Registration
{
    [ExcludeFromCodeCoverage]
    public class ConfigManager
    {
        public static IConfiguration? Config { get; set; }

        #region ConnectionStrings

        public static string CleanDDDDatabase
        {
            get
            {
                return Config != null ? Config["ConnectionStrings:CleanDDD"]! : string.Empty;
            }
        }

        public static string LocalDatabase
        {
            get
            {
                return Config != null ? Config["ConnectionStrings:Local"]! : string.Empty;
            }
        }

        #endregion

        #region WebAPI

        public static string WebAPIName
        {
            get
            {
                return Config != null ? Config["WebAPI:Name"]! : string.Empty;
            }
        }

        public static string CurrentDatabase
        {
            get
            {
                var current = Config != null ? Config["WebAPI:CurrentDB"]! : string.Empty;
                return Config != null && !string.IsNullOrEmpty(current) ? Config.GetConnectionString(current)! : string.Empty;
            }
        }

        public static string SchemaDatabase
        {
            get
            {
                return Config != null ? Config["WebAPI:SchemaDB"]! : string.Empty;
            }
        }

        #endregion

        #region Swagger

        public static string SwaggerEnabled
        {
            get
            {
                return Config != null ? Config["Swagger:Enabled"]! : string.Empty;
            }
        }

        #endregion
    }
}
