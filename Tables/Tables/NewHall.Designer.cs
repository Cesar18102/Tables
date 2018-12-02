namespace Tables
{
    partial class NewHall
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
            this.HallTable = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HallName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HallWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HallLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.HallLengthInput = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.HallWidthInput = new System.Windows.Forms.NumericUpDown();
            this.AddHall = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.HallNameInput = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.IDDelete = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.DeleteHall = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.HallTable)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HallLengthInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HallWidthInput)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IDDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // HallTable
            // 
            this.HallTable.AllowUserToAddRows = false;
            this.HallTable.AllowUserToDeleteRows = false;
            this.HallTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HallTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.HallName,
            this.HallWidth,
            this.HallLength});
            this.HallTable.Location = new System.Drawing.Point(356, 12);
            this.HallTable.Name = "HallTable";
            this.HallTable.ReadOnly = true;
            this.HallTable.RowHeadersVisible = false;
            this.HallTable.Size = new System.Drawing.Size(404, 294);
            this.HallTable.TabIndex = 9;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // HallName
            // 
            this.HallName.HeaderText = "Название";
            this.HallName.Name = "HallName";
            this.HallName.ReadOnly = true;
            // 
            // HallWidth
            // 
            this.HallWidth.HeaderText = "Ширина";
            this.HallWidth.Name = "HallWidth";
            this.HallWidth.ReadOnly = true;
            // 
            // HallLength
            // 
            this.HallLength.HeaderText = "Длина";
            this.HallLength.Name = "HallLength";
            this.HallLength.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.HallLengthInput);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.HallWidthInput);
            this.panel1.Controls.Add(this.AddHall);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.HallNameInput);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(337, 176);
            this.panel1.TabIndex = 10;
            // 
            // HallLengthInput
            // 
            this.HallLengthInput.Location = new System.Drawing.Point(131, 74);
            this.HallLengthInput.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.HallLengthInput.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.HallLengthInput.Name = "HallLengthInput";
            this.HallLengthInput.Size = new System.Drawing.Size(201, 29);
            this.HallLengthInput.TabIndex = 24;
            this.HallLengthInput.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 24);
            this.label1.TabIndex = 19;
            this.label1.Text = "Название:";
            // 
            // HallWidthInput
            // 
            this.HallWidthInput.Location = new System.Drawing.Point(131, 39);
            this.HallWidthInput.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.HallWidthInput.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.HallWidthInput.Name = "HallWidthInput";
            this.HallWidthInput.Size = new System.Drawing.Size(201, 29);
            this.HallWidthInput.TabIndex = 23;
            this.HallWidthInput.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // AddHall
            // 
            this.AddHall.Location = new System.Drawing.Point(8, 109);
            this.AddHall.Name = "AddHall";
            this.AddHall.Size = new System.Drawing.Size(324, 64);
            this.AddHall.TabIndex = 18;
            this.AddHall.Text = "Добавить зал";
            this.AddHall.UseVisualStyleBackColor = true;
            this.AddHall.Click += new System.EventHandler(this.AddHall_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 24);
            this.label3.TabIndex = 22;
            this.label3.Text = "Длина, см: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 24);
            this.label2.TabIndex = 20;
            this.label2.Text = "Ширина, см: ";
            // 
            // HallNameInput
            // 
            this.HallNameInput.Location = new System.Drawing.Point(131, 4);
            this.HallNameInput.MaxLength = 50;
            this.HallNameInput.Name = "HallNameInput";
            this.HallNameInput.Size = new System.Drawing.Size(201, 29);
            this.HallNameInput.TabIndex = 21;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DeleteHall);
            this.panel2.Controls.Add(this.IDDelete);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(13, 192);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(337, 114);
            this.panel2.TabIndex = 11;
            // 
            // IDDelete
            // 
            this.IDDelete.Location = new System.Drawing.Point(133, 3);
            this.IDDelete.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.IDDelete.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.IDDelete.Name = "IDDelete";
            this.IDDelete.Size = new System.Drawing.Size(201, 29);
            this.IDDelete.TabIndex = 25;
            this.IDDelete.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 24);
            this.label4.TabIndex = 24;
            this.label4.Text = "ID: ";
            // 
            // DeleteHall
            // 
            this.DeleteHall.Location = new System.Drawing.Point(8, 38);
            this.DeleteHall.Name = "DeleteHall";
            this.DeleteHall.Size = new System.Drawing.Size(324, 64);
            this.DeleteHall.TabIndex = 26;
            this.DeleteHall.Text = "Удалить зал";
            this.DeleteHall.UseVisualStyleBackColor = true;
            this.DeleteHall.Click += new System.EventHandler(this.DeleteHall_Click);
            // 
            // NewHall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 318);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.HallTable);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "NewHall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewHall";
            this.Load += new System.EventHandler(this.NewHall_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HallTable)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HallLengthInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HallWidthInput)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IDDelete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView HallTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn HallName;
        private System.Windows.Forms.DataGridViewTextBoxColumn HallWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn HallLength;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown HallLengthInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown HallWidthInput;
        private System.Windows.Forms.Button AddHall;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox HallNameInput;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button DeleteHall;
        private System.Windows.Forms.NumericUpDown IDDelete;
        private System.Windows.Forms.Label label4;
    }
}