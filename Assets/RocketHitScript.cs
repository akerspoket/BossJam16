using UnityEngine;
using System.Collections;

public class RocketHitScript : MonoBehaviour {
    public float force;
    private GameObject ignoredPlayer;
    public float heatSeekingFactor;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        GameObject[] list = GameObject.FindGameObjectsWithTag("Player");
        int listLength = list.Length;
        float ClosestDistance = 99999999999999999.0f;
        Vector3 vecBetweenMeAndTarget = new Vector3(0, 0, 0);
        GameObject ClosestObject;
        Vector3 myPosition = transform.position;
        for (int i = 0; i < listLength; i++)
        {
            if (list[i] != ignoredPlayer)
            {
                Vector3 vecBetweenMeAndPlayer = myPosition - list[i].transform.position;
                float lengthBetweenPlayers = vecBetweenMeAndPlayer.magnitude;
                if (lengthBetweenPlayers < ClosestDistance)
                {
                    ClosestDistance = lengthBetweenPlayers;
                    ClosestObject = list[i];
                    vecBetweenMeAndTarget = vecBetweenMeAndPlayer.normalized;
                }
            }
        }
        transform.GetComponent<Rigidbody>().AddForce(vecBetweenMeAndTarget * heatSeekingFactor);
    }
    void OnTriggerEnter(Collider Player)
    {
        if (Player.CompareTag("Player") && Player.gameObject != ignoredPlayer)
        {
            //Debug.Log("PlayerCollided");
            Player.transform.GetComponent<Rigidbody>().AddForce(new Vector3(force, 0.0f, 0.0f));
        }
    }
    void SetIgnoreTarget(GameObject Player)
    {
        ignoredPlayer = Player;
    }
}
