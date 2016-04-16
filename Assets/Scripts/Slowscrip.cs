using UnityEngine;
using System.Collections;

public class Slowscrip : MonoBehaviour {
    public float slowFactor;
    public float maxSlow;
	// Use this for initialization
    void OnTriggerStay(Collider player)
    {
        Rigidbody playerRB = player.GetComponent<Rigidbody>();
        if (playerRB.velocity.x > maxSlow)
        {
            playerRB.AddForce(-player.transform.right * slowFactor * Time.deltaTime);
        }
    }
}
