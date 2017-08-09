using System;
using System.Windows.Forms;
namespace Device_List_0._01
{
    public class Range
    {
        public void rangeset(object sender, KeyPressEventArgs e,TextBox t, int range_bottom, int range_top)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))       //숫자만 입력
            {
                e.Handled = true;
            }
            
            int c = Convert.ToInt32((t.Text == string.Empty ? Convert.ToString(range_bottom) : t.Text));
            string botton_length = Convert.ToString(range_bottom);
            for (int i=0; c > 0; i++)
            {
                c = c / 10;
            }
            if (t.TextLength < botton_length.Length) { }        //만약 range_bottom의 자리수가 한자리수 이상일 경우
            else
            {
                int tmp;
                if (!(e.KeyChar == Convert.ToChar(Keys.Back)))      //만약 입력받은 키가 뒤로가기가 아니라면
                    tmp = Convert.ToInt32((t.Text == string.Empty ? Convert.ToString(range_bottom) : t.Text + Convert.ToString(e.KeyChar)));
                else
                    tmp = Convert.ToInt32((t.Text == string.Empty ? Convert.ToString(range_bottom) : t.Text));  //뒤로가기였다면

                if ((tmp < range_bottom || tmp > range_top) && !(e.KeyChar == Convert.ToChar(Keys.Back)))
                {
                    MessageBox.Show(range_bottom + "~" + range_top + " 사이의 값을 입력해주세요.");
                    e.Handled = true;
                }
            }
        }

        public void ipset(object sender, KeyPressEventArgs e, TextBox t)
        { 
            int iPos = 0;               // IP 구역의 현재 위치
            int iDelimitNumber = 0;     // IP 구역의 갯수

            int iLength = t.Text.Length;
            int iIndex = t.Text.LastIndexOf(".");

            int iIndex2 = -1;
            while (true)
            {
                iIndex2 = t.Text.IndexOf(".", iIndex2 + 1);

                if (iIndex2 == -1)      //. 탐색 끝
                    break;

                ++iDelimitNumber;
            }

            // 숫자키와 백스페이스, '.' 만 입력 가능
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != '.')
            {
                MessageBox.Show("숫자만 입력 가능합니다", "오류");
                e.Handled = true;
                return;
            }

            if (e.KeyChar != 8)
            {
                if (e.KeyChar != '.')
                {
                    if (iIndex > 0)
                        iPos = iLength - iIndex;
                    else
                        iPos = iLength + 1;

                    if (iPos == 3)
                    {
                        // 255 이상 체크
                        string strTmp = t.Text.Substring(iIndex + 1) + e.KeyChar;
                        if (Int32.Parse(strTmp) > 255)
                        {
                            MessageBox.Show("255를 넘길수 없습니다.", "오류");
                            e.Handled = true;
                            return;
                        }
                        else
                        {
                            // 3자리가 넘어가면 자동으로 .을 찍어준다
                            if (iDelimitNumber < 3)
                            {
                                t.AppendText(e.KeyChar.ToString());
                                t.AppendText(".");
                                iDelimitNumber++;
                                e.Handled = true;
                                return;
                            }
                        }
                    }

                    // IP 마지막 4자리째는 무조건 무시
                    if (iPos == 4)
                    {
                        e.Handled = true;
                        return;
                    }
                }
                else
                {
                    // 아이피가 3구역 이상 쓰였으면, 이후 키는 무시한다
                    if (iDelimitNumber + 1 > 3)
                    {
                        MessageBox.Show("IP 주소가 정확하지 않습니다.", "오류");
                        e.Handled = true;
                        return;
                    }
                    else
                    {
                        // 연속으로 .을 찍었으면 오류
                        if (t.Text.EndsWith("."))
                        {
                            MessageBox.Show("IP 주소가 정확하지 않습니다.", "오류");
                            e.Handled = true;
                            return;
                        }
                        else
                            iDelimitNumber++;
                    }
                }
            }
        }
    }
}
