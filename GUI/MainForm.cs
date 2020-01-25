using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhotoParser;

namespace GUI
{
    public partial class MainForm : Form
    {
        const string ERROR_NOTIFICATION = "Ошибка!";

        public MainForm()
        {
            InitializeComponent();
        }

        private void RecognizeTextButton_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                var text = new TextRecogniser();
                text.Recognize().CopyToClipboard();
            }
            else
                MessageBox.Show("Буфер обмена не содержит изображение!", ERROR_NOTIFICATION);
        }

        private void RecognizeAndTranslateTextbutton_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                var text = new TextRecogniser();
                text.Translate().CopyToClipboard();
            }
            else
                MessageBox.Show("Буфер обмена не содержит изображение!", ERROR_NOTIFICATION);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
