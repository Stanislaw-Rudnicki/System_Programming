// Разработать Windows Forms приложение,
// которое будет использовать объект-семафор следующим образом:
// По нажатию на кнопку «Создать поток» создается новый поток и помещается в первый список,
// где находятся все созданные потоки.
// Порядковый номер потока берется от 1 и увеличивается на один.
// При двойном клике на потоке, поток перемещается в список ожидающих потоков,
// где он будет находиться до тех пор, пока в семафоре не освободится для него место.
// Как только такое место освободилось, поток перемещается из списка ожидания
// в список рабочих потоков и приступает к работе.
// Работа заключается в том, чтобы увеличивать локальный счетчик каждого потока
// на единицу в секунду и отображать это значение.
// При двойном клике по потоку в списке рабочих потоков – поток прекращает свою работу,
// удаляется из списка и освобождает место для очередного ожидающего потока.
// Количество свободных мест задается в счетчике.
// При изменении счетчика более «старые» потоки покидают список,
// если произошло уменьшение счетчика, или же добавляются новые «ожидающие» потоки
// при увеличении значения счетчика.
// Изменение размера формы происходит динамически,
// подстраиваясь под наибольшее количество потоков в каком-либо списке.
// Примерный вид приложения смотрите ниже (хотя собственная креативность приветствуется).


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sp04_2_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Source = new ThreadedBindingList<ListBoxThread>();
            listBox1.DataSource = Source;
            button1.Select();
        }

        ThreadedBindingList<ListBoxThread> Source;
        int itemHeight;

        private void button1_Click(object sender, EventArgs e)
        {
            listBox3.AddToListBox(new ListBoxThread());
            itemHeight = listBox3.GetItemRectangle(0).Height;
            HeightAdjust();
        }

        private void listBox3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBox3.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                if (Source.Count < numericUpDown1.Value)
                {
                    listBox1.HeightIncrease();
                    (listBox3.Items[index] as ListBoxThread).worker.Start();
                    Source.Add(listBox3.Items[index] as ListBoxThread);
                    listBox1.ClearSelected();
                }
                else
                {
                    (listBox3.Items[index] as ListBoxThread).State = "ожидает";
                    listBox2.AddToListBox(listBox3.Items[index]);
                }
                listBox3.Items.RemoveAt(index);
            }
            HeightAdjust();
        }
        
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBox1.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                Source[index].worker.Abort();
                Source.RemoveAt(index);
                if (Source.Count < numericUpDown1.Value && listBox2.Items.Count != 0)
                {
                    listBox1.HeightIncrease();
                    (listBox2.Items[0] as ListBoxThread).worker.Start();
                    Source.Add(listBox2.Items[0] as ListBoxThread);
                    listBox2.Items.RemoveAt(0);
                }
                listBox1.ClearSelected();
                HeightAdjust();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (Source.Count < numericUpDown1.Value && listBox2.Items.Count != 0)
            {
                listBox1.HeightIncrease();
                (listBox2.Items[0] as ListBoxThread).worker.Start();
                Source.Add(listBox2.Items[0] as ListBoxThread);
                listBox2.Items.RemoveAt(0);
                listBox1.ClearSelected();
            }
            else if (Source.Count > numericUpDown1.Value)
            {
                if (Source.Count != 0)
                {
                    Source[0].worker.Abort();
                    Source.RemoveAt(0);
                    listBox1.ClearSelected();
                }
            }
            HeightAdjust();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var item in Source)
            {
                item.worker.Abort();
            }
        }

        public void HeightAdjust()
        {
            if (listBox1.Items.Count > 2 || listBox2.Items.Count > 2 || listBox3.Items.Count > 2)
                listBox1.Height = listBox2.Height = listBox3.Height = itemHeight + itemHeight *
                    Math.Max(listBox1.Items.Count, Math.Max(listBox2.Items.Count, listBox3.Items.Count));
        }
    }

    public static class ListBoxExtension
    {
        public static void AddToListBox(this ListBox listBox, object item)
        {
            if (listBox.Items.Count > 2)
                listBox.Height += listBox.GetItemRectangle(0).Height;
            listBox.Items.Add(item);
        }

        public static void HeightIncrease(this ListBox listBox)
        {
            if (listBox.Items.Count > 2)
                listBox.Height += listBox.GetItemRectangle(0).Height;
        }
    }

    public class ListBoxThread : INotifyPropertyChanged
    {
        private static int quantity = 0;
        public int Id { get; set; }
        
        private int _counter = 0;
        public int Counter
        {
            get { return _counter; }
            set
            {
                _counter = value;
                OnPropertyChanged();
            }
        }

        public string State { get; set; } = "создан";

        public Thread worker;

        public ListBoxThread()
        {
            quantity += 1;
            Id = quantity;
            worker = new Thread(() =>
            {
                while (true)
                {
                    Counter += 1;
                    Thread.Sleep(1000);
                }
            });
            //worker.Start();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public override string ToString()
        {
            string s = (Counter != 0) ? Counter.ToString() : State;
            return $"Поток { Id } --> { s }";
        }
    }

    public class ThreadedBindingList<T> : BindingList<T>
    {
        SynchronizationContext ctx = SynchronizationContext.Current;
        protected override void OnAddingNew(AddingNewEventArgs e)
        {
            if (ctx == null) { BaseAddingNew(e); }
            else { ctx.Send(delegate { BaseAddingNew(e); }, null); }
        }
        protected override void OnListChanged(ListChangedEventArgs e)
        {
            if (ctx == null) { BaseListChanged(e); }
            else { ctx.Send(delegate { BaseListChanged(e); }, null); }
        }
        void BaseListChanged(ListChangedEventArgs e) { base.OnListChanged(e); }
        void BaseAddingNew(AddingNewEventArgs e) { base.OnAddingNew(e); }
    }
}
