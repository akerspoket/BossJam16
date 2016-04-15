using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraFocalPlacement : MonoBehaviour {
    private GameObject[] players;
	// Use this for initialization
	void Start () {
        players = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        int length = players.GetLength(0);
        Vector3 position = Vector3.zero;
        for (int i = 0; i < length; i++)
        {
            position += players[i].transform.position;
        }
        position /= length;
        position.y = transform.position.y;
        transform.position = position;
	}
}
