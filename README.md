# Calculator

## Description

A Console application that outputs the result of inputted mathematical operations.

## Requirements to run

1) .Net Core 3.1

## Projects

### Calculator

This project contains the code for the application.

### Calculator.UnitTests

This project contains the unit tests.

## Instructions

Run the console application with a list of string arguments. This list should only contain valid file paths.

Example:

`dotnet Calculator.dll C:\file1.txt C:\file2.txt`

## Known limitations

1) Operations are limited to 32 bit integers, there is no floating point number support.

2) Operations must not exceed int.MaxValue at any point during the calculation

3) Invalid input in any file will cause the program to raise an exception

## If I had more time / Future changes

1) Add StyleCop or some other static code analysis tool.

2) Support other types of numeric data rather than just ints.

3) Create a UI to select the input file(s)
