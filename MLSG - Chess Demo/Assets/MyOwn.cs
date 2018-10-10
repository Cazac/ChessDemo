using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyOwn : MonoBehaviour {

    //Declare a prefab refference to be made in Unity
    public GameObject tile_Prefab;
    public GameObject whiteUnit_prefab;
    public GameObject blackUnit_prefab;


    private MyOwnUnit unit_Selected;

    public int Turn_Num;




    //Uses X , Y coords to locate tile in array
    public MyOwnTile[,] tile_Array = new MyOwnTile[8, 8];
    public MyOwnUnit[,] unit_Array = new MyOwnUnit[8, 8];


    public void CreateCells()
    {
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                GenerateTile(x, y);
            }
        }
    }

    public void CreateUnits()
    {
        //White Unit Generation
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 2; x++)
            {
                GenerateUnit(x, y, true);
            }
        }

        //Black Unit Generation
        for (int y = 0; y < 8; y++)
        {
            for (int x = 6; x < 8; x++)
            {
                GenerateUnit(x, y, false);
            }
        }
    }


    public void GenerateTile(int x, int y)
    {
        GameObject tile_GameObject = Instantiate(tile_Prefab) as GameObject;


        tile_GameObject.AddComponent<MyOwnTile>();

        //Sets the name of GameObject One.
        tile_GameObject.name = "Tile X: " + x + " / Y: " + y;


        float smoolX = x * 0.1f;
        float smoolY = y * 0.1f;
        Vector3 tile_XY = new Vector3(smoolX, 0.0f, smoolY);

        tile_GameObject.transform.position = tile_XY;


        //MyOwnTile tile = tile_GameObject.GetComponent<MyOwnTile>();
        //MyOwnTile tile2 = new MyOwnTile();

        //tile_Array[x, y] = tile;
        //tile_Array[x, y] = tile2;
    }

    public void GenerateUnit(int x, int y, bool color)
    {
        GameObject unit_GameObject;

        //Create White or Black Units
        if (color == true)
        {
            unit_GameObject = Instantiate(whiteUnit_prefab) as GameObject;
        }
        else
        {
            unit_GameObject = Instantiate(blackUnit_prefab) as GameObject;
        }

        //Add Script to GameObject
        unit_GameObject.AddComponent<MyOwnUnit>();

        float smoolX = x * 0.1f;
        float smoolY = y * 0.1f;

        Vector3 unit_XY = new Vector3(smoolX, 0.025f, smoolY);

        MyOwnTile tile_UnitIsStandingOn;
        tile_UnitIsStandingOn = tile_Array[x, y];



        //tile_UnitIsStandingOn.unit_InCell.IsWhite = color;

        unit_GameObject.transform.position = unit_XY;
    }


    public void MoveUnit(int startX, int startY, Unit test, int endX, int endY)
    {
       // GameObject unit_moving = 




    }



    



    void Start ()
    {
        CreateCells();
        CreateUnits();

        Turn_Num = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {


        GameObject thePlayer = GameObject.Find("Tile X: 0 / Y: 0");
        MyOwnTile tileScript = thePlayer.GetComponent<MyOwnTile>();

        tileScript.tile_selected_1 = 0;


    }
}
