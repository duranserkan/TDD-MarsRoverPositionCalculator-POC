# TDD-MarsRoverPositionCalculator-POC
This repository contains requirements, codes and tests and for the Mars Rover Position Calculator. TDD practices applied during the development as a poc.

## Technical Specifications:
* .NET Core 3.1
* XUnit 2 as test framework
* Nsubstitute as mocking library
* Autofixture as data helper

## Requirements:
A squad of robotic rovers will explore a rectangular plateau on Mars.
   1. A rover's position and location is represented by a combination of x and y co-ordinates and a letter which describes one of the four cardinal compass points.
        1. x and y co-ordinate values are integer
        2. Cardinal compass point representing letter are N for North, E for East, S for South and W for west
        3. Position format is "{x} {y} {L}" where x and y are coordinate values and L is compass point representing letter
   2. A rover's movement is controlled by control signal which is represented by a letter
        1. Control signal L is send for 90 degrees rover spin to left without moving from its current spot
        2. Control signal R is send for 90 degrees rover spin to right without moving from its current spot
        3. Control signal R is send for move rover forward one grid point, and maintain the same heading
   3. Lower-left coordinates are assumed to be 0 0
   4. The first line of input is the upper-right coordinates of the plateau
   5. The rest of the input is information pertaining to the rovers that have been deployed. Each rover has two lines of input.
        1. The first line gives the rover's position
        2. The second line is a series of instructions telling the rover how to explore the plateau
   6. Each rover will be finished sequentially, which means that the second rover won't start to move until the first one has finished moving.
   7. The output for each rover should be its final co-ordinates and heading.
   
