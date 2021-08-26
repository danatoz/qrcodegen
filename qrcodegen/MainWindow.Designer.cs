
namespace qrcodegen
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCreateQR = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbInputField = new System.Windows.Forms.TextBox();
            this.pbQRCodePic = new System.Windows.Forms.PictureBox();
            this.btnSaveQR = new System.Windows.Forms.Button();
            this.tbWay = new System.Windows.Forms.TextBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnPath = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCodePic)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreateQR
            // 
            this.btnCreateQR.Location = new System.Drawing.Point(12, 277);
            this.btnCreateQR.Name = "btnCreateQR";
            this.btnCreateQR.Size = new System.Drawing.Size(215, 23);
            this.btnCreateQR.TabIndex = 0;
            this.btnCreateQR.Text = "Создать QR Code";
            this.btnCreateQR.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите текст";
            // 
            // tbInputField
            // 
            this.tbInputField.Location = new System.Drawing.Point(12, 248);
            this.tbInputField.Name = "tbInputField";
            this.tbInputField.Size = new System.Drawing.Size(215, 23);
            this.tbInputField.TabIndex = 2;
            // 
            // pbQRCodePic
            // 
            this.pbQRCodePic.Location = new System.Drawing.Point(12, 12);
            this.pbQRCodePic.Name = "pbQRCodePic";
            this.pbQRCodePic.Size = new System.Drawing.Size(215, 215);
            this.pbQRCodePic.TabIndex = 3;
            this.pbQRCodePic.TabStop = false;
            // 
            // btnSaveQR
            // 
            this.btnSaveQR.Location = new System.Drawing.Point(12, 306);
            this.btnSaveQR.Name = "btnSaveQR";
            this.btnSaveQR.Size = new System.Drawing.Size(215, 23);
            this.btnSaveQR.TabIndex = 0;
            this.btnSaveQR.Text = "Сохранить QR Code";
            this.btnSaveQR.UseVisualStyleBackColor = true;
            // 
            // tbWay
            // 
            this.tbWay.Location = new System.Drawing.Point(12, 335);
            this.tbWay.Name = "tbWay";
            this.tbWay.Size = new System.Drawing.Size(180, 23);
            this.tbWay.TabIndex = 2;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(12, 364);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(215, 23);
            this.btnPreview.TabIndex = 0;
            this.btnPreview.Text = "Предпросмотор";
            this.btnPreview.UseVisualStyleBackColor = true;
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(199, 335);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(28, 23);
            this.btnPath.TabIndex = 0;
            this.btnPath.Text = "...";
            this.btnPath.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 399);
            this.Controls.Add(this.pbQRCodePic);
            this.Controls.Add(this.tbWay);
            this.Controls.Add(this.tbInputField);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPath);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnSaveQR);
            this.Controls.Add(this.btnCreateQR);
            this.Name = "MainWindow";
            this.Text = "Генератор QR кода";
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCodePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateQR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbInputField;
        private System.Windows.Forms.PictureBox pbQRCodePic;
        private System.Windows.Forms.Button btnSaveQR;
        private System.Windows.Forms.TextBox tbWay;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnPath;
    }
}

