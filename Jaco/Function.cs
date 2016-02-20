using System.Collections.Generic;

namespace Jaco
{
    public class Function
    {
        public static readonly Function Root = new Function("R");
        public static readonly Function Third = new Function("3");
        public static readonly Function Fifth = new Function("5");
        public static readonly Function Seventh = new Function("7");
        public static readonly Function Ninth = new Function("9");
        public static readonly Function Eleventh = new Function("11");
        public static readonly Function Thirteenth = new Function("13");

        public string Name { get; }

        public Function(string name)
        {
            Name = name;
        }

        public static IEnumerable<Function> Functions
        {
            get
            {
                yield return Root;
                yield return Third;
                yield return Fifth;
                yield return Seventh;
                yield return Ninth;
                yield return Eleventh;
                yield return Thirteenth;
            }
        }

        public int Index
        {
            get
            {
                var index = 0;
                foreach (var element in Functions)
                {
                    if (element == this)
                    {
                        return index;
                    }

                    index++;
                }

                return index;
            }
        }
    }
}
