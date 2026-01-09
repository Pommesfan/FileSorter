namespace FileSorter
{
    partial class KeyWordsDialog
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
            listBoxKeywords = new ListBox();
            textBoxKeyword = new TextBox();
            btnAdd = new Button();
            btnRemove = new Button();
            layoutForList = new FlowLayoutPanel();
            textBoxInsertKeyword = new TextBox();
            layoutForBtns = new FlowLayoutPanel();
            btnOk = new Button();
            btnCancel = new Button();
            layoutMain = new FlowLayoutPanel();
            layoutForList.SuspendLayout();
            layoutForBtns.SuspendLayout();
            layoutMain.SuspendLayout();
            SuspendLayout();
            // 
            // listBoxKeywords
            // 
            listBoxKeywords.FormattingEnabled = true;
            listBoxKeywords.ItemHeight = 15;
            listBoxKeywords.Location = new Point(3, 67);
            listBoxKeywords.Name = "listBoxKeywords";
            listBoxKeywords.Size = new Size(313, 319);
            listBoxKeywords.TabIndex = 0;
            // 
            // textBoxKeyword
            // 
            textBoxKeyword.Location = new Point(3, 38);
            textBoxKeyword.Name = "textBoxKeyword";
            textBoxKeyword.Size = new Size(312, 23);
            textBoxKeyword.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(3, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(88, 23);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Hinzufügen";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(3, 32);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(88, 23);
            btnRemove.TabIndex = 3;
            btnRemove.Text = "Entfernen";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // layoutForList
            // 
            layoutForList.AutoSize = true;
            layoutForList.Controls.Add(textBoxInsertKeyword);
            layoutForList.Controls.Add(textBoxKeyword);
            layoutForList.Controls.Add(listBoxKeywords);
            layoutForList.FlowDirection = FlowDirection.TopDown;
            layoutForList.Location = new Point(107, 3);
            layoutForList.Name = "layoutForList";
            layoutForList.Size = new Size(319, 389);
            layoutForList.TabIndex = 4;
            // 
            // textBoxInsertKeyword
            // 
            textBoxInsertKeyword.Enabled = false;
            textBoxInsertKeyword.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxInsertKeyword.Location = new Point(3, 3);
            textBoxInsertKeyword.Name = "textBoxInsertKeyword";
            textBoxInsertKeyword.Size = new Size(312, 29);
            textBoxInsertKeyword.TabIndex = 2;
            textBoxInsertKeyword.Text = "Stichwort eingegeben";
            // 
            // layoutForBtns
            // 
            layoutForBtns.Controls.Add(btnAdd);
            layoutForBtns.Controls.Add(btnRemove);
            layoutForBtns.Controls.Add(btnOk);
            layoutForBtns.Controls.Add(btnCancel);
            layoutForBtns.FlowDirection = FlowDirection.TopDown;
            layoutForBtns.Location = new Point(3, 3);
            layoutForBtns.Name = "layoutForBtns";
            layoutForBtns.Size = new Size(98, 120);
            layoutForBtns.TabIndex = 5;
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(3, 61);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(88, 23);
            btnOk.TabIndex = 4;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(3, 90);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(88, 23);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Abbrechen";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // layoutMain
            // 
            layoutMain.AutoSize = true;
            layoutMain.Controls.Add(layoutForBtns);
            layoutMain.Controls.Add(layoutForList);
            layoutMain.Location = new Point(12, 12);
            layoutMain.Name = "layoutMain";
            layoutMain.Size = new Size(437, 401);
            layoutMain.TabIndex = 6;
            // 
            // KeyWordsDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(461, 422);
            Controls.Add(layoutMain);
            Name = "KeyWordsDialog";
            Text = "WordFilterPanel";
            layoutForList.ResumeLayout(false);
            layoutForList.PerformLayout();
            layoutForBtns.ResumeLayout(false);
            layoutMain.ResumeLayout(false);
            layoutMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxKeywords;
        private TextBox textBoxKeyword;
        private Button btnAdd;
        private Button btnRemove;
        private FlowLayoutPanel layoutForList;
        private TextBox textBoxInsertKeyword;
        private FlowLayoutPanel layoutForBtns;
        private FlowLayoutPanel layoutMain;
        private Button btnOk;
        private Button btnCancel;
    }
}