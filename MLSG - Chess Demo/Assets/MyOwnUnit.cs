using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyOwnUnit : MonoBehaviour {

    //Declare a prefab refference to be made in Unity

    public MyOwnTile unit_Position;


    Material unit_Material;

    void OnMouseDown()
    {
        //if has a unit no go
        //MyOwn.get

        //Change the Color of the GameObject when the mouse hovers over it
        unit_Material.color = Color.cyan;
    }


    void Start()
    {
        //Fetch the Material from the Renderer of the GameObject
        unit_Material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
