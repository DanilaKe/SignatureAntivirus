using System;
using Antivirus.GUI;
using Antivirus.Scanner.Service;
using Gtk;

namespace Anitvirus
{
    static class EntryPoint
    {
        static void Main(string[] args)
        {
            new MainWindow();
            Application.Run();
        }
    }
}