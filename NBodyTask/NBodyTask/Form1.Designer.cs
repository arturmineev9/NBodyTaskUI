using System.Windows.Forms;

namespace NBodyTask
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnStart = new Button();
            tbBodiesCount = new TextBox();
            tbBodyMass = new TextBox();
            tbDeltaTime = new TextBox();
            tbThreadsNum = new TextBox();
            panel = new Panel();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(15, 161);
            btnStart.Margin = new Padding(3, 4, 3, 4);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(86, 31);
            btnStart.TabIndex = 4;
            btnStart.Text = "Старт";
            btnStart.UseVisualStyleBackColor = true;
            // 
            // tbBodiesCount
            // 
            tbBodiesCount.Location = new Point(15, 17);
            tbBodiesCount.Margin = new Padding(3, 4, 3, 4);
            tbBodiesCount.Name = "tbBodiesCount";
            tbBodiesCount.Size = new Size(157, 27);
            tbBodiesCount.TabIndex = 0;
            tbBodiesCount.Text = "Количество тел";
            // 
            // tbBodyMass
            // 
            tbBodyMass.Location = new Point(15, 53);
            tbBodyMass.Margin = new Padding(3, 4, 3, 4);
            tbBodyMass.Name = "tbBodyMass";
            tbBodyMass.Size = new Size(157, 27);
            tbBodyMass.TabIndex = 1;
            tbBodyMass.Text = "Масса тела";
            // 
            // tbDeltaTime
            // 
            tbDeltaTime.Location = new Point(15, 89);
            tbDeltaTime.Margin = new Padding(3, 4, 3, 4);
            tbDeltaTime.Name = "tbDeltaTime";
            tbDeltaTime.Size = new Size(157, 27);
            tbDeltaTime.TabIndex = 2;
            tbDeltaTime.Text = "Delta-time";
            // 
            // tbThreadsNum
            // 
            tbThreadsNum.Location = new Point(15, 125);
            tbThreadsNum.Margin = new Padding(3, 4, 3, 4);
            tbThreadsNum.Name = "tbThreadsNum";
            tbThreadsNum.Size = new Size(157, 27);
            tbThreadsNum.TabIndex = 3;
            tbThreadsNum.Text = "Количество потоков";
            // 
            // panel
            // 
            panel.BackColor = Color.LightGray;
            panel.Location = new Point(293, 17);
            panel.Name = "panel";
            panel.Size = new Size(571, 394);
            panel.TabIndex = 0;
            panel.Paint += panel_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(panel);
            Controls.Add(tbThreadsNum);
            Controls.Add(tbDeltaTime);
            Controls.Add(tbBodyMass);
            Controls.Add(tbBodiesCount);
            Controls.Add(btnStart);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Гравитационная задача n тел";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private TextBox tbBodiesCount;
        private TextBox tbBodyMass;
        private TextBox tbDeltaTime;
        private TextBox tbThreadsNum;
        private Panel panel;
    }
}
