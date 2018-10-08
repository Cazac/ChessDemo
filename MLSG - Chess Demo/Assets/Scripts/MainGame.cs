using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour {

    Board MYGameBoard;

    public GameObject Player1UnitPrefab;
    public GameObject Player2UnitPrefab;


    public GameUnit[,] gameUnits = new GameUnit[8, 8];



    public void CreateBoard()
    {
        for (int y = 0; y < 2; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                GeneratePiece(x, y);
            }
        }
    }


    public void GeneratePiece(int x, int y)
    {
        GameObject Player1Unit_GameObject = Instantiate(Player1UnitPrefab) as GameObject;
        GameObject Player2Unit_GameObject = Instantiate(Player2UnitPrefab) as GameObject;

        Player1Unit_GameObject.transform.SetParent(transform);
        Player2Unit_GameObject.transform.SetParent(transform);

        GameUnit unit = Player1Unit_GameObject.GetComponent<GameUnit>();





        print("Unit Spawning for: " + x + " " + y);

        SetPosition(unit, x, y);
    }


    public void SetPosition(GameUnit unit, int x, int y)
    {
        print("Start SetPosition()");

        Vector3 test = new Vector3(0, 0, 0);
        unit.transform.position = (Vector3.right * x) + (Vector3.forward * y) + test;

        print("End SetPosition()");

    }




    // Use this for initialization
    void Start ()
    {
        CreateBoard();
        //MYGameBoard.CreateBoard();
    }
	
	// Update is called once per frame
	void Update ()
    {

	    //if 	
	}
}
