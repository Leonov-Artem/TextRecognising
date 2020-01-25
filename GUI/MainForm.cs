using System;
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

        private void RunAction(Action action)
        {
            if (Clipboard.ContainsImage())
                action.Invoke();
            else
                MessageBox.Show("Буфер обмена не содержит изображение!", ERROR_NOTIFICATION);
        }

        private void Recognize()
        {
            var text = new TextRecogniser();
            text.Recognize().CopyToClipboard();
        }

        private void Translate()
        {
            var text = new TextRecogniser();
            text.Translate().CopyToClipboard();
        }

        private void RecognizeTextButton_Click(object sender, EventArgs e)
        {
            RunAction(() => Recognize());
        }

        private void TranslateTextbutton_Click(object sender, EventArgs e)
        {
            RunAction(() => Translate());
        }
    }
}
