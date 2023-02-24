namespace WorkingWithSqlServerImages;

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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ReadClientButton = new System.Windows.Forms.Button();
            this.InsertClientButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TruncateCheckBox = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.PhotoPictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ReadDapperButton = new System.Windows.Forms.Button();
            this.InsertDapperButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ReadEntityButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PhotoPictureBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ReadClientButton);
            this.groupBox1.Controls.Add(this.InsertClientButton);
            this.groupBox1.Location = new System.Drawing.Point(27, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 137);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SqlClient";
            // 
            // ReadClientButton
            // 
            this.ReadClientButton.Location = new System.Drawing.Point(18, 72);
            this.ReadClientButton.Name = "ReadClientButton";
            this.ReadClientButton.Size = new System.Drawing.Size(206, 29);
            this.ReadClientButton.TabIndex = 2;
            this.ReadClientButton.Text = "Read first image";
            this.ReadClientButton.UseVisualStyleBackColor = true;
            this.ReadClientButton.Click += new System.EventHandler(this.ReadClientButton_Click);
            // 
            // InsertClientButton
            // 
            this.InsertClientButton.Location = new System.Drawing.Point(18, 37);
            this.InsertClientButton.Name = "InsertClientButton";
            this.InsertClientButton.Size = new System.Drawing.Size(206, 29);
            this.InsertClientButton.TabIndex = 1;
            this.InsertClientButton.Text = "Insert image";
            this.InsertClientButton.UseVisualStyleBackColor = true;
            this.InsertClientButton.Click += new System.EventHandler(this.InsertClientButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TruncateCheckBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 392);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 58);
            this.panel1.TabIndex = 1;
            // 
            // TruncateCheckBox
            // 
            this.TruncateCheckBox.AutoSize = true;
            this.TruncateCheckBox.Checked = true;
            this.TruncateCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TruncateCheckBox.Location = new System.Drawing.Point(12, 22);
            this.TruncateCheckBox.Name = "TruncateCheckBox";
            this.TruncateCheckBox.Size = new System.Drawing.Size(148, 24);
            this.TruncateCheckBox.TabIndex = 4;
            this.TruncateCheckBox.Text = "Truncate on insert";
            this.TruncateCheckBox.UseVisualStyleBackColor = true;
            // 
            // PhotoPictureBox
            // 
            this.PhotoPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PhotoPictureBox.Location = new System.Drawing.Point(297, 179);
            this.PhotoPictureBox.Name = "PhotoPictureBox";
            this.PhotoPictureBox.Size = new System.Drawing.Size(354, 207);
            this.PhotoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PhotoPictureBox.TabIndex = 3;
            this.PhotoPictureBox.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ReadDapperButton);
            this.groupBox2.Controls.Add(this.InsertDapperButton);
            this.groupBox2.Location = new System.Drawing.Point(27, 200);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 137);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dapper";
            // 
            // ReadDapperButton
            // 
            this.ReadDapperButton.Location = new System.Drawing.Point(18, 72);
            this.ReadDapperButton.Name = "ReadDapperButton";
            this.ReadDapperButton.Size = new System.Drawing.Size(206, 29);
            this.ReadDapperButton.TabIndex = 2;
            this.ReadDapperButton.Text = "Read first image";
            this.ReadDapperButton.UseVisualStyleBackColor = true;
            this.ReadDapperButton.Click += new System.EventHandler(this.ReadDapperButton_Click);
            // 
            // InsertDapperButton
            // 
            this.InsertDapperButton.Location = new System.Drawing.Point(18, 37);
            this.InsertDapperButton.Name = "InsertDapperButton";
            this.InsertDapperButton.Size = new System.Drawing.Size(206, 29);
            this.InsertDapperButton.TabIndex = 1;
            this.InsertDapperButton.Text = "Insert image";
            this.InsertDapperButton.UseVisualStyleBackColor = true;
            this.InsertDapperButton.Click += new System.EventHandler(this.InsertDapperButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ReadEntityButton);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Location = new System.Drawing.Point(297, 36);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(250, 137);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "EF Core";
            // 
            // ReadEntityButton
            // 
            this.ReadEntityButton.Location = new System.Drawing.Point(18, 72);
            this.ReadEntityButton.Name = "ReadEntityButton";
            this.ReadEntityButton.Size = new System.Drawing.Size(206, 29);
            this.ReadEntityButton.TabIndex = 2;
            this.ReadEntityButton.Text = "Read first image";
            this.ReadEntityButton.UseVisualStyleBackColor = true;
            this.ReadEntityButton.Click += new System.EventHandler(this.ReadEntityButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(18, 37);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(206, 29);
            this.button3.TabIndex = 1;
            this.button3.Text = "Insert image";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.InsertEntityButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.PhotoPictureBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code samples";
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PhotoPictureBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private GroupBox groupBox1;
    private Panel panel1;
    private ToolTip toolTip1;
    private Button InsertClientButton;
    private Button ReadClientButton;
    private PictureBox PhotoPictureBox;
    private GroupBox groupBox2;
    private Button ReadDapperButton;
    private Button InsertDapperButton;
    private GroupBox groupBox3;
    private Button ReadEntityButton;
    private Button button3;
    private CheckBox TruncateCheckBox;
}
