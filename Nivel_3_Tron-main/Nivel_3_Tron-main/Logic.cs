using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Logic
{       
    public static int[,] GenerateGridConfig(){

        int[,] grid = new int [20, 20];
        int x = -2;
        int y = -2;


        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                grid[i, j] = -1; // Casilla vacía
            }
        }

    return grid;
    }
}
