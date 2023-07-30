namespace GiDlls
{
    public class Utils
    {
        public String BinaryFileToBase64(string filename)
        {
            return Convert.ToBase64String(File.ReadAllBytes(filename));
        }
    }


    public class Traitement
    {
    }
}