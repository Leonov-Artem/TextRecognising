namespace GUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.recognizeTextButton = new System.Windows.Forms.Button();
            this.recognizeAndTranslateTextbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // recognizeTextButton
            // 
            this.recognizeTextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.recognizeTextButton.Location = new System.Drawing.Point(12, 76);
            this.recognizeTextButton.Name = "recognizeTextButton";
            this.recognizeTextButton.Size = new System.Drawing.Size(205, 48);
            this.recognizeTextButton.TabIndex = 1;
            this.recognizeTextButton.Text = "Распознать текст из буфера обмена\r\n";
            this.recognizeTextButton.UseVisualStyleBackColor = true;
            this.recognizeTextButton.Click += new System.EventHandler(this.RecognizeTextButton_Click);
            // 
            // recognizeAndTranslateTextbutton
            // 
            this.recognizeAndTranslateTextbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.recognizeAndTranslateTextbutton.Location = new System.Drawing.Point(12, 12);
            this.recognizeAndTranslateTextbutton.Name = "recognizeAndTranslateTextbutton";
            this.recognizeAndTranslateTextbutton.Size = new System.Drawing.Size(205, 48);
            this.recognizeAndTranslateTextbutton.TabIndex = 0;
            this.recognizeAndTranslateTextbutton.Text = "Перевести текст из буфера обмена";
            this.recognizeAndTranslateTextbutton.UseVisualStyleBackColor = true;
            this.recognizeAndTranslateTextbutton.Click += new System.EventHandler(this.TranslateTextbutton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 136);
            this.Controls.Add(this.recognizeAndTranslateTextbutton);
            this.Controls.Add(this.recognizeTextButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PhotoParser";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button recognizeTextButton;
        private System.Windows.Forms.Button recognizeAndTranslateTextbutton;
    }
}

