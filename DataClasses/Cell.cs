using System;
using Pointer;
using System.Collections.Generic;
namespace CellClass
{
    public class Cell
    {
        private PointerClass arrow;
        private string arrowLook;
        public Cell(int key)
        {
            arrow = new PointerClass(key);
            arrowLook = arrowsMap[key];
        }
        public PointerClass GetArrow()
        {
            return arrow;
        }
        private static Dictionary<int,string> arrowsMap= new Dictionary<int,string> {
            {1,"↖"},
            {2,"↑" },
            {3,"↗" },
            {4,"→" },
            {5,"↘" },
            {6,"↓" },
            {7,"↙" },
            {8,"←" },
            {9,"\u2691" },// прапорець
        };
        public string GetArrowLook()
        {
            return arrowLook;
        }
    }
}
