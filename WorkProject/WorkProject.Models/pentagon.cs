using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkProject.Models
{
    public class pentagon : AShape
    {
        Point[] points;
        public pentagon(Point _point, Brush _color, int _index, int _h, int _w, int _x, int _y, shapes _type) : base(_point, _color, _index, _type)
        {
            points = new Point[5];
            points[0] = new Point(_x, _y);
            points[1] = new Point(points[0].X + _w, points[0].Y + _h);
            points[2] = new Point(points[0].X - _w, points[0].Y + _h);
            points[3] = new Point(points[0].X - (_w / 2), points[0].Y + _h * 2);
            points[4] = new Point(points[0].X + (_w / 2), points[0].Y + _h * 2);
            this.w = _w;
            this.h = _h;
        }
        public override void Write(Graphics g)
        {
            if (visible)
            {
                Point[] triangle = new Point[3];
                triangle[0] = points[0];
                triangle[1] = points[2];
                triangle[2] = points[1];
                Point[] triangle1 = new Point[3];
                triangle1[0] = points[0];
                triangle1[1] = points[1];
                triangle1[2] = points[4];
                g.FillPolygon(color, points);
                g.FillPolygon(color, triangle);
                g.FillPolygon(color, triangle1);

            }
        }
        public override void ChangePoint(Point _point)
        {
            this.point = _point;
            points[0] = new Point(point.X, point.Y);
            points[1] = new Point(points[0].X + this.w, points[0].Y + this.h);
            points[2] = new Point(points[0].X - this.w, points[0].Y + this.h);
            points[3] = new Point(points[0].X - (this.w / 2), points[0].Y + this.h * 2);
            points[4] = new Point(points[0].X + (this.w / 2), points[0].Y + this.h * 2);
        }

        public override void Changewh(int _w, int _h)
        {
            points[1] = new Point(points[0].X + _w, points[0].Y + _h);
            points[2] = new Point(points[0].X - _w, points[0].Y + _h);
            points[3] = new Point(points[0].X - (_w/2),  points[0].Y + _h*2);
            points[4] = new Point(points[0].X + (_w/2),  points[0].Y + _h*2);
            this.w = _w;
            this.h = _h*2;
        }

        public override bool contain(Point _point)
        {
            if (_point.X > points[2].X && _point.X < points[1].X)
            {
                if (_point.Y > points[0].Y && _point.Y < points[3].Y)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
