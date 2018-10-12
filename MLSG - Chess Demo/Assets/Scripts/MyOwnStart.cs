using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyOwnStart : MonoBehaviour {

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

    void Start()
    {
        //Map the GameObject to refference the Main Script 
        scripting_GameObject = GameObject.Find("Scripting");
        mainCamera_GameObject = GameObject.Find("Main Camera");

        cam_Script = mainCamera_GameObject.GetComponent<MyOwnCamera>();
        main_Script = scripting_GameObject.GetComponent<MyOwn>();

        whiteCam_position = new Vector3(-0.25f, 0.5f, 0.35f);
        whiteCam_rotation = Quaternion.Euler(45, 90, 0);
        cameraRotationTime = 2f;
    }

    public void OnClicker()
    {
        //Set camera to white side
        cam_Script.SetDestination(whiteCam_position, whiteCam_rotation, cameraRotationTime);

        //Set the White GameObject Moveable
        main_Script.IsWhiteTurn = true;
        main_Script.UIUpdate_Player();

        //Turn The Start Element Off and the End Tunr Element On
        gameObject.SetActive(false);
        EndButton.SetActive(true);
    }
}
