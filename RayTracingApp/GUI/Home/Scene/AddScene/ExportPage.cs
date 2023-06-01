using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;


namespace GUI
{
    public partial class ExportPage : UserControl
    {
        public Image _img;

        public ExportPage(Image img)
        {
            _img = img;
            InitializeComponent();
        }

        private void btnChoosePath_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                txtPath.Text = dialog.FileName;
            }
        }

        private void lblJPG_Click(object sender, EventArgs e)
        {
        
        }

        private void picBGJPG_Click(object sender, EventArgs e)
        {
            //create new JPG Exporter and call exporter.export()
        }

        private void lblPNG_Click(object sender, EventArgs e)
        {
            //create new PNG Exporter and call exporter.export()
        }

        private void lblPPM_Click(object sender, EventArgs e)
        {
            //create new PPM Exporter and call exporter.export()
        }

        private void picIconBack_Click(object sender, EventArgs e)
        {

        }
    }
}
