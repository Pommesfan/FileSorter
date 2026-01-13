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
            listBoxFilteredOutItems = new ListBox();
            textBoxShowFilteredOutItems = new TextBox();
            layoutFilteredOut = new FlowLayoutPanel();
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
            // listBoxFilteredOutItems
            // 
            listBoxFilteredOutItems.FormattingEnabled = true;
            listBoxFilteredOutItems.ItemHeight = 15;
            listBoxFilteredOutItems.Location = new Point(3, 38);
            listBoxFilteredOutItems.Name = "listBoxFilteredOutItems";
            listBoxFilteredOutItems.Size = new Size(309, 499);
            listBoxFilteredOutItems.TabIndex = 1;
            // 
            // textBoxShowFilteredOutItems
            // 
            textBoxShowFilteredOutItems.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxShowFilteredOutItems.Location = new Point(3, 3);
            textBoxShowFilteredOutItems.Name = "textBoxShowFilteredOutItems";
            textBoxShowFilteredOutItems.Size = new Size(308, 29);
            textBoxShowFilteredOutItems.TabIndex = 2;
            textBoxShowFilteredOutItems.Text = "Herausgefilterte Dateien";
            // 
            // layoutFilteredOut
            // 
            layoutFilteredOut.AutoSize = true;
            layoutFilteredOut.Controls.Add(textBoxShowFilteredOutItems);
            layoutFilteredOut.Controls.Add(listBoxFilteredOutItems);
            layoutFilteredOut.FlowDirection = FlowDirection.TopDown;
            layoutFilteredOut.Location = new Point(484, 3);
            layoutFilteredOut.Name = "layoutFilteredOut";
            layoutFilteredOut.Size = new Size(315, 540);
            layoutFilteredOut.TabIndex = 3;
            // 
            // layoutMain
            // 
            layoutMain.AutoSize = true;
            layoutMain.Controls.Add(treeViewSorted);
            layoutMain.Controls.Add(layoutFilteredOut);
            layoutMain.Location = new Point(12, 12);
            layoutMain.Name = "layoutMain";
            layoutMain.Size = new Size(803, 546);
            layoutMain.TabIndex = 4;
            // 
            // SortPreview
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(819, 561);
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
        private ListBox listBoxFilteredOutItems;
        private TextBox textBoxShowFilteredOutItems;
        private FlowLayoutPanel layoutFilteredOut;
        private FlowLayoutPanel layoutMain;
    }
}