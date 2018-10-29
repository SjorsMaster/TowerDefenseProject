using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    public int[,] _tiles;

    public float Gap = 5;

    public float gridWidth;
    public float gridHeight;

    void Start()
    {
        SetUpGrid();
        SetUpTiles(gridWidth,gridHeight,0);
    }

    void SetUpGrid()
    {
        //_tiles = new int[,];

    }

    void SetUpTiles(float _w, float _h, TileType _type)
    {
        for (int i = 0; i < gridHeight; i++)//Horizontal
        {
            for (int j = 0; j < gridWidth; j++)//Vertical
            {

                GameObject tileObject = GameObject.CreatePrimitive(PrimitiveType.Plane);
                float tileW = tileObject.GetComponent<Renderer>().bounds.size.x;
                float tileD = tileObject.GetComponent<Renderer>().bounds.size.z;
                
                
                tileObject.transform.position = new Vector3((i * tileW) + Gap, 0, (j * tileD) + Gap);

            }
        }
    }
}
