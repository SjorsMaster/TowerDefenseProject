using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    //[ExecuteInEditMode]
    public float Gap = 5;

    public Tile(GameObject _parent, int _x, int _y)
    {
        //Vector3 _position
        GameObject tileObject = GameObject.CreatePrimitive(PrimitiveType.Plane);
        float tileW = tileObject.GetComponent<Renderer>().bounds.size.x;
        float tileD = tileObject.GetComponent<Renderer>().bounds.size.z;

        //Ik gebruik de _y als Z-Positie omdat de Grid een 2D array is
        tileObject.transform.position = new Vector3((_x * tileW) + Gap, 0, (_y * tileD) + Gap);

        ApplyRandomColor(tileObject);

        tileObject.transform.parent = _parent.transform;
    }



    private TileType ApplyRandomColor(GameObject _tile)
    {
        TileType randomColor = (TileType)Random.Range(0, System.Enum.GetNames(typeof(TileType)).Length);

        Renderer renderer = _tile.GetComponent<Renderer>();

        switch (randomColor)
        {
            case TileType.Grass:
                renderer.material.color = Color.green;
                break;

            case TileType.Path:
                renderer.material.color = Color.black;
                break;

            case TileType.Rock:
                renderer.material.color = Color.gray;
                break;

            case TileType.Water:
                renderer.material.color = Color.blue;
                break;


        }

        GiveTileName(_tile, randomColor);

        return randomColor;
    }

    private void GiveTileName(GameObject _tileToName, TileType _tileType)
    {
        //_tileToName.name = _tileToName.name + " - " + _tileType.ToString();
        _tileToName.name = "Tile - " + _tileType.ToString();
    }
}
