using System;
using System.Collections.Generic;
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
        public bool searchOK = false;
        public bool beforeButtonisNext = true;
        List<int> checklist = new List<int>();

        private void Form_Search_Load(object sender, EventArgs e)
        {
            Form_list m = (Form_list)this.Owner;
            button_before.Enabled = false;
            button_next.Enabled = false;
            textBox_fullname.Enabled = false;
            textBox_search_KEYWORD.Enabled = false;
        }

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
                            searchOK = true;
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
                            searchOK = true;
                        }
                    }
                }

                if (check == false)
                {
                    textBox_fullname.Text = "";
                    button_before.Enabled = false;
                    button_next.Enabled = false;
                    MessageBox.Show("카메라를 찾을 수 없습니다.");
                }

                else
                {
                    textBox_fullname.Text = m.listView_excel.Items[checklist[0]].SubItems[4].Text + "." + m.listView_excel.Items[checklist[0]].SubItems[5].Text; 
                    button_next.Enabled = true;
                    MessageBox.Show("검색을 완료했습니다.");
                }
            }
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            Form_list m = (Form_list)this.Owner;
            if (m.listView_excel.FocusedItem != null && searchOK==true)         //체크된 아이템이 있을 경우에만 다음 검색 가능
            {
                button_before.Enabled = true;
                if (beforeButtonisNext == false)
                {
                    Focusecheck++;
                    beforeButtonisNext = true;
                }

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
                    Focusecheck = 0;
                    searchOK = false;
                    button_before.Enabled = false;
                    button_next.Enabled = false;
                }
            }
        }

        private void button_before_Click(object sender, EventArgs e)
        {
            Form_list m = (Form_list)this.Owner;
            if (m.listView_excel.FocusedItem != null && searchOK == true)         //체크된 아이템이 있을 경우에만 다음 검색 가능
            {
                if (Focusecheck <= 0)
                {
                    button_before.Enabled = false;
                    MessageBox.Show("시작 지점 입니다");
                }

                else
                {
                    Focusecheck--;
                    if(beforeButtonisNext==true)
                    {
                       Focusecheck--;
                       beforeButtonisNext = false;
                    }
                    if (Focusecheck < 0)
                    {
                        button_before.Enabled = false;
                        MessageBox.Show("시작 지점 입니다");
                        Focusecheck++;
                    }
                    int tmp = checklist[Focusecheck];

                    for (int i = 0; i < m.listView_excel.Items.Count; i++)      //선택 해제
                    {
                        m.listView_excel.Items[i].Focused = false;
                        m.listView_excel.Items[i].Selected = false;
                    }

                    textBox_fullname.Text = m.listView_excel.Items[tmp].SubItems[4].Text + "." + m.listView_excel.Items[tmp].SubItems[5].Text;
                    m.listView_excel.Items[tmp].Focused = true;
                    m.listView_excel.Items[tmp].Selected = true;
                }
            }
        }

        private void button_fin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox_search_TYPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_search_KEYWORD.Enabled = true;

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
