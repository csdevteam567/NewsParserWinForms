namespace NewsParserWinForms
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.startParserBtn = new System.Windows.Forms.Button();
            this.stopParserBtn = new System.Windows.Forms.Button();
            this.parserInfoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startParserBtn
            // 
            this.startParserBtn.Location = new System.Drawing.Point(13, 13);
            this.startParserBtn.Name = "startParserBtn";
            this.startParserBtn.Size = new System.Drawing.Size(91, 22);
            this.startParserBtn.TabIndex = 1;
            this.startParserBtn.Text = "Start parser";
            this.startParserBtn.UseVisualStyleBackColor = true;
            this.startParserBtn.Click += new System.EventHandler(this.startParserBtn_Click);
            // 
            // stopParserBtn
            // 
            this.stopParserBtn.Location = new System.Drawing.Point(13, 42);
            this.stopParserBtn.Name = "stopParserBtn";
            this.stopParserBtn.Size = new System.Drawing.Size(91, 22);
            this.stopParserBtn.TabIndex = 2;
            this.stopParserBtn.Text = "Stop parser";
            this.stopParserBtn.UseVisualStyleBackColor = true;
            this.stopParserBtn.Click += new System.EventHandler(this.stopParserBtn_Click);
            // 
            // parserInfoLabel
            // 
            this.parserInfoLabel.AutoSize = true;
            this.parserInfoLabel.Location = new System.Drawing.Point(120, 21);
            this.parserInfoLabel.Name = "parserInfoLabel";
            this.parserInfoLabel.Size = new System.Drawing.Size(0, 13);
            this.parserInfoLabel.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 387);
            this.Controls.Add(this.parserInfoLabel);
            this.Controls.Add(this.stopParserBtn);
            this.Controls.Add(this.startParserBtn);
            this.Name = "MainForm";
            this.Text = "Parser form";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button startParserBtn;
        private System.Windows.Forms.Button stopParserBtn;
        private System.Windows.Forms.Label parserInfoLabel;
    }
}

