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
    public class Component : ICloneable
    {
        public bool IsOnLoadQueue { get; set; }
        public DateTime DownloadTime { get; set; }
        public string FileName { get; set; }
        public string FrameSet { get; set; }
        public int Number { get; set; }
        public bool Inverted { get; set; }
        public string Direction { get; set; }
        public List<ToolPosn> Tools { get; set; }
        public double Len { get; set; }
        public Component()
        {
            Tools = new List<ToolPosn>();
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}