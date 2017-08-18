using System;
using System.Collections;
using System.Windows.Forms;

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
                lvi.SubItems.Add(r.camera_list[i].network.network_IP);
                lvi.SubItems.Add(r.camera_list[i].camera_manufacturer);
                lvi.SubItems.Add(r.camera_list[i].device.device_model);
                lvi.SubItems.Add(r.camera_list[i].camera_ID);
                lvi.SubItems.Add(r.camera_list[i].camera_name);
                lvi.SubItems.Add(r.camera_list[i].username);
                lvi.SubItems.Add(r.camera_list[i].user_PW);
                r.comboBox_resolution_main.SelectedIndex = r.camera_list[i].video.video_main_resolution;
                lvi.SubItems.Add(r.comboBox_resolution_main.SelectedItem.ToString());
                r.comboBox_codec_main.SelectedIndex = r.camera_list[i].video.video_main_codec;
                lvi.SubItems.Add(r.comboBox_codec_main.SelectedItem.ToString());
                listView_excel.Items.Add(lvi);
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
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

                excelBook.SaveAs("test.xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, missingType, missingType, missingType, missingType, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, missingType, missingType, missingType, missingType, missingType);
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

        class ListViewItemComparer : IComparer
        {
            private int col;
            public string sort = "asc";
            public ListViewItemComparer()
            {
                col = 0;
            }

            public ListViewItemComparer(int column, string sort)
            {
                col = column;
                this.sort = sort;       //정렬방식 asc/desc
            }

            public int Compare(object x, object y)
            {
                if (sort == "asc")
                {
                    return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
                }
                else
                {
                    return String.Compare(((ListViewItem)y).SubItems[col].Text, ((ListViewItem)x).SubItems[col].Text);
                }
            }
        }

        private void listView_excel_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            for (int i = 0; i < listView_excel.Columns.Count; i++)
            {
                listView_excel.Columns[i].Text = listView_excel.Columns[i].Text.Replace(" △", "");  //없을시 △▽△▽...
                listView_excel.Columns[i].Text = listView_excel.Columns[i].Text.Replace(" ▽", "");
            }

            // DESC
            if (this.listView_excel.Sorting == SortOrder.Ascending)
            {
                this.listView_excel.ListViewItemSorter = new ListViewItemComparer(e.Column, "desc");
                listView_excel.Sorting = SortOrder.Descending;
                listView_excel.Columns[e.Column].Text = listView_excel.Columns[e.Column].Text + " ▽";
            }
            // ASC
            else
            {
                this.listView_excel.ListViewItemSorter = new ListViewItemComparer(e.Column, "asc");
                listView_excel.Sorting = SortOrder.Ascending;
                listView_excel.Columns[e.Column].Text = listView_excel.Columns[e.Column].Text + " △";
            }
            listView_excel.Sort();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            Form_Search search = new Form_Search();
            search.Owner = this;
            search.Show();
        }
    }
}
