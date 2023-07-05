using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace ScrollBars_n_Indicators
{    
    public partial class Form1 : Form
    {
        public Form Tools;
        Form2 newForm = new Form2();
        public Form1()
        {
            InitializeComponent();
            ShowToolTip();
            
        }
        public void ShowToolTip()
        {
            System.Windows.Forms.ToolTip myToolTip = new System.Windows.Forms.ToolTip();
            myToolTip.AutoPopDelay = 5000; // Время отображения
            myToolTip.InitialDelay = 1000; // Начальная задержка
            myToolTip.ReshowDelay = 100; // Задержка при повторном наведении
            
            myToolTip.ShowAlways = /*false */true; // Показывать подсказки когда
                                                   // родительское окно не активно
            //myToolTip.ShowAlways = false /*true*/;

            //myToolTip.IsBalloon = true;

            myToolTip.SetToolTip(this.vScrollBar1, "Перемещение объекта TextBox по вертикали");
            myToolTip.SetToolTip(this.hScrollBar1, "Нужно сделать TextBox перемещение объекта по горизонтали");
            myToolTip.SetToolTip(pictureBox1, "Картинка");
       }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            
            vScrollBar1.Minimum = 0;            
            vScrollBar1.Maximum = 120;
            textBox1.Location = new Point(textBox1.Location.X,
                vScrollBar1.Value + 10);
            
            textBox1.Text = $"{textBox1.Location.X} : {textBox1.Location.Y}";
        }


        private void btnStartPB_MouseClick(object sender, MouseEventArgs e)
        {
            Timer timerPB = new Timer();
            timerPB.Enabled = true;
            timerPB.Interval = 1000;
            timerPB.Tick += TimerPB_Tick;
        }
        
        private void TimerPB_Tick(object sender, EventArgs e)
        {
            btnStartPB.Text = progBarDemo.Value.ToString();
            progBarDemo.PerformStep();
            //Text = ((Timer)sender).Interval.ToString();
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
            //numericUpDown1.
            var X = 445 + (int)numericUpDown1.Value;
            pictureBox1.Location = new Point(X, pictureBox1.Location.Y);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            int Y = 137 + trackBar1.Value * 10;
            pictureBox1.Location = new Point(pictureBox1.Location.X, Y);
        }

        private void createElements(Form _form)
        {
            TextBox tbTools = new TextBox();
            tbTools.Location = new Point(10,10);
            tbTools.Size = new Size(50, 10);
            _form.Controls.Add(tbTools);
        }
        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            if (Tools != null )
            {
                Tools.Dispose();
                Tools.Close();
                Tools = null;
                newForm.Hide();
            }
            else
            {
                Tools = new Form();
                createElements(Tools);
                Tools.Text = "Настройки";
                Tools.Show();
                newForm.Show();
            }
        }

        
    }
}
