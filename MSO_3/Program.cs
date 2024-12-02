using GridRunner.Program;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("MSO_3Tests")]
namespace MSO_3
{
    

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            GridRunner.Program.GridRunnerProgram gr = new GridRunner.Program.GridRunnerProgram();
            

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Form f = new FormsApp(new UIMediator(gr));


            gr.Changed += (object? o, EventArgs ea) => f.Invalidate();
            Application.Run(f);
        }
    }
}