// See https://aka.ms/new-console-template for more information
using System;
using System.Data.SqlTypes;

Console.WriteLine("Hello, World!");

//program to write a grid, this grid should be an array and it should be stored in a funtion
//for every true value, x for every false value, .
bool[,] gameoflifegrid = new bool[20,20];
boardgen(gameoflifegrid);
printgrid(gameoflifegrid);
int neighbors = howmanybeside(gameoflifegrid,20,20);

void printgrid(bool[,] grid)
{
    for (int x = 0; x < grid.GetLength(0); x++)
    {
        for(int y = 0; y < grid.GetLength(1); y++)
        {
            string chartoprint = grid[x, y] ? "x" : ".";
            Console.Write(chartoprint);
        }
        Console.WriteLine();
    }
}

void boardgen(bool[,] grid)
{
    var random = new Random();
    for (int x = 0; x < grid.GetLength(0); x++)
    {
        for (int y = 0; y < grid.GetLength(1); y++)
        {
            grid[x, y] = random.Next() % 2 == 0;
        }
    }
}

int howmanybeside(bool[,]grid,int x,int y)
{
    int neighbors = 0;
    int sizex = grid.GetLength(0);
    int sizey = grid.GetLength (1);
    for(int i = -1; i <= 1; i++)
    {
        for(int j=-1;j<=1; j++)
        {
            if (i == 0 && j == 0)
            {
                continue;
            }
            int neighborx = (x + i + sizex) % sizex;
            int neighbory = (y + j + sizey) % sizex;
            if (grid[neighborx, neighbory])
            {
                neighbors++;
            }
        }
    }
    return neighbors;
}

void nextcellstage(bool[,]grid , int n)
{
    for (int x = 0; x < grid.GetLength(0); x++)
    {
        for (int y = 0; y < grid.GetLength(1); y++)
        {
            if (grid[x, y] == true && n == 2 || n == 3)
            {
                grid[x, y] = true;
            }
            else
            {
                grid[x, y] = false;
            }
            if (grid[x, y] == false && n == 3)
            {
                grid[x, y] = true;
            }
            else
            {
                grid[x, y] = false;
            }
        }
    }
}
nextcellstage(gameoflifegrid, neighbors);
printgrid(gameoflifegrid); //sets it all to false :/