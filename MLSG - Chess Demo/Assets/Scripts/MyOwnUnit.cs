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
    MyOwnUnit mainUnit_Selected;

    public AudioSource unit_AudioSource;
    public AudioClip emptyTile_SFX;
    public AudioClip CaptureUnit_SFX;
    public AudioClip SameUnit_SFX;

    //Units have Tiles
    public MyOwnTile Unit_tiled;

    //Position Ints
    public int x = 0;
    public int y = 0;

    //Attributes
    public bool IsWhite;
    public bool unit_Selected = false;

    /////////////////////////////////////////////////////////////////////////////

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

        unit_AudioSource = GetComponent<AudioSource>();
        emptyTile_SFX = Resources.Load("Empty", typeof(AudioClip)) as AudioClip;
        CaptureUnit_SFX = Resources.Load("Capture", typeof(AudioClip)) as AudioClip;
        SameUnit_SFX = Resources.Load("Same", typeof(AudioClip)) as AudioClip;
    }

    void Update()
    {

    }

    /////////////////////////////////////////////////////////////////////////////

    void OnMouseOver()
    {
        if (IsPlayersTurn() == true)
        {
            if (IsWhite == true)
            {
                //Change the Color of the GameObject when the mouse hovers over it
                GetComponent<Renderer>().material = greyLight_Mat;
            }
            else
            {
                //Change the Color of the GameObject when the mouse hovers over it
                GetComponent<Renderer>().material = blackLight_Mat;
            }


            //Set tile text to mouse over cords
            tile_Text.GetComponent<Text>().text = "Tile: " + x + " " + y;
        }
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
        if (IsPlayersTurn() == true)
        {
            //Grab Selected Unit From Main Script
            mainUnit_Selected = main_Script.mainUnit_Selected;

            unit_AudioSource.PlayOneShot(emptyTile_SFX);

            //if Main Script does not have a Unit already
            if (mainUnit_Selected == null)
            {
                //if the unit is selected already remove glow Mat if not apply it
                if (unit_Selected == false)
                {
                    SelectUnit();
                }
                else
                {
                    UnselectUnit();
                }
            }
            else //if Main Script has a Unit already
            {
                if (mainUnit_Selected == this)
                {
                    //Unselect its own Unit
                    UnselectUnit();
                }
                else
                {
                    //Remove the prevouis other Unit Selection
                    mainUnit_Selected.UnselectUnit();

                    //Set this Unit
                    SelectUnit();
                }
            }
        }   
    }

    public bool IsPlayersTurn()
    {
        bool PlayersTurn;

        if (this.IsWhite == true)
        {
            if (main_Script.IsWhiteTurn == true)
            {
                PlayersTurn = true;
            }
            else
            {
                PlayersTurn = false;
            }
        }
        else
        {
            if (main_Script.IsBlackTurn == true)
            {
                PlayersTurn = true;
            }
            else
            {
                PlayersTurn = false;
            }
        }
        
        return PlayersTurn;
    }

    /////////////////////////////////////////////////////////////////////////////

    public void DestoryMe()
    {
        Destroy(gameObject);
    }

    public void SelectUnit()
    {
        unit_Selected = true;
        main_Script.mainUnit_Selected = this;
        main_Script.mainUnitSelected_GO = gameObject;

        GetComponent<Renderer>().material = greyLight_Mat;
    }

    public void UnselectUnit()
    {
        unit_Selected = false;
        main_Script.mainUnit_Selected = null;
        main_Script.mainUnitSelected_GO = null;

        GetComponent<Renderer>().material = originalMaterial_Mat;
    }

}
