using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Spire.Xls;

namespace CSharp_ExcelConvertTool
{
    public partial class Form_ExcelConvert : Form
    {
        /// <summary>
        /// 转化类型列表
        /// </summary>
        private List<string> ConvertTypeList = new List<string>() 
        {
            "Json",
            "Xml",
            "JsonBase64",
            "XmlBase64",
            "JsonBinary",
            "XmlBinary",
            "C# Class",
        };

        private string outputPath;              //输出文件夹

        public Form_ExcelConvert()
        {
            InitializeComponent();
        }

        private void Form_ExcelConvert_Load(object sender, EventArgs e)
        {
            InitOperation();
        }

        /// <summary>
        /// 初始化操作
        /// </summary>
        private void InitOperation()
        {
            //初始化转换类型下拉框
            comboBox_ConvertType.Items.AddRange(ConvertTypeList.ToArray());
            comboBox_ConvertType.Text = ConvertTypeList[0];
        }

        //按钮-选择表格
        private void button_SelectExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Excel文件|*.xls;*.xlsx";
            dialog.Title = "选择Excel表格";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox_ExcelPath.Text = dialog.FileName;
            }
        }

        /// <summary>
        /// 下拉框-转化类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_ConvertType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox_ConvertType.Text== "C# Class")
            {
                label_SaveFileName.Visible = false;
                textBox_FileName.Visible = false;
            }
            else
            {
                label_SaveFileName.Visible = true;
                textBox_FileName.Visible = true;
            }
        }

        //按钮-设置文件路径
        private void button_SetSavePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            textBox_ConvertSavePath.Text = path.SelectedPath;
            outputPath = path.SelectedPath;
        }

        //按钮-转换
        private void button_Convert_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_ExcelPath.Text))
            {
                if (textBox_FileName.Visible)
                {
                    if (string.IsNullOrEmpty(textBox_FileName.Text))
                    {
                        MessageBoxButtons messButton = MessageBoxButtons.OK;
                        MessageBoxEx.Show(this, "输出文件名称不能为空", "警告", messButton);
                        return;
                    }

                    if (string.IsNullOrEmpty(outputPath))
                    {
                        MessageBoxButtons messButton = MessageBoxButtons.OK;
                        MessageBoxEx.Show(this, "文件输出路径为空", "警告", messButton);
                        return;
                    }
                }
            }
            else
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                MessageBoxEx.Show(this, "Excel不能为空", "警告", messButton);
                return;
            }

            switch (comboBox_ConvertType.Text)
            {
                case "Json": ToJson(); break;
                case "Xml": ToXml(); break;
                case "JsonBase64": ToJsonBase64(); break;
                case "XmlBase64": ToXmlBase64(); break;
                case "JsonBinary": ToJsonBinary(); break;
                case "XmlBinary": ToXmlBinary(); break;
                case "C# Class": ToCSharpClass(); break;
            }
        }

        //按钮-打开文件夹
        private void button_OpenFolder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(outputPath))
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                MessageBoxEx.Show(this, "文件输出路径为空", "警告", messButton);
            }
            else
            {
                System.Diagnostics.Process.Start("explorer.exe", outputPath);
            }
        }

        //Excel区域拖拽-开始
        private void listView_DragExcel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        //Excel区域拖拽-结束
        private void listView_DragExcel_DragDrop(object sender, DragEventArgs e)
        {
            string filePath = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];

            if (Path.GetExtension(filePath) == ".xls" || Path.GetExtension(filePath) == ".xlsx")
            {
                textBox_ExcelPath.Text = filePath;

                pictureBox_Excel.Visible = true;
                label_DragPrompt1.Visible = false;
                label_DragPrompt2.Visible = false;
            }
            else
            {
                textBox_ExcelPath.Text = "";

                pictureBox_Excel.Visible = false;
                label_DragPrompt1.Visible = true;
                label_DragPrompt2.Visible = true;

                MessageBoxButtons messButton = MessageBoxButtons.OK;
                MessageBoxEx.Show(this, "请拖拽入.xls/.xlsx文件", "警告", messButton);
                return;
            }
        }

        /// <summary>
        /// Excel转Json
        /// </summary>
        private void ToJson()
        {
            try
            {
                List<DataTable> dataTableList = GetDataTablesFromExcel(textBox_ExcelPath.Text);

                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("{\n");

                for (int i = 0; i < dataTableList.Count; i++)
                {
                    if (i < dataTableList.Count - 1)
                    {
                        stringBuilder.Append(DataTableToJson(dataTableList[i]) + ",\n");
                    }
                    else
                    {
                        stringBuilder.Append(DataTableToJson(dataTableList[i]) + "\n");
                    }
                }

                stringBuilder.Append("}");

                StreamWriter sw = new StreamWriter(outputPath + @"\" + textBox_FileName.Text + ".json");
                sw.Write(stringBuilder.ToString());
                sw.Close();

                MessageBoxButtons messButton = MessageBoxButtons.OK;
                MessageBoxEx.Show(this, "Excel转Json成功", "恭喜", messButton);
            }
            catch(Exception ex)
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                MessageBoxEx.Show(this, ex.Message, "警告", messButton);
            }
        }

        /// <summary>
        /// Excel转Xml
        /// </summary>
        private void ToXml()
        {
            try
            {
                Workbook workbook = new Workbook();
                workbook.LoadFromFile(textBox_ExcelPath.Text);
                workbook.SaveAsXml(outputPath + @"\" + textBox_FileName.Text + ".xml");

                MessageBoxButtons messButton = MessageBoxButtons.OK;
                MessageBoxEx.Show(this, "Excel转Xml成功", "恭喜", messButton);
            }
            catch(Exception ex)
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                MessageBoxEx.Show(this, ex.Message, "警告", messButton);
            }
        }

        /// <summary>
        /// Excel转Json Base64位字符串
        /// </summary>
        private void ToJsonBase64()
        {
            try
            {
                List<DataTable> dataTableList = GetDataTablesFromExcel(textBox_ExcelPath.Text);

                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("{\n");

                for (int i = 0; i < dataTableList.Count; i++)
                {
                    if (i < dataTableList.Count - 1)
                    {
                        stringBuilder.Append(DataTableToJson(dataTableList[i]) + ",\n");
                    }
                    else
                    {
                        stringBuilder.Append(DataTableToJson(dataTableList[i]) + "\n");
                    }
                }

                stringBuilder.Append("}");

                //配置文件加密
                byte[] datas = Encoding.UTF8.GetBytes(stringBuilder.ToString());
                string dataBase64 = Convert.ToBase64String(datas);
                StreamWriter swData = new StreamWriter(outputPath + @"\" + textBox_FileName.Text + ".base64");
                swData.Write(dataBase64);
                swData.Close();

                MessageBoxButtons messButton = MessageBoxButtons.OK;
                MessageBoxEx.Show(this, "Excel转Json Base64位字符串成功", "恭喜", messButton);
            }
            catch (Exception ex)
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                MessageBoxEx.Show(this, ex.Message, "警告", messButton);
            }
        }

        /// <summary>
        /// Excel转Xml Base64为字符串
        /// </summary>
        private void ToXmlBase64()
        {
            try
            {
                Workbook workbook = new Workbook();
                workbook.LoadFromFile(textBox_ExcelPath.Text);

                MemoryStream ms = new MemoryStream();
                workbook.SaveAsXml(ms);

                string dataBase64 = Convert.ToBase64String(ms.ToArray());
                StreamWriter swData = new StreamWriter(outputPath + @"\" + textBox_FileName.Text + ".base64");
                swData.Write(dataBase64);
                swData.Close();
                ms.Close();

                MessageBoxButtons messButton = MessageBoxButtons.OK;
                MessageBoxEx.Show(this, "Excel转Xml Base64位字符串成功", "恭喜", messButton);
            }
            catch (Exception ex)
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                MessageBoxEx.Show(this, ex.Message, "警告", messButton);
            }
        }

        /// <summary>
        /// Excel转Json二进制
        /// </summary>
        private void ToJsonBinary()
        {
            try
            {
                List<DataTable> dataTableList = GetDataTablesFromExcel(textBox_ExcelPath.Text);

                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("{\n");

                for (int i = 0; i < dataTableList.Count; i++)
                {
                    if (i < dataTableList.Count - 1)
                    {
                        stringBuilder.Append(DataTableToJson(dataTableList[i]) + ",\n");
                    }
                    else
                    {
                        stringBuilder.Append(DataTableToJson(dataTableList[i]) + "\n");
                    }
                }

                stringBuilder.Append("}");

                //转化为二进制
                byte[] unicodeData = Encoding.Unicode.GetBytes(stringBuilder.ToString());
                BinaryHelper.SaveBinary(outputPath + @"\" + textBox_FileName.Text + ".data", unicodeData);

                MessageBoxButtons messButton = MessageBoxButtons.OK;
                MessageBoxEx.Show(this, "Excel转Json二进制成功", "恭喜", messButton);
            }
            catch (Exception ex)
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                MessageBoxEx.Show(this, ex.Message, "警告", messButton);
            }
        }

        /// <summary>
        /// Excel转Xml二进制
        /// </summary>
        private void ToXmlBinary()
        {
            try
            {
                Workbook workbook = new Workbook();
                workbook.LoadFromFile(textBox_ExcelPath.Text);

                MemoryStream ms = new MemoryStream();
                workbook.SaveAsXml(ms);

                //转化为二进制
                string xmlStr = Encoding.UTF8.GetString(ms.ToArray());
                byte[] unicodeData = Encoding.Unicode.GetBytes(xmlStr);
                BinaryHelper.SaveBinary(outputPath + @"\" + textBox_FileName.Text + ".data", unicodeData);
                ms.Close();

                MessageBoxButtons messButton = MessageBoxButtons.OK;
                MessageBoxEx.Show(this, "Excel转Xml二进制成功", "恭喜", messButton);
            }
            catch (Exception ex)
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                MessageBoxEx.Show(this, ex.Message, "警告", messButton);
            }
        }

        /// <summary>
        /// Excel转C#类对象
        /// </summary>
        private void ToCSharpClass()
        {
            try
            {
                FileStream fs = new FileStream(textBox_ExcelPath.Text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                IWorkbook workbook = Path.GetExtension(textBox_ExcelPath.Text) == ".xls" ? (IWorkbook)new HSSFWorkbook(fs) : (IWorkbook)new XSSFWorkbook(fs);

                for (int i = 0; i < workbook.NumberOfSheets; i++)
                {
                    ISheet sheet = workbook.GetSheetAt(i);

                    string tag = sheet.GetRow(0).GetCell(0).ToString();
                    if (!tag.Equals("class")) { continue; }

                    string outputFile = outputPath + @"\" + sheet.SheetName + ".cs";

                    StringBuilder sbOutput = new StringBuilder();

                    //添加脚本描述
                    sbOutput.AppendLine("/*");
                    sbOutput.AppendLine(" * 描述:该脚本为自动生成,请勿直接修改");
                    sbOutput.AppendLine(" * 功能:根据配置文件自动生成C#类");
                    sbOutput.AppendLine(" */");

                    sbOutput.AppendLine();

                    //定义类
                    sbOutput.AppendLine($"public class {sheet.SheetName}");
                    sbOutput.AppendLine("{");

                    for (int cellNum = 1; cellNum < sheet.GetRow(0).LastCellNum; cellNum++)
                    {
                        //数据类型
                        string type = sheet.GetRow(2).GetCell(cellNum).ToString();

                        //字段
                        string filed = sheet.GetRow(1).GetCell(cellNum).ToString();

                        //注释
                        string summary = sheet.GetRow(0).GetCell(cellNum).ToString();

                        sbOutput.AppendLine("    /// <summary>");
                        sbOutput.AppendLine($"    /// {summary}");
                        sbOutput.AppendLine("    /// <summary>");
                        sbOutput.AppendLine($"    public {type} {filed};");
                        sbOutput.AppendLine();
                    }

                    sbOutput.AppendLine("}");

                    StreamWriter sw = new StreamWriter(outputFile);
                    sw.Write(sbOutput.ToString());
                    sw.Close();
                }

                MessageBoxButtons messButton = MessageBoxButtons.OK;
                MessageBoxEx.Show(this, "Excel转C# class成功", "恭喜", messButton);
            }
            catch (Exception ex)
            {
                MessageBoxButtons messButton = MessageBoxButtons.OK;
                MessageBoxEx.Show(this, ex.Message, "警告", messButton);
            }
        }

        /// <summary>
        /// Datatable 转 json
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private string DataTableToJson(DataTable table)
        {
            var JsonString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                JsonString.AppendLine($"    \"{table.TableName}\": [");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    JsonString.AppendLine("        {");
                    for (int j = 1; j < table.Columns.Count; j++)
                    {
                        string cellTitle = table.Columns[j].ColumnName.ToString();
                        string cellContent = table.Rows[i][j].ToString();

                        if (j < table.Columns.Count - 1)
                        {
                            if (IsString(cellContent))
                            {
                                string[] splitContent = cellContent.Split(new char[] { '\n', '\r' });
                                string realityContent = "";

                                splitContent.IFor((index, value) =>
                                {
                                    if (index < splitContent.Length - 1)
                                    {
                                        realityContent += $"{value}\\n";
                                    }
                                    else
                                    {
                                        realityContent += value;
                                    }
                                });

                                JsonString.AppendLine("            \"" + cellTitle + "\": " + "\"" + realityContent + "\",");
                            }
                            else { JsonString.AppendLine("            \"" + cellTitle + "\": " + cellContent + ","); }
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            if (IsString(cellContent))
                            {
                                string[] splitContent = cellContent.Split(new char[] { '\n', '\r' });
                                string realityContent = "";

                                splitContent.IFor((index, value) =>
                                {
                                    if (index < splitContent.Length - 1)
                                    {
                                        realityContent += $"{value}\\n";
                                    }
                                    else
                                    {
                                        realityContent += value;
                                    }
                                });

                                JsonString.AppendLine("            \"" + cellTitle + "\": " + "\"" + cellContent + "\"");
                            }
                            else { JsonString.AppendLine("            \"" + cellTitle + "\": " + cellContent); }
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        JsonString.AppendLine("        }");
                    }
                    else
                    {
                        JsonString.AppendLine("        },");
                    }
                }
                JsonString.Append("    ]");
            }
            return JsonString.ToString();
        }

        /// <summary>
        /// 将Excel数据转换成DataTable
        /// </summary>
        /// <param name="excelPath"></param>
        /// <returns></returns>
        private List<DataTable> GetDataTablesFromExcel(string excelPath)
        {
            List<DataTable> dataTableList = new List<DataTable>();

            FileInfo fileInfo = new FileInfo(excelPath);

            using (FileStream fileStream = fileInfo.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                IWorkbook workbook = Path.GetExtension(excelPath) == ".xls" ? (IWorkbook)new HSSFWorkbook(fileStream) : (IWorkbook)new XSSFWorkbook(fileStream);
                for (int index = 0; index < workbook.NumberOfSheets; index++)
                {
                    DataTable dataTable = new DataTable();
                    ISheet sheet = workbook.GetSheetAt(index);
                    if (sheet == null) { continue; }
                    dataTable.TableName = sheet.SheetName;
                    int rowsCount = sheet.PhysicalNumberOfRows;//获取Excel的最大行数
                    if (rowsCount <= 1) continue;

                    //为保证Table布局与Excel一样，这里应该取所有行中的最大列数（需要遍历整个Sheet）。
                    //为少一交全Excel遍历，提高性能，我们可以人为把第0行的列数调整至所有行中的最大列数。
                    int colsCount = sheet.GetRow(0).PhysicalNumberOfCells;

                    //取表格第二行（标题）为Columns
                    for (int i = 0; i < colsCount; i++)
                    {
                        var cellValue = sheet.GetRow(1).GetCell(i);
                        dataTable.Columns.Add(cellValue?.ToString());
                    }

                    //从第三行取数据，第一行默认为标题
                    for (int x = 3; x < rowsCount; x++)
                    {
                        DataRow dr = dataTable.NewRow();
                        for (int y = 0; y < colsCount; y++)
                        {
                            var cellValue = sheet.GetRow(x).GetCell(y);
                            dr[y] = cellValue?.ToString();
                        }
                        dataTable.Rows.Add(dr);
                    }
                    dataTableList.Add(dataTable);
                }
            }
            return dataTableList;
        }

        /// <summary>
        /// 判断是否为字符串
        /// </summary>
        /// <param name="cellContent">要判断的string字符串</param>
        /// <returns>true/false</returns>
        private bool IsString(string cellContent)
        {
            if (int.TryParse(cellContent, out _)) { return false; }
            if (bool.TryParse(cellContent, out _)) { return false; }
            if (float.TryParse(cellContent, out _)) { return false; }

            return true;
        }
    }

    //弹出框重写
    public class MessageBoxEx
    {
        private static IWin32Window _owner;
        private static HookProc _hookProc;
        private static IntPtr _hHook;

        public static DialogResult Show(string text)
        {
            Initialize();
            return MessageBox.Show(text);
        }

        public static DialogResult Show(string text, string caption)
        {
            Initialize();
            return MessageBox.Show(text, caption);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
        {
            Initialize();
            return MessageBox.Show(text, caption, buttons);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            Initialize();
            return MessageBox.Show(text, caption, buttons, icon);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defButton)
        {
            Initialize();
            return MessageBox.Show(text, caption, buttons, icon, defButton);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defButton, MessageBoxOptions options)
        {
            Initialize();
            return MessageBox.Show(text, caption, buttons, icon, defButton, options);
        }

        public static DialogResult Show(IWin32Window owner, string text)
        {
            _owner = owner;
            Initialize();
            return MessageBox.Show(owner, text);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption)
        {
            _owner = owner;
            Initialize();
            return MessageBox.Show(owner, text, caption);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons)
        {
            _owner = owner;
            Initialize();
            return MessageBox.Show(owner, text, caption, buttons);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            _owner = owner;
            Initialize();
            return MessageBox.Show(owner, text, caption, buttons, icon);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defButton)
        {
            _owner = owner;
            Initialize();
            return MessageBox.Show(owner, text, caption, buttons, icon, defButton);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defButton, MessageBoxOptions options)
        {
            _owner = owner;
            Initialize();
            return MessageBox.Show(owner, text, caption, buttons, icon,
                                   defButton, options);
        }

        public delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        public delegate void TimerProc(IntPtr hWnd, uint uMsg, UIntPtr nIDEvent, uint dwTime);

        public const int WH_CALLWNDPROCRET = 12;

        public enum CbtHookAction : int
        {
            HCBT_MOVESIZE = 0,
            HCBT_MINMAX = 1,
            HCBT_QS = 2,
            HCBT_CREATEWND = 3,
            HCBT_DESTROYWND = 4,
            HCBT_ACTIVATE = 5,
            HCBT_CLICKSKIPPED = 6,
            HCBT_KEYSKIPPED = 7,
            HCBT_SYSCOMMAND = 8,
            HCBT_SETFOCUS = 9
        }

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, ref Rectangle lpRect);

        [DllImport("user32.dll")]
        private static extern int MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("User32.dll")]
        public static extern UIntPtr SetTimer(IntPtr hWnd, UIntPtr nIDEvent, uint uElapse, TimerProc lpTimerFunc);

        [DllImport("User32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        [DllImport("user32.dll")]
        public static extern int UnhookWindowsHookEx(IntPtr idHook);

        [DllImport("user32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int maxLength);

        [DllImport("user32.dll")]
        public static extern int EndDialog(IntPtr hDlg, IntPtr nResult);

        [StructLayout(LayoutKind.Sequential)]
        public struct CWPRETSTRUCT
        {
            public IntPtr lResult;
            public IntPtr lParam;
            public IntPtr wParam;
            public uint message;
            public IntPtr hwnd;
        };

        static MessageBoxEx()
        {
            _hookProc = new HookProc(MessageBoxHookProc);
            _hHook = IntPtr.Zero;
        }

        private static void Initialize()
        {
            if (_hHook != IntPtr.Zero)
            {
                throw new NotSupportedException("multiple calls are not supported");
            }

            if (_owner != null)
            {
                _hHook = SetWindowsHookEx(WH_CALLWNDPROCRET, _hookProc, IntPtr.Zero, AppDomain.GetCurrentThreadId());
            }
        }

        private static IntPtr MessageBoxHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0)
            {
                return CallNextHookEx(_hHook, nCode, wParam, lParam);
            }

            CWPRETSTRUCT msg = (CWPRETSTRUCT)Marshal.PtrToStructure(lParam, typeof(CWPRETSTRUCT));
            IntPtr hook = _hHook;

            if (msg.message == (int)CbtHookAction.HCBT_ACTIVATE)
            {
                try
                {
                    CenterWindow(msg.hwnd);
                }
                finally
                {
                    UnhookWindowsHookEx(_hHook);
                    _hHook = IntPtr.Zero;
                }
            }

            return CallNextHookEx(hook, nCode, wParam, lParam);
        }

        private static void CenterWindow(IntPtr hChildWnd)
        {
            Rectangle recChild = new Rectangle(0, 0, 0, 0);
            bool success = GetWindowRect(hChildWnd, ref recChild);

            int width = recChild.Width - recChild.X;
            int height = recChild.Height - recChild.Y;

            Rectangle recParent = new Rectangle(0, 0, 0, 0);
            success = GetWindowRect(_owner.Handle, ref recParent);

            Point ptCenter = new Point(0, 0);
            ptCenter.X = recParent.X + ((recParent.Width - recParent.X) / 2);
            ptCenter.Y = recParent.Y + ((recParent.Height - recParent.Y) / 2);

            Point ptStart = new Point(0, 0);
            ptStart.X = (ptCenter.X - (width / 2));
            ptStart.Y = (ptCenter.Y - (height / 2));

            ptStart.X = (ptStart.X < 0) ? 0 : ptStart.X;
            ptStart.Y = (ptStart.Y < 0) ? 0 : ptStart.Y;

            int result = MoveWindow(hChildWnd, ptStart.X, ptStart.Y, width, height, false);
        }
    }
}
