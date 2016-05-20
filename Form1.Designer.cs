namespace DallasAdc {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            this.commandBox = new System.Windows.Forms.TextBox();
            this.bkgWorker = new System.ComponentModel.BackgroundWorker();
            this.cancelButton = new System.Windows.Forms.Button();
            this.dataBox = new System.Windows.Forms.TextBox();
            this.chipNumBox = new System.Windows.Forms.MaskedTextBox();
            this.chipNumLabel = new System.Windows.Forms.Label();
            this.signalBox = new System.Windows.Forms.PictureBox();
            this.resultBox = new System.Windows.Forms.TextBox();
            this.runButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.chipControl1 = new DallasAdc.ChipControl();
            ((System.ComponentModel.ISupportInitialize)(this.signalBox)).BeginInit();
            this.SuspendLayout();
            // 
            // commandBox
            // 
            this.commandBox.Location = new System.Drawing.Point(605, 10);
            this.commandBox.Multiline = true;
            this.commandBox.Name = "commandBox";
            this.commandBox.ReadOnly = true;
            this.commandBox.Size = new System.Drawing.Size(385, 130);
            this.commandBox.TabIndex = 1;
            // 
            // bkgWorker
            // 
            this.bkgWorker.WorkerSupportsCancellation = true;
            this.bkgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkgWorker_DoWork);
            this.bkgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bkgWorker_RunWorkerCompleted);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(13, 114);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(70, 25);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // dataBox
            // 
            this.dataBox.Location = new System.Drawing.Point(10, 145);
            this.dataBox.Multiline = true;
            this.dataBox.Name = "dataBox";
            this.dataBox.ReadOnly = true;
            this.dataBox.Size = new System.Drawing.Size(280, 380);
            this.dataBox.TabIndex = 5;
            // 
            // chipNumBox
            // 
            this.chipNumBox.Location = new System.Drawing.Point(105, 10);
            this.chipNumBox.Name = "chipNumBox";
            this.chipNumBox.Size = new System.Drawing.Size(85, 22);
            this.chipNumBox.TabIndex = 7;
            this.chipNumBox.ValidatingType = typeof(int);
            this.chipNumBox.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.chipNumBox_TypeValidationCompleted);
            // 
            // chipNumLabel
            // 
            this.chipNumLabel.Font = new System.Drawing.Font("Consolas", 9F);
            this.chipNumLabel.Location = new System.Drawing.Point(10, 10);
            this.chipNumLabel.Name = "chipNumLabel";
            this.chipNumLabel.Size = new System.Drawing.Size(90, 25);
            this.chipNumLabel.TabIndex = 8;
            this.chipNumLabel.Text = "Chip No:";
            this.chipNumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // signalBox
            // 
            this.signalBox.Location = new System.Drawing.Point(300, 145);
            this.signalBox.Name = "signalBox";
            this.signalBox.Size = new System.Drawing.Size(690, 595);
            this.signalBox.TabIndex = 9;
            this.signalBox.TabStop = false;
            // 
            // resultBox
            // 
            this.resultBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultBox.Location = new System.Drawing.Point(10, 530);
            this.resultBox.Multiline = true;
            this.resultBox.Name = "resultBox";
            this.resultBox.ReadOnly = true;
            this.resultBox.Size = new System.Drawing.Size(280, 210);
            this.resultBox.TabIndex = 10;
            // 
            // runButton
            // 
            this.runButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.runButton.Location = new System.Drawing.Point(10, 40);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(180, 70);
            this.runButton.TabIndex = 0;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(89, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 25);
            this.button1.TabIndex = 12;
            this.button1.Text = "Record Defect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chipControl1
            // 
            this.chipControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chipControl1.Location = new System.Drawing.Point(200, 10);
            this.chipControl1.Name = "chipControl1";
            this.chipControl1.pllControl = ((uint)(16u));
            this.chipControl1.refControl = ((uint)(0u));
            this.chipControl1.Size = new System.Drawing.Size(400, 135);
            this.chipControl1.slvsControl = ((uint)(0u));
            this.chipControl1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 750);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.signalBox);
            this.Controls.Add(this.chipNumLabel);
            this.Controls.Add(this.chipNumBox);
            this.Controls.Add(this.dataBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.chipControl1);
            this.Controls.Add(this.commandBox);
            this.Controls.Add(this.runButton);
            this.Font = new System.Drawing.Font("Consolas", 9F);
            this.Name = "Form1";
            this.Text = "DallasAdc Test Interface";
            ((System.ComponentModel.ISupportInitialize)(this.signalBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox commandBox;
        private System.ComponentModel.BackgroundWorker bkgWorker;
        private ChipControl chipControl1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox dataBox;
        private System.Windows.Forms.MaskedTextBox chipNumBox;
        private System.Windows.Forms.Label chipNumLabel;
        private System.Windows.Forms.PictureBox signalBox;
        private System.Windows.Forms.TextBox resultBox;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button button1;
    }
}

