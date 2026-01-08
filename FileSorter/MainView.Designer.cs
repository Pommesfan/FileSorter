
namespace FileSorter
{
    partial class FileSorter
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
            selectSource = new Button();
            selectDestination = new Button();
            textBoxSource = new TextBox();
            textBoxDestination = new TextBox();
            selectSortMode = new ComboBox();
            btnSort = new Button();
            textBoxSetFilters = new TextBox();
            textBoxSortBy = new TextBox();
            layoutSort = new FlowLayoutPanel();
            fileFilterPanel = new FileFilterPanel();
            btnAdd = new Button();
            layoutSort.SuspendLayout();
            SuspendLayout();
            // 
            // selectSource
            // 
            selectSource.Location = new Point(292, 7);
            selectSource.Name = "selectSource";
            selectSource.Size = new Size(188, 23);
            selectSource.TabIndex = 0;
            selectSource.Text = "Quelle auswählen";
            selectSource.UseVisualStyleBackColor = true;
            selectSource.Click += selectLocation;
            // 
            // selectDestination
            // 
            selectDestination.Location = new Point(292, 65);
            selectDestination.Name = "selectDestination";
            selectDestination.Size = new Size(188, 23);
            selectDestination.TabIndex = 1;
            selectDestination.Text = "Ziel auswählen";
            selectDestination.UseVisualStyleBackColor = true;
            selectDestination.Click += selectLocation;
            // 
            // textBoxSource
            // 
            textBoxSource.Enabled = false;
            textBoxSource.Location = new Point(200, 36);
            textBoxSource.Name = "textBoxSource";
            textBoxSource.Size = new Size(384, 23);
            textBoxSource.TabIndex = 2;
            // 
            // textBoxDestination
            // 
            textBoxDestination.Enabled = false;
            textBoxDestination.Location = new Point(199, 94);
            textBoxDestination.Name = "textBoxDestination";
            textBoxDestination.Size = new Size(385, 23);
            textBoxDestination.TabIndex = 3;
            // 
            // selectSortMode
            // 
            selectSortMode.FormattingEnabled = true;
            selectSortMode.Location = new Point(3, 38);
            selectSortMode.Name = "selectSortMode";
            selectSortMode.Size = new Size(188, 23);
            selectSortMode.TabIndex = 4;
            // 
            // btnSort
            // 
            btnSort.BackColor = Color.ForestGreen;
            btnSort.Font = new Font("Segoe UI", 16F);
            btnSort.ForeColor = Color.White;
            btnSort.Location = new Point(376, 397);
            btnSort.Name = "btnSort";
            btnSort.Size = new Size(113, 41);
            btnSort.TabIndex = 5;
            btnSort.Text = "Sortieren";
            btnSort.UseVisualStyleBackColor = false;
            btnSort.Click += btnSort_Click;
            // 
            // textBoxSetFilters
            // 
            textBoxSetFilters.Enabled = false;
            textBoxSetFilters.Font = new Font("Segoe UI", 12F);
            textBoxSetFilters.Location = new Point(12, 133);
            textBoxSetFilters.Name = "textBoxSetFilters";
            textBoxSetFilters.Size = new Size(146, 29);
            textBoxSetFilters.TabIndex = 8;
            textBoxSetFilters.Text = "Filter einstellen";
            // 
            // textBoxSortBy
            // 
            textBoxSortBy.Enabled = false;
            textBoxSortBy.Font = new Font("Segoe UI", 12F);
            textBoxSortBy.Location = new Point(3, 3);
            textBoxSortBy.Name = "textBoxSortBy";
            textBoxSortBy.Size = new Size(146, 29);
            textBoxSortBy.TabIndex = 9;
            textBoxSortBy.Text = "Sortieren nach";
            // 
            // layoutSort
            // 
            layoutSort.Controls.Add(textBoxSortBy);
            layoutSort.Controls.Add(selectSortMode);
            layoutSort.Location = new Point(406, 168);
            layoutSort.Name = "layoutSort";
            layoutSort.Size = new Size(303, 86);
            layoutSort.TabIndex = 0;
            // 
            // fileFilterPanel
            // 
            fileFilterPanel.AutoSize = true;
            fileFilterPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            fileFilterPanel.FlowDirection = FlowDirection.TopDown;
            fileFilterPanel.Location = new Point(12, 171);
            fileFilterPanel.Name = "fileFilterPanel";
            fileFilterPanel.Size = new Size(0, 0);
            fileFilterPanel.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.LimeGreen;
            btnAdd.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(164, 133);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(28, 32);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "+";
            btnAdd.TextAlign = ContentAlignment.TopLeft;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // FileSorter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxSetFilters);
            Controls.Add(btnAdd);
            Controls.Add(fileFilterPanel);
            Controls.Add(layoutSort);
            Controls.Add(selectSource);
            Controls.Add(selectDestination);
            Controls.Add(textBoxSource);
            Controls.Add(btnSort);
            Controls.Add(textBoxDestination);
            Name = "FileSorter";
            Text = "FileSorter";
            layoutSort.ResumeLayout(false);
            layoutSort.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            fileFilterPanel.addFilter();
        }

        #endregion

        private Button selectSource;
        private Button selectDestination;
        private TextBox textBoxSource;
        private TextBox textBoxDestination;
        private ComboBox selectSortMode;
        private Button btnSort;
        private TextBox textBoxSetFilters;
        private TextBox textBoxSortBy;
        private FlowLayoutPanel layoutSort;
        private FileFilterPanel fileFilterPanel;
        private Button btnAdd;
    }
}
