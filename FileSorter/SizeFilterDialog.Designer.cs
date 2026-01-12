namespace FileSorter
{
    partial class SizeFilterDialog
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
            comboBoxSizeFrom = new ComboBox();
            comboBoxSizeUntil = new ComboBox();
            checkBoxSizeFrom = new CheckBox();
            checkBoxSizeUntil = new CheckBox();
            textBoxSizeFrom = new TextBox();
            textBoxSizeUntil = new TextBox();
            btnOk = new Button();
            textBoxInsertSizeFrom = new TextBox();
            textBoxInsertSizeUntil = new TextBox();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // comboBoxSizeFrom
            // 
            comboBoxSizeFrom.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSizeFrom.FormattingEnabled = true;
            comboBoxSizeFrom.Location = new Point(144, 41);
            comboBoxSizeFrom.Name = "comboBoxSizeFrom";
            comboBoxSizeFrom.Size = new Size(93, 23);
            comboBoxSizeFrom.TabIndex = 0;
            // 
            // comboBoxSizeUntil
            // 
            comboBoxSizeUntil.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSizeUntil.FormattingEnabled = true;
            comboBoxSizeUntil.Location = new Point(144, 99);
            comboBoxSizeUntil.Name = "comboBoxSizeUntil";
            comboBoxSizeUntil.Size = new Size(93, 23);
            comboBoxSizeUntil.TabIndex = 1;
            // 
            // checkBoxSizeFrom
            // 
            checkBoxSizeFrom.AutoSize = true;
            checkBoxSizeFrom.Checked = true;
            checkBoxSizeFrom.CheckState = CheckState.Checked;
            checkBoxSizeFrom.Location = new Point(243, 43);
            checkBoxSizeFrom.Name = "checkBoxSizeFrom";
            checkBoxSizeFrom.Size = new Size(15, 14);
            checkBoxSizeFrom.TabIndex = 2;
            checkBoxSizeFrom.UseVisualStyleBackColor = true;
            checkBoxSizeFrom.CheckedChanged += checkBoxSizeFrom_CheckedChanged;
            // 
            // checkBoxSizeUntil
            // 
            checkBoxSizeUntil.AutoSize = true;
            checkBoxSizeUntil.Checked = true;
            checkBoxSizeUntil.CheckState = CheckState.Checked;
            checkBoxSizeUntil.Location = new Point(243, 101);
            checkBoxSizeUntil.Name = "checkBoxSizeUntil";
            checkBoxSizeUntil.Size = new Size(15, 14);
            checkBoxSizeUntil.TabIndex = 3;
            checkBoxSizeUntil.UseVisualStyleBackColor = true;
            checkBoxSizeUntil.CheckedChanged += checkBoxSizeUntil_CheckedChanged;
            // 
            // textBoxSizeFrom
            // 
            textBoxSizeFrom.Location = new Point(12, 41);
            textBoxSizeFrom.Name = "textBoxSizeFrom";
            textBoxSizeFrom.Size = new Size(126, 23);
            textBoxSizeFrom.TabIndex = 4;
            // 
            // textBoxSizeUntil
            // 
            textBoxSizeUntil.Location = new Point(12, 99);
            textBoxSizeUntil.Name = "textBoxSizeUntil";
            textBoxSizeUntil.Size = new Size(126, 23);
            textBoxSizeUntil.TabIndex = 5;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(12, 128);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(110, 23);
            btnOk.TabIndex = 6;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // textBoxInsertSizeFrom
            // 
            textBoxInsertSizeFrom.Enabled = false;
            textBoxInsertSizeFrom.Location = new Point(12, 12);
            textBoxInsertSizeFrom.Name = "textBoxInsertSizeFrom";
            textBoxInsertSizeFrom.Size = new Size(126, 23);
            textBoxInsertSizeFrom.TabIndex = 7;
            textBoxInsertSizeFrom.Text = "Größe von";
            // 
            // textBoxInsertSizeUntil
            // 
            textBoxInsertSizeUntil.Enabled = false;
            textBoxInsertSizeUntil.Location = new Point(12, 70);
            textBoxInsertSizeUntil.Name = "textBoxInsertSizeUntil";
            textBoxInsertSizeUntil.Size = new Size(126, 23);
            textBoxInsertSizeUntil.TabIndex = 8;
            textBoxInsertSizeUntil.Text = "Größe bis";
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(128, 128);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(109, 23);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Abbrechen";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // SizeFilterDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(280, 174);
            Controls.Add(btnCancel);
            Controls.Add(textBoxInsertSizeUntil);
            Controls.Add(textBoxInsertSizeFrom);
            Controls.Add(btnOk);
            Controls.Add(textBoxSizeUntil);
            Controls.Add(textBoxSizeFrom);
            Controls.Add(checkBoxSizeUntil);
            Controls.Add(checkBoxSizeFrom);
            Controls.Add(comboBoxSizeUntil);
            Controls.Add(comboBoxSizeFrom);
            Name = "SizeFilterDialog";
            Text = "Dateigröße auswählen";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxSizeFrom;
        private ComboBox comboBoxSizeUntil;
        private CheckBox checkBoxSizeFrom;
        private CheckBox checkBoxSizeUntil;
        private TextBox textBoxSizeFrom;
        private TextBox textBoxSizeUntil;
        private Button btnOk;
        private TextBox textBoxInsertSizeFrom;
        private TextBox textBoxInsertSizeUntil;
        private Button btnCancel;
    }
}