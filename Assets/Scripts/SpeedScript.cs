using UnityEngine;
using System.Collections;

public class SpeedScript : MonoBehaviour {
    public float speedFactor;
    public float amplitude;
	void OnTriggerStay(Collider player)
    {
        player.GetComponent<Rigidbody>().AddForce(new Vector3(1,0,0) * speedFactor, ForceMode.Acceleration);
    }
    void OnTriggerEnter(Collider Player)
    {
        if (Player.CompareTag("Player"))
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.volume = amplitude;
            audio.Play();
        }
    }
}
