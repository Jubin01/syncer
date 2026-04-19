

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Syncer;

class Program
{
    static void Main(string[] args)
    {
        //  List<string> prevDirs = new List<string>( new string[10] );
        string[] file = File.ReadAllLines("SavedList.txt");
        List<string> prevDirs = new List<string>(file);

        string driveLetter = "F:";
        Console.Write("Enter FTP server IP (e.g., 192.168.1.7): ");
        string ip = Console.ReadLine();

        // Mount the drive
        ProcessStartInfo mountInfo = new ProcessStartInfo("ftpuse", $"{driveLetter} {ip} ftp /USER:ftp /PORT:2121");
        Process.Start(mountInfo).WaitForExit();

        Console.WriteLine("SYNCER🔁⏲✨!");

        // This will open the file in the default text editor
        Process.Start(new ProcessStartInfo("SavedList.txt") { UseShellExecute = true });

        string strCmdText = "/C robocopy /E /MT:1";
        Console.WriteLine("Enter from Directory");
        string fromDir = Console.ReadLine();
        Console.WriteLine("Enter to Directory");
        string toDir = Console.ReadLine();

        prevDirs.Add(fromDir);
        prevDirs.Add(toDir);

        File.WriteAllLines("SavedList.txt", prevDirs);
        strCmdText = strCmdText + ' ' + fromDir + ' ' + toDir;
        System.Diagnostics.Process.Start("CMD.exe", strCmdText).WaitForExit();

        // Unmount the drive when done (even if sync fails)
        ProcessStartInfo unmountInfo = new ProcessStartInfo("ftpuse", $"{driveLetter} /delete");
        Process.Start(unmountInfo);

        Console.ReadLine();
    }
}
