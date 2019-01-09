using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyOwnTile : MonoBehaviour {

    //Mat Declartaion
    Material beige_Mat;
    Material beigeLight_Mat;

    //Text GameObject Declartaion
    GameObject tile_Text;

    //Script GameObject Declartaion + Script Class
    GameObject scripting_GameObject;
    MyOwn main_Script;
    MyOwnUnit mainUnit_Selected;

    //Tiles have Units
    public MyOwnUnit tiled_Unit;

    //Position Ints
    public int x = 0;
    public int y = 0;

    /////////////////////////////////////////////////////////////////////////////

    void Start()
    {
        //Grab Mats from Resources
        beige_Mat = Resources.Load("Beige", typeof(Material)) as Material;
        beigeLight_Mat = Resources.Load("BeigeLight", typeof(Material)) as Material;

        //Map the GameObject to refference the UI text 
        tile_Text = GameObject.Find("TileSelectedText");

        //Map the GameObject to refference the Main Script 
        scripting_GameObject = GameObject.Find("Scripting");
        main_Script = scripting_GameObject.GetComponent<MyOwn>();
    }

    void OnMouseDown()
    {
        //Grab Selected Unit From Main Script
        mainUnit_Selected = main_Script.mainUnit_Selected;

        if (mainUnit_Selected != null)
        {
            main_Script.MoveUnit(this);
        }
    }

    void OnMouseOver()
    {
        //Change the Color of the GameObject when the mouse hovers over it
        GetComponent<Renderer>().material = beigeLight_Mat;

        //Update Unit Text on Mouse Over
        tile_Text.GetComponent<Text>().text = "Tile: " + x + " " + y;
    }

    void OnMouseExit()
    {
        //Change the Color back when the mouse exits the GameObject
        GetComponent<Renderer>().material = beige_Mat;
    }

    public void Highlight()
    {
        //Change the Color of the GameObject when the mouse hovers over it
        GetComponent<Renderer>().material = beigeLight_Mat;
    }
}
