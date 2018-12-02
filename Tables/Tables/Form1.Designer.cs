namespace Tables
{
    partial class Form1
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
            this.AddHall = new System.Windows.Forms.Button();
            this.EditHall = new System.Windows.Forms.Button();
            this.Halls = new System.Windows.Forms.ComboBox();
            this.AddOffer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddHall
            // 
            this.AddHall.Location = new System.Drawing.Point(12, 12);
            this.AddHall.Name = "AddHall";
            this.AddHall.Size = new System.Drawing.Size(297, 64);
            this.AddHall.TabIndex = 0;
            this.AddHall.Text = "Добавить/Удалить зал";
            this.AddHall.UseVisualStyleBackColor = true;
            this.AddHall.Click += new System.EventHandler(this.AddHall_Click);
            // 
            // EditHall
            // 
            this.EditHall.Location = new System.Drawing.Point(12, 154);
            this.EditHall.Name = "EditHall";
            this.EditHall.Size = new System.Drawing.Size(297, 64);
            this.EditHall.TabIndex = 1;
            this.EditHall.Text = "Редактировать зал";
            this.EditHall.UseVisualStyleBackColor = true;
            this.EditHall.Click += new System.EventHandler(this.EditHall_Click);
            // 
            // Halls
            // 
            this.Halls.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Halls.FormattingEnabled = true;
            this.Halls.IntegralHeight = false;
            this.Halls.ItemHeight = 24;
            this.Halls.Location = new System.Drawing.Point(12, 116);
            this.Halls.Name = "Halls";
            this.Halls.Size = new System.Drawing.Size(297, 32);
            this.Halls.TabIndex = 2;
            // 
            // AddOffer
            // 
            this.AddOffer.Location = new System.Drawing.Point(12, 224);
            this.AddOffer.Name = "AddOffer";
            this.AddOffer.Size = new System.Drawing.Size(297, 64);
            this.AddOffer.TabIndex = 3;
            this.AddOffer.Text = "Оформить заказ/бронь";
            this.AddOffer.UseVisualStyleBackColor = true;
            this.AddOffer.Click += new System.EventHandler(this.AddOffer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 296);
            this.Controls.Add(this.AddOffer);
            this.Controls.Add(this.Halls);
            this.Controls.Add(this.EditHall);
            this.Controls.Add(this.AddHall);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddHall;
        private System.Windows.Forms.Button EditHall;
        private System.Windows.Forms.ComboBox Halls;
        private System.Windows.Forms.Button AddOffer;
    }
}

