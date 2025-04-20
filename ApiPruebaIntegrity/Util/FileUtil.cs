namespace ApiPruebaIntegrity.Util
{
    public class FileUtil
    {
        public static byte[] ReadAndDeletePdf(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("El archivo no existe.", filePath);
            }

            byte[] fileBytes = File.ReadAllBytes(filePath);
            File.Delete(filePath);

            return fileBytes;
        }
    }
}
