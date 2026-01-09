
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
            layoutFilterAndSort = new FlowLayoutPanel();
            layoutFilters = new FlowLayoutPanel();
            layoutSetUpFilter = new FlowLayoutPanel();
            layoutMain = new FileFilterPanel();
            layoutSort.SuspendLayout();
            layoutFilterAndSort.SuspendLayout();
            layoutFilters.SuspendLayout();
            layoutSetUpFilter.SuspendLayout();
            layoutMain.SuspendLayout();
            SuspendLayout();
            // 
            // selectSource
            // 
            selectSource.Anchor = AnchorStyles.Top;
            selectSource.Location = new Point(146, 3);
            selectSource.Name = "selectSource";
            selectSource.Size = new Size(188, 23);
            selectSource.TabIndex = 0;
            selectSource.Text = "Quelle auswählen";
            selectSource.UseVisualStyleBackColor = true;
            selectSource.Click += selectLocation;
            // 
            // selectDestination
            // 
            selectDestination.Anchor = AnchorStyles.Top;
            selectDestination.Location = new Point(146, 61);
            selectDestination.Name = "selectDestination";
            selectDestination.Size = new Size(188, 23);
            selectDestination.TabIndex = 1;
            selectDestination.Text = "Ziel auswählen";
            selectDestination.UseVisualStyleBackColor = true;
            selectDestination.Click += selectLocation;
            // 
            // textBoxSource
            // 
            textBoxSource.Anchor = AnchorStyles.Top;
            textBoxSource.Enabled = false;
            textBoxSource.Location = new Point(48, 32);
            textBoxSource.Name = "textBoxSource";
            textBoxSource.Size = new Size(384, 23);
            textBoxSource.TabIndex = 2;
            // 
            // textBoxDestination
            // 
            textBoxDestination.Anchor = AnchorStyles.Top;
            textBoxDestination.Enabled = false;
            textBoxDestination.Location = new Point(48, 90);
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
            btnSort.Anchor = AnchorStyles.Top;
            btnSort.BackColor = Color.ForestGreen;
            btnSort.Font = new Font("Segoe UI", 16F);
            btnSort.ForeColor = Color.White;
            btnSort.Location = new Point(184, 199);
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
            textBoxSetFilters.Location = new Point(3, 3);
            textBoxSetFilters.Name = "textBoxSetFilters";
            textBoxSetFilters.Size = new Size(214, 29);
            textBoxSetFilters.TabIndex = 8;
            textBoxSetFilters.Text = "Filter einstellen";
            // 
            // textBoxSortBy
            // 
            textBoxSortBy.Enabled = false;
            textBoxSortBy.Font = new Font("Segoe UI", 12F);
            textBoxSortBy.Location = new Point(3, 3);
            textBoxSortBy.Name = "textBoxSortBy";
            textBoxSortBy.Size = new Size(188, 29);
            textBoxSortBy.TabIndex = 9;
            textBoxSortBy.Text = "Sortieren nach";
            // 
            // layoutSort
            // 
            layoutSort.Controls.Add(textBoxSortBy);
            layoutSort.Controls.Add(selectSortMode);
            layoutSort.Location = new Point(275, 3);
            layoutSort.Name = "layoutSort";
            layoutSort.Size = new Size(197, 68);
            layoutSort.TabIndex = 0;
            // 
            // fileFilterPanel
            // 
            fileFilterPanel.AutoSize = true;
            fileFilterPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            fileFilterPanel.FlowDirection = FlowDirection.TopDown;
            fileFilterPanel.Location = new Point(3, 51);
            fileFilterPanel.Name = "fileFilterPanel";
            fileFilterPanel.Size = new Size(0, 0);
            fileFilterPanel.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.LimeGreen;
            btnAdd.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(223, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(28, 32);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "+";
            btnAdd.TextAlign = ContentAlignment.TopLeft;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // layoutFilterAndSort
            // 
            layoutFilterAndSort.Anchor = AnchorStyles.Top;
            layoutFilterAndSort.AutoSize = true;
            layoutFilterAndSort.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            layoutFilterAndSort.Controls.Add(layoutFilters);
            layoutFilterAndSort.Controls.Add(layoutSort);
            layoutFilterAndSort.Location = new Point(3, 119);
            layoutFilterAndSort.Name = "layoutFilterAndSort";
            layoutFilterAndSort.Size = new Size(475, 74);
            layoutFilterAndSort.TabIndex = 11;
            // 
            // layoutFilters
            // 
            layoutFilters.AutoSize = true;
            layoutFilters.Controls.Add(layoutSetUpFilter);
            layoutFilters.Controls.Add(fileFilterPanel);
            layoutFilters.FlowDirection = FlowDirection.TopDown;
            layoutFilters.Location = new Point(3, 3);
            layoutFilters.Name = "layoutFilters";
            layoutFilters.Size = new Size(266, 54);
            layoutFilters.TabIndex = 0;
            // 
            // layoutSetUpFilter
            // 
            layoutSetUpFilter.Controls.Add(textBoxSetFilters);
            layoutSetUpFilter.Controls.Add(btnAdd);
            layoutSetUpFilter.Location = new Point(3, 3);
            layoutSetUpFilter.Name = "layoutSetUpFilter";
            layoutSetUpFilter.Size = new Size(260, 42);
            layoutSetUpFilter.TabIndex = 12;
            // 
            // layoutMain
            // 
            layoutMain.Anchor = AnchorStyles.Top;
            layoutMain.AutoSize = true;
            layoutMain.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            layoutMain.Controls.Add(selectSource);
            layoutMain.Controls.Add(textBoxSource);
            layoutMain.Controls.Add(selectDestination);
            layoutMain.Controls.Add(textBoxDestination);
            layoutMain.Controls.Add(layoutFilterAndSort);
            layoutMain.Controls.Add(btnSort);
            layoutMain.FlowDirection = FlowDirection.TopDown;
            layoutMain.Location = new Point(4, 6);
            layoutMain.Name = "layoutMain";
            layoutMain.Size = new Size(481, 243);
            layoutMain.TabIndex = 12;
            // 
            // FileSorter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(504, 450);
            Controls.Add(layoutMain);
            Name = "FileSorter";
            Text = "FileSorter";
            layoutSort.ResumeLayout(false);
            layoutSort.PerformLayout();
            layoutFilterAndSort.ResumeLayout(false);
            layoutFilterAndSort.PerformLayout();
            layoutFilters.ResumeLayout(false);
            layoutFilters.PerformLayout();
            layoutSetUpFilter.ResumeLayout(false);
            layoutSetUpFilter.PerformLayout();
            layoutMain.ResumeLayout(false);
            layoutMain.PerformLayout();
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
        private FlowLayoutPanel layoutFilterAndSort;
        private FlowLayoutPanel layoutFilters;
        private FlowLayoutPanel layoutSetUpFilter;
        private FileFilterPanel layoutMain;
    }
}
