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

    //Position Ints
    public int x = 0;
    public int y = 0;

    ////////////////////////////////////////////
    


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
        MyOwnUnit unitttt;
       
        //Do Script Stuff
        unitttt = main_Script.selected_Unit;


        if (unitttt != null)
        {
            print("Object Present");
            //MoveUnit()
            
        }
        else
        {
            print("is Null");
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
}
