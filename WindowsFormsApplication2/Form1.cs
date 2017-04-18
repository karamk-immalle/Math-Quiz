using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();

        int addend1;
        int addend2;

        int timeleft;
        public Form1()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void StartTheQuiz()
        {
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            sum.Value = 0;

            timeleft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            Start.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswers())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congratulations!");
                Start.Enabled = true;
            }

            if (timeleft > 0)
            {
                timeleft = timeleft - 1;
                timeLabel.Text = timeleft + "seconds";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time is up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                Start.Enabled = true;
            }
        }

        private bool CheckTheAnswers()
        {
            if (addend1 + addend2 == sum.Value)
                return true;
            else
                return false;
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerbox = sender as NumericUpDown;

            if (answerbox != null)
            {
                int lengthOfAnswer = answerbox.Value.ToString().Length;
                answerbox.Select(0, lengthOfAnswer);
            }
        }
    }
}
