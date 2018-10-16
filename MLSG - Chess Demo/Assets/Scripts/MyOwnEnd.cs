using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyOwnEnd : MonoBehaviour {

    public GameObject EndButton;

    GameObject mainCamera_GameObject;
    GameObject scripting_GameObject;

    MyOwn main_Script;
    MyOwnCamera cam_Script;

    Vector3 whiteCam_position;
    Quaternion whiteCam_rotation;
    Vector3 blackCam_position;
    Quaternion blackCam_rotation;

    float cameraRotationTime;

    /////////////////////////////////////////////////////////////////////////////

    void Start()
    {
        //Map the GameObject to refference the Main Script 
        scripting_GameObject = GameObject.Find("Scripting");
        mainCamera_GameObject = GameObject.Find("Main Camera");

        cam_Script = mainCamera_GameObject.GetComponent<MyOwnCamera>();
        main_Script = scripting_GameObject.GetComponent<MyOwn>();

        whiteCam_position = new Vector3(-0.25f, 0.5f, 0.35f);
        whiteCam_rotation = Quaternion.Euler(45, 90, 0);

        blackCam_position = new Vector3(0.95f, 0.5f, 0.35f);
        blackCam_rotation = Quaternion.Euler(45, -90, 0);

        cameraRotationTime = 1.5f;
    }

    public void OnClicker()
    {

        if  (main_Script.IsWhiteTurn == true)
        {
            //Set the Black GameObject Moveable
            main_Script.IsWhiteTurn = false;
            main_Script.IsBlackTurn = true;

            //Set camera to Black side
            cam_Script.SetDestination(blackCam_position, blackCam_rotation, cameraRotationTime);
        }
        else
        {
            //Set the White GameObject Moveable
            main_Script.IsWhiteTurn = true;
            main_Script.IsBlackTurn = false;

            //Set camera to white side
            cam_Script.SetDestination(whiteCam_position, whiteCam_rotation, cameraRotationTime);
        }

        main_Script.UIUpdate_Player();
    }
}
