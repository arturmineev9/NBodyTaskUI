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
            button1 = new Button();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(13, 121);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 4;
            btnStart.Text = "Старт";
            btnStart.UseVisualStyleBackColor = true;
            // 
            // tbBodiesCount
            // 
            tbBodiesCount.Location = new Point(13, 13);
            tbBodiesCount.Name = "tbBodiesCount";
            tbBodiesCount.Size = new Size(138, 23);
            tbBodiesCount.TabIndex = 0;
            tbBodiesCount.Text = "Количество тел";
            // 
            // tbBodyMass
            // 
            tbBodyMass.Location = new Point(13, 40);
            tbBodyMass.Name = "tbBodyMass";
            tbBodyMass.Size = new Size(138, 23);
            tbBodyMass.TabIndex = 1;
            tbBodyMass.Text = "Масса тела";
            // 
            // tbDeltaTime
            // 
            tbDeltaTime.Location = new Point(13, 67);
            tbDeltaTime.Name = "tbDeltaTime";
            tbDeltaTime.Size = new Size(138, 23);
            tbDeltaTime.TabIndex = 2;
            tbDeltaTime.Text = "Delta-time";
            // 
            // tbThreadsNum
            // 
            tbThreadsNum.Location = new Point(13, 94);
            tbThreadsNum.Name = "tbThreadsNum";
            tbThreadsNum.Size = new Size(138, 23);
            tbThreadsNum.TabIndex = 3;
            tbThreadsNum.Text = "Количество потоков";
            // 
            // panel
            // 
            panel.BackColor = Color.LightGray;
            panel.Location = new Point(176, 13);
            panel.Margin = new Padding(3, 2, 3, 2);
            panel.Name = "panel";
            panel.Size = new Size(612, 426);
            panel.TabIndex = 0;
            panel.Paint += panel_Paint;
            
            // 
            // button1
            // 
            button1.Location = new Point(12, 150);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "Двигать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(panel);
            Controls.Add(tbThreadsNum);
            Controls.Add(tbDeltaTime);
            Controls.Add(tbBodyMass);
            Controls.Add(tbBodiesCount);
            Controls.Add(btnStart);
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
        private Button button1;
    }
}
