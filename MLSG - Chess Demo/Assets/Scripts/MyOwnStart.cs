using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyOwnStart : MonoBehaviour {

    public GameObject EndButton;
    //public MyOwn MethodCaller;


    GameObject scripting_GameObject;
    MyOwn main_Script;


    void Start()
    {
        //Map the GameObject to refference the Main Script 
        scripting_GameObject = GameObject.Find("Scripting");
        main_Script = scripting_GameObject.GetComponent<MyOwn>();
    }

    public void OnClicker()
    {
        gameObject.SetActive(false);
        EndButton.SetActive(true);

        //main_Script.MoveUnitTest();
        main_Script.MoveCamera();


        //GameObject go = GameObject.Find("somegameobjectname");
        //ScriptB other = (ScriptB)go.GetComponent(typeof(ScriptB));
        //other.DoSomething();
    }
}
