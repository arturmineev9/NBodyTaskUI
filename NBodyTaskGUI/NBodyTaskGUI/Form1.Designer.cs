using System.Windows.Forms;

namespace NBodyTaskGUI;

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
        SuspendLayout();
        // 
        // btnStart
        // 
        btnStart.Location = new Point(348, 264);
        btnStart.Name = "btnStart";
        btnStart.Size = new Size(75, 23);
        btnStart.TabIndex = 4;
        btnStart.Text = "Старт";
        btnStart.UseVisualStyleBackColor = true;
        // 
        // tbBodiesCount
        // 
        tbBodiesCount.Location = new Point(322, 148);
        tbBodiesCount.Name = "tbBodiesCount";
        tbBodiesCount.Size = new Size(138, 23);
        tbBodiesCount.TabIndex = 0;
        tbBodiesCount.Text = "Количество тел";
        // 
        // tbBodyMass
        // 
        tbBodyMass.Location = new Point(322, 177);
        tbBodyMass.Name = "tbBodyMass";
        tbBodyMass.Size = new Size(138, 23);
        tbBodyMass.TabIndex = 1;
        tbBodyMass.Text = "Масса тела";
        // 
        // tbDeltaTime
        // 
        tbDeltaTime.Location = new Point(322, 206);
        tbDeltaTime.Name = "tbDeltaTime";
        tbDeltaTime.Size = new Size(138, 23);
        tbDeltaTime.TabIndex = 2;
        tbDeltaTime.Text = "Delta-time";
        // 
        // tbThreadsNum
        // 
        tbThreadsNum.Location = new Point(322, 235);
        tbThreadsNum.Name = "tbThreadsNum";
        tbThreadsNum.Size = new Size(138, 23);
        tbThreadsNum.TabIndex = 3;
        tbThreadsNum.Text = "Количество потоков";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
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
    private Button button1;
}
