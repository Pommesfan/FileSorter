namespace FileSorter
{
    partial class DateFilterDialog
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
            dateFrom = new DateTimePicker();
            dateUntil = new DateTimePicker();
            layoutMain = new FlowLayoutPanel();
            layoutFrom = new FlowLayoutPanel();
            textBoxFrom = new TextBox();
            checkBoxFrom = new CheckBox();
            lautoutUntil = new FlowLayoutPanel();
            textBoxUntil = new TextBox();
            checkBoxUntil = new CheckBox();
            layoutOkCancel = new FlowLayoutPanel();
            btnOk = new Button();
            btnCancel = new Button();
            layoutMain.SuspendLayout();
            layoutFrom.SuspendLayout();
            lautoutUntil.SuspendLayout();
            layoutOkCancel.SuspendLayout();
            SuspendLayout();
            // 
            // dateFrom
            // 
            dateFrom.Location = new Point(3, 43);
            dateFrom.Name = "dateFrom";
            dateFrom.Size = new Size(223, 23);
            dateFrom.TabIndex = 0;
            dateFrom.ValueChanged += dateFrom_ValueChanged;
            // 
            // dateUntil
            // 
            dateUntil.Location = new Point(3, 112);
            dateUntil.Name = "dateUntil";
            dateUntil.Size = new Size(223, 23);
            dateUntil.TabIndex = 1;
            dateUntil.ValueChanged += dateUntil_ValueChanged;
            // 
            // layoutMain
            // 
            layoutMain.Controls.Add(layoutFrom);
            layoutMain.Controls.Add(dateFrom);
            layoutMain.Controls.Add(lautoutUntil);
            layoutMain.Controls.Add(dateUntil);
            layoutMain.Controls.Add(layoutOkCancel);
            layoutMain.Location = new Point(12, 12);
            layoutMain.Name = "layoutMain";
            layoutMain.Size = new Size(235, 191);
            layoutMain.TabIndex = 4;
            // 
            // layoutFrom
            // 
            layoutFrom.Controls.Add(textBoxFrom);
            layoutFrom.Controls.Add(checkBoxFrom);
            layoutFrom.Location = new Point(3, 3);
            layoutFrom.Name = "layoutFrom";
            layoutFrom.Size = new Size(220, 34);
            layoutFrom.TabIndex = 5;
            // 
            // textBoxFrom
            // 
            textBoxFrom.Enabled = false;
            textBoxFrom.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxFrom.Location = new Point(3, 3);
            textBoxFrom.Name = "textBoxFrom";
            textBoxFrom.Size = new Size(191, 29);
            textBoxFrom.TabIndex = 2;
            textBoxFrom.Text = "Von";
            // 
            // checkBoxFrom
            // 
            checkBoxFrom.AutoSize = true;
            checkBoxFrom.Checked = true;
            checkBoxFrom.CheckState = CheckState.Checked;
            checkBoxFrom.Location = new Point(200, 3);
            checkBoxFrom.Name = "checkBoxFrom";
            checkBoxFrom.Size = new Size(15, 14);
            checkBoxFrom.TabIndex = 7;
            checkBoxFrom.UseVisualStyleBackColor = true;
            checkBoxFrom.CheckedChanged += checkBoxFrom_CheckedChanged;
            // 
            // lautoutUntil
            // 
            lautoutUntil.Controls.Add(textBoxUntil);
            lautoutUntil.Controls.Add(checkBoxUntil);
            lautoutUntil.Location = new Point(3, 72);
            lautoutUntil.Name = "lautoutUntil";
            lautoutUntil.Size = new Size(220, 34);
            lautoutUntil.TabIndex = 6;
            // 
            // textBoxUntil
            // 
            textBoxUntil.Enabled = false;
            textBoxUntil.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxUntil.Location = new Point(3, 3);
            textBoxUntil.Name = "textBoxUntil";
            textBoxUntil.Size = new Size(191, 29);
            textBoxUntil.TabIndex = 3;
            textBoxUntil.Text = "Bis";
            // 
            // checkBoxUntil
            // 
            checkBoxUntil.AutoSize = true;
            checkBoxUntil.Checked = true;
            checkBoxUntil.CheckState = CheckState.Checked;
            checkBoxUntil.Location = new Point(200, 3);
            checkBoxUntil.Name = "checkBoxUntil";
            checkBoxUntil.Size = new Size(15, 14);
            checkBoxUntil.TabIndex = 6;
            checkBoxUntil.UseVisualStyleBackColor = true;
            checkBoxUntil.CheckedChanged += checkBoxUntil_CheckedChanged;
            // 
            // layoutOkCancel
            // 
            layoutOkCancel.Controls.Add(btnOk);
            layoutOkCancel.Controls.Add(btnCancel);
            layoutOkCancel.Location = new Point(3, 141);
            layoutOkCancel.Name = "layoutOkCancel";
            layoutOkCancel.Size = new Size(185, 28);
            layoutOkCancel.TabIndex = 5;
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(3, 3);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 0;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(84, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(98, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Abbrechen";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // DateFilterDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(261, 209);
            Controls.Add(layoutMain);
            Name = "DateFilterDialog";
            Text = "Datumsfilter";
            layoutMain.ResumeLayout(false);
            layoutFrom.ResumeLayout(false);
            layoutFrom.PerformLayout();
            lautoutUntil.ResumeLayout(false);
            lautoutUntil.PerformLayout();
            layoutOkCancel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dateFrom;
        private DateTimePicker dateUntil;
        private FlowLayoutPanel layoutMain;
        private FlowLayoutPanel layoutOkCancel;
        private Button btnOk;
        private Button btnCancel;
        private CheckBox checkBoxUntil;
        private CheckBox checkBoxFrom;
        private TextBox textBoxFrom;
        private TextBox textBoxUntil;
        private FlowLayoutPanel layoutFrom;
        private FlowLayoutPanel lautoutUntil;
    }
}