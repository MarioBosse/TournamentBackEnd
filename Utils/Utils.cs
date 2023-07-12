namespace GiDlls
{
    public class Utils
    {
        public String GetFileContent(string filename)
        {
            String content = Convert.ToBase64String(File.ReadAllBytes(filename));
            return content;
        }

    }
}