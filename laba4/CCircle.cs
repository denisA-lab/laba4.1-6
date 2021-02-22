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
    public class CCircle : Shape//класс круга
    {
        public CCircle()//конст без парам
        {
        }
        public CCircle(int x, int y)//копир конст
        {
            this.x = x;
            this.y = y;
        }
        public override bool ClickChecking(int x0, int y0)//проверка на выдел
        {
            if ((((x0 - x) * (x0 - x) + (y0 - y) * (y0 - y)) <= radius * radius))
                return true;
            else return false;
        }

        public override void Draw(Graphics g, Pen pen, SolidBrush solidbrush)//отрисовка
        {
            solidbrush.Color = color;
            g.DrawEllipse(pen, x - radius, y - radius, radius * 2, radius * 2);
            if (selected == true)
            {
                g.DrawEllipse(pen2, x - radius, y - radius, radius * 2, radius * 2);
            }
            if (doColor == true)
            {
                g.FillEllipse(brush, x - radius, y - radius, radius * 2, radius * 2);
            }
        }
    }
}