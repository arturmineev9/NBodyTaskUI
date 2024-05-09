namespace NBodyTaskGUI
{
    partial class Form0
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
            buttonLoadDll = new Button();
            SuspendLayout();
            // 
            // buttonLoadDll
            // 
            buttonLoadDll.Location = new Point(315, 208);
            buttonLoadDll.Name = "buttonLoadDll";
            buttonLoadDll.Size = new Size(133, 23);
            buttonLoadDll.TabIndex = 0;
            buttonLoadDll.Text = "Загрузить DLL";
            buttonLoadDll.UseVisualStyleBackColor = true;
            buttonLoadDll.Click += buttonLoadDll_Click_1;
            // 
            // Form0
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonLoadDll);
            Name = "Form0";
            Text = "Form2";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonLoadDll;
    }
}