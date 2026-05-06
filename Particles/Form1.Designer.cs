namespace Particles
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
            this.components = new System.ComponentModel.Container();
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbDirection = new System.Windows.Forms.TrackBar();
            this.lblDirection = new System.Windows.Forms.Label();
            this.tbSpreading = new System.Windows.Forms.TrackBar();
            this.lblSpreading = new System.Windows.Forms.Label();
            this.tbGraviton1 = new System.Windows.Forms.TrackBar();
            this.tbGraviton2 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.CountPointLabel = new System.Windows.Forms.Label();
            this.tbCountPoint = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpreading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCountPoint)).BeginInit();
            this.SuspendLayout();
            // 
            // picDisplay
            // 
            this.picDisplay.Location = new System.Drawing.Point(12, 12);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(806, 447);
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            this.picDisplay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseClick);
            this.picDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbDirection
            // 
            this.tbDirection.Location = new System.Drawing.Point(12, 471);
            this.tbDirection.Maximum = 359;
            this.tbDirection.Name = "tbDirection";
            this.tbDirection.Size = new System.Drawing.Size(291, 56);
            this.tbDirection.TabIndex = 1;
            this.tbDirection.Scroll += new System.EventHandler(this.tbDirection_Scroll);
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.Location = new System.Drawing.Point(324, 471);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(0, 16);
            this.lblDirection.TabIndex = 3;
            // 
            // tbSpreading
            // 
            this.tbSpreading.Location = new System.Drawing.Point(366, 471);
            this.tbSpreading.Maximum = 359;
            this.tbSpreading.Name = "tbSpreading";
            this.tbSpreading.Size = new System.Drawing.Size(311, 56);
            this.tbSpreading.TabIndex = 4;
            this.tbSpreading.Scroll += new System.EventHandler(this.tbSpreading_Scroll);
            // 
            // lblSpreading
            // 
            this.lblSpreading.AutoSize = true;
            this.lblSpreading.Location = new System.Drawing.Point(684, 466);
            this.lblSpreading.Name = "lblSpreading";
            this.lblSpreading.Size = new System.Drawing.Size(0, 16);
            this.lblSpreading.TabIndex = 5;
            // 
            // tbGraviton1
            // 
            this.tbGraviton1.Location = new System.Drawing.Point(12, 533);
            this.tbGraviton1.Maximum = 100;
            this.tbGraviton1.Name = "tbGraviton1";
            this.tbGraviton1.Size = new System.Drawing.Size(291, 56);
            this.tbGraviton1.TabIndex = 6;
            this.tbGraviton1.Scroll += new System.EventHandler(this.tbGraviton_Scroll);
            // 
            // tbGraviton2
            // 
            this.tbGraviton2.Location = new System.Drawing.Point(366, 533);
            this.tbGraviton2.Maximum = 100;
            this.tbGraviton2.Name = "tbGraviton2";
            this.tbGraviton2.Size = new System.Drawing.Size(311, 56);
            this.tbGraviton2.TabIndex = 7;
            this.tbGraviton2.Scroll += new System.EventHandler(this.tbGraviton2_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(706, 481);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Кол-во частиц";
            // 
            // CountPointLabel
            // 
            this.CountPointLabel.AutoSize = true;
            this.CountPointLabel.Location = new System.Drawing.Point(706, 511);
            this.CountPointLabel.Name = "CountPointLabel";
            this.CountPointLabel.Size = new System.Drawing.Size(0, 16);
            this.CountPointLabel.TabIndex = 9;
            // 
            // tbCountPoint
            // 
            this.tbCountPoint.Location = new System.Drawing.Point(702, 555);
            this.tbCountPoint.Maximum = 1000;
            this.tbCountPoint.Name = "tbCountPoint";
            this.tbCountPoint.Size = new System.Drawing.Size(104, 56);
            this.tbCountPoint.TabIndex = 10;
            this.tbCountPoint.Scroll += new System.EventHandler(this.tbCountPoint_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 623);
            this.Controls.Add(this.tbCountPoint);
            this.Controls.Add(this.CountPointLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbGraviton2);
            this.Controls.Add(this.tbGraviton1);
            this.Controls.Add(this.lblSpreading);
            this.Controls.Add(this.tbSpreading);
            this.Controls.Add(this.lblDirection);
            this.Controls.Add(this.tbDirection);
            this.Controls.Add(this.picDisplay);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpreading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCountPoint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar tbDirection;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.TrackBar tbSpreading;
        private System.Windows.Forms.Label lblSpreading;
        private System.Windows.Forms.TrackBar tbGraviton1;
        private System.Windows.Forms.TrackBar tbGraviton2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CountPointLabel;
        private System.Windows.Forms.TrackBar tbCountPoint;
    }
}

