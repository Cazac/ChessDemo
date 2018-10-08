using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyOwnTile : MonoBehaviour {

    Material tile_Material;

    public int x;
    public int y;


    int tile_selected_1;
    int tile_selected_2;


    void Start()
    {
        //Fetch the Material from the Renderer of the GameObject
        tile_Material = GetComponent<Renderer>().material;
    }

    void OnMouseOver()
    {
        //if has a unit no go


        //Change the Color of the GameObject when the mouse hovers over it
        tile_Material.color = Color.grey;
    }

    void OnMouseExit()
    {
        //Change the Color back when the mouse exits the GameObject
        tile_Material.color = Color.yellow;
    }
}
