using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Device_List_0._01
{
    public partial class Form_Search : Form
    {
        public Form_Search()
        {
            InitializeComponent();
        }

        public int Focusecheck = 0;                 //다음 카메라 검색시 활용
        List<int> checklist = new List<int>();

        public void button_search_Click(object sender, EventArgs e)
        {
            Form_list m = (Form_list)this.Owner;
            Focusecheck = 0;

            if (comboBox_search_TYPE.SelectedItem == null || textBox_search_KEYWORD.Text.Length < 1)
            {
                MessageBox.Show("검색 방법과 검색 키워드를 확인해주세요.");
            }
            else
            {
                bool check = false;
                checklist.Clear();

                for (int i = 0; i < m.listView_excel.Items.Count; i++)      //선택 해제
                {
                    m.listView_excel.Items[i].Focused = false;
                    m.listView_excel.Items[i].Selected = false;
                    textBox_fullname.Text = "";
                }
                if (label_type.Text == "카메라 ID")
                {
                    for (int i = 0; i < m.listView_excel.Items.Count; i++)
                    {
                        if (textBox_search_KEYWORD.Text == m.listView_excel.Items[i].SubItems[4].Text)
                        {
                            m.listView_excel.Items[i].Focused = true;
                            m.listView_excel.Items[i].Selected = true;
                            checklist.Add(i);
                            check = true;
                        }
                    }

                }
                else if (label_type.Text == "카메라 이름")
                {
                    for (int i = 0; i < m.listView_excel.Items.Count; i++)
                    {
                        if (textBox_search_KEYWORD.Text == m.listView_excel.Items[i].SubItems[5].Text)
                        {
                            m.listView_excel.Items[i].Focused = true;
                            m.listView_excel.Items[i].Selected = true;
                            checklist.Add(i);
                            check = true;
                        }
                    }
                }

                if (check == false)
                {
                    textBox_fullname.Text = "";
                    MessageBox.Show("카메라를 찾을 수 없습니다.");
                }
                else
                {
                    textBox_fullname.Text = m.listView_excel.Items[checklist[0]].SubItems[4].Text + "." + m.listView_excel.Items[checklist[0]].SubItems[5].Text;
                    MessageBox.Show("검색을 완료했습니다.");
                }
            }
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            Form_list m = (Form_list)this.Owner;
            if (m.listView_excel.FocusedItem != null)         //체크된 아이템이 있을 경우에만 다음 검색 가능
            {
                int tmp = checklist[Focusecheck];
                for (int i = 0; i < m.listView_excel.Items.Count; i++)      //선택 해제
                {
                    m.listView_excel.Items[i].Focused = false;
                    m.listView_excel.Items[i].Selected = false;
                }
                textBox_fullname.Text = m.listView_excel.Items[tmp].SubItems[4].Text + "." + m.listView_excel.Items[tmp].SubItems[5].Text;
                m.listView_excel.Items[tmp].Focused = true;
                m.listView_excel.Items[tmp].Selected = true;

                Focusecheck++;
                if (Focusecheck >= checklist.Count)
                {
                    MessageBox.Show("검색 종료");
                    m.listView_excel.Items[tmp].Focused = false;
                    m.listView_excel.Items[tmp].Selected = false;
                    Focusecheck = 0;
                }
            }
        }

        private void button_fin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox_search_TYPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_search_TYPE.SelectedItem.ToString() == "카메라 ID")
            {
                label_type.Text = "카메라 ID";
            }
            else if(comboBox_search_TYPE.SelectedItem.ToString() == "카메라 이름")
            {
                label_type.Text = "카메라 이름";
            }
        }
    }
}
