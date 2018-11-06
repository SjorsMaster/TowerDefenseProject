using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[ExecuteInEditMode]// Run this script in the editor

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

        //Create a pool for the tiles
        if (GameObject.Find("Tile Holder") == null)//if the tile holder not already exists make it (This because of the "[ExecuteInEditMode]")
            GridTileHolder = new GameObject("Tile Holder");

    }

    void Update()
    {
        CheckTiles();
    }


    void SetUpTiles(int _w, int _h)//How many tiles on W & H
    {
        int tileCount = 0;

        for (int i = 0; i < _w; i++)//Horizontal
        {
            for (int j = 0; j < _h; j++)//Vertical
            {
                //Maak een nieuwe tile op de juiste i & j positie
                Tile newTile = new Tile(GridTileHolder, tileCount, i, j);
                tileCount++;
            }
        }
    }

    void CheckTiles()
    {

    }


    //-Test- Creating an object from resources
    void CreateFromResources()
    {
        GameObject obj = Resources.Load("Tower") as GameObject;

        Instantiate(obj);
    }

    
}
