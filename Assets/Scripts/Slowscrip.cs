using UnityEngine;
using System.Collections;

public class Slowscrip : MonoBehaviour {
    public float slowFactor;
    public float maxSlow;
    public float amplitude;
	// Use this for initialization
    void OnTriggerStay(Collider player)
    {
        Rigidbody playerRB = player.GetComponent<Rigidbody>();
        if (playerRB.velocity.x > maxSlow)
        {
            playerRB.AddForce(new Vector3(-1,0,0) * slowFactor * Time.deltaTime);
        }
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
