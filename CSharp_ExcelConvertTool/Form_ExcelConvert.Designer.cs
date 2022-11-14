
namespace CSharp_ExcelConvertTool
{
    partial class Form_ExcelConvert
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ExcelConvert));
            this.button_SelectExcel = new System.Windows.Forms.Button();
            this.textBox_ExcelPath = new System.Windows.Forms.TextBox();
            this.label_ExcelPath = new System.Windows.Forms.Label();
            this.pictureBox_Excel = new System.Windows.Forms.PictureBox();
            this.label_DragPrompt2 = new System.Windows.Forms.Label();
            this.label_DragPrompt1 = new System.Windows.Forms.Label();
            this.listView_DragExcel = new System.Windows.Forms.ListView();
            this.comboBox_ConvertType = new System.Windows.Forms.ComboBox();
            this.label_ConvertType = new System.Windows.Forms.Label();
            this.button_SetSavePath = new System.Windows.Forms.Button();
            this.textBox_ConvertSavePath = new System.Windows.Forms.TextBox();
            this.label_ConvertSavePath = new System.Windows.Forms.Label();
            this.button_Convert = new System.Windows.Forms.Button();
            this.textBox_FileName = new System.Windows.Forms.TextBox();
            this.label_SaveFileName = new System.Windows.Forms.Label();
            this.button_OpenFolder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Excel)).BeginInit();
            this.SuspendLayout();
            // 
            // button_SelectExcel
            // 
            this.button_SelectExcel.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_SelectExcel.Location = new System.Drawing.Point(372, 296);
            this.button_SelectExcel.Name = "button_SelectExcel";
            this.button_SelectExcel.Size = new System.Drawing.Size(60, 30);
            this.button_SelectExcel.TabIndex = 37;
            this.button_SelectExcel.Text = "选择";
            this.button_SelectExcel.UseVisualStyleBackColor = true;
            this.button_SelectExcel.Click += new System.EventHandler(this.button_SelectExcel_Click);
            // 
            // textBox_ExcelPath
            // 
            this.textBox_ExcelPath.Location = new System.Drawing.Point(158, 300);
            this.textBox_ExcelPath.Name = "textBox_ExcelPath";
            this.textBox_ExcelPath.ReadOnly = true;
            this.textBox_ExcelPath.Size = new System.Drawing.Size(197, 21);
            this.textBox_ExcelPath.TabIndex = 36;
            // 
            // label_ExcelPath
            // 
            this.label_ExcelPath.AutoSize = true;
            this.label_ExcelPath.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_ExcelPath.Location = new System.Drawing.Point(45, 302);
            this.label_ExcelPath.Name = "label_ExcelPath";
            this.label_ExcelPath.Size = new System.Drawing.Size(112, 14);
            this.label_ExcelPath.TabIndex = 35;
            this.label_ExcelPath.Text = "Excel表格路径：";
            // 
            // pictureBox_Excel
            // 
            this.pictureBox_Excel.Enabled = false;
            this.pictureBox_Excel.ErrorImage = null;
            this.pictureBox_Excel.Image = global::CSharp_ExcelConvertTool.Properties.Resources.ExcelLogo;
            this.pictureBox_Excel.InitialImage = null;
            this.pictureBox_Excel.Location = new System.Drawing.Point(250, 37);
            this.pictureBox_Excel.Name = "pictureBox_Excel";
            this.pictureBox_Excel.Size = new System.Drawing.Size(180, 180);
            this.pictureBox_Excel.TabIndex = 46;
            this.pictureBox_Excel.TabStop = false;
            this.pictureBox_Excel.Visible = false;
            // 
            // label_DragPrompt2
            // 
            this.label_DragPrompt2.AutoSize = true;
            this.label_DragPrompt2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label_DragPrompt2.CausesValidation = false;
            this.label_DragPrompt2.Enabled = false;
            this.label_DragPrompt2.Font = new System.Drawing.Font("宋体", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_DragPrompt2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_DragPrompt2.Location = new System.Drawing.Point(273, 132);
            this.label_DragPrompt2.Name = "label_DragPrompt2";
            this.label_DragPrompt2.Size = new System.Drawing.Size(140, 47);
            this.label_DragPrompt2.TabIndex = 45;
            this.label_DragPrompt2.Text = "Excel";
            // 
            // label_DragPrompt1
            // 
            this.label_DragPrompt1.AutoSize = true;
            this.label_DragPrompt1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label_DragPrompt1.CausesValidation = false;
            this.label_DragPrompt1.Enabled = false;
            this.label_DragPrompt1.Font = new System.Drawing.Font("宋体", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_DragPrompt1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_DragPrompt1.Location = new System.Drawing.Point(281, 74);
            this.label_DragPrompt1.Name = "label_DragPrompt1";
            this.label_DragPrompt1.Size = new System.Drawing.Size(114, 47);
            this.label_DragPrompt1.TabIndex = 44;
            this.label_DragPrompt1.Text = "拖拽";
            // 
            // listView_DragExcel
            // 
            this.listView_DragExcel.AllowDrop = true;
            this.listView_DragExcel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.listView_DragExcel.HideSelection = false;
            this.listView_DragExcel.Location = new System.Drawing.Point(240, 27);
            this.listView_DragExcel.Name = "listView_DragExcel";
            this.listView_DragExcel.Size = new System.Drawing.Size(200, 200);
            this.listView_DragExcel.TabIndex = 43;
            this.listView_DragExcel.UseCompatibleStateImageBehavior = false;
            this.listView_DragExcel.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragExcel_DragDrop);
            this.listView_DragExcel.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_DragExcel_DragEnter);
            // 
            // comboBox_ConvertType
            // 
            this.comboBox_ConvertType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ConvertType.FormattingEnabled = true;
            this.comboBox_ConvertType.Location = new System.Drawing.Point(115, 74);
            this.comboBox_ConvertType.Name = "comboBox_ConvertType";
            this.comboBox_ConvertType.Size = new System.Drawing.Size(100, 20);
            this.comboBox_ConvertType.TabIndex = 48;
            this.comboBox_ConvertType.SelectedIndexChanged += new System.EventHandler(this.comboBox_ConvertType_SelectedIndexChanged);
            // 
            // label_ConvertType
            // 
            this.label_ConvertType.AutoSize = true;
            this.label_ConvertType.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_ConvertType.Location = new System.Drawing.Point(30, 76);
            this.label_ConvertType.Name = "label_ConvertType";
            this.label_ConvertType.Size = new System.Drawing.Size(77, 14);
            this.label_ConvertType.TabIndex = 47;
            this.label_ConvertType.Text = "转化类型：";
            // 
            // button_SetSavePath
            // 
            this.button_SetSavePath.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_SetSavePath.Location = new System.Drawing.Point(372, 348);
            this.button_SetSavePath.Name = "button_SetSavePath";
            this.button_SetSavePath.Size = new System.Drawing.Size(60, 30);
            this.button_SetSavePath.TabIndex = 51;
            this.button_SetSavePath.Text = "浏览";
            this.button_SetSavePath.UseVisualStyleBackColor = true;
            this.button_SetSavePath.Click += new System.EventHandler(this.button_SetSavePath_Click);
            // 
            // textBox_ConvertSavePath
            // 
            this.textBox_ConvertSavePath.Location = new System.Drawing.Point(158, 352);
            this.textBox_ConvertSavePath.Name = "textBox_ConvertSavePath";
            this.textBox_ConvertSavePath.ReadOnly = true;
            this.textBox_ConvertSavePath.Size = new System.Drawing.Size(197, 21);
            this.textBox_ConvertSavePath.TabIndex = 50;
            // 
            // label_ConvertSavePath
            // 
            this.label_ConvertSavePath.AutoSize = true;
            this.label_ConvertSavePath.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_ConvertSavePath.Location = new System.Drawing.Point(45, 354);
            this.label_ConvertSavePath.Name = "label_ConvertSavePath";
            this.label_ConvertSavePath.Size = new System.Drawing.Size(105, 14);
            this.label_ConvertSavePath.TabIndex = 49;
            this.label_ConvertSavePath.Text = "转换存储路径：";
            // 
            // button_Convert
            // 
            this.button_Convert.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Convert.Location = new System.Drawing.Point(192, 421);
            this.button_Convert.Name = "button_Convert";
            this.button_Convert.Size = new System.Drawing.Size(100, 28);
            this.button_Convert.TabIndex = 52;
            this.button_Convert.Text = "转换";
            this.button_Convert.UseVisualStyleBackColor = true;
            this.button_Convert.Click += new System.EventHandler(this.button_Convert_Click);
            // 
            // textBox_FileName
            // 
            this.textBox_FileName.Location = new System.Drawing.Point(158, 248);
            this.textBox_FileName.Name = "textBox_FileName";
            this.textBox_FileName.Size = new System.Drawing.Size(174, 21);
            this.textBox_FileName.TabIndex = 54;
            // 
            // label_SaveFileName
            // 
            this.label_SaveFileName.AutoSize = true;
            this.label_SaveFileName.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_SaveFileName.Location = new System.Drawing.Point(52, 250);
            this.label_SaveFileName.Name = "label_SaveFileName";
            this.label_SaveFileName.Size = new System.Drawing.Size(105, 14);
            this.label_SaveFileName.TabIndex = 53;
            this.label_SaveFileName.Text = "输出文件名称：";
            // 
            // button_OpenFolder
            // 
            this.button_OpenFolder.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_OpenFolder.Location = new System.Drawing.Point(192, 465);
            this.button_OpenFolder.Name = "button_OpenFolder";
            this.button_OpenFolder.Size = new System.Drawing.Size(100, 28);
            this.button_OpenFolder.TabIndex = 55;
            this.button_OpenFolder.Text = "打开文件夹";
            this.button_OpenFolder.UseVisualStyleBackColor = true;
            this.button_OpenFolder.Click += new System.EventHandler(this.button_OpenFolder_Click);
            // 
            // Form_ExcelConvert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 514);
            this.Controls.Add(this.button_OpenFolder);
            this.Controls.Add(this.textBox_FileName);
            this.Controls.Add(this.label_SaveFileName);
            this.Controls.Add(this.button_Convert);
            this.Controls.Add(this.button_SetSavePath);
            this.Controls.Add(this.textBox_ConvertSavePath);
            this.Controls.Add(this.label_ConvertSavePath);
            this.Controls.Add(this.comboBox_ConvertType);
            this.Controls.Add(this.label_ConvertType);
            this.Controls.Add(this.pictureBox_Excel);
            this.Controls.Add(this.label_DragPrompt2);
            this.Controls.Add(this.label_DragPrompt1);
            this.Controls.Add(this.listView_DragExcel);
            this.Controls.Add(this.button_SelectExcel);
            this.Controls.Add(this.textBox_ExcelPath);
            this.Controls.Add(this.label_ExcelPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_ExcelConvert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel转换工具";
            this.Load += new System.EventHandler(this.Form_ExcelConvert_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Excel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_SelectExcel;
        private System.Windows.Forms.TextBox textBox_ExcelPath;
        private System.Windows.Forms.Label label_ExcelPath;
        private System.Windows.Forms.PictureBox pictureBox_Excel;
        private System.Windows.Forms.Label label_DragPrompt2;
        private System.Windows.Forms.Label label_DragPrompt1;
        private System.Windows.Forms.ListView listView_DragExcel;
        private System.Windows.Forms.ComboBox comboBox_ConvertType;
        private System.Windows.Forms.Label label_ConvertType;
        private System.Windows.Forms.Button button_SetSavePath;
        private System.Windows.Forms.TextBox textBox_ConvertSavePath;
        private System.Windows.Forms.Label label_ConvertSavePath;
        private System.Windows.Forms.Button button_Convert;
        private System.Windows.Forms.TextBox textBox_FileName;
        private System.Windows.Forms.Label label_SaveFileName;
        private System.Windows.Forms.Button button_OpenFolder;
    }
}

