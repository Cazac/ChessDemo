using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyOwnUnit : MonoBehaviour {

    //Declare a prefab refference to be made in Unity

    public MyOwnTile unit_Position;


    Material originalMaterial_Mat;

    //Material black_Mat;
    Material blackLight_Mat;
    //Material grey_Mat;
    Material greyLight_Mat;

    int Movement;
    public bool IsWhite;
    int Turn_Num = 0;




    public bool unit_Selected = false;




    void Start()
    {
        //Fetch the Material from the Renderer of the GameObject
        originalMaterial_Mat = GetComponent<Renderer>().material;

        //black_Mat = Resources.Load("Black", typeof(Material)) as Material;
        blackLight_Mat = Resources.Load("BlackLight", typeof(Material)) as Material;

        //grey_Mat = Resources.Load("Grey", typeof(Material)) as Material;
        greyLight_Mat = Resources.Load("GreyLight", typeof(Material)) as Material;

    }

    void Update()
    {

    }

    void OnMouseOver()
    {
        //if has a unit no go


        //Change the Color of the GameObject when the mouse hovers over it
        GetComponent<Renderer>().material = greyLight_Mat;
    }

    void OnMouseExit()
    {
        //Change the Color back when the mouse exits the GameObject
        if (unit_Selected == false)
        {
            GetComponent<Renderer>().material = originalMaterial_Mat;
        }
    }


    void OnMouseDown()
    {
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
       


        //if ((Turn_Num % 2) == 0)
        //{

        //}


        //if has a unit no go
        //MyOwn.get

        
    }
}
