using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyOwn : MonoBehaviour {

    //Declare a prefab refference to be made in Unity
    public GameObject tile_Prefab;
    public GameObject whiteUnit_prefab;
    public GameObject blackUnit_prefab;


    private MyOwnUnit unit_Selected;






    //Uses X , Y coords to locate tile in array
    public MyOwnTile[,] tile_Array = new MyOwnTile[8, 8];

  

    public void CreateCells()
    {
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                GenerateTile(x, y);
            }
        }
    }

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


    public void GenerateTile(int x, int y)
    {
        GameObject tile_GameObject = Instantiate(tile_Prefab) as GameObject;


        tile_GameObject.AddComponent<MyOwnTile>();


            

        float smoolX = x * 0.1f;
        float smoolY = y * 0.1f;
        Vector3 tile_XY = new Vector3(smoolX, 0.0f, smoolY);

        tile_GameObject.transform.position = tile_XY;

      
        MyOwnTile tile;
        //tile_Array[x, y] = tile;
    }

    public void GenerateUnit(int x, int y, bool color)
    {
        GameObject unit_GameObject;

        //Create White or Black Units
        if (color == true)
        {
            unit_GameObject = Instantiate(whiteUnit_prefab) as GameObject;
        }
        else
        {
            unit_GameObject = Instantiate(blackUnit_prefab) as GameObject;
        }

        unit_GameObject.AddComponent<MyOwnUnit>();

        float smoolX = x * 0.1f;
        float smoolY = y * 0.1f;

        Vector3 unit_XY = new Vector3(smoolX, 0.025f, smoolY);

        unit_GameObject.transform.position = unit_XY;
    }










    void Start ()
    {
        CreateCells();
        CreateUnits();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
