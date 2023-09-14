
using WorkProject.Models;

namespace WorkProject.FormApps
{

    public partial class Form1 : Form
    {
        List<AShape> shapeList;
        Brush brush = Brushes.Blue;
        Point point;
        shapes clickedShape;
        bool isdelete = false;
        int index = 0;
        int current = 0;
        int clicked = 0;
        int x = 0;
        int y = 0;
        int h = 0;
        int w = 0;
        Graphics g;


        public Form1()
        {
            InitializeComponent();
            shapeList = new List<AShape>();
            clickedShape = shapes.rectangle;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);

            g = e.Graphics;

            foreach (AShape shape in shapeList)
            {
                shape.Write(g);
            }
            if (current != 0)
            {
                Pen pen = new Pen(Color.Pink, 5);
                g.DrawRectangle(pen, shapeList[clicked - 1].point.X, shapeList[clicked - 1].point.Y, shapeList[clicked - 1].w, shapeList[clicked - 1].h);
            }



        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (current != 0)
            {
                if (shapeList[current - 1].dragging == true)
                {
                    if (e.X > 0 && e.Y > 0)
                    {
                        if ((e.X + shapeList[current - 1].w) < panel1.Width && (e.Y + shapeList[current - 1].h) < panel1.Height)
                        {
                            Point p = new Point(e.X, e.Y);
                            shapeList[current - 1].ChangePoint(p);
                        }
                    }

                }

                else if (e.Button == MouseButtons.Left)
                {
                    if (e.X > 0 && e.Y > 0)
                    {
                        if ((e.X + shapeList[current - 1].w) < panel1.Width && (e.Y + shapeList[current - 1].h) < panel1.Height)
                        {
                            w = e.X - x;
                            h = e.Y - y;
                            shapeList[index - 1].Changewh(w, h);
                        }
                    }
                }
                Refresh();
            }


        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            point = new Point(e.X, e.Y);

            if (isdelete)
            {
                foreach (AShape shape in shapeList)
                {
                    if (shape.contain(point))
                    {
                        shape.visible = false;
                        Refresh();
                    }
                }

            }

            else
            {
                foreach (AShape shape in shapeList)
                {
                    if (shape.contain(point))
                    {

                        if (shape.visible)
                        {
                            current = shape.index;
                            clicked = shape.index;
                            shape.dragging = true;
                            Point p = new Point(e.X, e.Y);
                            shape.ChangePoint(p);
                        }
                    }
                }

                if (current == 0)
                {
                    x = e.X;
                    y = e.Y;
                    index++;
                    switch (clickedShape)
                    {
                        case shapes.triangle:
                            shapeList.Add(new triangle(point, brush, index, h, w, x, y, clickedShape));
                            break;

                        case shapes.rectangle:
                            shapeList.Add(new rectangle(point, brush, index, h, w, x, y, clickedShape));
                            break;
                        case shapes.circle:
                            shapeList.Add(new circle(point, brush, index, h, w, x, y, clickedShape));
                            break;

                        case shapes.pentagon:
                            shapeList.Add(new pentagon(point, brush, index, h, w, x, y, clickedShape));
                            break;

                        default: break;

                    }
                    current = index;
                    clicked = index;
                }
            }

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {

            if (current != 0)
            {
                if (shapeList[current - 1].dragging)
                {
                    shapeList[current - 1].dragging = false;
                }
            }

            current = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {

            brush = Brushes.Red;
            if (clicked != 0)
            {
                shapeList[clicked - 1].color = brush;
                Refresh();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            brush = Brushes.Blue;
            if (clicked != 0)
            {
                shapeList[clicked - 1].color = brush;
                Refresh();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            brush = Brushes.Green; if (clicked != 0)
            {
                shapeList[clicked - 1].color = brush;
                Refresh();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            brush = Brushes.YellowGreen; if (clicked != 0)
            {
                shapeList[clicked - 1].color = brush;
                Refresh();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            brush = Brushes.Black; if (clicked != 0)
            {
                shapeList[clicked - 1].color = brush;
                Refresh();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            brush = Brushes.Yellow; if (clicked != 0)
            {
                shapeList[clicked - 1].color = brush;
                Refresh();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            brush = Brushes.Purple; if (clicked != 0)
            {
                shapeList[clicked - 1].color = brush;
                Refresh();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            brush = Brushes.Brown; if (clicked != 0)
            {
                shapeList[clicked - 1].color = brush;
                Refresh();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            brush = Brushes.White; if (clicked != 0)
            {
                shapeList[clicked - 1].color = brush;
                Refresh();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            isdelete = false;
            current = 0;
            index = 0;
            shapeList.Clear();
            panel1.Invalidate();

        }

        private void button16_Click(object sender, EventArgs e)
        {
            isdelete = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            isdelete = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            clickedShape = shapes.rectangle;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clickedShape = shapes.circle;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            clickedShape = shapes.triangle;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            clickedShape = shapes.pentagon;

        }

        private void button18_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfg = new SaveFileDialog())

                if (sfg.ShowDialog() == DialogResult.OK)
                {
                    using (Stream s = File.Open(sfg.FileName, FileMode.CreateNew))
                    using (StreamWriter sw = new StreamWriter(s))
                    {
                        foreach (AShape shape in shapeList)
                        {
                            sw.WriteLine(shape.shapeType + "," + shape.point.X + "," + shape.point.Y + "," + shape.w + "," + shape.h + "," + getColor(shape.color));
                        }

                    }
                }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofg = new OpenFileDialog())
                if (ofg.ShowDialog() == DialogResult.OK)
                {
                    string filename = ofg.FileName;
                    string[] filetext = File.ReadAllLines(filename);
                    index = 0;
                    current = 0;
                    clicked = 0;
                    foreach (string row in filetext)
                    {
                        index++;
                        string[] elements = row.Split(",");
                        Point _point = new Point(int.Parse(elements[1]), int.Parse(elements[2]));
                        switch (elements[0])
                        {
                            case "triangle":
                                shapeList.Add(new triangle(_point, getBrush(elements[5]), index, int.Parse(elements[4]), int.Parse(elements[3]), _point.X, _point.Y, shapes.triangle));
                                break;

                            case "rectangle":
                                shapeList.Add(new rectangle(_point, getBrush(elements[5]), index, int.Parse(elements[4]), int.Parse(elements[3]), _point.X, _point.Y, shapes.rectangle));
                                break;
                            case "circle":
                                shapeList.Add(new circle(_point, getBrush(elements[5]), index, int.Parse(elements[4]), int.Parse(elements[3]), _point.X, _point.Y, shapes.circle));
                                break;

                            case "pentagon":
                                shapeList.Add(new pentagon(_point, getBrush(elements[5]), index, int.Parse(elements[4]), int.Parse(elements[3]), _point.X, _point.Y, shapes.pentagon));
                                break;

                            default: break;


                        }

                    }
                    Refresh();

                }
        }
        private string getColor(Brush color)
        {
            if (color == Brushes.Blue)
            {
                return "blue";
            }
            else if (color == Brushes.Red)
            {
                return "Red";
            }
            else if (color == Brushes.Green)
            {
                return "Green";
            }
            else if (color == Brushes.YellowGreen)
            {
                return "YellowGreen";
            }
            else if (color == Brushes.Yellow)
            {
                return "Yellow";
            }
            else if (color == Brushes.Black)
            {
                return "Black";
            }
            else if (color == Brushes.Purple)
            {
                return "Purple";
            }
            else if (color == Brushes.Brown)
            {
                return "Brown";
            }
            else if (color == Brushes.White)
            {
                return "White";
            }

            return "s";
        }
        private Brush getBrush(string color)
        {
            if (color == "blue")
            {
                return Brushes.Blue;
            }
            else if (color == "Red")
            {
                return Brushes.Red;
            }
            else if (color == "Green")
            {
                return Brushes.Green;
            }
            else if (color == "YellowGreen")
            {
                return Brushes.YellowGreen;
            }
            else if (color == "Yellow")
            {
                return Brushes.Yellow;
            }
            else if (color == "Black")
            {
                return Brushes.Black;
            }
            else if (color == "Purple")
            {
                return Brushes.Purple;
            }
            else if (color == "Brown")
            {
                return Brushes.Brown;
            }
            else if (color == "White")
            {
                return Brushes.White;
            }

            return Brushes.Blue;
        }
    }
}