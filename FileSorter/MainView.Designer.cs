
namespace FileSorter
{
    partial class MainView
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
            selectDestination = new Button();
            textBoxSource = new TextBox();
            textBoxDestination = new TextBox();
            btnSort = new Button();
            textBoxSetFilters = new TextBox();
            layoutSort = new FlowLayoutPanel();
            checkboxSortInSubFolders = new CheckBox();
            layoutSearchDepth = new FlowLayoutPanel();
            textBoxInsertSearchDepth = new TextBox();
            textBoxSearchDepth = new TextBox();
            checkBoxCopyOnly = new CheckBox();
            fileSortStrategyPanel = new FileSortStrategyPanel();
            fileFilterPanel = new FileFilterPanel();
            btnAddFilter = new Button();
            layoutFilterAndSort = new FlowLayoutPanel();
            layoutFilters = new FlowLayoutPanel();
            layoutSetUpFilterHead = new FlowLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            layoutSetUpSorterHead = new FlowLayoutPanel();
            textBoxInsertSortStrategy = new TextBox();
            btnAddSortStrategy = new Button();
            layoutMain = new FileFilterPanel();
            layoutGenralSortSettings = new FlowLayoutPanel();
            layoutSrcAndDst = new FlowLayoutPanel();
            selectSource = new Button();
            layoutSortAndPreview = new FlowLayoutPanel();
            btnPreview = new Button();
            menuStrip2 = new MenuStrip();
            fileSorterMenu = new ToolStripMenuItem();
            menuItemOpen = new ToolStripMenuItem();
            menuItemSaveIn = new ToolStripMenuItem();
            menuItemSave = new ToolStripMenuItem();
            fileSystemWatcher1 = new FileSystemWatcher();
            layoutSort.SuspendLayout();
            layoutSearchDepth.SuspendLayout();
            layoutFilterAndSort.SuspendLayout();
            layoutFilters.SuspendLayout();
            layoutSetUpFilterHead.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            layoutSetUpSorterHead.SuspendLayout();
            layoutMain.SuspendLayout();
            layoutGenralSortSettings.SuspendLayout();
            layoutSrcAndDst.SuspendLayout();
            layoutSortAndPreview.SuspendLayout();
            menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // selectDestination
            // 
            selectDestination.Anchor = AnchorStyles.Top;
            selectDestination.Location = new Point(120, 61);
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
            textBoxSource.Location = new Point(3, 32);
            textBoxSource.Name = "textBoxSource";
            textBoxSource.Size = new Size(423, 23);
            textBoxSource.TabIndex = 2;
            // 
            // textBoxDestination
            // 
            textBoxDestination.Anchor = AnchorStyles.Top;
            textBoxDestination.Enabled = false;
            textBoxDestination.Location = new Point(3, 90);
            textBoxDestination.Name = "textBoxDestination";
            textBoxDestination.Size = new Size(423, 23);
            textBoxDestination.TabIndex = 3;
            // 
            // btnSort
            // 
            btnSort.Anchor = AnchorStyles.Top;
            btnSort.BackColor = Color.ForestGreen;
            btnSort.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSort.ForeColor = Color.White;
            btnSort.Location = new Point(3, 3);
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
            // layoutSort
            // 
            layoutSort.Anchor = AnchorStyles.Top;
            layoutSort.AutoSize = true;
            layoutSort.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            layoutSort.Controls.Add(checkboxSortInSubFolders);
            layoutSort.Controls.Add(layoutSearchDepth);
            layoutSort.Controls.Add(checkBoxCopyOnly);
            layoutSort.FlowDirection = FlowDirection.TopDown;
            layoutSort.Location = new Point(438, 3);
            layoutSort.Name = "layoutSort";
            layoutSort.Size = new Size(197, 86);
            layoutSort.TabIndex = 0;
            // 
            // checkboxSortInSubFolders
            // 
            checkboxSortInSubFolders.AutoSize = true;
            checkboxSortInSubFolders.Location = new Point(3, 3);
            checkboxSortInSubFolders.Name = "checkboxSortInSubFolders";
            checkboxSortInSubFolders.Size = new Size(159, 19);
            checkboxSortInSubFolders.TabIndex = 0;
            checkboxSortInSubFolders.Text = "in Unterordnern sortieren";
            checkboxSortInSubFolders.UseVisualStyleBackColor = true;
            checkboxSortInSubFolders.CheckedChanged += sortInSubFolders_CheckedChanged;
            // 
            // layoutSearchDepth
            // 
            layoutSearchDepth.Controls.Add(textBoxInsertSearchDepth);
            layoutSearchDepth.Controls.Add(textBoxSearchDepth);
            layoutSearchDepth.Enabled = false;
            layoutSearchDepth.Location = new Point(3, 28);
            layoutSearchDepth.Name = "layoutSearchDepth";
            layoutSearchDepth.Size = new Size(191, 30);
            layoutSearchDepth.TabIndex = 13;
            // 
            // textBoxInsertSearchDepth
            // 
            textBoxInsertSearchDepth.Enabled = false;
            textBoxInsertSearchDepth.Location = new Point(3, 3);
            textBoxInsertSearchDepth.Name = "textBoxInsertSearchDepth";
            textBoxInsertSearchDepth.Size = new Size(87, 23);
            textBoxInsertSearchDepth.TabIndex = 0;
            textBoxInsertSearchDepth.Text = "Max. Suchtiefe";
            // 
            // textBoxSearchDepth
            // 
            textBoxSearchDepth.Location = new Point(96, 3);
            textBoxSearchDepth.Name = "textBoxSearchDepth";
            textBoxSearchDepth.Size = new Size(92, 23);
            textBoxSearchDepth.TabIndex = 1;
            // 
            // checkBoxCopyOnly
            // 
            checkBoxCopyOnly.AutoSize = true;
            checkBoxCopyOnly.Checked = true;
            checkBoxCopyOnly.CheckState = CheckState.Checked;
            checkBoxCopyOnly.Location = new Point(3, 64);
            checkBoxCopyOnly.Name = "checkBoxCopyOnly";
            checkBoxCopyOnly.Size = new Size(136, 19);
            checkBoxCopyOnly.TabIndex = 10;
            checkBoxCopyOnly.Text = "Dateien nur kopieren";
            checkBoxCopyOnly.UseVisualStyleBackColor = true;
            // 
            // fileSortStrategyPanel
            // 
            fileSortStrategyPanel.Anchor = AnchorStyles.Top;
            fileSortStrategyPanel.AutoSize = true;
            fileSortStrategyPanel.FlowDirection = FlowDirection.TopDown;
            fileSortStrategyPanel.Location = new Point(130, 47);
            fileSortStrategyPanel.Name = "fileSortStrategyPanel";
            fileSortStrategyPanel.Size = new Size(0, 0);
            fileSortStrategyPanel.TabIndex = 14;
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
            // btnAddFilter
            // 
            btnAddFilter.BackColor = Color.LimeGreen;
            btnAddFilter.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddFilter.ForeColor = Color.White;
            btnAddFilter.Location = new Point(223, 3);
            btnAddFilter.Name = "btnAddFilter";
            btnAddFilter.Size = new Size(28, 32);
            btnAddFilter.TabIndex = 10;
            btnAddFilter.Text = "+";
            btnAddFilter.TextAlign = ContentAlignment.TopLeft;
            btnAddFilter.UseVisualStyleBackColor = false;
            btnAddFilter.Click += btnAddFilter_Click;
            // 
            // layoutFilterAndSort
            // 
            layoutFilterAndSort.Anchor = AnchorStyles.Top;
            layoutFilterAndSort.AutoSize = true;
            layoutFilterAndSort.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            layoutFilterAndSort.Controls.Add(layoutFilters);
            layoutFilterAndSort.Controls.Add(flowLayoutPanel1);
            layoutFilterAndSort.Location = new Point(53, 131);
            layoutFilterAndSort.Name = "layoutFilterAndSort";
            layoutFilterAndSort.Size = new Size(538, 60);
            layoutFilterAndSort.TabIndex = 11;
            // 
            // layoutFilters
            // 
            layoutFilters.Anchor = AnchorStyles.Top;
            layoutFilters.AutoSize = true;
            layoutFilters.Controls.Add(layoutSetUpFilterHead);
            layoutFilters.Controls.Add(fileFilterPanel);
            layoutFilters.FlowDirection = FlowDirection.TopDown;
            layoutFilters.Location = new Point(3, 3);
            layoutFilters.Name = "layoutFilters";
            layoutFilters.Size = new Size(266, 54);
            layoutFilters.TabIndex = 0;
            // 
            // layoutSetUpFilterHead
            // 
            layoutSetUpFilterHead.Controls.Add(textBoxSetFilters);
            layoutSetUpFilterHead.Controls.Add(btnAddFilter);
            layoutSetUpFilterHead.Location = new Point(3, 3);
            layoutSetUpFilterHead.Name = "layoutSetUpFilterHead";
            layoutSetUpFilterHead.Size = new Size(260, 42);
            layoutSetUpFilterHead.TabIndex = 12;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(layoutSetUpSorterHead);
            flowLayoutPanel1.Controls.Add(fileSortStrategyPanel);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(275, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(260, 50);
            flowLayoutPanel1.TabIndex = 14;
            // 
            // layoutSetUpSorterHead
            // 
            layoutSetUpSorterHead.AutoSize = true;
            layoutSetUpSorterHead.Controls.Add(textBoxInsertSortStrategy);
            layoutSetUpSorterHead.Controls.Add(btnAddSortStrategy);
            layoutSetUpSorterHead.Location = new Point(3, 3);
            layoutSetUpSorterHead.Name = "layoutSetUpSorterHead";
            layoutSetUpSorterHead.Size = new Size(254, 38);
            layoutSetUpSorterHead.TabIndex = 0;
            // 
            // textBoxInsertSortStrategy
            // 
            textBoxInsertSortStrategy.Enabled = false;
            textBoxInsertSortStrategy.Font = new Font("Segoe UI", 12F);
            textBoxInsertSortStrategy.Location = new Point(3, 3);
            textBoxInsertSortStrategy.Name = "textBoxInsertSortStrategy";
            textBoxInsertSortStrategy.Size = new Size(214, 29);
            textBoxInsertSortStrategy.TabIndex = 11;
            textBoxInsertSortStrategy.Text = "Sortierer einstellen";
            // 
            // btnAddSortStrategy
            // 
            btnAddSortStrategy.BackColor = Color.LimeGreen;
            btnAddSortStrategy.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddSortStrategy.ForeColor = Color.White;
            btnAddSortStrategy.Location = new Point(223, 3);
            btnAddSortStrategy.Name = "btnAddSortStrategy";
            btnAddSortStrategy.Size = new Size(28, 32);
            btnAddSortStrategy.TabIndex = 12;
            btnAddSortStrategy.Text = "+";
            btnAddSortStrategy.TextAlign = ContentAlignment.TopLeft;
            btnAddSortStrategy.UseVisualStyleBackColor = false;
            btnAddSortStrategy.Click += btnAddSortStrategy_Click;
            // 
            // layoutMain
            // 
            layoutMain.Anchor = AnchorStyles.Top;
            layoutMain.AutoSize = true;
            layoutMain.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            layoutMain.Controls.Add(layoutGenralSortSettings);
            layoutMain.Controls.Add(layoutFilterAndSort);
            layoutMain.Controls.Add(layoutSortAndPreview);
            layoutMain.FlowDirection = FlowDirection.TopDown;
            layoutMain.Location = new Point(21, 27);
            layoutMain.Name = "layoutMain";
            layoutMain.Size = new Size(644, 247);
            layoutMain.TabIndex = 12;
            // 
            // layoutGenralSortSettings
            // 
            layoutGenralSortSettings.Anchor = AnchorStyles.Top;
            layoutGenralSortSettings.AutoSize = true;
            layoutGenralSortSettings.Controls.Add(layoutSrcAndDst);
            layoutGenralSortSettings.Controls.Add(layoutSort);
            layoutGenralSortSettings.Location = new Point(3, 3);
            layoutGenralSortSettings.Name = "layoutGenralSortSettings";
            layoutGenralSortSettings.Size = new Size(638, 122);
            layoutGenralSortSettings.TabIndex = 15;
            // 
            // layoutSrcAndDst
            // 
            layoutSrcAndDst.Anchor = AnchorStyles.Top;
            layoutSrcAndDst.AutoSize = true;
            layoutSrcAndDst.Controls.Add(selectSource);
            layoutSrcAndDst.Controls.Add(textBoxSource);
            layoutSrcAndDst.Controls.Add(selectDestination);
            layoutSrcAndDst.Controls.Add(textBoxDestination);
            layoutSrcAndDst.FlowDirection = FlowDirection.TopDown;
            layoutSrcAndDst.Location = new Point(3, 3);
            layoutSrcAndDst.Name = "layoutSrcAndDst";
            layoutSrcAndDst.Size = new Size(429, 116);
            layoutSrcAndDst.TabIndex = 14;
            // 
            // selectSource
            // 
            selectSource.Anchor = AnchorStyles.Top;
            selectSource.Location = new Point(120, 3);
            selectSource.Name = "selectSource";
            selectSource.Size = new Size(188, 23);
            selectSource.TabIndex = 0;
            selectSource.Text = "Quelle auswählen";
            selectSource.UseVisualStyleBackColor = true;
            selectSource.Click += selectLocation;
            // 
            // layoutSortAndPreview
            // 
            layoutSortAndPreview.Anchor = AnchorStyles.Top;
            layoutSortAndPreview.AutoSize = true;
            layoutSortAndPreview.Controls.Add(btnSort);
            layoutSortAndPreview.Controls.Add(btnPreview);
            layoutSortAndPreview.Location = new Point(203, 197);
            layoutSortAndPreview.Name = "layoutSortAndPreview";
            layoutSortAndPreview.Size = new Size(237, 47);
            layoutSortAndPreview.TabIndex = 13;
            // 
            // btnPreview
            // 
            btnPreview.BackColor = Color.Yellow;
            btnPreview.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPreview.ForeColor = Color.RosyBrown;
            btnPreview.Location = new Point(122, 3);
            btnPreview.Name = "btnPreview";
            btnPreview.Size = new Size(112, 41);
            btnPreview.TabIndex = 6;
            btnPreview.Text = "Vorschau";
            btnPreview.UseVisualStyleBackColor = false;
            btnPreview.Click += btnPreview_Click;
            // 
            // menuStrip2
            // 
            menuStrip2.Items.AddRange(new ToolStripItem[] { fileSorterMenu });
            menuStrip2.Location = new Point(0, 0);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(804, 24);
            menuStrip2.TabIndex = 13;
            menuStrip2.Text = "menuStrip2";
            // 
            // fileSorterMenu
            // 
            fileSorterMenu.DropDownItems.AddRange(new ToolStripItem[] { menuItemOpen, menuItemSaveIn, menuItemSave });
            fileSorterMenu.Name = "fileSorterMenu";
            fileSorterMenu.Size = new Size(68, 20);
            fileSorterMenu.Text = "FileSorter";
            // 
            // menuItemOpen
            // 
            menuItemOpen.Name = "menuItemOpen";
            menuItemOpen.Size = new Size(157, 22);
            menuItemOpen.Text = "Öffnen";
            menuItemOpen.Click += menuItemOpen_Click;
            // 
            // menuItemSaveIn
            // 
            menuItemSaveIn.Name = "menuItemSaveIn";
            menuItemSaveIn.Size = new Size(157, 22);
            menuItemSaveIn.Text = "Speichern unter";
            menuItemSaveIn.Click += menuItemSaveIn_Click;
            // 
            // menuItemSave
            // 
            menuItemSave.Name = "menuItemSave";
            menuItemSave.Size = new Size(157, 22);
            menuItemSave.Text = "Speichern";
            menuItemSave.Click += menuItemSave_Click;
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(804, 596);
            Controls.Add(layoutMain);
            Controls.Add(menuStrip2);
            MainMenuStrip = menuStrip2;
            Name = "MainView";
            Text = "FileSorter";
            layoutSort.ResumeLayout(false);
            layoutSort.PerformLayout();
            layoutSearchDepth.ResumeLayout(false);
            layoutSearchDepth.PerformLayout();
            layoutFilterAndSort.ResumeLayout(false);
            layoutFilterAndSort.PerformLayout();
            layoutFilters.ResumeLayout(false);
            layoutFilters.PerformLayout();
            layoutSetUpFilterHead.ResumeLayout(false);
            layoutSetUpFilterHead.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            layoutSetUpSorterHead.ResumeLayout(false);
            layoutSetUpSorterHead.PerformLayout();
            layoutMain.ResumeLayout(false);
            layoutMain.PerformLayout();
            layoutGenralSortSettings.ResumeLayout(false);
            layoutGenralSortSettings.PerformLayout();
            layoutSrcAndDst.ResumeLayout(false);
            layoutSrcAndDst.PerformLayout();
            layoutSortAndPreview.ResumeLayout(false);
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button selectDestination;
        private TextBox textBoxSource;
        private TextBox textBoxDestination;
        private Button btnSort;
        private TextBox textBoxSetFilters;
        private FlowLayoutPanel layoutSort;
        private FileFilterPanel fileFilterPanel;
        private Button btnAddFilter;
        private FlowLayoutPanel layoutFilterAndSort;
        private FlowLayoutPanel layoutFilters;
        private FlowLayoutPanel layoutSetUpFilterHead;
        private CheckBox checkBoxCopyOnly;
        private FileFilterPanel layoutMain;
        private Button selectSource;
        private CheckBox checkboxSortInSubFolders;
        private FlowLayoutPanel layoutSearchDepth;
        private TextBox textBoxInsertSearchDepth;
        private TextBox textBoxSearchDepth;
        private FlowLayoutPanel layoutSortAndPreview;
        private Button btnPreview;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem fileSorterMenu;
        private ToolStripMenuItem menuItemOpen;
        private ToolStripMenuItem menuItemSaveIn;
        private ToolStripMenuItem menuItemSave;
        private FileSortStrategyPanel fileSortStrategyPanel;
        private FlowLayoutPanel layoutSrcAndDst;
        private FileSystemWatcher fileSystemWatcher1;
        private FlowLayoutPanel layoutGenralSortSettings;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel layoutSetUpSorterHead;
        private TextBox textBoxInsertSortStrategy;
        private Button btnAddSortStrategy;
    }
}
