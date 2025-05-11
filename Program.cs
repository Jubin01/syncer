namespace Syncer;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("SYNCER🔁⏲✨!");
        string strCmdText = "/C robocopy /S /E /MT:8";
        Console.WriteLine("Enter from Directory");
        string fromDir = Console.ReadLine();
        Console.WriteLine("Enter to Directory");
        string toDir = Console.ReadLine();
        strCmdText = strCmdText + ' ' + fromDir + ' ' + toDir;
        System.Diagnostics.Process.Start("CMD.exe", strCmdText);
    }
}
