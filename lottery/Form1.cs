using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lottery
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int Num = 38;
            int[] index = new int[Num];
            int[] numArray = new int[6];

            Random random = new Random();

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

            lblNum01.Text = numArray[0].ToString();
            lblNum02.Text = numArray[1].ToString();
            lblNum03.Text = numArray[2].ToString();
            lblNum04.Text = numArray[3].ToString();
            lblNum05.Text = numArray[4].ToString();
            lblNum06.Text = numArray[5].ToString();
            lblNum07.Text = random.Next(1, 8).ToString();
        }

        
    }
}
