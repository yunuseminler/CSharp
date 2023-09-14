using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkProject.Models
{
    public class circle : AShape
    {
        public Rectangle shape;

        public circle(Point _point, Brush _color, int _index, int _h, int _w, int _x, int _y, shapes _type) : base(_point, _color, _index, _type)
        {
            shape = new Rectangle(_x, _y, _w, _h);
            this.w = _w; this.h = _h;
        }
        public override void Write(Graphics g)
        {
            if (visible)
            {
                g.FillEllipse(color, shape);

            }


        }
        public override void Changewh(int _w, int _h)
        {
            shape.Width = _w; shape.Height = _h;
            this.w = _w; this.h = _h;

        }
        public override bool contain(Point _point)
        {
            return shape.Contains(_point);
        }
        public override void ChangePoint(Point _point)
        {
            this.point = _point;
            this.shape.X = _point.X;
            this.shape.Y = _point.Y;
        }

    }
}
