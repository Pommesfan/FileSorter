namespace FileSorter
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            String pattern = "Hallo?1Hi?2";
            String txt = "HalloHiUpsJesses";
            String[]patternArray = pattern.Split("\\?[0-9]");
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainView());
        }
    }
}