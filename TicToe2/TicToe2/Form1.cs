using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicToe2
{
    public partial class Form1 : Form
    {
        bool turn = true;
        int turn_count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developed By Wajahat");
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button) sender;

            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }

            turn = !turn;
            b.Enabled = false;
            turn_count++;

            check_winner();

        }

        private void check_winner()
        {
            Boolean there_is_Winner = false;

            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                there_is_Winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                there_is_Winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                there_is_Winner = true;

            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                there_is_Winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                there_is_Winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                there_is_Winner = true;

            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                there_is_Winner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
                there_is_Winner = true;



            if (there_is_Winner)
            {
                disable_btn();

                string winner = "";

                if (turn)
                {
                    winner = "O";
                    o_win_count.Text=(Int32.Parse(o_win_count.Text) + 1).ToString();             
                }
                else
                {
                    winner = "X";
                    x_win_count.Text=(Int32.Parse(o_win_count.Text) + 1).ToString();                                
                }

                MessageBox.Show(winner + " Wins");
            }
            else
            {
                if (turn_count == 9)
                {
                    draw_count.Text=(Int32.Parse(o_win_count.Text) + 1).ToString();           
                    MessageBox.Show("Game Draw");
                }
            }
        }

        private void disable_btn()
        {
            try
            {

                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;

                foreach (Control c in Controls)
                {
                     try
            {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }         
                    catch { }
                }

            }
            
        

        private void Button_Enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";

            }
        }

        private void Button_Leave(object sender, EventArgs e)
        {
            
             Button b = (Button)sender;

            if(b.Enabled)
                b.Text = " ";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x_win_count.Text = "0";
            draw_count.Text = "0";
            o_win_count.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
