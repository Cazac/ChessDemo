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
    public GameObject destructionText_Prefab;

    //Text GameObject Declartaion
    GameObject turnNumber_Text;
    GameObject turnPlayer_Text;
    GameObject canvas;

    //Audio Files added to script by Unity Designer
    public AudioClip Ambient_SFX;
    public AudioClip emptyTile_SFX;
    public AudioClip CaptureUnit_SFX;
    public AudioClip SameUnit_SFX;

    //GameOjects Audio Compantent
    AudioSource main_AudioSourceSFX;
    AudioSource main_AudioSourceBG;

    //Volume float value used to set audio volume
    float volume = 1f;

    //Vector3 used to center Text
    Vector3 center_V3;

    //Selected Unit used to find out what to move / select / unselect
    public MyOwnUnit mainUnit_Selected;
    public GameObject mainUnitSelected_GO;

    //count the turns taken in a match
    public int turnCounter = 0;
    public bool IsWhiteTurn = false;
    public bool IsBlackTurn = false;

    //Unit and Tile arrays - Uses X , Y coords to locate object and link them
    public GameObject[,] tileGO_Array = new GameObject[8, 8];
    public GameObject[,] unitGO_Array = new GameObject[8, 8];


    /////////////////////////////////////////////////////////////////////////////

    //When the Script Starts
    void Start()
    {
        //Startup Functions
        CreateTiles();
        CreateUnits();
        Link_TileUnit();

        //Map the GameObject to refference the UI text 
        turnNumber_Text = GameObject.Find("TurnNumberText");
        turnPlayer_Text = GameObject.Find("TurnPlayerText");
        canvas = GameObject.Find("Canvas");

        //Setup for SFX Audio
        main_AudioSourceSFX = GetComponent<AudioSource>();
        main_AudioSourceSFX.PlayOneShot(emptyTile_SFX, volume);

        //Setup for Background Audio
        main_AudioSourceBG = GetComponent<AudioSource>();
        main_AudioSourceBG.loop = true;
        main_AudioSourceBG.clip = Ambient_SFX;
        main_AudioSourceBG.volume = 0.2f;
        main_AudioSourceBG.Play();

        //Set UI Text for the First Turn Counter
        turnNumber_Text.GetComponent<Text>().text = "Turn: " + turnCounter;
    }

    //For Each Frame
    void Update()
    {
        //If Statment for closing the Application on "ESC: key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

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
    }

    //Link Units to Tiles
    public void Link_TileUnit()
    {
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                //If a unit is in the array
                if (unitGO_Array[x, y] != null) 
                {
                    //Refference loop specific GameObjects
                    GameObject tile_GO = tileGO_Array[x, y];
                    GameObject unit_GO = unitGO_Array[x, y];

                    //Get GameObject Componants
                    MyOwnTile linkingTile_Script = tile_GO.GetComponent<MyOwnTile>();
                    MyOwnUnit linkingUnit_Script = unit_GO.GetComponent<MyOwnUnit>();

                    //Link the Classes to each other
                    linkingTile_Script.tiled_Unit = linkingUnit_Script;
                    linkingUnit_Script.Unit_tiled = linkingTile_Script; 
                }
            }
        }
    }

    /////////////////////////////////////////////////////////////////////////////

    public void MoveUnit(MyOwnTile end_Tile)
    {
        //Declare the Starting tile Class OBJ
        MyOwnTile start_Tile;

        //If the Unit is of the same Color Retun from function
        if (end_Tile.tiled_Unit != null)
        {
            if (end_Tile.tiled_Unit.IsWhite == mainUnit_Selected.IsWhite)
            {
                //Play the Corresponding SFX
                main_AudioSourceSFX.PlayOneShot(SameUnit_SFX);
                return;
            }
        }

        //Create new V3 with XY given by selected Tile then Chnages Unit position
        Vector3 newPosition_V3 = new Vector3((end_Tile.x * 0.1f), 0.025f, (end_Tile.y * 0.1f));
        mainUnitSelected_GO.transform.position = newPosition_V3;

        //A Unit is already in this position!
        if (end_Tile.tiled_Unit != null)
        {
            //Play the Corresponding SFX
            main_AudioSourceSFX.PlayOneShot(CaptureUnit_SFX);
            CheckCollisionEnemy(end_Tile);
        }
        else
        {
            //Play the Corresponding SFX
            main_AudioSourceSFX.PlayOneShot(emptyTile_SFX);
        }

        //Get the Starting Tile and Remove the Unit refference
        start_Tile = mainUnit_Selected.Unit_tiled;
        start_Tile.tiled_Unit = null;
       
        //Set new Unit Coords
        mainUnit_Selected.x = end_Tile.x;
        mainUnit_Selected.y = end_Tile.y;

        //New Tile is Set to the Moved Unit + the vise versa
        end_Tile.tiled_Unit = mainUnit_Selected;
        mainUnit_Selected.Unit_tiled = end_Tile;

        //UnSelect after moving
        mainUnit_Selected.UnselectUnit();

        //Update Turn counter and then The UI
        turnCounter++;
        UIUpdate_Turn();
    }

    public void CheckCollisionEnemy(MyOwnTile end_Tile)
    {
        //Get Unit Color for UI
        bool IsWhite = end_Tile.tiled_Unit.IsWhite;

        //Destroy the old Unit
        end_Tile.tiled_Unit.DestoryMe();

        //Set UI for the Destruction
        UIUpdate_Destroy(IsWhite);
    }

    /////////////////////////////////////////////////////////////////////////////

    public void UIUpdate_Turn()
    {
        //Set new UI Text
        turnNumber_Text.GetComponent<Text>().text = "Turn: " + turnCounter;
    }

    public void UIUpdate_Player()
    {
        //Set new UI Text for white or black turn
        if (IsWhiteTurn == true)
        {
            turnPlayer_Text.GetComponent<Text>().text = "Player: White";
        }
        else
        {
            turnPlayer_Text.GetComponent<Text>().text = "Player: Black";
        }
        
    }

    public void UIUpdate_Destroy(bool IsWhite)
    {
        //Declare the new Text String
        string color_Text;

        if (IsWhite == true)
        {
            //Set New UI Text variable
            color_Text = "A White Unit was destroyed";

            //Map Vector3 to higher text placement
            center_V3 = new Vector3(0, -300, 0);
        }
        else
        {
            //Set New UI Text variable
            color_Text = "A Black Unit was destroyed";

            //Map Vector3 to lower text placement
            center_V3 = new Vector3(0, -280, 0);
        }

        //Create new UI Text GameObject
        GameObject destruction_Text = Instantiate(destructionText_Prefab) as GameObject;
       
        //Set GameObject Postion
        destruction_Text.transform.SetParent(canvas.transform);
        destruction_Text.transform.localPosition = center_V3;

        //Destory GameObject after 3 Seconds
        destruction_Text.GetComponent<Text>().text = color_Text;
        Destroy(destruction_Text, 3);
    }
}
