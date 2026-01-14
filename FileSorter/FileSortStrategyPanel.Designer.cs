
namespace FileSorter
{
    partial class FileSortStrategyPanel
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // FileSortStrategyPanel
            // 
            Name = "FileSortStrategyPanel";
            Size = new Size(239, 247);
            textBoxSortBy = new TextBox();
            btnAdd = new Button();
            layoutSortStrategyHead = new FlowLayoutPanel();
            layoutSortStrategyHead.SuspendLayout();
            // 
            // textBoxSortBy
            // 
            textBoxSortBy.Enabled = false;
            textBoxSortBy.Font = new Font("Segoe UI", 12F);
            textBoxSortBy.Location = new Point(3, 3);
            textBoxSortBy.Name = "textBoxSortBy";
            textBoxSortBy.Size = new Size(160, 29);
            textBoxSortBy.TabIndex = 9;
            textBoxSortBy.Text = "Sortieren nach";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.LimeGreen;
            btnAdd.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(154, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(28, 32);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "+";
            btnAdd.TextAlign = ContentAlignment.TopLeft;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += addSortStrategy;
            // 
            // layoutSortStrategyHead
            // 
            layoutSortStrategyHead.AutoSize = true;
            layoutSortStrategyHead.Controls.Add(textBoxSortBy);
            layoutSortStrategyHead.Controls.Add(btnAdd);
            layoutSortStrategyHead.Location = new Point(3, 3);
            layoutSortStrategyHead.Name = "layoutSortStrategyHead";
            layoutSortStrategyHead.Size = new Size(185, 38);
            layoutSortStrategyHead.TabIndex = 10;
            //
            // FileSortStrategy
            //
            Controls.Add(layoutSortStrategyHead);

            layoutSortStrategyHead.ResumeLayout(false);
            layoutSortStrategyHead.PerformLayout();
            ResumeLayout(false);
        }

        private TextBox textBoxSortBy;
        private Button btnAdd;
        private FlowLayoutPanel layoutSortStrategyHead;
        #endregion
    }
}
