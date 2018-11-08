using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[ExecuteInEditMode]
public class Tile : MonoBehaviour
{
    //[ExecuteInEditMode]
    public float Gap = 50;

    //Tile dimentions
    public float tileW;//X
    public float tileD;//Y

    //2D coordinates for the visuals
    public float xPos;
    public float yPos;

    //2D coordinates in the grid
    public float xPosGrid;
    public float yPosGrid;

    private GameObject Parent;
    private GameObject tileObject;

    public TileType tileId;

    /// <summary>
    /// Creates a Tile object
    /// </summary>
    /// <param name="_parent">The GameObject that holds the tile. Will be used for the storing of the tiles in the scene</param>
    /// <param name="_tileType">The type of tile it need to be</param>
    /// <param name="_x">X Coordinate in the array</param>
    /// <param name="_y">Y Coordinate in the array</param>
    public Tile(GameObject _parent, TileType _tileType, float _x, float _y)
    {
        Parent = _parent;

        tileId = _tileType;

        //X / Y in the grid array
        xPosGrid = _x;
        yPosGrid = _y;

        //Load the tile debug object from the recourses folder
        GameObject tileObject = Instantiate(Resources.Load("TileDebug", typeof(GameObject))) as GameObject;


        //Get the dimentions of the tile so it can be used for the positioning of the tile
        tileW = tileObject.GetComponent<Renderer>().bounds.size.x;
        tileD = tileObject.GetComponent<Renderer>().bounds.size.z;

        //Add visual text to the object
        //AddTextToObject(_x + " , " + _y);

        //Set the x / yPos to the arguments
        xPos = (_x * tileW) + Gap;
        yPos = (_y * tileD) + Gap;

        //Set the position
        tileObject.transform.position = new Vector3(xPos, 0, yPos);//I use the _y as Z-Position because the Grid is a 2D array

        //Set the type of the tile
        ApplyType(tileObject, _tileType);

        //Set the object as child to the Tile Holder
        tileObject.transform.parent = _parent.transform;

        //Change the text on the tile to the position
        AddTextToObject(tileObject, _x.ToString() + "," + _y.ToString());
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

    /// <summary>
    /// This applys the right color and additions to the right tile
    /// </summary>
    /// <param name="_tile">The Tile GameObject</param>
    /// <param name="_type">The Tile Type of the Tile object</param>
    /// <returns></returns>
    private TileType ApplyType(GameObject _tile, TileType _type)
    {
        //TileType randomType = (TileType)Random.Range(0, System.Enum.GetNames(typeof(TileType)).Length);//Apply a random type

        Renderer renderer = _tile.GetComponent<Renderer>();

        switch (_type)
        {
            case TileType.Grass:
                renderer.material.color = Color.green;
                break;

            case TileType.Path:
                renderer.material.color = Color.black;
                break;

            case TileType.Waypoint://Waypoint where the enemys tries to go
                renderer.material.color = Color.yellow;
                //Create Waypoint
                CreateWaypoint(xPos, yPos);
                break;

            case TileType.Spawnpoint://Waypoint where the enemys tries to go
                renderer.material.color = Color.magenta;
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

    private void GiveTileName(GameObject _tileToName, TileType _tileType)
    {
        _tileToName.name = "Tile - " + _tileType.ToString();
    }

    void AddTextToObject(GameObject _tileToNumber, string _text)
    {
        _tileToNumber.transform.GetChild(4).GetComponent<TextMesh>().text = _text;
    }

    /// <summary>
    /// Creates a waypoint for the enemy to follow
    /// </summary>
    /// <param name="_x">X on the grid</param>
    /// <param name="_y">Y on the grid</param>
    void CreateWaypoint(float _x, float _y)
    {
        var TilePool = GameObject.Find("Waypoint Holder");

        var WPList = GameObject.Find("Grid System").GetComponent<GridSystemBasic>().WaypointList;

        var d = WPList.Count + 1;

        //Create the object
        GameObject Waypoint = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Waypoint.name = "Waypoint - " + d.ToString();

        //Add a color to the waypoint
        Waypoint.GetComponent<Renderer>().material.color = Color.red;
        //Make it bigger
        Waypoint.transform.localScale = new Vector3(3, 3, 3);
        //Change the position
        Waypoint.transform.position = new Vector3(_x, 5, _y);//2D array. Dus Z is Y
        //Add this waypoint to the Waypoint Holder
        Waypoint.transform.parent = TilePool.transform;

        //Add a Line
        AddALine(Waypoint.transform.position, new Vector3(_x, 0, _y));

        //Add the waypoint to the list
        WPList.Add(Waypoint);
    }

    /// <summary>
    /// Add a line from 2 vector3s
    /// </summary>
    /// <param name="_V1">First Vector3</param>
    /// <param name="_V2">Seccond Vector3</param>
    public GameObject AddALine(Vector3 _V1, Vector3 _V2)
    {
        GameObject Line = new GameObject("Line");

        var linerenderer = Line.AddComponent<LineRenderer>();

        linerenderer.startColor = Color.gray;
        linerenderer.endColor = Color.gray;

        linerenderer.startWidth = 2;
        linerenderer.endWidth = 2;

        linerenderer.SetPosition(0, _V1);
        linerenderer.SetPosition(1, _V2);

        return Line;
    }
}
