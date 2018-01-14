namespace FinalCompiler
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.exitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.topContainer = new System.Windows.Forms.Panel();
            this.bottomContainer = new System.Windows.Forms.Panel();
            this.outputBox = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.openFileButton = new System.Windows.Forms.Button();
            this.saveFileButton = new System.Windows.Forms.Button();
            this.newFileButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.compileButton = new System.Windows.Forms.Button();
            this.codeBox = new System.Windows.Forms.TextBox();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.topContainer.SuspendLayout();
            this.bottomContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.MaximumSize = new System.Drawing.Size(0, 49);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(383, 49);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.exitButton);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(286, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(97, 49);
            this.panel5.TabIndex = 5;
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.exitButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exitButton.BackgroundImage")));
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Location = new System.Drawing.Point(57, 0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(40, 40);
            this.exitButton.TabIndex = 4;
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Компилятор";
            // 
            // topContainer
            // 
            this.topContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topContainer.Controls.Add(this.panel4);
            this.topContainer.Controls.Add(this.codeBox);
            this.topContainer.Location = new System.Drawing.Point(0, 0);
            this.topContainer.Name = "topContainer";
            this.topContainer.Size = new System.Drawing.Size(383, 302);
            this.topContainer.TabIndex = 2;
            // 
            // bottomContainer
            // 
            this.bottomContainer.Controls.Add(this.outputBox);
            this.bottomContainer.Controls.Add(this.panel1);
            this.bottomContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomContainer.Location = new System.Drawing.Point(0, 303);
            this.bottomContainer.Name = "bottomContainer";
            this.bottomContainer.Size = new System.Drawing.Size(383, 196);
            this.bottomContainer.TabIndex = 3;
            // 
            // outputBox
            // 
            this.outputBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.outputBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.outputBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outputBox.ForeColor = System.Drawing.Color.White;
            this.outputBox.Location = new System.Drawing.Point(0, 56);
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(383, 140);
            this.outputBox.TabIndex = 3;
            this.outputBox.Text = "";
            this.outputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.outputBox_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.openFileButton);
            this.panel1.Controls.Add(this.saveFileButton);
            this.panel1.Controls.Add(this.newFileButton);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 56);
            this.panel1.TabIndex = 2;
            // 
            // openFileButton
            // 
            this.openFileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.openFileButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("openFileButton.BackgroundImage")));
            this.openFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.openFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.openFileButton.ForeColor = System.Drawing.Color.White;
            this.openFileButton.Location = new System.Drawing.Point(58, 5);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(40, 40);
            this.openFileButton.TabIndex = 2;
            this.openFileButton.UseVisualStyleBackColor = false;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // saveFileButton
            // 
            this.saveFileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.saveFileButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("saveFileButton.BackgroundImage")));
            this.saveFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.saveFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveFileButton.ForeColor = System.Drawing.Color.White;
            this.saveFileButton.Location = new System.Drawing.Point(104, 5);
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(40, 40);
            this.saveFileButton.TabIndex = 2;
            this.saveFileButton.UseVisualStyleBackColor = false;
            this.saveFileButton.Click += new System.EventHandler(this.saveFileButton_Click);
            // 
            // newFileButton
            // 
            this.newFileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.newFileButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("newFileButton.BackgroundImage")));
            this.newFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.newFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.newFileButton.ForeColor = System.Drawing.Color.White;
            this.newFileButton.Location = new System.Drawing.Point(12, 5);
            this.newFileButton.Name = "newFileButton";
            this.newFileButton.Size = new System.Drawing.Size(40, 40);
            this.newFileButton.TabIndex = 1;
            this.newFileButton.UseVisualStyleBackColor = false;
            this.newFileButton.Click += new System.EventHandler(this.newFileButton_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.compileButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(183, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 56);
            this.panel3.TabIndex = 0;
            // 
            // compileButton
            // 
            this.compileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.compileButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("compileButton.BackgroundImage")));
            this.compileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.compileButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.compileButton.ForeColor = System.Drawing.Color.White;
            this.compileButton.Location = new System.Drawing.Point(133, 5);
            this.compileButton.Name = "compileButton";
            this.compileButton.Size = new System.Drawing.Size(40, 40);
            this.compileButton.TabIndex = 0;
            this.compileButton.UseVisualStyleBackColor = false;
            this.compileButton.Click += new System.EventHandler(this.compileButton_Click);
            // 
            // codeBox
            // 
            this.codeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.codeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.codeBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codeBox.Font = new System.Drawing.Font("Courant", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeBox.ForeColor = System.Drawing.Color.White;
            this.codeBox.Location = new System.Drawing.Point(0, 46);
            this.codeBox.Multiline = true;
            this.codeBox.Name = "codeBox";
            this.codeBox.Size = new System.Drawing.Size(383, 251);
            this.codeBox.TabIndex = 1;
            this.codeBox.Text = "var\r\na, b :integer;\r\nbegin\r\na = 2;\r\nfor b = 0 to 2 do\r\na = a + 2;\r\nend_for;\r\nwrit" +
    "e(a);\r\nend";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(383, 499);
            this.ControlBox = false;
            this.Controls.Add(this.bottomContainer);
            this.Controls.Add(this.topContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compiler";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.topContainer.ResumeLayout(false);
            this.topContainer.PerformLayout();
            this.bottomContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel topContainer;
        private System.Windows.Forms.Panel bottomContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button compileButton;
        private System.Windows.Forms.RichTextBox outputBox;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Button saveFileButton;
        private System.Windows.Forms.Button newFileButton;
        private System.Windows.Forms.TextBox codeBox;
    }
}

