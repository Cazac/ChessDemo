using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyOwnStart : MonoBehaviour {

    public GameObject EndButton;

    void onClick()
    {
        gameObject.SetActive(false);
        EndButton.SetActive(true);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
