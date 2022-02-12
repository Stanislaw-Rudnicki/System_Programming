// Написать программу, которая рассчитывает факториалы чисел
// в пуле потоков и выводит в соответствующий TextBox.

using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Sp04_1_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var o in Controls.OfType<TextBox>()
                .OrderBy(t => t.Name)
                .Select((x, i) => new Tuple<TextBox, int>(x, i)))
            {
                ThreadPool.QueueUserWorkItem(JobForAThread, o);
            }
        }

        private void JobForAThread(object obj)
        {
            var o = obj as Tuple<TextBox, int>;
            if (!(o.Item2 is int @int) && @int < 0)
                throw new FormatException("The parameter must be greater than or equal to 0");
            BeginInvoke((MethodInvoker)(() => o.Item1.Text = Factorial(@int).ToString()));
        }

        private int Factorial(int n)
        {
            return n == 0 ? 1 : n * Factorial(n - 1);
        }
    }
}
