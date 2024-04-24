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
        lbInteractions = new ListBox();
        pictureBox1 = new PictureBox();
        groupBox1 = new GroupBox();
        groupBox2 = new GroupBox();
        lblLastAction = new Label();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        groupBox1.SuspendLayout();
        groupBox2.SuspendLayout();
        SuspendLayout();
        // 
        // lbInteractions
        // 
        lbInteractions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lbInteractions.BackColor = SystemColors.Control;
        lbInteractions.BorderStyle = BorderStyle.None;
        lbInteractions.FormattingEnabled = true;
        lbInteractions.ItemHeight = 15;
        lbInteractions.Location = new Point(19, 34);
        lbInteractions.Name = "lbInteractions";
        lbInteractions.Size = new Size(306, 645);
        lbInteractions.TabIndex = 3;
        // 
        // pictureBox1
        // 
        pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        pictureBox1.BackColor = SystemColors.ControlDark;
        pictureBox1.Location = new Point(364, 12);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(776, 700);
        pictureBox1.TabIndex = 4;
        pictureBox1.TabStop = false;
        // 
        // groupBox1
        // 
        groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        groupBox1.Controls.Add(lbInteractions);
        groupBox1.Location = new Point(12, 12);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(346, 700);
        groupBox1.TabIndex = 5;
        groupBox1.TabStop = false;
        groupBox1.Text = "Interactions";
        // 
        // groupBox2
        // 
        groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        groupBox2.Controls.Add(lblLastAction);
        groupBox2.Location = new Point(12, 718);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new Size(1128, 70);
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
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1152, 800);
        Controls.Add(groupBox2);
        Controls.Add(groupBox1);
        Controls.Add(pictureBox1);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        groupBox1.ResumeLayout(false);
        groupBox2.ResumeLayout(false);
        groupBox2.PerformLayout();
        ResumeLayout(false);
    }

    #endregion
    private ListBox lbInteractions;
    private PictureBox pictureBox1;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private Label lblLastAction;
}
