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
   
    class Group : Shape
    {
        private Storage<Shape> StorageGroup = new Storage<Shape>();

        override public bool ClickChecking(int x0, int y0)//проверка на выдел
        {
            for (StorageGroup.ToHead(); !StorageGroup.eol(); StorageGroup.Next())
                if (StorageGroup.obj().ClickChecking(x0, y0))
                    return true;
            return false;
        }
        override public void SetSelectedStat(bool value)//знач выбранных
        {
            for (StorageGroup.ToHead(); !StorageGroup.eol(); StorageGroup.Next())
                StorageGroup.obj().SetSelectedStat(value);
            selected = value;
        }

        override public bool GetSelectedStat()//получить знач выбранных
        {
            for (StorageGroup.ToHead(); !StorageGroup.eol(); StorageGroup.Next())
                if (StorageGroup.obj().GetSelectedStat())
                    return true;
            return false;
        }

        override public void SetColor(Color grcolor)//установка цвета 
        {
            for (StorageGroup.ToHead(); !StorageGroup.eol(); StorageGroup.Next())
                StorageGroup.obj().SetColor(grcolor);
        }

        override public void SetColorStat(bool value)
        {
            for (StorageGroup.ToHead(); !StorageGroup.eol(); StorageGroup.Next())
                StorageGroup.obj().SetColorStat(value);
            doColor = value;
        }

        override public bool GetColorStat()
        {
            for (StorageGroup.ToHead(); !StorageGroup.eol(); StorageGroup.Next())
                StorageGroup.obj().GetColorStat();
            return doColor;
        }

        override public Color GetColor()
        {
            for (StorageGroup.ToHead(); !StorageGroup.eol(); StorageGroup.Next())
                StorageGroup.obj().GetColor();
            return color;
        }

        public override void Draw(Graphics g, Pen pen, SolidBrush solidbrush)//отрисовка
        {
            for (StorageGroup.ToHead(); !StorageGroup.eol(); StorageGroup.Next())
            {
                StorageGroup.obj().Draw(g, pen, solidbrush);
            }
        }
        public override bool CheckBorder(PictureBox pb)//проверка полей
        {
            for (StorageGroup.ToHead(); !StorageGroup.eol(); StorageGroup.Next())
                if (StorageGroup.obj().CheckBorder(pb))
                    return true;
            return false;
        }
        //увеличить уменьшить для группы
        public override void IncRadius()
        {
            for (StorageGroup.ToHead(); !StorageGroup.eol(); StorageGroup.Next())
                StorageGroup.obj().IncRadius();
        }
        public override void DecRadius()
        {
            for (StorageGroup.ToHead(); !StorageGroup.eol(); StorageGroup.Next())
                StorageGroup.obj().DecRadius();
        }
        //передвижение для группы
        public override void IncX()
        {
            for (StorageGroup.ToHead(); !StorageGroup.eol(); StorageGroup.Next())
                StorageGroup.obj().IncX();
        }
        public override void DecX()
        {
            for (StorageGroup.ToHead(); !StorageGroup.eol(); StorageGroup.Next())
                StorageGroup.obj().DecX();
        }
        public override void IncY()
        {
            for (StorageGroup.ToHead(); !StorageGroup.eol(); StorageGroup.Next())
                StorageGroup.obj().IncY();
        }
        public override void DecY()
        {
            for (StorageGroup.ToHead(); !StorageGroup.eol(); StorageGroup.Next())
                StorageGroup.obj().DecY();
        }

        public override bool IsInGroup()
        {
            return true;
        }
    }
}
