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
            comboBoxFilter1 = new ComboBox();
            textBoxFilterArgs1 = new TextBox();
            textBoxSetFilters = new TextBox();
            textBoxSortBy = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            layoutFilters = new FlowLayoutPanel();
            layoutFilter1 = new FlowLayoutPanel();
            btnAdd = new Button();
            flowLayoutPanel1.SuspendLayout();
            layoutFilters.SuspendLayout();
            layoutFilter1.SuspendLayout();
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
            // comboBoxFilter1
            // 
            comboBoxFilter1.FormattingEnabled = true;
            comboBoxFilter1.Location = new Point(3, 3);
            comboBoxFilter1.Name = "comboBoxFilter1";
            comboBoxFilter1.Size = new Size(146, 23);
            comboBoxFilter1.TabIndex = 6;
            // 
            // textBoxFilterArgs1
            // 
            textBoxFilterArgs1.Location = new Point(155, 3);
            textBoxFilterArgs1.Name = "textBoxFilterArgs1";
            textBoxFilterArgs1.Size = new Size(135, 23);
            textBoxFilterArgs1.TabIndex = 7;
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
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(textBoxSortBy);
            flowLayoutPanel1.Controls.Add(selectSortMode);
            flowLayoutPanel1.Location = new Point(406, 168);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(303, 86);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // layoutFilters
            // 
            layoutFilters.AutoSize = true;
            layoutFilters.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            layoutFilters.Controls.Add(layoutFilter1);
            layoutFilters.FlowDirection = FlowDirection.TopDown;
            layoutFilters.Location = new Point(13, 168);
            layoutFilters.Name = "layoutFilters";
            layoutFilters.Size = new Size(331, 38);
            layoutFilters.TabIndex = 0;
            // 
            // layoutFilter1
            // 
            layoutFilter1.Controls.Add(comboBoxFilter1);
            layoutFilter1.Controls.Add(textBoxFilterArgs1);
            layoutFilter1.Location = new Point(3, 3);
            layoutFilter1.Name = "layoutFilter1";
            layoutFilter1.Size = new Size(325, 32);
            layoutFilter1.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.LimeGreen;
            btnAdd.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(171, 130);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(31, 38);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "+";
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
            Controls.Add(layoutFilters);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(selectSource);
            Controls.Add(selectDestination);
            Controls.Add(textBoxSource);
            Controls.Add(btnSort);
            Controls.Add(textBoxDestination);
            Name = "FileSorter";
            Text = "FileSorter";
            Load += FileSorter_Load;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            layoutFilters.ResumeLayout(false);
            layoutFilter1.ResumeLayout(false);
            layoutFilter1.PerformLayout();
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
        private ComboBox comboBoxFilter1;
        private TextBox textBoxFilterArgs1;
        private TextBox textBoxSetFilters;
        private TextBox textBoxSortBy;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel layoutFilters;
        private FlowLayoutPanel layoutFilter1;
        private Button btnAdd;
    }
}
