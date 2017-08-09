using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using Microsoft.Office;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace Device_List_0._01
{
    public partial class Form_list : Form
    {
        public Form_list()
        {
            InitializeComponent();

            listView_excel.View = View.Details;
            listView_excel.BeginUpdate();
        }

        private void Form_list_Load(object sender, EventArgs e)
        {
            Form_main r = (Form_main)this.Owner;

            for (int i = 0; i < r.camera_list.Count; i++)
            {
                ListViewItem lvi = new ListViewItem(r.camera_list[i].camera_server);
                lvi.SubItems.Add(r.camera_list[i].camera_IP);
                lvi.SubItems.Add(r.camera_list[i].device.device_manufacturer);
                lvi.SubItems.Add(r.camera_list[i].device.device_model);
                lvi.SubItems.Add(r.camera_list[i].device.device_name);
                lvi.SubItems.Add(r.camera_list[i].device.device_username);
                lvi.SubItems.Add(r.camera_list[i].device.device_PW);
                r.comboBox_resolution_main.SelectedIndex = r.camera_list[i].video.video_main_resolution;
                lvi.SubItems.Add(r.comboBox_resolution_main.SelectedItem.ToString());
                r.comboBox_codec_main.SelectedIndex = r.camera_list[i].video.video_main_codec;
                lvi.SubItems.Add(r.comboBox_codec_main.SelectedItem.ToString());
                listView_excel.Items.Add(lvi);
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            Form_main r = (Form_main)this.Owner;

            try
            {
                object missingType = Type.Missing;
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Add(missingType);
                Microsoft.Office.Interop.Excel.Worksheet excelWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)excelBook.Worksheets.Add(missingType, missingType, missingType, missingType);
                excelApp.Visible = false;

                
                for (int i = 0; i < listView_excel.Columns.Count; i++)
                {
                    excelWorksheet.Cells[1, i + 1] = this.listView_excel.Columns[i].Text;
                }
                for (int i = 0; i < listView_excel.Items.Count; i++)
                {
                    for (int j = 0; j < listView_excel.Columns.Count; j++)
                    {
                        excelWorksheet.Cells[i + 2, j + 1] = this.listView_excel.Items[i].SubItems[j].Text;

                    }
                }

                excelBook.SaveAs(@"C:\Users\qwer\Documents\Visual Studio 2017\Projects\Device_List_0.01\Device_List_0.01\bin\Debug\test.xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, missingType, missingType, missingType, missingType, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, missingType, missingType, missingType, missingType, missingType);
                excelApp.Visible = true;
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
            catch
            {
                MessageBox.Show("Excel 파일 저장중 에러가 발생했습니다.");
            }

        }
    }
}
