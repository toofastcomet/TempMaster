namespace TempMaster
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
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.alert1TextBox = new System.Windows.Forms.TextBox();
            this.alert2TextBox = new System.Windows.Forms.TextBox();
            this.alert1TimerCheckBox = new System.Windows.Forms.CheckBox();
            this.alert2TimerCheckBox = new System.Windows.Forms.CheckBox();
            this.timerBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.timer1label = new System.Windows.Forms.Label();
            this.timer2label = new System.Windows.Forms.Label();
            this.stopTimersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 150F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(931, 557);
            this.label1.TabIndex = 0;
            this.label1.Text = "78.5";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.TextChanged += new System.EventHandler(this.label1_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupToolStripMenuItem,
            this.stopTimersToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(931, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.setupToolStripMenuItem.Text = "Notification Setup";
            this.setupToolStripMenuItem.Click += new System.EventHandler(this.setupToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Alert 1 Temp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Alert 2 Temp";
            // 
            // alert1TextBox
            // 
            this.alert1TextBox.Location = new System.Drawing.Point(85, 40);
            this.alert1TextBox.Name = "alert1TextBox";
            this.alert1TextBox.Size = new System.Drawing.Size(77, 20);
            this.alert1TextBox.TabIndex = 4;
            this.alert1TextBox.Validating += new System.ComponentModel.CancelEventHandler(this.alert1TextBox_Validating);
            // 
            // alert2TextBox
            // 
            this.alert2TextBox.Location = new System.Drawing.Point(85, 72);
            this.alert2TextBox.Name = "alert2TextBox";
            this.alert2TextBox.Size = new System.Drawing.Size(77, 20);
            this.alert2TextBox.TabIndex = 5;
            this.alert2TextBox.Validating += new System.ComponentModel.CancelEventHandler(this.alert2TextBox_Validating);
            // 
            // alert1TimerCheckBox
            // 
            this.alert1TimerCheckBox.AutoSize = true;
            this.alert1TimerCheckBox.ForeColor = System.Drawing.Color.White;
            this.alert1TimerCheckBox.Location = new System.Drawing.Point(168, 42);
            this.alert1TimerCheckBox.Name = "alert1TimerCheckBox";
            this.alert1TimerCheckBox.Size = new System.Drawing.Size(77, 17);
            this.alert1TimerCheckBox.TabIndex = 6;
            this.alert1TimerCheckBox.Text = "Start Timer";
            this.alert1TimerCheckBox.UseVisualStyleBackColor = true;
            // 
            // alert2TimerCheckBox
            // 
            this.alert2TimerCheckBox.AutoSize = true;
            this.alert2TimerCheckBox.ForeColor = System.Drawing.Color.White;
            this.alert2TimerCheckBox.Location = new System.Drawing.Point(168, 74);
            this.alert2TimerCheckBox.Name = "alert2TimerCheckBox";
            this.alert2TimerCheckBox.Size = new System.Drawing.Size(77, 17);
            this.alert2TimerCheckBox.TabIndex = 7;
            this.alert2TimerCheckBox.Text = "Start Timer";
            this.alert2TimerCheckBox.UseVisualStyleBackColor = true;
            // 
            // timer1label
            // 
            this.timer1label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.timer1label.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timer1label.ForeColor = System.Drawing.Color.White;
            this.timer1label.Location = new System.Drawing.Point(12, 533);
            this.timer1label.Name = "timer1label";
            this.timer1label.Size = new System.Drawing.Size(151, 39);
            this.timer1label.TabIndex = 8;
            this.timer1label.Text = "00:00:00";
            this.timer1label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer2label
            // 
            this.timer2label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.timer2label.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timer2label.ForeColor = System.Drawing.Color.White;
            this.timer2label.Location = new System.Drawing.Point(768, 528);
            this.timer2label.Name = "timer2label";
            this.timer2label.Size = new System.Drawing.Size(151, 44);
            this.timer2label.TabIndex = 9;
            this.timer2label.Text = "00:00:00";
            this.timer2label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stopTimersToolStripMenuItem
            // 
            this.stopTimersToolStripMenuItem.Name = "stopTimersToolStripMenuItem";
            this.stopTimersToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.stopTimersToolStripMenuItem.Text = "Stop Timers";
            this.stopTimersToolStripMenuItem.Click += new System.EventHandler(this.stopTimersToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(931, 581);
            this.Controls.Add(this.timer2label);
            this.Controls.Add(this.timer1label);
            this.Controls.Add(this.alert2TimerCheckBox);
            this.Controls.Add(this.alert1TimerCheckBox);
            this.Controls.Add(this.alert2TextBox);
            this.Controls.Add(this.alert1TextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "TempMaster";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox alert1TextBox;
        private System.Windows.Forms.TextBox alert2TextBox;
        private System.Windows.Forms.CheckBox alert1TimerCheckBox;
        private System.Windows.Forms.CheckBox alert2TimerCheckBox;
        private System.ComponentModel.BackgroundWorker timerBackgroundWorker;
        private System.Windows.Forms.Label timer1label;
        private System.Windows.Forms.Label timer2label;
        private System.Windows.Forms.ToolStripMenuItem stopTimersToolStripMenuItem;
    }
}

