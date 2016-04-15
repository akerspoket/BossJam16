using UnityEngine;
using System.Collections;

public class Slowscrip : MonoBehaviour {
    public float slowFactor;
	// Use this for initialization
    void OnTriggerStay(Collider player)
    {
        player.GetComponent<Rigidbody>().AddForce(Vector3.right * (- slowFactor) , ForceMode.Acceleration);
    }
}
