using System.Windows.Forms;

namespace C_Project
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();


        }

        // creating an instance from the polygon class to access the members from the polygon class

        Polygon polygon = new Polygon();





        private void draw_Click(object sender, EventArgs e)
        {
            // storing an identifier for the draw button to check if it's clicked 

            draw.Tag = true;


            // calling the setdefault function if the textboxes are empty

            SetDefault();

            // clearing the listbox named coordinates when pressed draw button every time

            coordinates.Items.Clear();

            // declaring new variables for type conversion

            double centerx, centery, length1;
            int numberOfEdges;


            // converting the string texts into corresponding numerical types
            // and storing them into the new declared variables

            double.TryParse(centerX.Text, out centerx);
            double.TryParse(centerY.Text, out centery);
            double.TryParse(length.Text, out length1);
            int.TryParse(numofedge.Text, out numberOfEdges);


            // and assining the variables to the now accesible variables
            // that we have used in the previous classes

            polygon.center._x = centerx;
            polygon.center._y = centery;
            polygon._length = length1;
            polygon._numberOfEdges = numberOfEdges;

            // calculating the edge coordintes by accesing the polygon class
            polygon.calculateEdgeCoordinates();



            // Calculating the offset to centre the polygon in the picturebox (setting the polygon center to thee picturebox centre as wanted )
            // and multiplying because i did previously in the polygon class to prevent distortions in polygon

            int offsetX = (int)(pictureBox.Width / 2 - (polygon.center._x) * 10);
            int offsetY = (int)(pictureBox.Height / 2 - (polygon.center._y) * 10);


            // iterating the edges list that was declared in the point2d class
            // and printing the coordinates in the listbox 

            foreach (Point2D point in polygon.edges)
            {
                coordinates.Items.Add($"({point.x.ToString("F2")}, {point.y.ToString("F2")})   ");
                Console.WriteLine();

            }



            // creating a new bitmap object is created with the width and height of the picturebox
            // bitmap represents an image as a collection of pixels that helps modify our graph

            Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);

            // graphic object is created using the method FromImage() passing the bitmap 
            // this helps us to draw operations on the bitmap 

            using (Graphics graphics = Graphics.FromImage(bmp))

            {

                // the bitmap is cleared with a white color.
                // this ensures previous content on the bitmap is removed before drwaing the polygon
                graphics.Clear(Color.White);

                // using the color black with an instance of the pen class
                using (Pen pen = new Pen(Color.Black))
                {
                    // then the vertices of the polygon are transformed based on an offset
                    // and converting to an array of objects

                    Point[] points = polygon
                        .edges
                        .Select(p => new Point((int)(p._x + offsetX), (int)(p._y + offsetY)))
                        .ToArray();

                    // and using the draw polygon method with the pen instace 
                    graphics.DrawPolygon(pen, points);

                }
            }
            // the bitmap containing the drawn polygon is set as the img property of the pictureBox 
            pictureBox.Image = bmp;
        }




        private void button2_Click(object sender, EventArgs e)
        {
            // checking if the draw button is clicked from the bool set to true previously
            if (draw.Tag != null && (bool)draw.Tag)
            {

                // calling the setdefault function if the textboxes are empty
                SetDefault();

                // new variable
                double rotate;

                // converting the string to double and storing it 
                double.TryParse(angle.Text, out rotate);

                // assining the rotate variable and setting it to my actual rotate angle var
                polygon._rotateAngle = rotate;

                polygon.rotatePolygon();





                // Calculating the offset to centre the polygon in the picturebox (setting the polygon center to thee picturebox centre as wanted )
                // and multiplying because i did previously in the polygon class to prevent distortions in polygon

                int offsetX = (int)(pictureBox.Width / 2 - (polygon.center._x) * 10);
                int offsetY = (int)(pictureBox.Height / 2 - (polygon.center._y) * 10);


                // same explanations as before 

                Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
                using (Graphics graphics = Graphics.FromImage(bmp))

                {
                    graphics.Clear(Color.White);

                    using (Pen pen = new Pen(Color.Black))
                    {
                        Point[] points = polygon
                            .edges
                            .Select(p => new Point((int)(p._x + offsetX), (int)(p._y + offsetY)))
                            .ToArray();
                        graphics.DrawPolygon(pen, points);

                    }
                }

                pictureBox.Image = bmp;

            }

            // if the button isnt clicked there isnt any graph so a message box pops up
            else { MessageBox.Show(" There isn't a Graph to rotate.Please click the Draw button"); }


        }


        private void setrandom_Click(object sender, EventArgs e)
        {
            //  creating an instance from the Random class
            Random randomClass = new Random();

            // creating a new instance from the polygon class 
            Polygon polygon2 = new Polygon();

            // and randomizing the variables as wanted 
            polygon2.center._x = randomClass.Next(-5, 5);
            polygon2.center._y = randomClass.Next(-5, 5);
            polygon2._length = randomClass.Next(3, 10);
            polygon2._numberOfEdges = randomClass.Next(3, 10);
            polygon2._rotateAngle = randomClass.Next(0, 359);


            // first converting to string bcs the textboxes are known as string
            // and setting them to the textboxes
            centerX.Text = polygon2.center._x.ToString();
            centerY.Text = polygon2.center._y.ToString();
            length.Text = polygon2._length.ToString();
            numofedge.Text = polygon2._numberOfEdges.ToString();
            angle.Text = polygon2._rotateAngle.ToString();



        }


        // i thought that creating a method to set the default values to be easier this way 
        public void SetDefault()

        {
            // checking if the textboxes are empty if so setting the default values

            if (string.IsNullOrWhiteSpace(centerX.Text))
            {
                centerX.Text = "0";
            }
            if (string.IsNullOrWhiteSpace(centerY.Text))
            {
                centerY.Text = "0";
            }
            if (string.IsNullOrWhiteSpace(angle.Text))
            {
                angle.Text = "30";
            }
            if (string.IsNullOrWhiteSpace(numofedge.Text))
            { numofedge.Text = "5"; }
            if (string.IsNullOrWhiteSpace(length.Text))
            {
                length.Text = "4";
            }


        }

       
    }
}