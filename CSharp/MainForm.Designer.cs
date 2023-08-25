namespace DicomMetadataEditorDemo
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDicomFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.saveCurrentDicomFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCurrentDicomFileToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.closeDicomSeriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metadataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveEmbeddedVideoFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDicomFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveDicomFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.dicomMetadataEditorControl1 = new DemosCommonCode.Imaging.DicomMetadataEditorControl();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.metadataToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1056, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDicomFilesToolStripMenuItem,
            this.toolStripSeparator21,
            this.saveCurrentDicomFileToolStripMenuItem,
            this.saveCurrentDicomFileToToolStripMenuItem,
            this.toolStripSeparator5,
            this.closeDicomSeriesToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openDicomFilesToolStripMenuItem
            // 
            this.openDicomFilesToolStripMenuItem.Name = "openDicomFilesToolStripMenuItem";
            this.openDicomFilesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openDicomFilesToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.openDicomFilesToolStripMenuItem.Text = "Open DICOM File ...";
            this.openDicomFilesToolStripMenuItem.Click += new System.EventHandler(this.openDicomFilesToolStripMenuItem_Click);
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            this.toolStripSeparator21.Size = new System.Drawing.Size(225, 6);
            // 
            // saveCurrentDicomFileToolStripMenuItem
            // 
            this.saveCurrentDicomFileToolStripMenuItem.Name = "saveCurrentDicomFileToolStripMenuItem";
            this.saveCurrentDicomFileToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.saveCurrentDicomFileToolStripMenuItem.Text = "Save Current DICOM File";
            this.saveCurrentDicomFileToolStripMenuItem.Click += new System.EventHandler(this.saveCurrentDicomFileToolStripMenuItem_Click);
            // 
            // saveCurrentDicomFileToToolStripMenuItem
            // 
            this.saveCurrentDicomFileToToolStripMenuItem.Name = "saveCurrentDicomFileToToolStripMenuItem";
            this.saveCurrentDicomFileToToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.saveCurrentDicomFileToToolStripMenuItem.Text = "Save Current DICOM File To...";
            this.saveCurrentDicomFileToToolStripMenuItem.Click += new System.EventHandler(this.saveCurrentDicomFileToToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(225, 6);
            // 
            // closeDicomSeriesToolStripMenuItem
            // 
            this.closeDicomSeriesToolStripMenuItem.Name = "closeDicomSeriesToolStripMenuItem";
            this.closeDicomSeriesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.closeDicomSeriesToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.closeDicomSeriesToolStripMenuItem.Text = "Close DICOM File";
            this.closeDicomSeriesToolStripMenuItem.Click += new System.EventHandler(this.closeDicomSeriesToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(225, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // metadataToolStripMenuItem
            // 
            this.metadataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveEmbeddedVideoFileToolStripMenuItem});
            this.metadataToolStripMenuItem.Name = "metadataToolStripMenuItem";
            this.metadataToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.metadataToolStripMenuItem.Text = "Metadata";
            // 
            // saveEmbeddedVideoFileToolStripMenuItem
            // 
            this.saveEmbeddedVideoFileToolStripMenuItem.Name = "saveEmbeddedVideoFileToolStripMenuItem";
            this.saveEmbeddedVideoFileToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.saveEmbeddedVideoFileToolStripMenuItem.Text = "Save Embedded Video File...";
            this.saveEmbeddedVideoFileToolStripMenuItem.Click += new System.EventHandler(this.saveEmbeddedVideoFileToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // openDicomFileDialog
            // 
            this.openDicomFileDialog.Filter = "DICOM files|*.dcm;*.dic;*.acr|All files|*.*";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "mpg";
            this.saveFileDialog1.Filter = "Mpeg files|*.mpg";
            // 
            // saveDicomFileDialog
            // 
            this.saveDicomFileDialog.DefaultExt = "dcm";
            this.saveDicomFileDialog.Filter = "DICOM file|*.dcm|DICOM directory|DICOMDIR|Presentation State file|*.pre";
            // 
            // dicomMetadataEditorControl1
            // 
            this.dicomMetadataEditorControl1.CanEdit = true;
            this.dicomMetadataEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dicomMetadataEditorControl1.Image = null;
            this.dicomMetadataEditorControl1.Location = new System.Drawing.Point(0, 24);
            this.dicomMetadataEditorControl1.Name = "dicomMetadataEditorControl1";
            this.dicomMetadataEditorControl1.RootMetadataNode = null;
            this.dicomMetadataEditorControl1.Size = new System.Drawing.Size(1056, 563);
            this.dicomMetadataEditorControl1.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 587);
            this.Controls.Add(this.dicomMetadataEditorControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dicom Metadata Editor Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDicomFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator21;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentDicomFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentDicomFileToToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem closeDicomSeriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem metadataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveEmbeddedVideoFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openDicomFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveDicomFileDialog;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private DemosCommonCode.Imaging.DicomMetadataEditorControl dicomMetadataEditorControl1;
    }
}
