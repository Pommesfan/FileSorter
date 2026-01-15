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
            textBoxShowFilteredOutItems = new TextBox();
            layoutFilteredOut = new FlowLayoutPanel();
            treeViewsortedOut = new TreeView();
            layoutMain = new FlowLayoutPanel();
            layoutFilteredOut.SuspendLayout();
            layoutMain.SuspendLayout();
            SuspendLayout();
            // 
            // treeViewSorted
            // 
            treeViewSorted.Location = new Point(3, 3);
            treeViewSorted.Name = "treeViewSorted";
            treeViewSorted.Size = new Size(475, 537);
            treeViewSorted.TabIndex = 0;
            // 
            // textBoxShowFilteredOutItems
            // 
            textBoxShowFilteredOutItems.Enabled = false;
            textBoxShowFilteredOutItems.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxShowFilteredOutItems.Location = new Point(3, 3);
            textBoxShowFilteredOutItems.Name = "textBoxShowFilteredOutItems";
            textBoxShowFilteredOutItems.Size = new Size(441, 29);
            textBoxShowFilteredOutItems.TabIndex = 2;
            textBoxShowFilteredOutItems.Text = "Herausgefilterte Dateien";
            // 
            // layoutFilteredOut
            // 
            layoutFilteredOut.AutoSize = true;
            layoutFilteredOut.Controls.Add(textBoxShowFilteredOutItems);
            layoutFilteredOut.Controls.Add(treeViewsortedOut);
            layoutFilteredOut.FlowDirection = FlowDirection.TopDown;
            layoutFilteredOut.Location = new Point(484, 3);
            layoutFilteredOut.Name = "layoutFilteredOut";
            layoutFilteredOut.Size = new Size(447, 537);
            layoutFilteredOut.TabIndex = 3;
            // 
            // treeViewsortedOut
            // 
            treeViewsortedOut.Location = new Point(3, 38);
            treeViewsortedOut.Name = "treeViewsortedOut";
            treeViewsortedOut.Size = new Size(441, 496);
            treeViewsortedOut.TabIndex = 4;
            // 
            // layoutMain
            // 
            layoutMain.AutoSize = true;
            layoutMain.Controls.Add(treeViewSorted);
            layoutMain.Controls.Add(layoutFilteredOut);
            layoutMain.Location = new Point(12, 12);
            layoutMain.Name = "layoutMain";
            layoutMain.Size = new Size(934, 546);
            layoutMain.TabIndex = 4;
            // 
            // SortPreview
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(951, 561);
            Controls.Add(layoutMain);
            Name = "SortPreview";
            Text = "SortPreview";
            layoutFilteredOut.ResumeLayout(false);
            layoutFilteredOut.PerformLayout();
            layoutMain.ResumeLayout(false);
            layoutMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView treeViewSorted;
        private TextBox textBoxShowFilteredOutItems;
        private FlowLayoutPanel layoutFilteredOut;
        private FlowLayoutPanel layoutMain;
        private TreeView treeViewsortedOut;
    }
}