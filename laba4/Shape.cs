using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace laba4
{

    public class Shape //родительский класс для фигур 
    {
        protected Pen pen = new Pen(Color.Black, 1);
        protected Pen pen2 = new Pen(Color.Green, 5);
        protected int x;
        protected int y;
        protected int radius = 30;
        protected bool selected = false;
        protected bool doColor = false;
        protected Color color = Color.White;
        protected SolidBrush brush = new SolidBrush(Color.Black);

        public Shape()
        {
        }

        virtual public bool ClickChecking(int x0, int y0) //проверка на клик
        {
            return true;
        }

        virtual public void Draw(Graphics g, Pen pen, SolidBrush solidbrush) // отрисовка 
        {
        }

        virtual public bool GetSelectedStat() //узнать выбранные
        {
            return selected == true;
        }

        virtual public void SetSelectedStat(bool value) //вернуть выбранные
        {
            selected = value;
        }

        virtual public bool GetColorStat() 
        {
            return doColor;
        }

        virtual public void SetColorStat(bool value) 
        {
            doColor = value;
        }

        virtual public void SetColor(Color curcolor)//установить цвет
        {
            color = curcolor;
            brush.Color = color;
        }

        virtual public Color GetColor()//получить цвет
        {
            return color;
        }

        virtual public bool CheckBorder(PictureBox pb)//проверка на границы 
        {
            return (x - radius < 0 || y - radius < 0 || x + radius > pb.Width || y + radius > pb.Height);
        }

        virtual public void IncRadius() //увеличить радиус
        {
            radius++;
        }
        virtual public void DecRadius()//уменьшить радиус
        {
            if (radius - 1 > 1)
                radius--;
        }
        //передвижение
        virtual public void IncX()
        {
            x++;
        }
        virtual public void IncY()
        {
            y++;
        }
        virtual public void DecX()
        {
            x--;
        }
        virtual public void DecY()
        {
            y--;
        }

        virtual public bool IsInGroup()
        {
            return false;
        }

    }
}