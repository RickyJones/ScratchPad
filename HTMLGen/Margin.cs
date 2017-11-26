using System;
namespace ScratchApp.HTMLGen
{
    public class Margin : Box
    {
        public Margin(double all, double top, double bttm, double right, double left)
        {
            this.all = all;
            this.top = top;
            this.bottom = bttm;
            this.right = right;
            this.left = left;
        }
    }
}
