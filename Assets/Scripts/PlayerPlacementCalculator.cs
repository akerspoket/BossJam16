using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PlayerPlacementCalculator : MonoBehaviour {
    private GameObject[] players;
    private List<GameObject> p = new List<GameObject>();
	// Use this for initialization
	void Start () {
        players = GameObject.FindGameObjectsWithTag("Player");
        players.OrderBy(platform => platform.transform.position.x);
    }
	
	// Update is called once per frame
	void Update () {
        players = players.OrderBy(platform => platform.transform.position.x).ToArray();
        Debug.Log(players[2].transform.position.x);
    }
}
