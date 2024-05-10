namespace NBodyTaskGUI
{
    partial class DllCheckForm
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
            buttonLoadDll.Location = new Point(360, 277);
            buttonLoadDll.Margin = new Padding(3, 4, 3, 4);
            buttonLoadDll.Name = "buttonLoadDll";
            buttonLoadDll.Size = new Size(152, 31);
            buttonLoadDll.TabIndex = 0;
            buttonLoadDll.Text = "Загрузить DLL";
            buttonLoadDll.UseVisualStyleBackColor = true;
            buttonLoadDll.Click += buttonLoadDll_Click_1;
            // 
            // DllCheckForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(buttonLoadDll);
            Margin = new Padding(3, 4, 3, 4);
            Name = "DllCheckForm";
            Text = "Гравитационная задача n тел";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonLoadDll;
    }
}