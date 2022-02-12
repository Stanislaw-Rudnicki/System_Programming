// Написать программу, которая копирует файл блоками по 4096 байт в указанное место.
// Должна отображать прогресс копирования с помощью ProgressBar.
// Пользователь может указать пути к файлам с помощью клавиатуры
// или с помощью диалогового окна, которое отображается при нажатии кнопок “Файл”.
// Запуск копирования происходит при нажатии кнопки “Копировать”
// или клавиши Enter в текстовом поле, где указывается путь куда копировать.
// GUI должен отвечать на действия пользователя в момент работы.

using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Sp03_1_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonFile1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            textBox1.Text = openFileDialog1.FileName;
        }

        private void buttonFile2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = openFileDialog1.FileName;
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            textBox2.Text = saveFileDialog1.FileName;
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            if (!File.Exists(textBox1.Text))
            {
                textBox1.Focus();
                return;
            }
            if (textBox1.Text == textBox2.Text)
            {
                textBox2.Focus();
                return;
            }

            ThreadStart threadstart = new ThreadStart(() =>
            {
                try
                {
                    var from = new FileInfo(textBox1.Text);
                    var to = new FileInfo(textBox2.Text);

                    if (!to.Exists)
                        to.Create().Dispose();

                    using (var fromStream = from.OpenRead())
                    using (var toStream = to.OpenWrite())
                    {
                        byte[] buffer = new byte[4096];
                        int count;
                        long readed = 0;
                        long total = from.Length;

                        while ((count = fromStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            toStream.Write(buffer, 0, count);

                            readed += count;

                            int percent = Convert.ToInt32((readed * 100) / total);

                            //Отображаем прогресс
                            this.BeginInvoke(new Action<int>(perc =>
                            {
                                this.progressBar1.Value = perc;
                            }), percent);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    textBox2.Invoke((MethodInvoker)delegate () { textBox2.Focus(); });
                }
                buttonCopy.Invoke((MethodInvoker)delegate () { buttonCopy.Enabled = true; });
            });

            Thread thread = new Thread(threadstart);
            buttonCopy.Enabled = false;
            thread.Start();
        }

        private void textBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonCopy_Click(sender, e);
            }
        }
    }
}
