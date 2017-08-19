namespace postalCode {
    partial class MainWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
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
        private void InitializeComponent() {
            this.FirstNumber = new System.Windows.Forms.DataGridView();
            this.SecondNumber = new System.Windows.Forms.DataGridView();
            this.ThirdNumber = new System.Windows.Forms.DataGridView();
            this.FourthNumber = new System.Windows.Forms.DataGridView();
            this.FifthNumber = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FirstNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecondNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThirdNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FourthNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FifthNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // FirstNumber
            // 
            this.FirstNumber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FirstNumber.Location = new System.Drawing.Point(38, 44);
            this.FirstNumber.Name = "FirstNumber";
            this.FirstNumber.Size = new System.Drawing.Size(139, 159);
            this.FirstNumber.TabIndex = 0;
            // 
            // SecondNumber
            // 
            this.SecondNumber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SecondNumber.Location = new System.Drawing.Point(211, 44);
            this.SecondNumber.Name = "SecondNumber";
            this.SecondNumber.Size = new System.Drawing.Size(139, 159);
            this.SecondNumber.TabIndex = 1;
            // 
            // ThirdNumber
            // 
            this.ThirdNumber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ThirdNumber.Location = new System.Drawing.Point(449, 44);
            this.ThirdNumber.Name = "ThirdNumber";
            this.ThirdNumber.Size = new System.Drawing.Size(139, 159);
            this.ThirdNumber.TabIndex = 2;
            // 
            // FourthNumber
            // 
            this.FourthNumber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FourthNumber.Location = new System.Drawing.Point(616, 44);
            this.FourthNumber.Name = "FourthNumber";
            this.FourthNumber.Size = new System.Drawing.Size(139, 159);
            this.FourthNumber.TabIndex = 3;
            // 
            // FifthNumber
            // 
            this.FifthNumber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FifthNumber.Location = new System.Drawing.Point(783, 44);
            this.FifthNumber.Name = "FifthNumber";
            this.FifthNumber.Size = new System.Drawing.Size(139, 159);
            this.FifthNumber.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(379, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 55);
            this.label1.TabIndex = 5;
            this.label1.Text = "-";
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(713, 273);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(209, 52);
            this.confirmButton.TabIndex = 6;
            this.confirmButton.Text = "OK";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 354);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FifthNumber);
            this.Controls.Add(this.FourthNumber);
            this.Controls.Add(this.ThirdNumber);
            this.Controls.Add(this.SecondNumber);
            this.Controls.Add(this.FirstNumber);
            this.Name = "MainWindow";
            this.Text = "Postal Code";
            ((System.ComponentModel.ISupportInitialize)(this.FirstNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecondNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThirdNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FourthNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FifthNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView FirstNumber;
        private System.Windows.Forms.DataGridView SecondNumber;
        private System.Windows.Forms.DataGridView ThirdNumber;
        private System.Windows.Forms.DataGridView FourthNumber;
        private System.Windows.Forms.DataGridView FifthNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button confirmButton;
    }
}

