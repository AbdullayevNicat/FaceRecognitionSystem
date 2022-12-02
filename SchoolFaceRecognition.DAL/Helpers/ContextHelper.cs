namespace SchoolFaceRecognition.DAL.Helpers
{
    internal static class ContextHelper
    {
        internal static void LogToFile(string log)
        {
            string path = Directory.GetCurrentDirectory();

            string fileName = "query.txt";

            File.AppendAllText(Path.Combine(path, fileName), log);
        }
    }
}
