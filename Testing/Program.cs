using System;
using System.Collections.Generic;
using System.Linq;
using Cell;
using System.IO;
namespace Testing
{
    class Program
    {
        //StreamWriter sw = new StreamWriter(File.OpenRead("C:\\Users\\Artem\\Desktop\\kekev.txt"));
        public static int num = 1;
        static void Main(string[] args)
        {
            

            Dictionary<int, int> path = GeneratePath();
            foreach(var a in path)
            {
                Console.WriteLine("({0}, {1})", a.Key,a.Value);
            }

        }
        public static Dictionary<int, int> GeneratePath()
        {
            Dictionary<int,int> pathMemberAndArrow = new Dictionary<int, int>();
            Stack<Tuple<int,int>> queue = new Stack<Tuple<int, int>>();
            num++;
            PushNumberToQueue(queue, new List<int>() { 0 });
            while (queue.Count != 0)
            {
               /* Console.WriteLine("Queue");
                foreach (var a in queue)
                {
                    Console.Write("({0}, {1})", a.Item1, a.Item2);
                }
                Console.WriteLine();
                Console.WriteLine("Path");
                foreach (var a in pathMemberAndArrow)
                {
                    Console.Write("({0} :: {1}) ", a.Key, a.Value);
                }
                Console.WriteLine(pathMemberAndArrow.Count);*/
                Tuple<int, int> lastOfQueue = queue.Peek();
                List<int> legalWaysFromThisCell = WithouAlreadyUsed(pathMemberAndArrow, GetPossibleCells(lastOfQueue));
                if ((pathMemberAndArrow.Keys.Count == 24) &(!pathMemberAndArrow.Keys.Contains(24)&(PointsAt24(lastOfQueue))))
                {
                    pathMemberAndArrow.Add(lastOfQueue.Item1, lastOfQueue.Item2);
                    pathMemberAndArrow.Add(24,9);
                    return pathMemberAndArrow;
                }
                if ((legalWaysFromThisCell.Count != 0)&(!pathMemberAndArrow.ContainsKey(lastOfQueue.Item1)))
                {

                    Zakynuty(pathMemberAndArrow, queue, legalWaysFromThisCell);
                }
                else
                {
                    if (queue.Count != 0)
                    {
                        Vydalyty(queue, pathMemberAndArrow);
                    }
                }
            }
            return new Dictionary<int, int>() { { 999,999 } };
        }
        public static void PushNumberToQueue(Stack<Tuple<int,int>> queue, List<int> numbers)
        {
            List<int> indexes = GenerateRandomizedSequence(0, numbers.Count);
            foreach (int number in indexes)
            {
                foreach(var a in GenerateTuples(numbers[number]))
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
                if ((path.Count != 0)&(queue.Count!=0))
                {
                    while ((queue.Peek().Item1 == path.Keys.Last())&(queue.Peek().Item2 == path.Values.Last()))
                    {
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
            /*foreach (var a in path)
            {
                Console.Write("({0},{1}) ", a.Key, a.Value);
            }
            Console.WriteLine();*/
                var number = queue.Peek();
                path.Add(number.Item1, number.Item2);
                PushNumberToQueue(queue, numbers);
               // Console.WriteLine("({0}, {1})", number.Item1, number.Item2);
                Vydalyty(queue, path);
        }
        public static List<Tuple<int,int>> GenerateTuples(int origin)
        {
            Random rand = new Random();
            var temp = new List<Tuple<int, int>>() { Tuple.Create(origin, 1), Tuple.Create(origin, 2), Tuple.Create(origin, 3), Tuple.Create(origin, 4), Tuple.Create(origin, 5), Tuple.Create(origin, 6), Tuple.Create(origin, 7), Tuple.Create(origin, 8) };
            temp = temp.OrderBy(_ => rand.Next()).ToList();
            return temp;
        }

        public static List<int> GetPossibleCells(Tuple<int, int> originAndDirection)
        {
            List<int> possibleCells = new List<int>();
            int x = originAndDirection.Item1%5, y = originAndDirection.Item1 / 5;
            var tempCell = new CellClass(originAndDirection.Item2);
            while (true)
            {
                // Console.WriteLine("i={2}; j={3}; x-{0}; y-{1}; vertical- {4},horizontal- {5}", x, y, i, j, cellsArray[i, j].GetArrow().GetVertical(), cellsArray[i, j].GetArrow().GetHorizontal());
                x += tempCell.GetArrow().GetHorizontal();
                y += tempCell.GetArrow().GetVertical();
                if (CheckIfInBorders(x) & CheckIfInBorders(y))
                {
                    if ((y * 5 + x != 24)) { possibleCells.Add(y * 5 + x); }
                }
                else break;
            }
            return possibleCells;
        }

        public static bool CheckIfInBorders(int x)
        {
            return (x < 5) & (x > -1);
        }

        public static List<int> GenerateRandomizedSequence(int start,int endExcluded)
        {
            Random rand = new Random();
            List<int> sequence = new List<int>();
            HashSet<int> temp = new HashSet<int>();
            temp.Add(0);
            while (temp.Count != endExcluded - start)
            {
                temp.Add(rand.Next(start, endExcluded));
            }
            return temp.ToList();
        }

        public static bool PointsAt24(Tuple<int, int> originAndDirection)
        {
            List<int> possibleCells = new List<int>();
            int x = originAndDirection.Item1 % 5, y = originAndDirection.Item1 / 5;
            var tempCell = new CellClass(originAndDirection.Item2);
            while (CheckIfInBorders(x) & CheckIfInBorders(y))
            {
                //Console.WriteLine(x);
               // Console.WriteLine(y);
                // Console.WriteLine("i={2}; j={3}; x-{0}; y-{1}; vertical- {4},horizontal- {5}", x, y, i, j, cellsArray[i, j].GetArrow().GetVertical(), cellsArray[i, j].GetArrow().GetHorizontal());
                x += tempCell.GetArrow().GetHorizontal();
                y += tempCell.GetArrow().GetVertical();
                if ((y * 5 + x == 24))
                {
                    return true;
                }
                //else break;
            }
            return false;
        }
    }
}
