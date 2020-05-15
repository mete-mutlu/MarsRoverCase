# Mars Rover
Implementation of a command pattern example in c# for Mars Rover case.

## Table Of Contents 
- Case Description
- Case Analysis
- Class Diagram

## Case Description
A squad of robotic rovers are to be landed by NASA on a plateau on Mars. This plateau, which is
curiously rectangular, must be navigated by the rovers so that their on board cameras can get a
complete view of the surrounding terrain to send back to Earth.

A rover's position and location is represented by a combination of x and y co-ordinates and a letter
representing one of the four cardinal compass points. The plateau is divided up into a grid to
simplify navigation. An example position might be 0, 0, N, which means the rover is in the bottom
left corner and facing North.

In order to control a rover, NASA sends a simple string of letters. The possible letters are 'L', 'R' and
'M'. 'L' and 'R' makes the rover spin 90 degrees left or right respectively, without moving from its
current spot. 'M' means move forward one grid point, and maintain the same heading.

Assume that the square directly North from (x, y) is (x, y+1).

#### Input:
The first line of input is the upper-right coordinates of the plateau, the lower-left coordinates are
assumed to be 0,0.

The rest of the input is information pertaining to the rovers that have been deployed. Each rover
has two lines of input. The first line gives the rover's position, and the second line is a series of
instructions telling the rover how to explore the plateau.
The position is made up of two integers and a letter separated by spaces, corresponding to the x
and y co-ordinates and the rover's orientation.
Each rover will be finished sequentially, which means that the second rover won't start to move
until the first one has finished moving.

#### Output:
The output for each rover should be its final co-ordinates and heading.
Input and Output

Test Input:
5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM

Expected Output:
1 3 N
5 1 E

## Case Analysis
There are three possible accepted types of command information lines which are;
#### Upper-right coordinates of the plateau
This information lets us to find size of the plateu.
#### Rover's initial location and direction
Which includes X and Y coordinates and direction(N,S,W,E).
#### Movement commands 
Which might be Left,Right and Forward(L,R,M). 

These information directs us to use command pattern on this case. We can use three commands types to do this;

#### SetSizeOfPlateu
Which sets height and width of the plateu.
#### Land
Sets initial location and direction of the rover.
#### Move
Updates location or direction of the rover.

### Key Points
We should allow only recognized commands(we can use regex). We should interpret command input lines into command objects. In general we can use dictionaries in order to avoid using switch case or if else statements. We can also delegates(Action or Func) in dictionaries as a return type to map command methods and movements.  








