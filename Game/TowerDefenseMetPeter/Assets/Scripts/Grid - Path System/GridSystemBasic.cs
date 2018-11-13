using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[ExecuteInEditMode]// Run this script in the editor

public class GridSystemBasic : MonoBehaviour
{

    //2D array: Grid

    /// <summary>
    /// Creates a 2D grid.
    /// 0 = Path.
    /// 1 = Water.
    /// 2 = Grass.
    /// 3 = Waypoint.
    /// 4 = Spawnpoint.
    /// </summary>
    private int[,] Grid = new int[10,10]
    { 
        { 4, 2, 2, 3, 0, 0, 3, 2, 1, 1 },
        { 0, 2, 2, 0, 2, 2, 0, 2, 1, 1 },
        { 0, 2, 2, 0, 2, 2, 0, 2, 1, 1 },
        { 3, 0, 0, 3, 2, 2, 0, 2, 1, 1 },
        { 2, 2, 2, 2, 2, 2, 0, 2, 1, 1 },
        { 1, 1, 1, 1, 1, 2, 0, 2, 1, 1 },
        { 1, 2, 2, 1, 1, 2, 0, 2, 1, 1 },
        { 1, 2, 2, 1, 1, 2, 0, 2, 2, 2 },
        { 1, 2, 2, 1, 1, 2, 3, 0, 0, 3 },
        { 1, 2, 2, 1, 1, 2, 2, 2, 2, 2 },
    };

    public List<GameObject> WaypointList = new List<GameObject>();
    //public GameObject[] WaypointArray;
    //public int[] WaypointArray = new int[10];


    //public List<Tile> Grid;


    //The pools
    [SerializeField]
    private GameObject GridTileHolder;
    [SerializeField]
    private GameObject WaypointHolder;

    //Grid Width & Height
    public float gridWidth = 10;
    public float gridHeight = 10;

    void Start()
    {
        //for (int i = 0; i < 6; i++)
        //{
        //    GameObject Waypoint = new GameObject();
        //    WaypointList.Add(Waypoint);
        //}
        //WaypointArray = new GameObject[10];
        //Debug.Log(WaypointArray.Length);

        SetUpGrid(gridWidth,gridHeight);
        SetUpTiles(gridWidth,gridHeight);

        
    }

    void SetUpGrid(float _w, float _h)//How many tiles on W & H
    {
        //Create a pool for the Tiles
        if (GameObject.Find("Tile Holder") == null)//if the tile holder not already exists make it (This because of the "[ExecuteInEditMode]")
            GridTileHolder = new GameObject("Tile Holder");

        //Create a pool for the Waypoints
        if (GameObject.Find("Waypoint Holder") == null)//if the tile holder not already exists make it (This because of the "[ExecuteInEditMode]")
            WaypointHolder = new GameObject("Waypoint Holder");

    }

    //void Update()
    //{
    //    //CheckTiles();

    //    if (Input.anyKey)
    //    {
    //        for (int i = 0; i < WaypointList.Count; i++)
    //        {
    //            Debug.Log(WaypointList[i].name);
    //        }
    //    }
    //}

    /// <summary>
    ///     Creates all the tiles in the array
    /// </summary>
    /// <param name="_w">Width</param>
    /// <param name="_h">Height</param>
    void SetUpTiles(float _w, float _h)//How many tiles on Width & Height
    {


        Debug.Log("Checking array");
        for (int j = 0; j < _h; j++)//Vertical
        {
            for (int i = 0; i < _w; i++)//Horizontal
            {
                //Maak een nieuwe tile op de juiste i & j positie
                switch (Grid[i, j])
                {
                    case 0:
                        //var type = 0;
                        //var prevTileType = Grid[i, j];

                        //Debug.Log("Type: 0");
                        Tile newTilePath = new Tile(GridTileHolder, TileType.Path, (float)i, (float)j);
                        break;

                    case 1:
                        //Debug.Log("Type: 1");
                        Tile newTileWater = new Tile(GridTileHolder, TileType.Water, (float)i, (float)j);
                        break;

                    case 2:
                        //Debug.Log("Type: 2");
                        Tile newTileGrass = new Tile(GridTileHolder, TileType.Grass, (float)i, (float)j);
                        break;

                    case 3:
                        //Debug.Log("Type: 2");
                        Tile newTileWaypoint = new Tile(GridTileHolder, TileType.Waypoint, (float)i, (float)j);
                        break;

                    case 4:
                        //Debug.Log("Type: 2");
                        Tile newTileSpawnpoint = new Tile(GridTileHolder, TileType.Spawnpoint, (float)i, (float)j);
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



/*
 * if (Grid[i - 1, j] != 0 && Grid[i - 1, j] != prevTileType)//Kijk Links in het array of er geen pad zit
    {

    }

    if (Grid[i + 1, j] != 0 && Grid[i + 1, j] != prevTileType)//Kijk Rechts in het array of er geen pad zit
    {

    }

    if (Grid[i, j - 1] != 0 && Grid[i, j - 1] != prevTileType)//Kijk Boven in het array of er geen pad zit
    {

    }

    if (Grid[i, j + 1] != 0 && Grid[i, j + 1] != prevTileType)//Kijk Onder in het array of er geen pad zit
    {

    }
*/