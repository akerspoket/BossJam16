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
        Vector3 vecBetweenMeAndTarget = new Vector3(1, 0, 0);
        Vector3 myPosition = transform.position;
        for (int i = 0; i < listLength; i++)
        {
            if (list[i] != ignoredPlayer)
            {
                Vector3 vecBetweenMeAndPlayer = list[i].transform.position - myPosition;
                float lengthBetweenPlayers = vecBetweenMeAndPlayer.magnitude;
                if (lengthBetweenPlayers < ClosestDistance)
                {
                    ClosestDistance = lengthBetweenPlayers;
                    vecBetweenMeAndTarget = vecBetweenMeAndPlayer.normalized;
                }
            }
        }

        transform.GetComponent<Rigidbody>().AddForce(vecBetweenMeAndTarget * heatSeekingFactor);
        transform.LookAt(transform.position - vecBetweenMeAndTarget);
        transform.Rotate(90, 0, 0);
    }
    void OnTriggerEnter(Collider Player)
    {
        if (Player.CompareTag("Player") && Player.gameObject != ignoredPlayer)
        {
            Player.transform.GetComponent<Rigidbody>().AddForce(new Vector3(force, 0.0f, 0.0f));
            Player.gameObject.GetComponent<AudioSource>().Play();

            Destroy(this.gameObject);
        }
    }
    public void SetIgnoreTarget(GameObject Player)
    {
        ignoredPlayer = Player;
    }
}
