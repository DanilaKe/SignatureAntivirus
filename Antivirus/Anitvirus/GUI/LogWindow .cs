using Gtk;
using System;
using System.Collections.Generic;

namespace Antivirus.GUI
{
    public class LogWindow : IDisposable
    {
        [Builder.Object] private Window Window;
        [Builder.Object] private TextView LogTextView;
        private bool disposed = false;
        
        private Builder GuiBuilder;
        
        public LogWindow(IDictionary<string, bool> logs)
        {
            Application.Init();
            using (GuiBuilder = new Builder())
            {
                GuiBuilder.AddFromFile("/media/danila/DISK1/code/Antivirus/Anitvirus/GladeWindow/LogWindow.glade");
                GuiBuilder.Autoconnect(this);
                
                foreach (var log in logs)
                {
                    var b = log.Value ? "is virus" : "is not virus";
                    LogTextView.Buffer.Text += $"{log.Key}  --  {b}\n";
                }
            }
        }

        private void ClickedCloseButton(object sender, EventArgs a) => Close();
        public void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    Window.Dispose();
                }
            }
            this.disposed = true;
        }
 
        public void Dispose()
        {
            Window.Visible = false;
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        public void Show() => Window.Visible = true;
        public void Close() => Dispose();
        
    }
}