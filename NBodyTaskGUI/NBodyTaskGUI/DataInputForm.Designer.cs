using System.Windows.Forms;

namespace NBodyTaskGUI;

partial class DataInputForm
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
        invisibleControl = new Control();
        SuspendLayout();
        // 
        // btnStart
        // 
        btnStart.Location = new Point(395, 349);
        btnStart.Margin = new Padding(3, 4, 3, 4);
        btnStart.Name = "btnStart";
        btnStart.Size = new Size(86, 31);
        btnStart.TabIndex = 4;
        btnStart.Text = "Старт";
        btnStart.UseVisualStyleBackColor = true;
        // 
        // tbBodiesCount
        // 
        tbBodiesCount.Location = new Point(331, 198);
        tbBodiesCount.Margin = new Padding(3, 4, 3, 4);
        tbBodiesCount.Name = "tbBodiesCount";
        tbBodiesCount.PlaceholderText = "Количество тел";
        tbBodiesCount.Size = new Size(222, 27);
        tbBodiesCount.TabIndex = 0;
        // 
        // tbBodyMass
        // 
        tbBodyMass.Location = new Point(331, 233);
        tbBodyMass.Margin = new Padding(3, 4, 3, 4);
        tbBodyMass.Name = "tbBodyMass";
        tbBodyMass.PlaceholderText = "Масса тел";
        tbBodyMass.Size = new Size(222, 27);
        tbBodyMass.TabIndex = 1;
        // 
        // tbDeltaTime
        // 
        tbDeltaTime.Location = new Point(331, 276);
        tbDeltaTime.Margin = new Padding(3, 4, 3, 4);
        tbDeltaTime.Name = "tbDeltaTime";
        tbDeltaTime.PlaceholderText = "Временной шаг (Delta-time)";
        tbDeltaTime.Size = new Size(222, 27);
        tbDeltaTime.TabIndex = 2;
        // 
        // tbThreadsNum
        // 
        tbThreadsNum.Location = new Point(331, 314);
        tbThreadsNum.Margin = new Padding(3, 4, 3, 4);
        tbThreadsNum.Name = "tbThreadsNum";
        tbThreadsNum.PlaceholderText = "Количество потоков";
        tbThreadsNum.Size = new Size(222, 27);
        tbThreadsNum.TabIndex = 3;
        // 
        // invisibleControl
        // 
        invisibleControl.Location = new Point(-11, -13);
        invisibleControl.Margin = new Padding(3, 4, 3, 4);
        invisibleControl.Name = "invisibleControl";
        invisibleControl.Size = new Size(0, 0);
        invisibleControl.TabIndex = 0;
        // 
        // DataInputForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(914, 600);
        Controls.Add(invisibleControl);
        Controls.Add(tbThreadsNum);
        Controls.Add(tbDeltaTime);
        Controls.Add(tbBodyMass);
        Controls.Add(tbBodiesCount);
        Controls.Add(btnStart);
        Margin = new Padding(3, 4, 3, 4);
        Name = "DataInputForm";
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
    Control invisibleControl;
}
