using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Main : MonoBehaviour {

    public GameObject playerRef;
    public Transform playerT;
    
    
    public  List<GameObject> doorArrEnter = new List<GameObject>();
    public  List<GameObject> doorArrExit = new List<GameObject>();

    public static List<GameObject> doorArrEnterRef = new List<GameObject>();
    public static List<GameObject> doorArrExitRef = new List<GameObject>();

    // Use this for initialization
    void Start () {
        doorArrEnterRef = doorArrEnter;
        doorArrExitRef = doorArrExit;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(playerT.transform.position.x, playerT.transform.position.y + 3, -10);
	}

   
}
