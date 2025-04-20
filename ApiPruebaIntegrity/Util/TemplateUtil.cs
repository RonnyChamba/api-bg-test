namespace ApiPruebaIntegrity.Util
{
    public class TemplateUtil
    {

        public static readonly string MnemonicTemplateHtmlReport = "TEMPLATE_FACTURA";
        public static string ReemplazarPlaceholders(string htmlTemplate, Dictionary<string, string> valores)
        {
            foreach (var kvp in valores)
            {
                htmlTemplate = htmlTemplate.Replace(kvp.Key, kvp.Value);
            }
            return htmlTemplate;
        }
    }
}
