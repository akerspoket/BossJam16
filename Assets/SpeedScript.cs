using UnityEngine;
using System.Collections;

public class SpeedScript : MonoBehaviour {
    public float speedFactor;
	void OnTriggerStay(Collider player)
    {
        player.GetComponent<Rigidbody>().AddForce(Vector3.right * speedFactor, ForceMode.Acceleration);
    }
}
