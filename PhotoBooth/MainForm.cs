using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace PhotoBooth
{
    public partial class MainForm : Form
    {
        private string IMAGE_DIR = @"E:\Test";
        private FileSystemWatcher _watcher;
        
        public MainForm()
        {
            _watcher = new FileSystemWatcher();
            _watcher.Path = IMAGE_DIR;
            //_watcher.NotifyFilter = NotifyFilters.;
            _watcher.Filter = "*.*";
            _watcher.Created += _watcher_Created;
            _watcher.EnableRaisingEvents = true;
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TakePhoto();
        }

        public void _watcher_Created(object sender, FileSystemEventArgs e)
        {
            this.pictureBox1.ImageLocation = e.FullPath;
        }

        public void TakePhoto()
        {
            var hWindow = WindowTools.FindWindowByWindowName("Remote Camera Control");
            WindowTools.SetForegroundWindow(hWindow);
            WindowTools.SetWindowPosition(hWindow, new Point(0, 0));
            MouseTools.Move(new Point(223, 193));
            MouseTools.Click(MouseTools.Button.Left, MouseTools.Speed.Slow);
        }
    }
}
