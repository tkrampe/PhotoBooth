using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utilities;

namespace PhotoBooth
{
    public class SonyAppWrapperCamera : ICamera
    {
        private string IMAGE_DIR = @"E:\Test";
        private FileSystemWatcher _imageDirectoryWatcher;
        private string _lastImagePath;
        private AutoResetEvent _waitHandle;

        public SonyAppWrapperCamera()
        {
            _waitHandle = new AutoResetEvent(false);
            _imageDirectoryWatcher = new FileSystemWatcher();
            _imageDirectoryWatcher.Path = IMAGE_DIR;
            _imageDirectoryWatcher.Filter = "*.jpg";
            _imageDirectoryWatcher.Created += NewImageFileCreated;
            _imageDirectoryWatcher.EnableRaisingEvents = true;
        }

        public Image TakePhoto()
        {
            _lastImagePath = null;
            var hWindow = WindowTools.FindWindowByWindowName("Remote Camera Control");
            WindowTools.SetForegroundWindow(hWindow);
            WindowTools.SetWindowPosition(hWindow, new Point(0, 0));
            MouseTools.Move(new Point(223, 193));
            MouseTools.Click(MouseTools.Button.Left, MouseTools.Speed.Slow);

            if (_waitHandle.WaitOne(5000) && _lastImagePath != null)
                return Image.FromFile(_lastImagePath);

            return null;
        }

        private void NewImageFileCreated(object sender, FileSystemEventArgs e)
        {
            _lastImagePath = e.FullPath;
            _waitHandle.Set();
        }
    }
}
