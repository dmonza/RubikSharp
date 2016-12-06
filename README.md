# RubikSharp
Rubik CSharp resolution lab and framework.

Is a base framework to test resolution algorithms and play with your cube.

![Rubik Cube](https://raw.github.com/dmonza/RubikSharp/master/screen.gif)

Table of Contents
-----------------
  * [Introduction](#introduction)
  * [Moves](#moves)
  * [Some things](#things)
  * [Environment](#environment)
  * [Licence](LICENSE.md)

## Introduction
I start this framework on 2015 and a  leave for a while. Now I do some fixes and was published for who like to play with it.

## Moves
The moves language is: [Axis][Rotor].[Count]

For example: Y1.2
Means that you turn the first rotor of Y axis twice.

## Some things
### Axis
![Rubik Cube Axis](https://raw.github.com/dmonza/RubikSharp/master/rubikaxis.png)
### Resolution algorithms
I wrote a brute force resolution algorithm who is not very efficient and may not resolve the cube.

Next step is to write an algorithm that uses common know resolve movements.

### Do you like to create a new algorithm
You can inherit from AbstractAlgorithm and add it to MainUI.

## Environment
* .Net framework 4.0
* Visual Studio Community 2015
