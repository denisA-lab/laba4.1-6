using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
    

namespace laba4
{
    public class Square : Shape//класс квадрата
    {
        public Square()
        {
        }
        public Square(int x, int y)//копир конст
        {
            this.x = x;
            this.y = y;
        }

        public override bool ClickChecking(int x0, int y0)//проверка на клик
        {
            if (x0 > x - radius && x0 < x + radius && y0 > y - radius && y0 < y + radius)
                return true;
            else return false;
        }

        public override void Draw(Graphics g, Pen pen, SolidBrush solidbrush)//отрисовка
        {
            solidbrush.Color = color;
            g.FillRectangle(solidbrush, x - radius, y - radius, radius * 2, radius * 2);
            g.DrawRectangle(pen, x - radius, y - radius, radius * 2, radius * 2);
            if (selected == true)
            {
                g.DrawRectangle(pen2, x - radius, y - radius, radius * 2, radius * 2);
            }
            if (doColor == true)
            {
                g.FillRectangle(brush, x - radius, y - radius, radius * 2, radius * 2);
            }
        }
 
    }
}
