using UnityEngine;
using System.Collections;

public class SpeedScript : MonoBehaviour {
    public float speedFactor;
	void OnTriggerStay(Collider player)
    {
        player.GetComponent<Rigidbody>().AddForce(new Vector3(1,0,0) * speedFactor, ForceMode.Acceleration);
    }
    void OnTriggerEnter()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play(44100);
    }
}
