using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace lottery
{
    public partial class Form_chooseNum : Form
    {
        //威力彩
        List<Button> myBtnList1 = new List<Button>();
        List<Button> myBtnList2 = new List<Button>();
        List<int> clickedBtnList1 = new List<int>();
        List<int> clickedBtnList2 = new List<int>();
        List<int> clickedBtnList3 = new List<int>();

        int bingoHe = 0;
        
        int[] star4Array = new int[4];
        int[] star4Array2 = new int[4];

        int count1 = 0;
        int count2 = 0;
        int count3 = 0;

        int[] index = new int[38];
        int[] numArray = new int[6];
        int numArray2;

        int[] happy39Index = new int[39];
        int[] happy39Array = new int[6];
        bool star4Clicked_1 = false;
        bool star4Clicked_2 = false;

        //39樂合彩
        List<Button> myBtnList3 = new List<Button>();

        int[] cb1Data1 = new int[10];
        int[] cb1Data2 = new int[10];
        int[] cb1Data3 = new int[10];
        int[] cb1Data4 = new int[10];

        public Form_chooseNum()
        {
            InitializeComponent();
        }
        public void set_btn_tabpage1(int x,int y,int z)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (j >= 8 && i == x - 1 )
                    {
                        break;
                    }
                    Button btn = new Button();
                    btn.BackColor = Color.White;
                    btn.ForeColor = Color.Red;
                    btn.Size = new Size(45, 45);
                    btn.Location = new Point(40 + 50 * j, 80 + 50 * i);
                    btn.Text = (j + 1 + i * y).ToString();
                    btn.Name = "btn" + (j + 1 + i * y).ToString();
                    btn.Font = new Font("微軟正黑體", 13);
                    btn.Click += new EventHandler(btn_Click1);

                    tabPage1.Controls.Add(btn);
                    myBtnList1.Add(btn);
                }
            }
            for(int i = 0; i < z; i++)
            {
                Button btn = new Button();
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Red;
                btn.Size = new Size(45, 45);
                btn.Location = new Point(40 + 50 * i, 280);
                btn.Text = (i+1).ToString();
                btn.Name = "btn_two" + i.ToString();
                btn.Font = new Font("微軟正黑體", 13);
                btn.Click += new EventHandler(btn_Click2);
                tabPage1.Controls.Add(btn);
                myBtnList2.Add(btn);
            }
        }
        void btn_Click1(object sender, EventArgs e)
        {
            Button clickedBtn = (Button)sender;
            if (count1 < 7)
            {
                if (clickedBtn.BackColor == Color.White)
                {
                    if (count1 <= 6)
                    {
                        tbResult1.Clear();
                        clickedBtn.BackColor = Color.Pink;
                        clickedBtnList1.Add(Convert.ToInt32(clickedBtn.Text));
                        clickedBtnList1.Sort();
                        count1 += 1;
                        foreach (int item in clickedBtnList1)
                        {
                            tbResult1.Text += item.ToString() + " ";
                        }
                    }
                    else{ }
                }
                else if (clickedBtn.BackColor == Color.Pink)
                {
                    if (count1 == 6)
                    {
                        foreach (Button btn in myBtnList1)
                        {
                            btn.Enabled = true;
                        }
                    }
                    tbResult1.Clear();
                    clickedBtn.BackColor = Color.White;
                    clickedBtnList1.Remove(Convert.ToInt32(clickedBtn.Text));
                    clickedBtnList1.Sort();
                    count1 -= 1;
                    foreach (int item in clickedBtnList1)
                    {
                        tbResult1.Text += item.ToString() + " ";
                    }
                }
                if (count1 == 6)
                {
                    foreach (Button btn in myBtnList1)
                    {
                        if (btn.BackColor == Color.White)
                        {
                            btn.Enabled = false;
                        }
                    }
                }
            }
        }
        void btn_Click2(object sender, EventArgs e)
        {
            Button clickedBtn = (Button)sender;

            //第二欄號碼
            if (count2 < 3)
            {
                if (clickedBtn.BackColor == Color.White)
                {
                    if (count2 <= 2)
                    {
                        tbResult2.Clear();
                        clickedBtn.BackColor = Color.Pink;
                        clickedBtnList2.Add(Convert.ToInt32(clickedBtn.Text));
                        clickedBtnList2.Sort();
                        count2 += 1;
                        foreach (int item in clickedBtnList2)
                        {
                            tbResult2.Text += item.ToString() + " ";
                        }
                    }
                }
                else if (clickedBtn.BackColor == Color.Pink)
                {
                    if (count2 == 1)
                    {
                        foreach (Button btn in myBtnList2)
                        {
                            btn.Enabled = true;
                        }
                    }
                    tbResult2.Clear();
                    clickedBtn.BackColor = Color.White;
                    clickedBtnList2.Remove(Convert.ToInt32(clickedBtn.Text));
                    clickedBtnList2.Sort();
                    count2 -= 1;
                    foreach (int item in clickedBtnList2)
                    {
                        tbResult2.Text += item.ToString() + " ";
                    }
                }
                if (count2 == 1)
                {
                    foreach (Button btn in myBtnList2)
                    {
                        if (btn.BackColor == Color.White)
                        {
                            btn.Enabled = false;
                        }
                    }
                }
            }
        }

        private void Form_chooseNum_Load(object sender, EventArgs e)
        {
            set_btn_tabpage1(4, 10, 8);
            for (int i = 0; i < 10; i++)
            {
                cb1.Items.Add(i);
                cb2.Items.Add(i);
                cb3.Items.Add(i);
                cb4.Items.Add(i);
            }
            btnsubmit4star.Enabled = false;
            cb1.Enabled = false;
            cb2.Enabled = false;
            cb3.Enabled = false;
            cb4.Enabled = false;

            timer1.Interval = 1500;
            timer1.Enabled = true;
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (clickedBtnList1.Count() == 6 && clickedBtnList2.Count() == 1)
            {


                string strList1 = "";
                foreach (int index in clickedBtnList1)
                {
                    strList1 += index.ToString() + " ";
                }

                DialogResult result;
                result = MessageBox.Show("璇璇黑心彩卷行\n" +
                        "-----------------\n" +
                        "您輸入的獎號為:\n\n" +
                        "第一區: " + strList1 + "\n" +
                        "第二區: " + clickedBtnList2[0] + "\n\n" +
                        "-----------------\n" +
                        "確認送出?", "璇璇黑心彩卷行",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    int bingo1 = 0;
                    int bingo2 = 0;
                    string strBingo1 = "恭喜中頭獎!";
                    string strBingo2 = "恭喜中貳獎!";
                    string strBingo3 = "恭喜中參獎!";
                    string strBingo4 = "恭喜中肆獎!";
                    string strBingo5 = "恭喜中伍獎!";
                    string strBingo6 = "恭喜中陸獎!";
                    string strBingo7 = "恭喜中柒獎!";
                    string strBingo8 = "恭喜中捌獎!";
                    string strBingo9 = "恭喜中玖獎!";
                    string strBingo10 = "恭喜中普獎!";
                    string strBingo0 = "銘謝惠顧";

                    string dateTime = DateTime.Now.ToString("威力彩 yyyyMMdd HH時mm分ss秒");
                    saveFileDialog1.FileName = dateTime;
                    string strSaveFilePath = saveFileDialog1.FileName + @".text";
                    StreamWriter myWrite = new StreamWriter(strSaveFilePath);
                    for (int index1 = 0; index1 < numArray.Length; index1++)
                    {
                        for (int index2 = 0; index2 < clickedBtnList1.Count; index2++)
                        {
                            if (clickedBtnList1[index2] == numArray[index1])
                            {
                                bingo1++;
                            }
                        }
                    }
                    if (clickedBtnList2[0] == numArray2)
                    {
                        bingo2++;
                    }
                    if (bingo1 == 6 && bingo2 == 1)
                    {
                        MessageBox.Show(strBingo1);
                        myWrite.Write("獎號:" +strList1+"\n"+
                            "中獎訊息:" + strBingo1
                            );
                    }
                    else if (bingo1 == 6)
                    {
                        MessageBox.Show(strBingo2);
                        myWrite.Write("獎號:" + strList1 + "\n" +
                            "中獎訊息:" + strBingo2
                            );
                    }
                    else if (bingo1 == 5 && bingo2 == 1)
                    {
                        MessageBox.Show(strBingo3);
                        myWrite.Write("獎號:" + strList1 + "\n" +
                            "中獎訊息:" + strBingo3
                            );
                    }
                    else if (bingo1 == 5)
                    {
                        MessageBox.Show(strBingo4);
                        myWrite.Write("獎號:" + strList1 + "\n" +
                            "中獎訊息:" + strBingo4
                            );
                    }
                    else if (bingo1 == 4 && bingo2 == 1)
                    {
                        myWrite.Write("獎號:" + strList1 + "\n" +
                            "中獎訊息:" + strBingo5
                            );
                        MessageBox.Show(strBingo5);
                    }
                    else if (bingo1 == 4)
                    {
                        MessageBox.Show(strBingo6);
                        myWrite.Write("獎號:" + strList1 + "\n" +
                            "中獎訊息:" + strBingo6
                            );
                    }
                    else if (bingo1 == 3 && bingo2 == 1)
                    {
                        myWrite.Write("獎號:" + strList1 + "\n" +
                            "中獎訊息:" + strBingo7
                            );
                        MessageBox.Show(strBingo7);
                    }
                    else if (bingo1 == 2 && bingo2 == 1)
                    {
                        MessageBox.Show(strBingo8);
                        myWrite.Write("獎號:" + strList1 + "\n" +
                            "中獎訊息:" + strBingo8
                            );
                    }
                    else if (bingo1 == 3)
                    {
                        MessageBox.Show(strBingo9);
                        myWrite.Write("獎號:" + strList1 + "\n" +
                            "中獎訊息:" + strBingo9
                            );
                    }
                    else if (bingo1 == 1 && bingo2 == 1)
                    {
                        MessageBox.Show(strBingo10);
                        myWrite.Write("獎號:" + strList1 + "\n" +
                            "中獎訊息:" + strBingo10
                            );
                    }
                    else
                    {
                        MessageBox.Show(strBingo0);
                        myWrite.Write("獎號:" + strList1 + "\n" +
                            "中獎訊息:" + strBingo0
                            );
                    }
                    myWrite.Close();
                    MessageBox.Show(strSaveFilePath + " 存檔完成");
                }
            }
            else
            {
                MessageBox.Show("第一區請選擇六位號碼\n第二區請選擇一位號碼");
            }
        }
        void result()
        {
            Random random = new Random();
            numArray2 = random.Next(1, 8);
            int Num = 38;
            //每個index陣列的索引值只對應到一個值
            //index[0]=1, index[37]=38

            for (int i = 0; i < Num; i++)
            {
                index[i] = i + 1;
            }

            //給予numArray值
            for (int i = 0; i <= numArray.GetUpperBound(0); i++)
            {
                //1~Max數組-1中的隨機數
                int theRandomNumForIndex = random.Next(1, Num - 1);
                //index陣列中隨機數對應的值存入numArray
                numArray[i] = index[theRandomNumForIndex];

                //index[Num最大值]取代index[隨機值]
                index[theRandomNumForIndex] = index[Num - 1];
                //index[Num的最大值]轉移完畢,消失
                Num--;
            }
            Array.Sort(numArray);

            int happy39Num = 39;
            for (int i = 0; i < happy39Num; i++)
            {
                happy39Index[i] = i + 1;
            }
            for (int i = 0; i <= happy39Array.GetUpperBound(0); i++)
            {
                int theRandomNumForIndex = random.Next(1, happy39Num -1);
                happy39Array[i] = happy39Index[theRandomNumForIndex];
                happy39Index[theRandomNumForIndex] = happy39Index[happy39Num - 1];
                happy39Num--;
            }
            Array.Sort(happy39Array);

            for (int i = 0; i < 4; i++)
            {
                star4Array[i] = random.Next(0, 9);
            }
            for(int i = 0; i < 4; i++)
            {
                star4Array2[i] = star4Array[i];
            }

            lblNum01.Text = numArray[0].ToString();
            lblNum02.Text = numArray[1].ToString();
            lblNum03.Text = numArray[2].ToString();
            lblNum04.Text = numArray[3].ToString();
            lblNum05.Text = numArray[4].ToString();
            lblNum06.Text = numArray[5].ToString();
            lblNum07.Text = numArray2.ToString();

            lbl39Num1.Text = happy39Array[0].ToString();
            lbl39Num2.Text = happy39Array[1].ToString();
            lbl39Num3.Text = happy39Array[2].ToString();
            lbl39Num4.Text = happy39Array[3].ToString();
            lbl39Num5.Text = happy39Array[4].ToString();

            Array.Sort(star4Array);
            lbl4Num1.Text = star4Array[0].ToString();
            lbl4Num2.Text = star4Array[1].ToString();
            lbl4Num3.Text = star4Array[2].ToString();
            lbl4Num4.Text = star4Array[3].ToString();

            lbl4_2Num1.Text = star4Array2[0].ToString();
            lbl4_2Num2.Text = star4Array2[1].ToString();
            lbl4_2Num3.Text = star4Array2[2].ToString();
            lbl4_2Num4.Text = star4Array2[3].ToString();
        }
        private void btnstart_Click(object sender, EventArgs e)
        {
            result();
        }


        private void tabPage2_Enter(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (j >= 9 && i == 3)
                    {
                        break;
                    }
                    Button btn = new Button();
                    btn.BackColor = Color.White;
                    btn.ForeColor = Color.Red;
                    btn.Size = new Size(45, 45);
                    btn.Location = new Point(40 + 50 * j, 150 + 50 * i);
                    btn.Text = (j + 1 + i * 10).ToString();
                    btn.Name = "btn" + (j + 1 + i * 10).ToString();
                    btn.Font = new Font("微軟正黑體", 13);
                    btn.Click += new EventHandler(btn_Click3);

                    tabPage2.Controls.Add(btn);
                    myBtnList3.Add(btn);
                }
            }
            foreach (Button btn in myBtnList3)
            {
                btn.Enabled = false;
            }
        }
        

        void btn_Click3(object sender, EventArgs e)
        {
            Button clickedBtn = (Button)sender;
            if (count3 < bingoHe + 1)
            {
                if (clickedBtn.BackColor == Color.White)
                {
                    if (count3 <= bingoHe)
                    {
                        tbResult3.Clear();
                        clickedBtn.BackColor = Color.Pink;
                        clickedBtnList3.Add(Convert.ToInt32(clickedBtn.Text));
                        clickedBtnList3.Sort();
                        count3 += 1;
                        foreach (int item in clickedBtnList3)
                        {
                            tbResult3.Text += item.ToString() + " ";
                        }
                    }
                }
                else if (clickedBtn.BackColor == Color.Pink)
                {
                    if (count3 == bingoHe)
                    {
                        foreach (Button btn in myBtnList3)
                        {
                            btn.Enabled = true;
                        }
                    }
                    tbResult3.Clear();
                    clickedBtn.BackColor = Color.White;
                    clickedBtnList3.Remove(Convert.ToInt32(clickedBtn.Text));
                    clickedBtnList3.Sort();
                    count3 -= 1;
                    foreach (int item in clickedBtnList3)
                    {

                        tbResult3.Text += item.ToString() + " ";
                    }
                }
                if (count3 == bingoHe)
                {
                    foreach (Button btn in myBtnList3)
                    {
                        if (btn.BackColor == Color.White)
                        {
                            btn.Enabled = false;
                        }
                    }
                }
            }   
        }
        
        
        private void btnBingoHe2_Click(object sender, EventArgs e)
        {
            count3 = 0;
            foreach (Button btn in myBtnList3)
            {
                btn.BackColor = Color.White;
                btn.Enabled = true; 
            }
            bingoHe = 2;
            clickedBtnList3.Clear();
            tbResult3.Text = "";
        }

        private void btnBingoHe3_Click(object sender, EventArgs e)
        {
            count3 = 0;
            foreach (Button btn in myBtnList3)
            {
                btn.BackColor = Color.White;
                btn.Enabled = true; 
            }
            bingoHe = 3;
            clickedBtnList3.Clear();
            tbResult3.Text = "";
        }

        private void btnBingoHe4_Click(object sender, EventArgs e)
        {
            count3 = 0;
            foreach (Button btn in myBtnList3)
            {
                btn.BackColor = Color.White;
                btn.Enabled = true; 
            }
            bingoHe = 4;
            clickedBtnList3.Clear();
            tbResult3.Text = "";
        }

        private void btnsubmit39_Click(object sender, EventArgs e)
        {
            string strList3 = "";
            foreach (int index in clickedBtnList3)
            {
                strList3 += index.ToString() + " ";
            }
            DialogResult result;
            result = MessageBox.Show("璇璇黑心彩卷行\n" +
                    "-----------------\n" +
                    "您輸入的獎號為:\n\n" +
                    strList3 + "\n" +
                    "-----------------\n" +
                    "確認送出?", "璇璇黑心彩卷行",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {

                int bingo = 0;
                string dateTime = DateTime.Now.ToString("39樂合彩 yyyyMMdd HH時mm分ss秒 ");
                saveFileDialog1.FileName = dateTime;
                string strSaveFilePath = saveFileDialog1.FileName + @".text";
                StreamWriter myWrite = new StreamWriter(strSaveFilePath);

                if (bingoHe == 2)
                {
                    for (int i = 0; i < happy39Array.Count(); i++)
                    {
                        for (int j = 0; j < clickedBtnList3.Count(); j++)
                        {
                            if (happy39Array[i] == clickedBtnList3[j])
                            {
                                bingo++;
                            }
                        }
                    }
                    if (bingo == 2)
                    {
                        MessageBox.Show("恭喜中獎");
                        myWrite.Write("獎號:"+strList3+"\n"+"中獎訊息: 中獎(二合)");
                    }
                    else
                    {
                        MessageBox.Show("銘謝惠顧");
                        myWrite.Write("獎號:" + strList3 + "\n" + "中獎訊息: 銘謝惠顧");
                    }
                }else if(bingoHe == 3)
                {
                    for (int i = 0; i < happy39Array.Count(); i++)
                    {
                        for (int j = 0; j < clickedBtnList3.Count(); j++)
                        {
                            if (happy39Array[i] == clickedBtnList3[j])
                            {
                                bingo++;
                            }
                        }
                    }
                    if (bingo == 3)
                    {
                        MessageBox.Show("恭喜中獎");
                        myWrite.Write("獎號:" + strList3 + "\n" + "中獎訊息: 中獎(三合)");
                    }
                    else
                    {
                        MessageBox.Show("銘謝惠顧");
                        myWrite.Write("獎號:" + strList3 + "\n" + "中獎訊息: 銘謝惠顧");
                    }
                }else if(bingoHe == 4)
                {
                    for (int i = 0; i < happy39Array.Count(); i++)
                    {
                        for (int j = 0; j < clickedBtnList3.Count(); j++)
                        {
                            if (happy39Array[i] == clickedBtnList3[j])
                            {
                                bingo++;
                            }
                        }
                    }
                    if (bingo == 4)
                    {
                        MessageBox.Show("恭喜中獎");
                        myWrite.Write("獎號:" + strList3 + "\n" + "中獎訊息: 中獎(三合)");
                    }
                    else
                    {
                        MessageBox.Show("銘謝惠顧");
                        myWrite.Write("獎號:" + strList3 + "\n" + "中獎訊息: 銘謝惠顧");
                    }
                }
                myWrite.Close();
                MessageBox.Show(strSaveFilePath + " 存檔完成");
            }
        }
        int[] star4Selected2 = new int[4];
        int[] star4Selected = new int[4];
        int tzutai24 = 3;
        int tzutai6 = 1;
        int tzutai4 = 1;
        bool tzutai12 = false;


        private void btnsubmit4star_Click(object sender, EventArgs e)
        {           
            int bingo = 0;
            calculate();
            if (star4Selected.Count() == 4)
            {
                star4Selected[0] = (int)cb1.SelectedItem;
                star4Selected[1] = (int)cb2.SelectedItem;
                star4Selected[2] = (int)cb3.SelectedItem;
                star4Selected[3] = (int)cb4.SelectedItem;
                for(int i =0; i < 4; i++)
                {
                    star4Selected2[i] = star4Selected[i];
                }
                Array.Sort(star4Selected);

                if (
             star4Selected[0] == star4Selected[1] &&
             star4Selected[0] == star4Selected[2] &&
             star4Selected[0] == star4Selected[3])
                {
                    MessageBox.Show("不可以有四位相同數字");
                }
                else
                {

                    string strList4 = "";
                    strList4 = cb1.SelectedItem.ToString() + cb2.SelectedItem.ToString() +
                        cb3.SelectedItem.ToString() + cb4.SelectedItem.ToString();
                    DialogResult result;
                    result = MessageBox.Show("璇璇黑心彩卷行\n" +
                            "-----------------\n" +
                            "您輸入的獎號為:\n\n" +
                             strList4 + "\n" +
                            "-----------------\n" +
                            "確認送出?", "璇璇黑心彩卷行",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (result == DialogResult.OK)
                    {
                        string dateTime = DateTime.Now.ToString("四星彩 yyyyMMdd HH時mm分ss秒 ");
                        saveFileDialog1.FileName = dateTime;
                        string strSaveFilePath = saveFileDialog1.FileName + @".text";
                        StreamWriter myWrite = new StreamWriter(strSaveFilePath);

                        if (star4Clicked_2)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                if (star4Selected[i] == star4Array[i])
                                {
                                    bingo++;
                                }
                            }
                            if (bingo == 4)
                            {
                                if (tzutai4 == 0)
                                {
                                    MessageBox.Show("恭喜中4組彩");
                                    myWrite.Write("獎號: "+strList4+ "\n"+ "中獎訊息:恭喜中4組彩");

                                }
                                else if (tzutai6 == 0)
                                {
                                    MessageBox.Show("恭喜中6組彩");
                                    myWrite.Write("獎號: " + strList4 + "\n" + "中獎訊息:恭喜中6組彩");
                                }
                                else if (tzutai12)
                                {
                                    MessageBox.Show("恭喜中12組彩");
                                    myWrite.Write("獎號: " + strList4 + "\n" + "中獎訊息:恭喜中12組彩");
                                }
                                else if (tzutai24 == 0)
                                {
                                    MessageBox.Show("恭喜中24組彩");
                                    myWrite.Write("獎號: " + strList4 + "\n" + "中獎訊息:恭喜中24組彩");
                                }
                            }
                            else
                            {
                                MessageBox.Show("銘謝惠顧");
                                myWrite.Write("獎號: " + strList4 + "\n" + "中獎訊息:銘謝惠顧");
                            }
                        }
                        else if (star4Clicked_1)
                        {
                            int count = 0;
                            for (int i = 0; i < 4; i++)
                            {
                                
                                if(star4Selected2[i] == star4Array2[i])
                                {
                                    count++;
                                }
                            }
                            if(count == 4)
                            {
                                MessageBox.Show("恭喜中獎(正彩)");
                                myWrite.Write("獎號: " + strList4 + "\n" + "中獎訊息:恭喜中正彩");
                            }
                            else
                            {
                                MessageBox.Show("銘謝惠顧");
                                myWrite.Write("獎號: " + strList4 + "\n" + "中獎訊息:銘謝惠顧");
                            }
                        }
                        myWrite.Close();
                        MessageBox.Show(strSaveFilePath + " 存檔完成");
                    }
                }
                tzutai24 = 3;
                tzutai6 = 1;
                tzutai4 = 1;
                tzutai12 = false;
            }
            else
            {
                MessageBox.Show("請選擇四位數字");
            }
        }
        void calculate()
        {
            Array.Clear(star4Selected,0,3);
            for (int i = 0; i < 3; i++)
            {
                if (star4Array[i] != star4Array[i + 1])
                {
                    tzutai24--;
                }
            }
            for (int i = 0; i <= 2; i++)
            {               
                if (star4Array[i] == star4Array[i + 1])
                {
                    tzutai12 = true;
                }
                
            }
            for (int i = 0; i <= 1; i++)
            {
                if (star4Array[i] == star4Array[i + 1] && star4Array[i] == star4Array[i + 2])
                {
                    tzutai4--;
                }
            }
            if (star4Array[0] == star4Array[1] && star4Array[2] == star4Array[3])
            {
                tzutai6--;
            }
        }

        private void cbStar4_1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (star4Clicked_1 == false)
            {
                star4Clicked_1 = true;
                cbStar4_2.Enabled = false;
                btnsubmit4star.Enabled = true;
                cb1.Enabled = true;
                cb2.Enabled = true;
                cb3.Enabled = true;
                cb4.Enabled = true;
            }
            else
            {
                star4Clicked_1 = false;
                cbStar4_2.Enabled = true;
                btnsubmit4star.Enabled = false;
                cb1.Enabled = false;
                cb2.Enabled = false;
                cb3.Enabled = false;
                cb4.Enabled = false;
            }
        }

        private void cbStar4_2_CheckedChanged(object sender, EventArgs e)
        {
            if (star4Clicked_2 == false)
            {
                star4Clicked_2 = true;
                cbStar4_1.Enabled = false;
                btnsubmit4star.Enabled = true;
                cb1.Enabled = true;
                cb2.Enabled = true;
                cb3.Enabled = true;
                cb4.Enabled = true;
            }
            else
            {
                star4Clicked_2 = false;
                cbStar4_1.Enabled = true;
                btnsubmit4star.Enabled = false;
                cb1.Enabled = false;
                cb2.Enabled = false;
                cb3.Enabled = false;
                cb4.Enabled = false;
            }
        }
        int itimer = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            result();
            itimer++;
            date.Text = "第" + itimer.ToString() + "期";
            lblDateStar4.Text = "第" + itimer.ToString() + "期";
            lblDateWeiLi.Text = "第" + itimer.ToString() + "期";
            lblDate39.Text = "第" + itimer.ToString() + "期";
            lblNow.Text = string.Format($"{DateTime.Now}");
        }
    }   
}
