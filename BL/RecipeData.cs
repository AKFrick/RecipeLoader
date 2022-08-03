using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecipeLoader
{
    public class RecipeItem
    {
        public int Tool { get; private set; }
        public double Value { get; private set; }

        public RecipeItem(int tool, double value)
        {
            Tool = tool;
            Value = value;
        }
    }
    public class RecipeLine
    {
        public List<RecipeItem> Items;
        public RecipeLine()
        {
            Items = new List<RecipeItem>();
        }
    }
    public class RecipeData
    {
        public List<RecipeLine> Lines { get; private set; }
        public RecipeData()
        {
            Lines = new List<RecipeLine>();
        }

    }
}
