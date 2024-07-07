using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace C_Project
{
    internal class Polygon
    {
        // adding necessary data members 

        public Point2D center;
        public double _length;
        public double _rotateAngle;
        public int _numberOfEdges;

        // creating a List to store the vertex coordinates 

        public List<Point2D> edges = new List<Point2D>();   
        

        //Creating the properties for setting and getting
       public double rotateAngle { get { return _rotateAngle; } set { _rotateAngle = value; } }
        public double length { get { return _length; } set { _length = value; } }
        public int numberOfEdges { get { return _numberOfEdges; } set { _numberOfEdges = value; } }


        // Defining a default constructor with no parameters

     public Polygon() 

        {
            center = new Point2D(0, 0);

        }


        // Definngn a second constructor gets inital center and radius as parameter
        public  Polygon(Point2D center,double radius)
        { 
            this.center = center;
         Point2D r=new Point2D();
            r.radius = radius;
        }


        // Calculating the edge coordinates 
        public void calculateEdgeCoordinates()
        {
            // creating an instance from the Random class

            Random random = new Random();


            edges.Clear(); // clearing the edges list 


            // Creating a random angle to ensure "First vertex should start with a random point"

            double randomAngle = random.NextDouble() * 2 * Math.PI;


            // this angle between will be helpful for us to find the rest of the vertexes

            double anglebetween = 2 * Math.PI / _numberOfEdges;


         // receiving random points with a random angle and also retrieving the length property
         // and muliplying it by 10 so the polygon is displayed bigger 

            double randomx =  (_length *10) * Math.Cos(randomAngle);

            double randomy =  (_length *10) * Math.Sin(randomAngle);


            // calling the constructor by creating an instance to set my random coordinates 

            Point2D p = new Point2D(randomx, randomy);


            // calling this method to calculate and retrieve the radius and theta  

            p.calculatePolarCoordinates();


            // calculating the rest of the vertexes with the formulas x = r * cos(theta ) y = r * sin(theta ) 

            for (int i = 0; i < _numberOfEdges; i++)
            {


                double x = p.radius * Math.Cos(p.theta + anglebetween * i);
                double y = p.radius * Math.Sin(p.theta + anglebetween * i);



                // and adding them to my edges list using the Point2D constructor

                edges.Add(new Point2D(x , y ));
            }

        }
        public void rotatePolygon()
        {

            // creatingt a new list to prevent errors

            List<Point2D> rotatedEdges = new List<Point2D>();


            // converting the entered degree from the textbox to radians
            // because we are working with Cosine and Sine since they accept radians 

            double radianAngle= _rotateAngle *Math.PI / 180.0 ;

            double cosang = Math.Cos(radianAngle);

            double sinang = Math.Sin(radianAngle);


            // iterating through the edges list and for every edge use the rotating maths formula
            // that i learned during high school

            foreach (Point2D edge in edges)
            {
                double rx = edge.x * cosang - edge.y * sinang;
                double ry = edge.x * sinang + edge.y * cosang;

                // and adding them to my edges list using the Point2D constructor
                rotatedEdges.Add(new Point2D(rx, ry));


            }

            //clearing the edges formula
            edges.Clear();
            // and adding the rotatedEdges list to the edges to use the same list in the future  
            edges.AddRange(rotatedEdges);



        }





    }
}
