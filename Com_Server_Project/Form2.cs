using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Com_Server_Project
{
    public partial class Form2 : Form
    {
        Button[,] GetButtons = new Button[7, 7];
        int[,] board = new int[7, 7];
        int[] temp = new int[7];
        int[] idx = new int[7];
        int flag;

        public Form2()
        {
            InitializeComponent();
            intitAreaButton();
            Initialize();
            Payer.Text = Com_Server_Project.Form1.instance.serialPort1.PortName;
        }

        private void intitAreaButton() {
            GetButtons[0, 0] = btn00;
            GetButtons[0, 1] = btn01;
            GetButtons[0, 2] = btn02;
            GetButtons[0, 3] = btn03;
            GetButtons[0, 4] = btn04;
            GetButtons[0, 5] = btn05;
            GetButtons[0, 6] = btn06;

            GetButtons[1, 0] = btn10;
            GetButtons[1, 1] = btn11;
            GetButtons[1, 2] = btn12;
            GetButtons[1, 3] = btn13;
            GetButtons[1, 4] = btn14;
            GetButtons[1, 5] = btn15;
            GetButtons[1, 6] = btn16;

            GetButtons[2, 0] = btn20;
            GetButtons[2, 1] = btn21;
            GetButtons[2, 2] = btn22;
            GetButtons[2, 3] = btn23;
            GetButtons[2, 4] = btn24;
            GetButtons[2, 5] = btn25;
            GetButtons[2, 6] = btn26;


            GetButtons[3, 0] = btn30;
            GetButtons[3, 1] = btn31;
            GetButtons[3, 2] = btn32;
            GetButtons[3, 3] = btn33;
            GetButtons[3, 4] = btn34;
            GetButtons[3, 5] = btn35;
            GetButtons[3, 6] = btn36;

            GetButtons[4, 0] = btn40;
            GetButtons[4, 1] = btn41;
            GetButtons[4, 2] = btn42;
            GetButtons[4, 3] = btn43;
            GetButtons[4, 4] = btn44;
            GetButtons[4, 5] = btn45;
            GetButtons[4, 6] = btn46;

            GetButtons[5, 0] = btn50;
            GetButtons[5, 1] = btn51;
            GetButtons[5, 2] = btn52;
            GetButtons[5, 3] = btn53;
            GetButtons[5, 4] = btn54;
            GetButtons[5, 5] = btn55;
            GetButtons[5, 6] = btn56;

            GetButtons[6, 0] = btn60;
            GetButtons[6, 1] = btn61;
            GetButtons[6, 2] = btn62;
            GetButtons[6, 3] = btn63;
            GetButtons[6, 4] = btn64;
            GetButtons[6, 5] = btn65;
            GetButtons[6, 6] = btn66;
        }
        private void Initialize()
        {
            flag = 1;
            for (int i = 0; i < 7; ++i)
                for (int j = 0; j < 7; ++j) {
                    board[i, j] = 0;
                    idx[j] = 6;
                    temp[j] = 6;
                }
        }
        private void setBoardColor()
        {
            for (int i = 0; i < 7; ++i)
            {
                for (int j = 0; j < 7; ++j)
                {
                    if (board[i, j] == 1) GetButtons[i, j].BackColor = Color.LightGreen;
                    else if (board[i, j] == 2) GetButtons[i, j].BackColor = Color.OrangeRed;
                }
            }
        }

        # region Checks Fuctions

        private Boolean checkRow() {
            bool isAns = true;
            for (int i = 0; i < 7; ++i) {
                for (int j = 0; j < 4; ++j) {
                    for (int k = 0; k < 4; ++k)
                        if (board[i, j + k] != 1)
                        { isAns = false;
                            break;
                        }
                }
            }
            return isAns;



        }

        private Boolean checkColmun()
        {
            bool isAns = true;
            for (int i = 0; i < 7; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    for (int k = 0; k < 4; ++k)
                        if (board[j + k, i] != 1)
                        {
                            isAns = false;
                            break;
                        }
                }
            }
            return isAns;



        }

        private Boolean checkPrimaryRaduis()
        {
            bool isAns = true;
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    for (int k = 0; k < 4; ++k)
                        if (board[i + k, j + k] != 1)
                        {
                            isAns = false;
                            break;
                        }
                }
            }
            return isAns;



        }

        private Boolean checkSecondRaduis()
        {
            bool isAns = true;
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 7; ++j)
                {
                    for (int k = 0; k < 4; ++k)
                        if (board[i + k, j - k] != 1)
                        {
                            isAns = false;
                            break;
                        }
                }
            }
            return isAns;



        }
        #endregion
        #region  Click Buttons 
        private void add0_Click(object sender, EventArgs e)
        {
            if (idx[0] >= 0)
            {
                board[idx[0], 0] = 1;
                idx[0]--;
                setBoardColor();
            }
            else
                MessageBox.Show(" isFull ");


        }

        private void add1_Click(object sender, EventArgs e)
        {
            if (idx[1] >= 0)
            {
                board[idx[1], 1] = 1;
                idx[1]--;
                setBoardColor();
            }

            else
                MessageBox.Show(" isFull ");

        }

        private void add2_Click(object sender, EventArgs e)
        {
            if (idx[2] >= 0)
            {
                board[idx[2], 2] = 1;
                idx[2]--;
                setBoardColor();
            }
            else
                MessageBox.Show(" isFull ");
        }

        private void add3_Click(object sender, EventArgs e)
        {
            if (idx[3] >= 0) {
            board[idx[3], 3] = 1;
            idx[3]--;
            setBoardColor();

        }
                       else
                MessageBox.Show(" isFull ");
        
}
        private void add4_Click(object sender, EventArgs e)
        {
            if (idx[4] >= 0)
            {
                board[idx[4], 4] = 1;
                idx[4]--;
                setBoardColor();
            }
            else
                MessageBox.Show(" isFull ");
        }

        private void add5_Click(object sender, EventArgs e)
        {
            if (idx[5] >= 0)
            {
                board[idx[5], 5] = 1;
                idx[5]--;
                setBoardColor();
            }
            else
                MessageBox.Show(" isFull ");

        }

        private void add6_Click(object sender, EventArgs e)
        {
            if (idx[6] >= 0)
            {
                board[idx[6], 6] = 1;
                idx[6]--;
                setBoardColor();
            }
            else
                MessageBox.Show(" isFull ");
        }

        #endregion
    }
}
