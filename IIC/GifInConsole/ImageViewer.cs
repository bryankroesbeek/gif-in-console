using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GifInConsole
{
    class ImageViewer
    {
        private Image Image { get; set; }

        public ImageViewer(Image i)
        {
            this.Image = i;
        }

        public void View()
        {
            Form window = new Form();
            window.Controls.Add(new PictureBox
            {
                Image = this.Image,
                Dock = DockStyle.Fill
            });
            Application.Run(window);
        }
    }
}