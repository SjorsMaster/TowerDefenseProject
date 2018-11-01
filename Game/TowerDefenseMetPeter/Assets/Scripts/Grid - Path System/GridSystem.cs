using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    //2D array: Grid
    public int[,] Grid;
    public GameObject GridTileHolder;

    

    //Grid Width & Height
    public int gridWidth;
    public int gridHeight;

    void Start()
    {
        SetUpGrid(gridWidth,gridHeight);
        SetUpTiles(gridWidth,gridHeight);
    }

    void SetUpGrid(int _w, int _h)//How many tiles on W & H
    {
        Grid = new int[_w, _h];
        GridTileHolder = new GameObject("Tile Holder");

    }


    void SetUpTiles(int _w, int _h)//How many tiles on W & H
    {
        for (int i = 0; i < _w; i++)//Horizontal
        {
            for (int j = 0; j < _h; j++)//Vertical
            {
                
                //Maak een nieuwe tile op de juiste i & j positie
                Tile newTile = new Tile(GridTileHolder, i, j);

            }
        }
    }

    
}
