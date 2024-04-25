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
        btnShowEvents = new Button();
        groupBox1 = new GroupBox();
        lblLastEvent = new Label();
        btnClearEvents = new Button();
        gbEvents = new GroupBox();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        groupBox2.SuspendLayout();
        groupBox1.SuspendLayout();
        gbEvents.SuspendLayout();
        SuspendLayout();
        // 
        // pictureBox1
        // 
        pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        pictureBox1.BackColor = SystemColors.ControlDark;
        pictureBox1.Location = new Point(12, 12);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(668, 369);
        pictureBox1.TabIndex = 4;
        pictureBox1.TabStop = false;
        // 
        // groupBox2
        // 
        groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        groupBox2.Controls.Add(lblLastAction);
        groupBox2.Location = new Point(12, 451);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new Size(668, 58);
        groupBox2.TabIndex = 6;
        groupBox2.TabStop = false;
        groupBox2.Text = "Last Action";
        // 
        // lblLastAction
        // 
        lblLastAction.AutoSize = true;
        lblLastAction.Location = new Point(14, 25);
        lblLastAction.Name = "lblLastAction";
        lblLastAction.Size = new Size(57, 15);
        lblLastAction.TabIndex = 0;
        lblLastAction.Text = "Waiting...";
        // 
        // btnShowEvents
        // 
        btnShowEvents.Location = new Point(6, 22);
        btnShowEvents.Name = "btnShowEvents";
        btnShowEvents.Size = new Size(78, 30);
        btnShowEvents.TabIndex = 7;
        btnShowEvents.Text = "Show All";
        btnShowEvents.UseVisualStyleBackColor = true;
        // 
        // groupBox1
        // 
        groupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        groupBox1.Controls.Add(lblLastEvent);
        groupBox1.Location = new Point(196, 387);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(484, 58);
        groupBox1.TabIndex = 8;
        groupBox1.TabStop = false;
        groupBox1.Text = "Last Event";
        // 
        // lblLastEvent
        // 
        lblLastEvent.AutoSize = true;
        lblLastEvent.Location = new Point(14, 25);
        lblLastEvent.Name = "lblLastEvent";
        lblLastEvent.Size = new Size(57, 15);
        lblLastEvent.TabIndex = 0;
        lblLastEvent.Text = "Waiting...";
        // 
        // btnClearEvents
        // 
        btnClearEvents.Location = new Point(90, 22);
        btnClearEvents.Name = "btnClearEvents";
        btnClearEvents.Size = new Size(78, 30);
        btnClearEvents.TabIndex = 9;
        btnClearEvents.Text = "Clear";
        btnClearEvents.UseVisualStyleBackColor = true;
        // 
        // gbEvents
        // 
        gbEvents.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        gbEvents.Controls.Add(btnShowEvents);
        gbEvents.Controls.Add(btnClearEvents);
        gbEvents.Enabled = false;
        gbEvents.Location = new Point(12, 387);
        gbEvents.Name = "gbEvents";
        gbEvents.Size = new Size(178, 58);
        gbEvents.TabIndex = 10;
        gbEvents.TabStop = false;
        gbEvents.Text = "Events";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(692, 521);
        Controls.Add(gbEvents);
        Controls.Add(groupBox1);
        Controls.Add(groupBox2);
        Controls.Add(pictureBox1);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        groupBox2.ResumeLayout(false);
        groupBox2.PerformLayout();
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        gbEvents.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion
    private PictureBox pictureBox1;
    private GroupBox groupBox2;
    private Label lblLastAction;
    private Button btnShowEvents;
    private GroupBox groupBox1;
    private Label lblLastEvent;
    private Button btnClearEvents;
    private GroupBox gbEvents;
}
