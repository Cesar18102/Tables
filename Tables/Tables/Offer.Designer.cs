namespace Tables
{
    partial class Offer
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
            this.label1 = new System.Windows.Forms.Label();
            this.PeopleCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.DateSatrt = new System.Windows.Forms.DateTimePicker();
            this.Duration = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.TimeStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.Reserve = new System.Windows.Forms.Button();
            this.Offers = new System.Windows.Forms.DataGridView();
            this.RemoveReserve = new System.Windows.Forms.Button();
            this.IDDEL = new System.Windows.Forms.NumericUpDown();
            this.IDDELLabel = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.End = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.PeopleCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Duration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Offers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDDEL)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Кол-во человек:";
            // 
            // PeopleCount
            // 
            this.PeopleCount.Location = new System.Drawing.Point(183, 12);
            this.PeopleCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PeopleCount.Name = "PeopleCount";
            this.PeopleCount.Size = new System.Drawing.Size(151, 29);
            this.PeopleCount.TabIndex = 1;
            this.PeopleCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Дата: ";
            // 
            // DateSatrt
            // 
            this.DateSatrt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateSatrt.Location = new System.Drawing.Point(183, 47);
            this.DateSatrt.Name = "DateSatrt";
            this.DateSatrt.Size = new System.Drawing.Size(151, 29);
            this.DateSatrt.TabIndex = 3;
            // 
            // Duration
            // 
            this.Duration.DecimalPlaces = 2;
            this.Duration.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.Duration.Location = new System.Drawing.Point(183, 117);
            this.Duration.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.Duration.Name = "Duration";
            this.Duration.Size = new System.Drawing.Size(151, 29);
            this.Duration.TabIndex = 5;
            this.Duration.Value = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Длительность, ч:";
            // 
            // TimeStart
            // 
            this.TimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.TimeStart.Location = new System.Drawing.Point(183, 82);
            this.TimeStart.Name = "TimeStart";
            this.TimeStart.Size = new System.Drawing.Size(151, 29);
            this.TimeStart.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Время: ";
            // 
            // Reserve
            // 
            this.Reserve.Location = new System.Drawing.Point(12, 152);
            this.Reserve.Name = "Reserve";
            this.Reserve.Size = new System.Drawing.Size(322, 39);
            this.Reserve.TabIndex = 8;
            this.Reserve.Text = "Бронь";
            this.Reserve.UseVisualStyleBackColor = true;
            this.Reserve.Click += new System.EventHandler(this.Reserve_Click);
            // 
            // Offers
            // 
            this.Offers.AllowUserToAddRows = false;
            this.Offers.AllowUserToDeleteRows = false;
            this.Offers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Offers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.count,
            this.Start,
            this.End});
            this.Offers.Location = new System.Drawing.Point(340, 12);
            this.Offers.Name = "Offers";
            this.Offers.ReadOnly = true;
            this.Offers.RowHeadersVisible = false;
            this.Offers.Size = new System.Drawing.Size(466, 185);
            this.Offers.TabIndex = 9;
            // 
            // RemoveReserve
            // 
            this.RemoveReserve.Location = new System.Drawing.Point(816, 44);
            this.RemoveReserve.Name = "RemoveReserve";
            this.RemoveReserve.Size = new System.Drawing.Size(119, 153);
            this.RemoveReserve.TabIndex = 12;
            this.RemoveReserve.Text = "Снять бронь";
            this.RemoveReserve.UseVisualStyleBackColor = true;
            this.RemoveReserve.Click += new System.EventHandler(this.RemoveReserve_Click);
            // 
            // IDDEL
            // 
            this.IDDEL.Location = new System.Drawing.Point(851, 12);
            this.IDDEL.Name = "IDDEL";
            this.IDDEL.Size = new System.Drawing.Size(84, 29);
            this.IDDEL.TabIndex = 11;
            // 
            // IDDELLabel
            // 
            this.IDDELLabel.AutoSize = true;
            this.IDDELLabel.Location = new System.Drawing.Point(812, 14);
            this.IDDELLabel.Name = "IDDELLabel";
            this.IDDELLabel.Size = new System.Drawing.Size(32, 24);
            this.IDDELLabel.TabIndex = 10;
            this.IDDELLabel.Text = "ID:";
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 50;
            // 
            // count
            // 
            this.count.HeaderText = "Кол-во людей";
            this.count.Name = "count";
            this.count.ReadOnly = true;
            this.count.Width = 120;
            // 
            // Start
            // 
            this.Start.HeaderText = "Начало";
            this.Start.Name = "Start";
            this.Start.ReadOnly = true;
            this.Start.Width = 120;
            // 
            // End
            // 
            this.End.HeaderText = "Окончание";
            this.End.Name = "End";
            this.End.ReadOnly = true;
            this.End.Width = 120;
            // 
            // Offer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 209);
            this.Controls.Add(this.RemoveReserve);
            this.Controls.Add(this.IDDEL);
            this.Controls.Add(this.IDDELLabel);
            this.Controls.Add(this.Offers);
            this.Controls.Add(this.Reserve);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TimeStart);
            this.Controls.Add(this.Duration);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DateSatrt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PeopleCount);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Offer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Offer";
            this.Load += new System.EventHandler(this.Offer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PeopleCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Duration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Offers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IDDEL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown PeopleCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DateSatrt;
        private System.Windows.Forms.NumericUpDown Duration;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker TimeStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Reserve;
        private System.Windows.Forms.DataGridView Offers;
        private System.Windows.Forms.Button RemoveReserve;
        private System.Windows.Forms.NumericUpDown IDDEL;
        private System.Windows.Forms.Label IDDELLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Start;
        private System.Windows.Forms.DataGridViewTextBoxColumn End;
    }
}