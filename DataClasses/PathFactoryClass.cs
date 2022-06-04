using System;
using System.Collections.Generic;
using System.Linq;
using CellClass;
namespace pathFactory
{
    public class FieldFactoryClass
    {
        public Stack<int> GeneratePath(List<int>[] possibleMoves,int seventeenth)
        {
            Stack<int> path = new Stack<int>();
            Stack<int> queue = new Stack<int>();
            path.Push(0);
            PushNumbersToQueue(queue, WithouAlreadyUsed(path,possibleMoves[0]));
            while (queue.Count != 0)
            {
                int lastOfQueue = queue.Peek();
                List<int> legalWaysFromThisCell = WithouAlreadyUsed(path, possibleMoves[lastOfQueue]);
                if ((path.Count == 24) & (lastOfQueue == 24))
                {
                    path.Push(24);
                    return path;
                }
                if (legalWaysFromThisCell.Count != 0)
                {
                    if ((path.Count == 17) & (path.Peek()!= seventeenth))
                    {
                        Vydalyty(queue, path);
                        continue;
                    }
                    Zakynuty(path, queue, legalWaysFromThisCell);
                }
                else
                {
                    if (queue.Count != 0)
                    {
                        Vydalyty(queue, path);
                    }
                }
            }
            return new Stack<int>();
        }
        public static void PushNumbersToQueue(Stack<int> queue,List<int> numbers)
        {
            foreach(int number in numbers)
            {
                queue.Push(number);
            }
        }
        public static List<int> WithouAlreadyUsed(Stack<int> path, List<int> originalNumbers)
        {
            List<int> nonUsedNumbers = new List<int>();
            foreach(int number in originalNumbers)
            {
                if (!path.Contains(number))
                {
                    nonUsedNumbers.Add(number);
                }
            }
            return nonUsedNumbers;
        }
        public static void Vydalyty(Stack<int> queue, Stack<int> path)
        {
            queue.Pop();
            while (queue.Peek() == path.Peek())
            {
                path.Pop();
                queue.Pop();
                if ((queue.Count < 1) | (path.Count < 1))
                {
                    return;
                }
            }
        }
        public void Zakynuty(Stack<int> path,Stack<int> queue, List<int> numbers)
        {
            int number = queue.Peek();
            path.Push(number);
            PushNumbersToQueue(queue, numbers);
        }

        public Dictionary<int, int> GenerateRandomRawFieldData()
        {
            Dictionary<int, int> pathMemberAndArrow = new Dictionary<int, int>();
            Stack<Tuple<int, int>> queue = new Stack<Tuple<int, int>>();
            PushNumberToQueue(queue, new List<int>() { 0 });
            while (queue.Count != 0)
            {
                Tuple<int, int> lastOfQueue = queue.Peek();
                List<int> legalWaysFromThisCell = WithouAlreadyUsed(pathMemberAndArrow, GetPossibleCells(lastOfQueue));
                if ((pathMemberAndArrow.Keys.Count == 23) & (!pathMemberAndArrow.Keys.Contains(24) & (PointsAt24(lastOfQueue))))
                {
                    pathMemberAndArrow.Add(lastOfQueue.Item1, lastOfQueue.Item2);
                    pathMemberAndArrow.Add(24, 9);
                    return pathMemberAndArrow;
                }
                if ((legalWaysFromThisCell.Count != 0) & (!pathMemberAndArrow.ContainsKey(lastOfQueue.Item1)))
                {

                    Zakynuty(pathMemberAndArrow, queue, legalWaysFromThisCell);
                }
                else
                {
                        Vydalyty(queue, pathMemberAndArrow);
                }
            }
            return new Dictionary<int, int>() { { 999, 999 } };
        }
        public static void PushNumberToQueue(Stack<Tuple<int, int>> queue, List<int> numbers)
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
            if ((path.Count != 0) & (queue.Count != 0))
            {
                while ((queue.Peek().Item1 == path.Keys.Last()) & (queue.Peek().Item2 == path.Values.Last()))
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
            var number = queue.Peek();
            path.Add(number.Item1, number.Item2);
            PushNumberToQueue(queue, numbers);
            //Vydalyty(queue, path);
        }
        public static List<Tuple<int, int>> GenerateTuples(int origin)
        {
            Random rand = new Random();
            var temp = new List<Tuple<int, int>>() { Tuple.Create(origin, 1), Tuple.Create(origin, 2), Tuple.Create(origin, 3), Tuple.Create(origin, 4), Tuple.Create(origin, 5), Tuple.Create(origin, 6), Tuple.Create(origin, 7), Tuple.Create(origin, 8) };
            temp = temp.OrderBy(_ => rand.Next()).ToList();
            return temp;
        }

        public static List<int> GetPossibleCells(Tuple<int, int> originAndDirection)
        {
            List<int> possibleCells = new List<int>();
            int x = originAndDirection.Item1 % 5, y = originAndDirection.Item1 / 5;
            var tempCell = new Cell(originAndDirection.Item2);
            while (true)
            {
                
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

        public static List<int> GenerateRandomizedSequence(int start, int endExcluded)
        {
            Random rand = new Random();
            List<int> sequence = new List<int>();
            HashSet<int> temp = new HashSet<int>();
            temp.Add(0);
            while (temp.Count != endExcluded - start)
            {
                temp.Add(rand.Next(start + 1, endExcluded));
            }
            return temp.ToList();
        }

        public static bool PointsAt24(Tuple<int, int> originAndDirection)
        {
            int x = originAndDirection.Item1 % 5, y = originAndDirection.Item1 / 5;
            var tempCell = new Cell(originAndDirection.Item2);
            x += tempCell.GetArrow().GetHorizontal();
            y += tempCell.GetArrow().GetVertical();
            while (CheckIfInBorders(x) & CheckIfInBorders(y))
            {
                if (y * 5 + x == 24)
                {
                    return true;
                }
                else
                {
                    x += tempCell.GetArrow().GetHorizontal();
                    y += tempCell.GetArrow().GetVertical();
                }
            }
            return false;
        }
    }
}
