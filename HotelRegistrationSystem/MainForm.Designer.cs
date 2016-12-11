namespace HotelRegistrationSystem
{
    partial class MainForm
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
            this.roomTypeComboBox = new System.Windows.Forms.ComboBox();
            this.loadListButton = new System.Windows.Forms.Button();
            this.hotelEntriesGridView = new System.Windows.Forms.DataGridView();
            this.searchDateFromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.searchDateToDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startDateLabel = new System.Windows.Forms.Label();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.roomTypeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.hotelEntriesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // roomTypeComboBox
            // 
            this.roomTypeComboBox.FormattingEnabled = true;
            this.roomTypeComboBox.Location = new System.Drawing.Point(143, 115);
            this.roomTypeComboBox.Name = "roomTypeComboBox";
            this.roomTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.roomTypeComboBox.TabIndex = 1;
            this.roomTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.roomTypeComboBox_SelectedIndexChanged);
            // 
            // loadListButton
            // 
            this.loadListButton.Location = new System.Drawing.Point(45, 157);
            this.loadListButton.Name = "loadListButton";
            this.loadListButton.Size = new System.Drawing.Size(264, 38);
            this.loadListButton.TabIndex = 2;
            this.loadListButton.Text = "Зареди списък";
            this.loadListButton.UseVisualStyleBackColor = true;
            this.loadListButton.Click += new System.EventHandler(this.loadListButton_Click);
            // 
            // hotelEntriesGridView
            // 
            this.hotelEntriesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hotelEntriesGridView.Location = new System.Drawing.Point(328, 33);
            this.hotelEntriesGridView.Name = "hotelEntriesGridView";
            this.hotelEntriesGridView.ReadOnly = true;
            this.hotelEntriesGridView.Size = new System.Drawing.Size(233, 288);
            this.hotelEntriesGridView.TabIndex = 4;
            this.hotelEntriesGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.hotelEntriesGridView_RowHeaderMouseClick);
            // 
            // searchDateFromDateTimePicker
            // 
            this.searchDateFromDateTimePicker.CustomFormat = "yyyy-MM-dd";
            this.searchDateFromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.searchDateFromDateTimePicker.Location = new System.Drawing.Point(167, 33);
            this.searchDateFromDateTimePicker.Name = "searchDateFromDateTimePicker";
            this.searchDateFromDateTimePicker.Size = new System.Drawing.Size(97, 20);
            this.searchDateFromDateTimePicker.TabIndex = 5;
            // 
            // searchDateToDateTimePicker
            // 
            this.searchDateToDateTimePicker.CustomFormat = "yyyy-MM-dd";
            this.searchDateToDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.searchDateToDateTimePicker.Location = new System.Drawing.Point(167, 80);
            this.searchDateToDateTimePicker.Name = "searchDateToDateTimePicker";
            this.searchDateToDateTimePicker.Size = new System.Drawing.Size(97, 20);
            this.searchDateToDateTimePicker.TabIndex = 6;
            // 
            // startDateLabel
            // 
            this.startDateLabel.AutoSize = true;
            this.startDateLabel.Location = new System.Drawing.Point(72, 33);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Size = new System.Drawing.Size(79, 13);
            this.startDateLabel.TabIndex = 7;
            this.startDateLabel.Text = "Начална дата:";
            // 
            // endDateLabel
            // 
            this.endDateLabel.AutoSize = true;
            this.endDateLabel.Location = new System.Drawing.Point(72, 80);
            this.endDateLabel.Name = "endDateLabel";
            this.endDateLabel.Size = new System.Drawing.Size(73, 13);
            this.endDateLabel.TabIndex = 8;
            this.endDateLabel.Text = "Крайна дата:";
            // 
            // roomTypeLabel
            // 
            this.roomTypeLabel.AutoSize = true;
            this.roomTypeLabel.Location = new System.Drawing.Point(72, 115);
            this.roomTypeLabel.Name = "roomTypeLabel";
            this.roomTypeLabel.Size = new System.Drawing.Size(55, 13);
            this.roomTypeLabel.TabIndex = 9;
            this.roomTypeLabel.Text = "Тип стая:";
            // 
            // MainForm
            // 
            this.AcceptButton = this.loadListButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 347);
            this.Controls.Add(this.roomTypeLabel);
            this.Controls.Add(this.endDateLabel);
            this.Controls.Add(this.startDateLabel);
            this.Controls.Add(this.searchDateToDateTimePicker);
            this.Controls.Add(this.searchDateFromDateTimePicker);
            this.Controls.Add(this.hotelEntriesGridView);
            this.Controls.Add(this.loadListButton);
            this.Controls.Add(this.roomTypeComboBox);
            this.Name = "MainForm";
            this.Text = "Справки";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hotelEntriesGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox roomTypeComboBox;
        private System.Windows.Forms.Button loadListButton;
        private System.Windows.Forms.DataGridView hotelEntriesGridView;
        private System.Windows.Forms.DateTimePicker searchDateFromDateTimePicker;
        private System.Windows.Forms.DateTimePicker searchDateToDateTimePicker;
        private System.Windows.Forms.Label startDateLabel;
        private System.Windows.Forms.Label endDateLabel;
        private System.Windows.Forms.Label roomTypeLabel;
    }
}