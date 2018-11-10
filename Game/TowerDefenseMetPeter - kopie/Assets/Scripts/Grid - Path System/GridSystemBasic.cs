using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[ExecuteInEditMode]// Run this script in the editor

public class GridSystemBasic : MonoBehaviour
{

    //2D array: Grid
    public int[,] Grid = new int[10,10]
    { 
        { 0, 2, 2, 0, 0, 0, 0, 2, 1, 1 },
        { 0, 2, 2, 0, 2, 2, 0, 2, 1, 1 },
        { 0, 2, 2, 0, 2, 2, 0, 2, 1, 1 },
        { 0, 0, 0, 0, 2, 2, 0, 2, 1, 1 },
        { 2, 2, 2, 2, 2, 2, 0, 2, 1, 1 },
        { 1, 1, 1, 1, 1, 2, 0, 2, 1, 1 },
        { 1, 2, 2, 1, 1, 2, 0, 2, 1, 1 },
        { 1, 2, 2, 1, 1, 2, 0, 2, 2, 2 },
        { 1, 2, 2, 1, 1, 2, 0, 0, 0, 0 },
        { 1, 2, 2, 1, 1, 2, 2, 2, 2, 2 },
    };
    //public List<Tile> Grid;



    public GameObject GridTileHolder;

    //Grid Width & Height
    public float gridWidth = 10;
    public float gridHeight = 10;

    void Start()
    {
        SetUpGrid(gridWidth,gridHeight);
        SetUpTiles(gridWidth,gridHeight);
    }

    void SetUpGrid(float _w, float _h)//How many tiles on W & H
    {
        

        //Create a pool for the tiles
        if (GameObject.Find("Tile Holder") == null)//if the tile holder not already exists make it (This because of the "[ExecuteInEditMode]")
            GridTileHolder = new GameObject("Tile Holder");

    }

    void Update()
    {
        CheckTiles();
    }


    void SetUpTiles(float _w, float _h)//How many tiles on W & H
    {
        Debug.Log("Checking array");
        for (int i = 0; i < _w; i++)//Horizontal
        {
            for (int j = 0; j < _h; j++)//Vertical
            {
                //Maak een nieuwe tile op de juiste i & j positie
                switch (Grid[i, j])
                {
                    case 0:
                        Debug.Log("Type: 0");
                        Tile newTilePath = new Tile(GridTileHolder, TileType.Path, (float)i, (float)j);
                        //Grid[i, j] = new Tile(GridTileHolder, TileType.Noone, i, j);
                        break;

                    case 1:
                        Debug.Log("Type: 1");
                        Tile newTileWater = new Tile(GridTileHolder, TileType.Water, (float)i, (float)j);
                        break;

                    case 2:
                        Debug.Log("Type: 2");
                        Tile newTileGrass = new Tile(GridTileHolder, TileType.Grass, (float)i, (float)j);
                        break;
                }
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
