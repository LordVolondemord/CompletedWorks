namespace qrCodeLebedev
{
    partial class mainQRCodeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components. Dispose ( );
            }
            base. Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxQRCode = new System.Windows.Forms.PictureBox();
            this.textBoxOriginalText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonRecognize = new System.Windows.Forms.Button();
            this.textBoxDefaultWidth = new System.Windows.Forms.TextBox();
            this.textBoxDefaultHeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxQRCode
            // 
            this.pictureBoxQRCode.Location = new System.Drawing.Point(20, 12);
            this.pictureBoxQRCode.Name = "pictureBoxQRCode";
            this.pictureBoxQRCode.Size = new System.Drawing.Size(209, 173);
            this.pictureBoxQRCode.TabIndex = 0;
            this.pictureBoxQRCode.TabStop = false;
            // 
            // textBoxOriginalText
            // 
            this.textBoxOriginalText.Location = new System.Drawing.Point(20, 221);
            this.textBoxOriginalText.Name = "textBoxOriginalText";
            this.textBoxOriginalText.Size = new System.Drawing.Size(209, 20);
            this.textBoxOriginalText.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Введите текст";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(20, 284);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(209, 23);
            this.buttonCreate.TabIndex = 3;
            this.buttonCreate.Text = "Создать QR код";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(20, 313);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(209, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Сохранить QR код";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(20, 342);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(209, 23);
            this.buttonLoad.TabIndex = 5;
            this.buttonLoad.Text = "Загрузить QR код";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonRecognize
            // 
            this.buttonRecognize.Location = new System.Drawing.Point(20, 371);
            this.buttonRecognize.Name = "buttonRecognize";
            this.buttonRecognize.Size = new System.Drawing.Size(209, 23);
            this.buttonRecognize.TabIndex = 6;
            this.buttonRecognize.Text = "Распознать QR код";
            this.buttonRecognize.UseVisualStyleBackColor = true;
            this.buttonRecognize.Click += new System.EventHandler(this.buttonRecognize_Click);
            // 
            // textBoxDefaultWidth
            // 
            this.textBoxDefaultWidth.Location = new System.Drawing.Point(20, 445);
            this.textBoxDefaultWidth.Name = "textBoxDefaultWidth";
            this.textBoxDefaultWidth.Size = new System.Drawing.Size(44, 20);
            this.textBoxDefaultWidth.TabIndex = 7;
            this.textBoxDefaultWidth.Leave += new System.EventHandler(this.textBoxDefaultWidth_Leave);
            // 
            // textBoxDefaultHeight
            // 
            this.textBoxDefaultHeight.Location = new System.Drawing.Point(84, 445);
            this.textBoxDefaultHeight.Name = "textBoxDefaultHeight";
            this.textBoxDefaultHeight.Size = new System.Drawing.Size(43, 20);
            this.textBoxDefaultHeight.TabIndex = 8;
            this.textBoxDefaultHeight.Leave += new System.EventHandler(this.textBoxDefaultHeight_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 426);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Ширина";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 426);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Высота";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 413);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Размер изображения для печати (в пикселях)";
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(20, 472);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(209, 23);
            this.buttonPrint.TabIndex = 12;
            this.buttonPrint.Text = "Распечатать QR код";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(20, 247);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(209, 31);
            this.buttonClear.TabIndex = 13;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // mainQRCodeForm
            // 
            this.ClientSize = new System.Drawing.Size(252, 508);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxDefaultHeight);
            this.Controls.Add(this.textBoxDefaultWidth);
            this.Controls.Add(this.buttonRecognize);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxOriginalText);
            this.Controls.Add(this.pictureBoxQRCode);
            this.Name = "mainQRCodeForm";
            this.Load += new System.EventHandler(this.mainQRCodeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQRCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System. Windows. Forms. PictureBox pictureBoxQRCode;
        private System. Windows. Forms. TextBox textBoxOriginalText;
        private System. Windows. Forms. Label label1;
        private System. Windows. Forms. Button buttonCreate;
        private System. Windows. Forms. Button buttonSave;
        private System. Windows. Forms. Button buttonLoad;
        private System. Windows. Forms. Button buttonRecognize;
        private System. Windows. Forms. TextBox textBoxDefaultWidth;
        private System. Windows. Forms. TextBox textBoxDefaultHeight;
        private System. Windows. Forms. Label label2;
        private System. Windows. Forms. Label label3;
        private System. Windows. Forms. Label label4;
        private System. Windows. Forms. Button buttonPrint;
        private System. Windows. Forms. Button buttonClear;
    }
}