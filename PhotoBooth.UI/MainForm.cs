using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace PhotoBooth.UI
{
    public partial class MainForm : Form
    {
        private ICamera _camera;
                
        public MainForm()
        {
            _camera = new SonyAppWrapperCamera();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = _camera.TakePhoto();
        }
    }
}
