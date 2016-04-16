using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraFocalPlacement : MonoBehaviour {
    private GameObject[] players;
    public bool victoryScreenTime = false;
    private bool isItInitialized = false;

    // Use this for initialization
    void Start () {
        players = GameObject.FindGameObjectsWithTag("Player");
        int length = players.GetLength(0);
        Vector3 position = Vector3.zero;
        for (int i = 0; i < length; i++)
        {
            position += players[i].transform.position;
        }
        position /= length;
        transform.position = position;


    }
	
	// Update is called once per frame
	void Update () {
        victoryScreenTime = GameObject.Find("GoalTrigger").GetComponent<GoalScript>().IsItDoneFunc();
        if (!victoryScreenTime)
        {
            int length = players.GetLength(0);
            Vector3 position = Vector3.zero;
            for (int i = 0; i < length; i++)
            {
                position += players[i].transform.position;
            }
            position /= length;
            //position.y = transform.position.y;
            transform.position = position;
        }
        else
        {
            if(!isItInitialized)
            {
                GetComponent<CameraLerpScript>().OwnStart();
                isItInitialized = true;
            }
            GetComponent<CameraLerpScript>().OwnUpdate();
        }

	}
}
