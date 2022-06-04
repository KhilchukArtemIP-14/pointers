using System;
using CellClass;
using System.Collections.Generic;
using pathFactory;
namespace Field
{
    public class FieldInstance
    {
        Cell[,] cellsArray = new Cell[5,5];
        int seventeenth;
        public static FieldFactoryClass fieldFactory = new FieldFactoryClass();
        private FieldInstance(int[,] matrixOfKeys,int tempSeventeenth)
        {
            for(int i = 0; i < 25; i++)
            {
                cellsArray[i / 5, i % 5] = new Cell(matrixOfKeys[i / 5, i % 5]);
            }
            seventeenth = tempSeventeenth;
        }
        public List<int>[] GetMatrixOfPossibleMoves()
        {
            List<int>[] moves = new List<int>[25];

            for (int i = 0; i < 25; i++)
            {
                moves[i] = new List<int>();
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    int x = j, y = i;
                    x += cellsArray[i, j].GetArrow().GetHorizontal();
                    y += cellsArray[i, j].GetArrow().GetVertical();
                    while (CheckIfInBorders(x) & CheckIfInBorders(y))
                    {
                        moves[i * 5 + j].Add(y * 5 + x);
                        x += cellsArray[i, j].GetArrow().GetHorizontal();
                        y += cellsArray[i, j].GetArrow().GetVertical();
                    }

                }
            }
            return moves;
        }

        public static bool CheckIfInBorders(int x)
        {
            return (x < 5) & (x > -1);
        }
        public int GetSeventeenth()
        {
            return seventeenth;
        }
        public static List<FieldInstance> templates = new List<FieldInstance>() 
        {
            new FieldInstance(new int[,]{ {4,4,4,4,6},{6,8,8,8,8 },{4,4,4,4,6 },{6,8,8,8,8 },{4,4,4,4,9}},18),
            new FieldInstance(new int[,]{{5,7,4,7,7},{5,7,6,5,1},{4,7,6,1,7},{6,2,7,1,2},{4,2,2,3,9}},3),
            new FieldInstance(new int[,]{{6,5,7,8,8},{5,6,6,6,6},{4,3,3,6,1},{3,4,3,5,8},{2,8,1,2,9}},8),
            new FieldInstance(new int[,]{{6,6,8,7,8 },{4,5,6,6,7},{3,6,3,6,8},{3,3,1,8,2},{2,8,3,3,9} },4)
        };
        public string RecieveArrowText(int i)
        {
            return cellsArray[i/5,i%5].GetArrowLook();
        }

        public static FieldInstance GenerateRandomField()
        {
            Dictionary<int, int> rawData = fieldFactory.GenerateRandomRawFieldData();
            int[,] matrixOfArrowKeys = new int[5, 5];
            foreach(var a in rawData)
            {
                matrixOfArrowKeys[a.Key/5,a.Key%5] = a.Value;
            }
            int[] temp = new int[rawData.Count];
            rawData.Keys.CopyTo(temp,0);
            int seventeenth = temp[16];
            return new FieldInstance(matrixOfArrowKeys, seventeenth);
        }
    }
}
