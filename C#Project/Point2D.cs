using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



//*******************************************************************************************************************************
//*************                         STUDENT NAME: BEYZA KOMİŞ                                              ******************
//*************                         STUDENT NUMBER: B231202072                                             ******************
//*******************************************************************************************************************************




namespace C_Project
{
    internal class Point2D
    {
      
        // Adding required required data members 

        public double _x, _y;
        public double radius, theta;

        // Creating required properties for the data members
        public double x { get { return _x; } set { _x = value; } } 
        public double y { get { return _y; } set { _y = value; } }

        // Defining a default constructor with no parameters
        public Point2D()
        { 

        }

       // Defining a constructor setting inital 2D coordinates 

        public Point2D(double x, double y)
        {
            
            _x = x;
            _y = y;
        }

        // creating a method to print the coordinates
       public void printCoordinates()
        {
        
            Console.WriteLine($"({_x},{_y})");
            

        }

        // calculating the Polar coordinates
        public void calculatePolarCoordinates()
        {
            radius = Math.Sqrt(Math.Pow(_x,2)+Math.Pow(_y,2));
           
            double absoluteX=Math.Abs(_x);

            double absoluteY=Math.Abs(_y);


            theta = Math.Atan(absoluteY/absoluteX) * (180/Math.PI);



        }


        // calculating the cartesian coordinates
        public void calculateCartesianCoordinates()
        {
            x=radius*Math.Cos(theta);

            y=radius *Math.Sin(theta);
        }



        // Printing the Polar coordinates
        public void printPolarCoordinates()
        {
            Console.WriteLine($"({radius},{theta})");
        }

    }
}
