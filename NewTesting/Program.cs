using System;
using System;
using System.Collections.Generic;
using System.Linq;
using Cell;

namespace NewTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> pathMemberAndArrow = new Dictionary<int, int>();
            Stack<Tuple<int, int>> queue = new Stack<Tuple<int, int>>();
            PushNumbersToQueue(queue,new List<int>() { 0});
            foreach(var a in queue)
            {
                Console.Write("({0}, {1})",a.Item1,a.Item2);
            }
            Console.WriteLine();
            var lastOfQueue = queue.Peek();
            var b = GetPossibleCells(lastOfQueue);
            foreach (var a in b)
            {
                Console.WriteLine("({0}) ",a);
            }
            Vydalyty(queue, pathMemberAndArrow);
            foreach (var a in queue)
            {
                Console.Write("({0}, {1})", a.Item1, a.Item2);
            }
            Console.WriteLine();
            Console.WriteLine(queue.Peek());
            lastOfQueue = queue.Peek();
            b = GetPossibleCells(lastOfQueue);
            foreach (var a in b)
            {
                Console.WriteLine("({0}) ", a);
            }
            Vydalyty(queue, pathMemberAndArrow);
            foreach (var a in queue)
            {
                Console.Write("({0}, {1})", a.Item1, a.Item2);
            }
            lastOfQueue = queue.Peek();
            b = GetPossibleCells(lastOfQueue);
            foreach (var a in b)
            {
                Console.WriteLine("({0}) ", a);
            }
            PushNumbersToQueue(queue,WithouAlreadyUsed(pathMemberAndArrow, b));
            Console.WriteLine("Queue");
            foreach (var a in queue)
            {
                Console.Write("({0}, {1})", a.Item1, a.Item2);
            }
            Console.WriteLine();
        }

        public static void PushNumbersToQueue(Stack<Tuple<int, int>> queue, List<int> numbers)
        {
            List<int> indexes = GenerateRandomizedSequence(0, numbers.Count);
            foreach (int number in indexes)
            {
                foreach (var a in GenerateTuples(numbers[number]))
                {
                    queue.Push(a);
                }
            }
        }
        public static List<int> WithouAlreadyUsed(Dictionary<int, int> pathMemberAndArrow, List<int> originalNumbers)
        {
            List<int> nonUsedNumbers = new List<int>();
            foreach (int number in originalNumbers)
            {
                if (!pathMemberAndArrow.Keys.Contains(number))
                {
                    nonUsedNumbers.Add(number);
                }
            }
            return nonUsedNumbers;
        }
        public static void Vydalyty(Stack<Tuple<int, int>> queue, Dictionary<int, int> path)
        {
 
            queue.Pop();
            if ((path.Count != 0))
            {
                while (queue.Peek() == Tuple.Create<int, int>(path.Keys.Last(), path.Values.Last()))
                {
                    if (path.Keys.Last() == 0)
                    {
                        Console.WriteLine("({0}, {1})", path.Keys.Last(), path.Values.Last());
                    }
                    path.Remove(path.Keys.Last());
                    queue.Pop();
                    if ((queue.Count < 1) | (path.Count < 1))
                    {
                        return;
                    }
                }
            }

        }
        public static void Zakynuty(Dictionary<int, int> path, Stack<Tuple<int, int>> queue, List<int> numbers)
        {

            foreach (var a in path)
            {
                Console.Write("({0},{1}) ", a.Key, a.Value);
            }
            Console.WriteLine();
            try
            {
                var number = queue.Peek();
                path.Add(number.Item1, number.Item2);
                PushNumbersToQueue(queue, numbers);
            }
            catch (ArgumentException)
            {
                var number = queue.Peek();
                Console.WriteLine("({0}, {1})", number.Item1, number.Item2);
                Vydalyty(queue, path);
            }
        }
        public static List<Tuple<int, int>> GenerateTuples(int origin)
        {
            return new List<Tuple<int, int>>() { Tuple.Create(origin, 1), Tuple.Create(origin, 2), Tuple.Create(origin, 3), Tuple.Create(origin, 4), Tuple.Create(origin, 5), Tuple.Create(origin, 6), Tuple.Create(origin, 7), Tuple.Create(origin, 8) };
        }

        public static List<int> GetPossibleCells(Tuple<int, int> originAndDirection)
        {
            List<int> possibleCells = new List<int>();
            int x = originAndDirection.Item1 % 5, y = originAndDirection.Item1 / 5;
            var tempCell = new CellClass(originAndDirection.Item2);
            while (true)
            {
                // Console.WriteLine("i={2}; j={3}; x-{0}; y-{1}; vertical- {4},horizontal- {5}", x, y, i, j, cellsArray[i, j].GetArrow().GetVertical(), cellsArray[i, j].GetArrow().GetHorizontal());
                x += tempCell.GetArrow().GetHorizontal();
                y += tempCell.GetArrow().GetVertical();
                if (CheckIfInBorders(x) & CheckIfInBorders(y) & (y * 5 + x != 24))
                {
                    possibleCells.Add(y * 5 + x);
                }
                else break;
            }
            return possibleCells;
        }

        public static bool CheckIfInBorders(int x)
        {
            return (x < 5) & (x > -1);
        }

        public static List<int> GenerateRandomizedSequence(int start, int endExcluded)
        {
            Random rand = new Random();
            List<int> sequence = new List<int>();
            HashSet<int> temp = new HashSet<int>();
            temp.Add(0);
            while (temp.Count != endExcluded - start)
            {
                temp.Add(rand.Next(start, endExcluded));
            }
            Console.WriteLine("Start: {0}, Excluded: {1}, Result: {2}", start, endExcluded, temp.Count);
            return temp.ToList();
        }
    }
}

/*  Console.WriteLine("path");
   foreach (var a in path)
   {
       Console.Write("({0},{1}) ", a.Key, a.Value);
   }
   Console.WriteLine();
   Console.WriteLine("Last of queue");
   Console.WriteLine("({0}, {1})", queue.Peek().Item1, queue.Peek().Item2);
   Console.WriteLine();*/

/*Console.WriteLine("path");
foreach(var a in path)
{
    Console.Write("({0},{1}) ",a.Key,a.Value);
}
Console.WriteLine();*/
/* Console.WriteLine("legal ways");
 foreach (var a in numbers)
 {
     Console.Write("{0} ", a);
 }*/
/*Console.WriteLine();
Console.WriteLine("Last of queue");
Console.WriteLine("({0}, {1})",queue.Peek().Item1,queue.Peek().Item2);*/