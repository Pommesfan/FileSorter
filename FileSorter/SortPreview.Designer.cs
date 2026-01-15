namespace FileSorter
{
    partial class SortPreview
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
            treeViewSorted = new TreeView();
            layoutMain = new SplitContainer();
            treeViewSortedOut = new TreeView();
            ((System.ComponentModel.ISupportInitialize)layoutMain).BeginInit();
            layoutMain.Panel1.SuspendLayout();
            layoutMain.Panel2.SuspendLayout();
            layoutMain.SuspendLayout();
            SuspendLayout();
            // 
            // treeViewSorted
            // 
            treeViewSorted.Dock = DockStyle.Fill;
            treeViewSorted.Location = new Point(0, 0);
            treeViewSorted.Name = "treeViewSorted";
            treeViewSorted.Size = new Size(574, 758);
            treeViewSorted.TabIndex = 0;
            // 
            // layoutMain
            // 
            layoutMain.Dock = DockStyle.Fill;
            layoutMain.Location = new Point(0, 0);
            layoutMain.Name = "layoutMain";
            // 
            // layoutMain.Panel1
            // 
            layoutMain.Panel1.Controls.Add(treeViewSorted);
            // 
            // layoutMain.Panel2
            // 
            layoutMain.Panel2.Controls.Add(treeViewSortedOut);
            layoutMain.Size = new Size(1132, 758);
            layoutMain.SplitterDistance = 574;
            layoutMain.TabIndex = 5;
            // 
            // treeViewSortedOut
            // 
            treeViewSortedOut.Dock = DockStyle.Fill;
            treeViewSortedOut.Location = new Point(0, 0);
            treeViewSortedOut.Name = "treeViewSortedOut";
            treeViewSortedOut.Size = new Size(554, 758);
            treeViewSortedOut.TabIndex = 1;
            // 
            // SortPreview
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1132, 758);
            Controls.Add(layoutMain);
            Name = "SortPreview";
            Text = "SortPreview";
            layoutMain.Panel1.ResumeLayout(false);
            layoutMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)layoutMain).EndInit();
            layoutMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TreeView treeViewSorted;
        private SplitContainer layoutMain;
        private TreeView treeViewSortedOut;
    }
}