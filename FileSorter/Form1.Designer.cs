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
            comboBoxFilter = new ComboBox();
            textBoxFileType = new TextBox();
            textBoxSetFilters = new TextBox();
            textBoxSortBy = new TextBox();
            SuspendLayout();
            // 
            // selectSource
            // 
            selectSource.Location = new Point(279, 33);
            selectSource.Name = "selectSource";
            selectSource.Size = new Size(188, 23);
            selectSource.TabIndex = 0;
            selectSource.Text = "Quelle auswählen";
            selectSource.UseVisualStyleBackColor = true;
            selectSource.Click += selectLocation;
            // 
            // selectDestination
            // 
            selectDestination.Location = new Point(279, 91);
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
            textBoxSource.Location = new Point(187, 62);
            textBoxSource.Name = "textBoxSource";
            textBoxSource.Size = new Size(384, 23);
            textBoxSource.TabIndex = 2;
            // 
            // textBoxDestination
            // 
            textBoxDestination.Enabled = false;
            textBoxDestination.Location = new Point(186, 120);
            textBoxDestination.Name = "textBoxDestination";
            textBoxDestination.Size = new Size(385, 23);
            textBoxDestination.TabIndex = 3;
            // 
            // selectSortMode
            // 
            selectSortMode.FormattingEnabled = true;
            selectSortMode.Location = new Point(236, 273);
            selectSortMode.Name = "selectSortMode";
            selectSortMode.Size = new Size(188, 23);
            selectSortMode.TabIndex = 4;
            // 
            // btnSort
            // 
            btnSort.BackColor = Color.ForestGreen;
            btnSort.Font = new Font("Segoe UI", 16F);
            btnSort.ForeColor = Color.White;
            btnSort.Location = new Point(306, 397);
            btnSort.Name = "btnSort";
            btnSort.Size = new Size(113, 41);
            btnSort.TabIndex = 5;
            btnSort.Text = "Sortieren";
            btnSort.UseVisualStyleBackColor = false;
            btnSort.Click += btnSort_Click;
            // 
            // comboBoxFilter
            // 
            comboBoxFilter.FormattingEnabled = true;
            comboBoxFilter.Location = new Point(236, 199);
            comboBoxFilter.Name = "comboBoxFilter";
            comboBoxFilter.Size = new Size(146, 23);
            comboBoxFilter.TabIndex = 6;
            // 
            // textBoxFileType
            // 
            textBoxFileType.Location = new Point(388, 199);
            textBoxFileType.Name = "textBoxFileType";
            textBoxFileType.Size = new Size(135, 23);
            textBoxFileType.TabIndex = 7;
            // 
            // textBoxSetFilters
            // 
            textBoxSetFilters.Enabled = false;
            textBoxSetFilters.Font = new Font("Segoe UI", 12F);
            textBoxSetFilters.Location = new Point(236, 166);
            textBoxSetFilters.Name = "textBoxSetFilters";
            textBoxSetFilters.Size = new Size(146, 29);
            textBoxSetFilters.TabIndex = 8;
            textBoxSetFilters.Text = "Filter einstellen";
            // 
            // textBoxSortBy
            // 
            textBoxSortBy.Enabled = false;
            textBoxSortBy.Font = new Font("Segoe UI", 12F);
            textBoxSortBy.Location = new Point(236, 238);
            textBoxSortBy.Name = "textBoxSortBy";
            textBoxSortBy.Size = new Size(146, 29);
            textBoxSortBy.TabIndex = 9;
            textBoxSortBy.Text = "Sortieren nach";
            // 
            // FileSorter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxSortBy);
            Controls.Add(textBoxSetFilters);
            Controls.Add(textBoxFileType);
            Controls.Add(comboBoxFilter);
            Controls.Add(selectSource);
            Controls.Add(selectDestination);
            Controls.Add(textBoxSource);
            Controls.Add(btnSort);
            Controls.Add(textBoxDestination);
            Controls.Add(selectSortMode);
            Name = "FileSorter";
            Text = "FileSorter";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button selectSource;
        private Button selectDestination;
        private TextBox textBoxSource;
        private TextBox textBoxDestination;
        private ComboBox selectSortMode;
        private Button btnSort;
        private ComboBox comboBoxFilter;
        private TextBox textBoxFileType;
        private TextBox textBoxSetFilters;
        private TextBox textBoxSortBy;
    }
}
