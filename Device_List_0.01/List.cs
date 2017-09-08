using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Device_List_0._01
{
    public partial class Form_list : Form
    {
        public Form_list()
        {
            InitializeComponent();
            this.KeyPreview = true;

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
                if (r.camera_list[i].camera_connect == "connected" || r.camera_list[i].camera_connect == "signal_restored")
                {
                    lvi.SubItems.Add("connected");
                }
                else
                {
                    lvi.SubItems.Add("unconnected");
                }
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

        private void button_refresh_list_Click(object sender, EventArgs e)
        {
            Form_main r = (Form_main)this.Owner;

            r.camera_list.Clear();
            listView_excel.Clear();
            listView_excel.Columns.Add("서버",80);
            listView_excel.Columns.Add("IP",80);
            listView_excel.Columns.Add("제조사",60);
            listView_excel.Columns.Add("Model",60);
            listView_excel.Columns.Add("카메라 id",80);
            listView_excel.Columns.Add("카메라 이름",80);
            listView_excel.Columns.Add("Username",70);
            listView_excel.Columns.Add("Password",80);
            listView_excel.Columns.Add("Resolution",80);
            listView_excel.Columns.Add("Codec",60);
            listView_excel.Columns.Add("연결상태",60);
            //listView_excel.Items.Clear();
            r.listView_device.Items.Clear();
            ///////////////////////////////////카메라 받아오는 코드 테스트/////////////
            management server = new management();
            List<json_camera> J = new List<json_camera>();
            string json = server.Request_Json();
            J = server.ParseJson(json);

            for (int i = 0; i < J.Count; i++)
            {
                r.camera_list.Add(new Camera() { camera_server = J[i].Server, camera_ID = J[i].JCamera_id, camera_name = J[i].FriendlyNameLong, camera_connect = J[i].State });
            }

            int tmp = r.camera_list.Count;
            Xmlclass re = new Xmlclass();               //
            for (int i = 0; i < tmp; i++)
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
                if (r.camera_list[i].camera_connect == "connected" || r.camera_list[i].camera_connect == "signal_restored")
                {
                    lvi.SubItems.Add("connected");
                }
                else
                {
                    lvi.SubItems.Add("unconnected");
                }
                listView_excel.Items.Add(lvi);

                re.item.Add(r.camera_list[i]);
            }
            r.M.serialize(re);
            r.x = re;
            
            for (int i = 0; i < tmp; i++)
            {
                ListViewItem lvi = new ListViewItem(r.camera_list[i].camera_server);
                lvi.SubItems.Add(r.camera_list[i].camera_ID);
                lvi.SubItems.Add(r.camera_list[i].camera_name);
                if (r.camera_list[i].camera_connect == "connected" || r.camera_list[i].camera_connect == "signal_restored")
                {
                    lvi.SubItems.Add("connected");
                }
                else
                {
                    lvi.SubItems.Add("unconnected");
                }
                r.listView_device.Items.Add(lvi);
            }
        }

        private void Form_list_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                this.Close();
            }
        }
    }
}
