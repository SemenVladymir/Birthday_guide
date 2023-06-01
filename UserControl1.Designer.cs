namespace Birthday_guide
{
    partial class UserControl1
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lName = new System.Windows.Forms.Label();
            this.lMonth = new System.Windows.Forms.Label();
            this.lBirthday = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(30, 14);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(44, 16);
            this.lName.TabIndex = 0;
            this.lName.Text = "Name";
            // 
            // lMonth
            // 
            this.lMonth.AutoSize = true;
            this.lMonth.Location = new System.Drawing.Point(259, 14);
            this.lMonth.Name = "lMonth";
            this.lMonth.Size = new System.Drawing.Size(43, 16);
            this.lMonth.TabIndex = 1;
            this.lMonth.Text = "Month";
            this.lMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lBirthday
            // 
            this.lBirthday.AutoSize = true;
            this.lBirthday.Location = new System.Drawing.Point(453, 14);
            this.lBirthday.Name = "lBirthday";
            this.lBirthday.Size = new System.Drawing.Size(56, 16);
            this.lBirthday.TabIndex = 2;
            this.lBirthday.Text = "Birthday";
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lBirthday);
            this.Controls.Add(this.lMonth);
            this.Controls.Add(this.lName);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(766, 53);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       





        #endregion

        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lMonth;
        private System.Windows.Forms.Label lBirthday;
    }
}
