using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn2025.PageLearn.NonUIProgram
{
    abstract class BaseClass
    {
        protected int _x = 100;
        protected int _y = 150;

        // Abstract method
        public abstract void AbstractMethod();

        // Abstract properties
        public abstract int X { get; }
        public abstract int Y { get; }
    }

    internal class P_001Abstract : BaseClass
    {
        public override int X 
        {
            get
            {
                return _x + 10;
            }
        }

        public override int Y 
        {
            get
            {
                return _y + 10;
            }
        }

        public override void AbstractMethod()
        {
            _x++;
            _y++;
        }

        public static void MyTest()
        {
            var o = new P_001Abstract();
            o.AbstractMethod();
            Debug.WriteLine($"x = {o.X}, y = {o.Y}");
            //BaseClass bc = new BaseClass(); //這樣會有錯誤
        }
    }
}
