using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecipeLoader
{
    public class ToolPosn
    {
        public int Tool { get; private set; }
        public double Value { get; private set; }

        public ToolPosn(int tool, double value)
        {
            Tool = tool;
            Value = value;
        }
    }
    public class Component
    {


        public List<ToolPosn> Tools;
        public double Len { get; set; }
        public Component()
        {
            Tools = new List<ToolPosn>();
        }
    }
    public class RecipeData
    {
        public List<Component> Components { get; private set; }
        public RecipeData()
        {
            Components = new List<Component>();
        }

    }
}
