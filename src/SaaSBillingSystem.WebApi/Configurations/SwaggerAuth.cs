namespace SaaSBillingSystem.WebApi.Configurations
{
    public class SwaggerAuth
    {
        public const string SectionName = "SwaggerAuth";
        public string Username {get;set;} = string.Empty;
        public string Password {get;set;} = string.Empty;
    }
}