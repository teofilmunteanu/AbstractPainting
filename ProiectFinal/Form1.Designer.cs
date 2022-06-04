namespace ProiectFinal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.closeButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.printButton = new System.Windows.Forms.ToolStripButton();
            this.inkQtyButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.shapesDropdown = new System.Windows.Forms.ToolStripDropDownButton();
            this.ShapeNrTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.runButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.colorPickerButton = new System.Windows.Forms.ToolStripButton();
            this.fillButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.infoButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.fasdfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Gainsboro;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeButton,
            this.toolStripSeparator1,
            this.saveButton,
            this.printButton,
            this.inkQtyButton,
            this.toolStripSeparator2,
            this.shapesDropdown,
            this.ShapeNrTextBox,
            this.runButton,
            this.toolStripSeparator3,
            this.colorPickerButton,
            this.fillButton,
            this.toolStripSeparator4,
            this.infoButton,
            this.toolStripSeparator5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(517, 70);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // closeButton
            // 
            this.closeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
            this.closeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(36, 67);
            this.closeButton.ToolTipText = "Clear";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 70);
            // 
            // saveButton
            // 
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(36, 67);
            this.saveButton.ToolTipText = "Save";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // printButton
            // 
            this.printButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printButton.Image = ((System.Drawing.Image)(resources.GetObject("printButton.Image")));
            this.printButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(36, 67);
            this.printButton.ToolTipText = "Print";
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // inkQtyButton
            // 
            this.inkQtyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.inkQtyButton.Image = ((System.Drawing.Image)(resources.GetObject("inkQtyButton.Image")));
            this.inkQtyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.inkQtyButton.Name = "inkQtyButton";
            this.inkQtyButton.Size = new System.Drawing.Size(36, 67);
            this.inkQtyButton.ToolTipText = "InkConsumption";
            this.inkQtyButton.Click += new System.EventHandler(this.inkQtyButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 70);
            // 
            // shapesDropdown
            // 
            this.shapesDropdown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.shapesDropdown.Image = ((System.Drawing.Image)(resources.GetObject("shapesDropdown.Image")));
            this.shapesDropdown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.shapesDropdown.Name = "shapesDropdown";
            this.shapesDropdown.Size = new System.Drawing.Size(45, 67);
            this.shapesDropdown.ToolTipText = "Shapes";
            this.shapesDropdown.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.shapesDropdown_DropDownItemClicked);
            // 
            // ShapeNrTextBox
            // 
            this.ShapeNrTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ShapeNrTextBox.Name = "ShapeNrTextBox";
            this.ShapeNrTextBox.Size = new System.Drawing.Size(100, 70);
            this.ShapeNrTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ShapeNrTextBox.ToolTipText = "Number of shapes";
            this.ShapeNrTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ShapeNrTextBox_KeyPress);
            // 
            // runButton
            // 
            this.runButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.runButton.Image = ((System.Drawing.Image)(resources.GetObject("runButton.Image")));
            this.runButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(36, 67);
            this.runButton.Text = "toolStripButton5";
            this.runButton.ToolTipText = "Run";
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 70);
            // 
            // colorPickerButton
            // 
            this.colorPickerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.colorPickerButton.Image = ((System.Drawing.Image)(resources.GetObject("colorPickerButton.Image")));
            this.colorPickerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.colorPickerButton.Name = "colorPickerButton";
            this.colorPickerButton.Size = new System.Drawing.Size(36, 67);
            this.colorPickerButton.Text = "toolStripButton6";
            this.colorPickerButton.ToolTipText = "Color Pallete";
            this.colorPickerButton.Click += new System.EventHandler(this.colorPickerButton_Click);
            // 
            // fillButton
            // 
            this.fillButton.BackColor = System.Drawing.Color.Gainsboro;
            this.fillButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fillButton.Image = ((System.Drawing.Image)(resources.GetObject("fillButton.Image")));
            this.fillButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fillButton.Name = "fillButton";
            this.fillButton.Size = new System.Drawing.Size(36, 67);
            this.fillButton.Text = "toolStripButton7";
            this.fillButton.ToolTipText = "Fill";
            this.fillButton.Click += new System.EventHandler(this.fillButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 70);
            // 
            // infoButton
            // 
            this.infoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.infoButton.Image = ((System.Drawing.Image)(resources.GetObject("infoButton.Image")));
            this.infoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(36, 67);
            this.infoButton.Text = "toolStripButton8";
            this.infoButton.ToolTipText = "Info";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 70);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(29, 98);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(460, 460);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            // 
            // fasdfToolStripMenuItem
            // 
            this.fasdfToolStripMenuItem.Name = "fasdfToolStripMenuItem";
            this.fasdfToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.fasdfToolStripMenuItem.Text = "fasdf";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("testToolStripMenuItem.Image")));
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(176, 38);
            this.testToolStripMenuItem.Text = "test";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            this.colorDialog1.Color = System.Drawing.Color.Silver;
            this.colorDialog1.FullOpen = true;
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(517, 589);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Tablou abstract";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton closeButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.ToolStripButton printButton;
        private System.Windows.Forms.ToolStripButton inkQtyButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox ShapeNrTextBox;
        private System.Windows.Forms.ToolStripButton runButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton colorPickerButton;
        private System.Windows.Forms.ToolStripButton fillButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton infoButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripDropDownButton shapesDropdown;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem fasdfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}
