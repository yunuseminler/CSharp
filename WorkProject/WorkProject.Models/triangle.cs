using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkProject.Models
{
    public class triangle : AShape
    {
        Point[] points;
        public triangle(Point _point, Brush _color, int _index, int _h, int _w, int _x, int _y,shapes _type) : base(_point, _color, _index,_type)
        {
            points = new Point[3];
            points[0] = new Point(_x,_y);
            points[1] = new Point(_x+_w,_y+_h);
            points[2] = new Point(_x-_w,_y+_h);
            this.w = _w;
            this.h = _h;
        }
        public override void Write(Graphics g)
        {
            if (visible)
            {
                g.FillPolygon(color, points);

            }
        }
        public override void ChangePoint(Point _point)
        {
            this.point = _point;
            points[0] = new Point(point.X, point.Y);
            points[1] = new Point(point.X+w, point.Y+h);
            points[2] = new Point(point.X-w, point.Y+h);
        }

        public override void Changewh(int _w, int _h)
        {
            points[1] = new Point(points[0].X+_w, points[0].Y+_h);
            points[2] = new Point(points[0].X-_w, points[0].Y+_h);
            this.w = points[2].X - points[0].X;
            this.h = points[2].Y - points[0].Y;
        }

        public override bool contain(Point _point)
        {
            if (_point.X > points[2].X && _point.X < points[1].X) {
                if (_point.Y > points[0].Y && _point.Y < points[1].Y) { 
                    return true;
                }
            }
            return false;
        }

    }
}
