using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyOwnTile : MonoBehaviour {

    Material tile_Material;

    Material beige_Mat;
    Material beigeLight_Mat;  

    public int x;
    public int y;

    public MyOwnUnit unit_InCell;

    public int tile_selected_1;
    int tile_selected_2;


    

    void Start()
    {
        beige_Mat = Resources.Load("Beige", typeof(Material)) as Material;
        beigeLight_Mat = Resources.Load("BeigeLight", typeof(Material)) as Material;
    }

    void OnMouseOver()
    {
        //if has a unit no go

       
        //Change the Color of the GameObject when the mouse hovers over it
        GetComponent<Renderer>().material = beigeLight_Mat;
    }

    void OnMouseExit()
    {
        //Change the Color back when the mouse exits the GameObject


        GetComponent<Renderer>().material = beige_Mat;
    }
}
