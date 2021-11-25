namespace MVC_Project.Logic.Settings
{
    public class AzureBlobSettings
    {
        public string ConnectionString { get; set; }

        public string ImagesContainerName { get; set; }

        public string PdfContainerName { get; set; }

        public string ApplicationResourcesContainerName { get; set; }
    }
}
