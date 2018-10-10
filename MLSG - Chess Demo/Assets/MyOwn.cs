using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyOwn : MonoBehaviour {

    //Declare GameObjects which will have refference to be made in Unity or Script

    //PreFab GameObject Declartaion
    public GameObject tile_Prefab;
    public GameObject whiteUnit_Prefab;
    public GameObject blackUnit_Prefab;

    //Text GameObject Declartaion
    GameObject turnNumber_Text;
    GameObject turnPlayer_Text;
    GameObject tileSelected_Text;

    //Selected Unit used to find out what to move / select / unselect
    public MyOwnUnit selected_Unit;

    //count the turns taken in a match
    public int turnCounter = 0;




    //Unit and Tile arrays - Uses X , Y coords to locate object
    public GameObject[,] tileGO_Array = new GameObject[8, 8];
    public GameObject[,] unitGO_Array = new GameObject[8, 8];

    //Old Arrays from Demo Vid
    public MyOwnTile[,] tile_Array = new MyOwnTile[8, 8];
    public MyOwnUnit[,] unit_Array = new MyOwnUnit[8, 8];


    /////////////////////////////////////////////////////////////////////////////

    //Function to Create all Tiles
    public void CreateTiles()
    {
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                GenerateTile(x, y);
            }
        }
    }

    //Function to Create all Units
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

    //Function to Generate all Tiles
    public void GenerateTile(int x, int y)
    {
        //Create the GameObject from the Prefab
        GameObject tile_GameObject = Instantiate(tile_Prefab) as GameObject;

        //Sets the Script of GameObject.
        tile_GameObject.AddComponent<MyOwnTile>();

        //Sets the name of GameObject.
        tile_GameObject.name = "Tile X: " + x + " / Y: " + y;

        //Manipulate the X and Y coords to match the board size and position.
        float smoolX = x * 0.1f;
        float smoolY = y * 0.1f;

        //Set Vector3 value for position then transform the GameObject with the variable
        Vector3 tile_XY = new Vector3(smoolX, 0.0f, smoolY);
        tile_GameObject.transform.position = tile_XY;

        //Grab Script from the GameObject and set entity dependant Script variables
        MyOwnTile tile_Script = tile_GameObject.GetComponent<MyOwnTile>();
        tile_Script.x = x;
        tile_Script.y = y;









        //Add GameObject to Array with coords as refference ID
        tileGO_Array[x, y] = tile_GameObject;

        //MyOwnTile tile = tile_GameObject.GetComponent<MyOwnTile>();
        //MyOwnTile tile2 = new MyOwnTile();
        //tile_Array[x, y] = tile;
        //tile_Array[x, y] = tile2;
    }

    //Function to Generate all Units
    public void GenerateUnit(int x, int y, bool color)
    {
        //Create the GameObject
        GameObject unit_GameObject;

        //Create White or Black Units
        if (color == true)
        {
            //Set the GameObject from the Prefab
            unit_GameObject = Instantiate(whiteUnit_Prefab) as GameObject;

            //Sets the name of GameObject.
            unit_GameObject.name = "White Unit X: " + x + " / Y: " + y;
        }
        else
        {
            //Set the GameObject from the Prefab
            unit_GameObject = Instantiate(blackUnit_Prefab) as GameObject;

            //Sets the name of GameObject.
            unit_GameObject.name = "Black Unit X: " + x + " / Y: " + y;
        }

        //Add Script to GameObject
        unit_GameObject.AddComponent<MyOwnUnit>();

        //Manipulate the X and Y coords to match the board size and position.
        float smoolX = x * 0.1f;
        float smoolY = y * 0.1f;

        //Set Vector3 value for position then transform the GameObject with the variable
        Vector3 unit_XY = new Vector3(smoolX, 0.025f, smoolY);
        unit_GameObject.transform.position = unit_XY;

        //Grab Script from the GameObject and set entity dependant Script variables
        MyOwnUnit unit_Script = unit_GameObject.GetComponent<MyOwnUnit>();
        unit_Script.x = x;
        unit_Script.y = y;
        unit_Script.IsWhite = color;





        //Add GameObject to Array with coords as refference ID
        unitGO_Array[x, y] = unit_GameObject;

        //MyOwnTile tile_UnitIsStandingOn;
        //tile_UnitIsStandingOn = tile_Array[x, y];
        //tile_UnitIsStandingOn.unit_InCell.IsWhite = color;
    }





    public void MoveUnit(int startX, int startY, Unit test, int endX, int endY)
    {

    }



    



    void Start ()
    {
        //Startup Functions
        CreateTiles();
        CreateUnits();

        //Map the GameObject to refference the UI text 
        turnNumber_Text = GameObject.Find("TurnNumberText"); 
        turnPlayer_Text = GameObject.Find("TurnPlayerText");
        tileSelected_Text = GameObject.Find("TileSelectedText");

        //Set UI Text
        turnNumber_Text.GetComponent<Text>().text = "Turn: " + turnCounter;
    }

    void Update ()
    {

    }
}
