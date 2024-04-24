namespace MyGui;

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
        pictureBox1 = new PictureBox();
        groupBox2 = new GroupBox();
        lblLastAction = new Label();
        button1 = new Button();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        groupBox2.SuspendLayout();
        SuspendLayout();
        // 
        // pictureBox1
        // 
        pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        pictureBox1.BackColor = SystemColors.ControlDark;
        pictureBox1.Location = new Point(12, 12);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(695, 361);
        pictureBox1.TabIndex = 4;
        pictureBox1.TabStop = false;
        // 
        // groupBox2
        // 
        groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        groupBox2.Controls.Add(lblLastAction);
        groupBox2.Location = new Point(115, 379);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new Size(592, 70);
        groupBox2.TabIndex = 6;
        groupBox2.TabStop = false;
        groupBox2.Text = "Last Action";
        // 
        // lblLastAction
        // 
        lblLastAction.AutoSize = true;
        lblLastAction.Location = new Point(19, 31);
        lblLastAction.Name = "lblLastAction";
        lblLastAction.Size = new Size(57, 15);
        lblLastAction.TabIndex = 0;
        lblLastAction.Text = "Waiting...";
        // 
        // button1
        // 
        button1.Enabled = false;
        button1.Location = new Point(12, 386);
        button1.Name = "button1";
        button1.Size = new Size(97, 63);
        button1.TabIndex = 7;
        button1.Text = "Show Unprocessed Events (0)";
        button1.UseVisualStyleBackColor = true;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(719, 461);
        Controls.Add(button1);
        Controls.Add(groupBox2);
        Controls.Add(pictureBox1);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        groupBox2.ResumeLayout(false);
        groupBox2.PerformLayout();
        ResumeLayout(false);
    }

    #endregion
    private PictureBox pictureBox1;
    private GroupBox groupBox2;
    private Label lblLastAction;
    private Button button1;
}
