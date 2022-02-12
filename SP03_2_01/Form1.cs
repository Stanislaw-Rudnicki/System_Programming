// Создать генератор случайных чисел
// и во время генерации программа должна проверять
// является ли число совершенное и фибоначчи.
// Программа должна работать по такому принципу:
// первый поток генерирует числа, второй проверяет является ли число совершенным,
// третий поток проверяет является ли число фибоначчи,
// а в четвертом потоке должен быть progressbar.
// Первый поток должен ждать, пока второй и третий поток проверит число
// и только потом генерировать новое число,
// т.е. одно сгенерировал число, проверил и дальше генерирует.

using System;
using System.Threading;
using System.Windows.Forms;

namespace Sp03_2_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            numericUpDown1.Select();
        }

        private const int MAX_VALUE = 30;
        private volatile int i = 0;
        private int number = 0;

        // Initialized set to ensure that the producer goes first.
        private EventWaitHandle consumed1 = new AutoResetEvent(true);

        // Initialized not set to ensure consumer waits until first producer run.
        private EventWaitHandle consumed3 = new AutoResetEvent(false);
        private EventWaitHandle consumed2 = new AutoResetEvent(false);
        private EventWaitHandle produced = new AutoResetEvent(false);

        private void button1_Click(object sender, EventArgs e)
        {
            i = 0;
            this.BeginInvoke(new Action<int>(perc =>
            {
                this.progressBar1.Value = perc;
            }), 0);
            new Thread(Consumer3).Start();
            new Thread(Consumer2).Start();
            new Thread(Consumer1).Start();
            new Thread(Producer).Start();
        }

        public void Producer()
        {
            Random rnd = new Random();

            while (i < numericUpDown1.Value)
            {
                consumed1.WaitOne();
                if (i < numericUpDown1.Value)
                {
                    number = rnd.Next(MAX_VALUE + 1);
                    BeginInvoke((MethodInvoker)(() => listBox1.Items.Add(number)));
                    Thread.Sleep(100);
                }
                produced.Set();
            }
        }

        public void Consumer1()
        {
            while (i < numericUpDown1.Value)
            {
                produced.WaitOne();
                if (i < numericUpDown1.Value)
                {
                    int n = number;
                    if (isPerfect(n))
                        BeginInvoke((MethodInvoker)(() => listBox2.Items.Add(n)));
                }
                consumed2.Set();
            }
        }

        public void Consumer2()
        {
            while (i < numericUpDown1.Value)
            {
                consumed2.WaitOne();
                if (i < numericUpDown1.Value)
                {
                    int n = number;
                    if (isFibonacci(n))
                        BeginInvoke((MethodInvoker)(() => listBox3.Items.Add(n)));
                }
                consumed3.Set();
            }
        }
        
        public void Consumer3()
        {
            while (i < numericUpDown1.Value + 1)
            {
                consumed3.WaitOne();

                int percent = Convert.ToInt32((i * 100) / numericUpDown1.Value);

                //Отображаем прогресс
                this.BeginInvoke(new Action<int>(perc =>
                {
                    this.progressBar1.Value = perc;
                }), percent);

                i++;
                consumed1.Set();
            }
        }

        private bool isPerfect(int n)
        {
            int sum = 1;
            for (int i = 2; i < Math.Sqrt(n); i++)
                if (n % i == 0)
                    sum += i + n / i;
            return sum == n && sum != 1;
        }

        private bool isFibonacci(int w)
        {
            double X1 = 5 * Math.Pow(w, 2) + 4;
            double X2 = 5 * Math.Pow(w, 2) - 4;

            long X1_sqrt = (long)Math.Sqrt(X1);
            long X2_sqrt = (long)Math.Sqrt(X2);

            return (X1_sqrt * X1_sqrt == X1) || (X2_sqrt * X2_sqrt == X2);
        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                button1.Focus();
                button1_Click(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            progressBar1.Value = 0;
        }
    }
}
