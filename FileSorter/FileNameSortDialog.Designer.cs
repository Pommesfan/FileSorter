namespace FileSorter
{
    partial class FileNameSortDialog
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
            textBoxFileName = new TextBox();
            textBoxIndertFolderName = new TextBox();
            textBoxInsertFileName = new TextBox();
            textBoxFolderName = new TextBox();
            btnOk = new Button();
            btnCancel = new Button();
            layoutOkCancel = new FlowLayoutPanel();
            layoutMain = new FlowLayoutPanel();
            layoutOkCancel.SuspendLayout();
            layoutMain.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxFileName
            // 
            textBoxFileName.Anchor = AnchorStyles.Top;
            textBoxFileName.Location = new Point(3, 32);
            textBoxFileName.Name = "textBoxFileName";
            textBoxFileName.Size = new Size(355, 23);
            textBoxFileName.TabIndex = 0;
            // 
            // textBoxIndertFolderName
            // 
            textBoxIndertFolderName.Anchor = AnchorStyles.Top;
            textBoxIndertFolderName.Enabled = false;
            textBoxIndertFolderName.Location = new Point(139, 61);
            textBoxIndertFolderName.Name = "textBoxIndertFolderName";
            textBoxIndertFolderName.Size = new Size(82, 23);
            textBoxIndertFolderName.TabIndex = 1;
            textBoxIndertFolderName.Text = "Ordnername";
            // 
            // textBoxInsertFileName
            // 
            textBoxInsertFileName.Anchor = AnchorStyles.Top;
            textBoxInsertFileName.Enabled = false;
            textBoxInsertFileName.Location = new Point(139, 3);
            textBoxInsertFileName.Name = "textBoxInsertFileName";
            textBoxInsertFileName.Size = new Size(82, 23);
            textBoxInsertFileName.TabIndex = 2;
            textBoxInsertFileName.Text = "Dateiname";
            // 
            // textBoxFolderName
            // 
            textBoxFolderName.Anchor = AnchorStyles.Top;
            textBoxFolderName.Location = new Point(3, 90);
            textBoxFolderName.Name = "textBoxFolderName";
            textBoxFolderName.Size = new Size(355, 23);
            textBoxFolderName.TabIndex = 3;
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(84, 3);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 4;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(3, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Abbrechen";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // layoutOkCancel
            // 
            layoutOkCancel.Anchor = AnchorStyles.Top;
            layoutOkCancel.AutoSize = true;
            layoutOkCancel.Controls.Add(btnCancel);
            layoutOkCancel.Controls.Add(btnOk);
            layoutOkCancel.Location = new Point(99, 119);
            layoutOkCancel.Name = "layoutOkCancel";
            layoutOkCancel.Size = new Size(162, 29);
            layoutOkCancel.TabIndex = 6;
            // 
            // layoutMain
            // 
            layoutMain.Controls.Add(textBoxInsertFileName);
            layoutMain.Controls.Add(textBoxFileName);
            layoutMain.Controls.Add(textBoxIndertFolderName);
            layoutMain.Controls.Add(textBoxFolderName);
            layoutMain.Controls.Add(layoutOkCancel);
            layoutMain.FlowDirection = FlowDirection.TopDown;
            layoutMain.Location = new Point(12, 12);
            layoutMain.Name = "layoutMain";
            layoutMain.Size = new Size(377, 162);
            layoutMain.TabIndex = 7;
            // 
            // FileNameSortDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(396, 182);
            Controls.Add(layoutMain);
            Name = "FileNameSortDialog";
            Text = "FileNameSortDialog";
            layoutOkCancel.ResumeLayout(false);
            layoutMain.ResumeLayout(false);
            layoutMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBoxFileName;
        private TextBox textBoxIndertFolderName;
        private TextBox textBoxInsertFileName;
        private TextBox textBoxFolderName;
        private Button btnOk;
        private Button btnCancel;
        private FlowLayoutPanel layoutOkCancel;
        private FlowLayoutPanel layoutMain;
    }
}