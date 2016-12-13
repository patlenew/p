using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour {

    public List<GameObject> EventCont = new List<GameObject>();

    public static List<GameObject> EventContGet = new List<GameObject>();

    // Use this for initialization
    void Start () {
        EventContGet = EventCont;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
