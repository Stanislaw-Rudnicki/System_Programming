// Создайте поток, который «принимает» в себя коллекцию элементов,
// и вызывает из каждого элемента коллекции метод ToString()
// и выводит результат работы метода на экран.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sp02_1_01
{
    class Program
    {
        static void Main(string[] args)
        {
            ParameterizedThreadStart threadstart = new ParameterizedThreadStart(ThreadFunk);

            // Запуск первого потока.
            Thread thread1 = new Thread(threadstart);
            thread1.Start(Enumerable.Range(0, 10).ToList());
        }

        static void ThreadFunk(object col)
        {
            // Получаем List<int> из прнятого object.
            List<int> collection = (List<int>)col;

            collection.ForEach(i => Console.WriteLine(i.ToString()));
        }
    }
}
