using System;
using System.Collections.Generic;
namespace Pointer
{
    public class PointerClass
    {
        int verticalVector,
            horizontalVector;
        public void SetVectors(int key)
        {
            var temp = vectorsMap[key];
            verticalVector = temp.Item1;
            horizontalVector = temp.Item2;
        }
        public int GetHorizontal()
        {
            return horizontalVector;
        }
        public int GetVertical()
        {
            return verticalVector ;
        }
        public PointerClass(int key)
        {
            SetVectors(key);
        }
        private static readonly Dictionary<int, Tuple<int, int>> vectorsMap = new Dictionary<int, Tuple<int, int>> {
            {1,Tuple.Create(-1,-1) },
            {2,Tuple.Create(-1,0) },
            {3,Tuple.Create(-1,1) },
            {4,Tuple.Create(0,1) },
            {5,Tuple.Create(1,1) },
            {6,Tuple.Create(1,0) },
            {7,Tuple.Create(1,-1) },
            {8,Tuple.Create(0,-1) },
            {9,Tuple.Create(6,6) },
        };

    }
}
