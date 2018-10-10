using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyOwnUnit : MonoBehaviour {

    //Mat Declartaion
    Material originalMaterial_Mat;
    Material blackLight_Mat;
    Material greyLight_Mat;

    //Text GameObject Declartaion
    GameObject tile_Text;

    //Script GameObject Declartaion + Script Class
    GameObject scripting_GameObject;
    MyOwn main_Script;

    //Position Ints
    public int x = 0;
    public int y = 0;

    //Attributes
    public bool IsWhite;
    public bool unit_Selected = false;

    ////////////////////////////////////////////////////


    void Start()
    {
        //Fetch the Material from the Renderer of the GameObject
        originalMaterial_Mat = GetComponent<Renderer>().material;

        //Grab the highlighted versions of each Mat
        blackLight_Mat = Resources.Load("BlackLight", typeof(Material)) as Material;
        greyLight_Mat = Resources.Load("GreyLight", typeof(Material)) as Material;

        //Map the GameObject to refference the UI text 
        tile_Text = GameObject.Find("TileSelectedText");

        //Map the GameObject to refference the Main Script 
        scripting_GameObject = GameObject.Find("Scripting");
        main_Script = scripting_GameObject.GetComponent<MyOwn>();
    }

    void Update()
    {

    }

    void OnMouseOver()
    {
        //Change the Color of the GameObject when the mouse hovers over it
        GetComponent<Renderer>().material = greyLight_Mat;

        //Set tile text to mouse over cords
        tile_Text.GetComponent<Text>().text = "Tile: " + x + " " + y;
    }

    void OnMouseExit()
    {
        //Change the Color back when the mouse exits the GameObject but only if its not selected
        if (unit_Selected == false)
        {
            GetComponent<Renderer>().material = originalMaterial_Mat;
        }
    }

    void OnMouseDown()
    {
        //if the unit is selected already remove glow Mat if not apply it
        if (unit_Selected == false)
        {
            unit_Selected = true;

            GetComponent<Renderer>().material = greyLight_Mat;
        }
        else
        {
            unit_Selected = false;

            GetComponent<Renderer>().material = originalMaterial_Mat;
        }
    }
}
