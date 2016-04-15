using UnityEngine;
using System.Collections;

public class PlayerPlacementCalculator : MonoBehaviour {
    private GameObject[] players;
	// Use this for initialization
	void Start () {
        players = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
