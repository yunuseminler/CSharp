using System.Drawing;

namespace WorkProject.Models
{
    public abstract class AShape
    {
        public bool visible;
        public bool dragging;
        public Point point;
        public Brush color;
        public shapes shapeType;
        public int index;
        public int w;
        public int h;
        public AShape(Point _point, Brush _color, int _index,shapes _type)
        {
            this.point = _point;
            this.color = _color;
            this.dragging = false;
            this.index = _index;
            this.visible = true;
            this.shapeType = _type;
        }
        public abstract void Write(Graphics g);
        public abstract void Changewh(int _w,int _h);
        public abstract bool contain(Point _point);
        public abstract void ChangePoint(Point _point);
    }
}