using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class Tile : MonoBehaviour
{
    //[ExecuteInEditMode]
    public float Gap = 50;

    //Tile dimentions
    public float tileW;//X
    public float tileD;//Y

    //2D coordinates in the grid
    public float xPos;
    public float yPos;

    public TileType tileId;

    public Tile(GameObject _parent, TileType _tileType, float _x, float _y)
    {
        //Set the x / yPos to the arguments
        xPos = _x;
        yPos = _y;

        tileId = _tileType;
        //Vector3 _position
        //GameObject tileObject = GameObject.CreatePrimitive(PrimitiveType.Plane);
        //GameObject tileObject = Resources.Load<GameObject>("Assets/Resources/DebugTiles/TileDebug");
        GameObject tileObject = Instantiate(Resources.Load("TileDebug", typeof(GameObject))) as GameObject;

        Debug.Log(tileObject);
        Debug.Log(tileW);
        tileW = tileObject.GetComponent<Renderer>().bounds.size.x;
        Debug.Log(tileW);
        tileD = tileObject.GetComponent<Renderer>().bounds.size.z;



        //Add visual text to the object
        //AddTextToObject(_x + " , " + _y);

        //Ik gebruik de _y als Z-Positie omdat de Grid een 2D array is
        tileObject.transform.position = new Vector3((_x * tileW) + Gap, 0, (_y * tileD) + Gap);

        //ApplyRandomType(tileObject);
        ApplyType(tileObject, _tileType);

        tileObject.transform.parent = _parent.transform;
    }



    private void Update()
    {
        CheckForObjects();
    }

    //Check if an object is being placed on the tile
    void CheckForObjects()
    {
        Debug.Log("Checking...");
        var checkObj = GameObject.FindGameObjectWithTag("Tower");

        if (checkObj != null)
        {
            Debug.Log("Found one");
            if (Vector3.Distance(transform.position,checkObj.transform.position) < tileW)//If the object is within the tile
            {
                checkObj.transform.position = new Vector3(xPos + tileW / 2, 0, yPos + tileD / 2);
                Debug.Log("Set object on pos");
            }
        }
    }

    private TileType ApplyType(GameObject _tile, TileType _type)
    {
        //TileType randomType = (TileType)Random.Range(0, System.Enum.GetNames(typeof(TileType)).Length);

        Renderer renderer = _tile.GetComponent<Renderer>();

        switch (_type)
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

        GiveTileName(_tile, _type);

        return _type;
    }


    private TileType ApplyRandomType(GameObject _tile)
    {
        TileType randomType = (TileType)Random.Range(0, System.Enum.GetNames(typeof(TileType)).Length);

        Renderer renderer = _tile.GetComponent<Renderer>();

        switch (randomType)
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

        GiveTileName(_tile, randomType);

        return randomType;
    }

    private void GiveTileName(GameObject _tileToName, TileType _tileType)
    {
        //_tileToName.name = _tileToName.name + " - " + _tileType.ToString();
        _tileToName.name = "Tile - " + _tileType.ToString();
    }

    void AddTextToObject(string _text)
    {

    }
}
