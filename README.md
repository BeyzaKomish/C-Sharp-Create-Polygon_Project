# Polygon Drawer and Rotator

## Overview
This C# program allows users to create and manipulate polygons using a graphical user interface. The program consists of two main classes, `Point2D` and `Polygon`, and provides functionality to create, draw, and rotate polygons on a form. Users can input the center point, length, number of edges, and rotation angle of the polygon through text boxes, and visualize the polygon in a picture box.

## Classes

### Point2D Class
- **Data Members**: Cartesian coordinates (x and y)
- **Properties**: Accessor properties for x and y
- **Constructors**:
  - Default constructor
  - Constructor that sets initial 2D coordinates with random x and y values
- **Methods**:
  - `printCoordinates()`: Prints the coordinates of the 2D point
  - `calculatePolarCoordinates()`: Calculates polar coordinates (P(r,θ)) of the 2D point
  - `calculateCartesianCoordinates()`: Calculates Cartesian coordinates (P(x,y)) from polar coordinates
  - `printPolarCoordinates()`: Prints the pre-calculated polar coordinates of the 2D point

### Polygon Class
- **Data Members**: Center (Point2D), length, number of edges
- **Properties**: Accessor properties for length and number of edges
- **Constructors**:
  - Default constructor
  - Constructor that takes initial center and length as parameters
- **Methods**:
  - `calculateEdgeCoordinates()`: Calculates the vertex points of the polygon starting from a random point
  - `rotatePolygon()`: Recalculates the vertex points of the polygon in a clockwise direction

## GUI Elements
- **TextBoxes**:
  - Center of the polygon (range for x: [0,3], range for y: [0,3], default: (0,0))
  - Length of the polygon (range: [3-9], default: 4)
  - Number of edges of the polygon (range: [3-10], default: 5)
  - Angle of rotation (range: [0-359], default: 30)
- **ListBox**: Displays the edge coordinates in order
- **PictureBox**: Draws the graphics of the polygon
  - The center point of the polygon is the midpoint of the PictureBox
- **Buttons**:
  - **Draw Polygon**: 
    - Creates a polygon object based on the text box values (rotation angle is zero for the first draw)
    - Recalculates the edge coordinates
    - Draws the polygon in the PictureBox and lists the edge coordinates in the ListBox
  - **Rotate Polygon**: 
    - Rotates the drawn polygon based on the entered angle
    - Does nothing or gives a warning if no polygon is drawn
  - **Set Random Values**: Sets random values on all text boxes

## Usage

1. **Run the Program**: 
   - Open the project in your preferred C# IDE (e.g., Visual Studio).
   - Build and run the solution.

2. **Interface**:
   - Enter values for the center point, length, number of edges, and rotation angle in the respective text boxes.
   - Click "Draw Polygon" to create and draw the polygon.
   - The edge coordinates will be displayed in the ListBox.
   - Click "Rotate Polygon" to rotate the polygon based on the entered angle.
   - Click "Set Random Values" to populate the text boxes with random values.

## Notes
- Default and random values are provided for ease of use. If these values cause issues, feel free to use alternative values.
- The program uses the midpoint of the PictureBox as the center point for drawing the polygon.

## ! Please check the Instruction file for more information. 


