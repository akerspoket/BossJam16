using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
    public float speed = 1;
    public float turnSpeed = 1;
    public float maxTurnSpeed = 1;
    public float turnDecay = 1;
    public string buttonName;
    public string buttonNameFire;
    private Rigidbody rb;
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
    void FixedUpdate()
    {
        float turn = Input.GetAxis(buttonName)*-1;
        float oldTurnVelo = rb.velocity.z;
        if(rb.velocity.z < -maxTurnSpeed && turn < 0)
        {
            // gör inte ett piss ditt groggluder
        }
        else if(rb.velocity.z > maxTurnSpeed && turn > 0)
        {
            // gör itne ett puss diriajsrpijaspljasd
        }
        else if(turn != 0)
        {
            rb.AddForce(new Vector3(0.0f, 0.0f, turn * turnSpeed * Time.deltaTime));
        }
        else if(turn == 0)
        {
            rb.AddForce(new Vector3(0.0f, 0.0f, -rb.velocity.z * turnDecay * Time.deltaTime));
        }
        Vector3 movement = new Vector3(speed, 0.0f, oldTurnVelo);
        rb.velocity = movement;
        if(Input.GetKeyDown(buttonNameFire))
        {
            GetComponent<PowerUpHandler>().FirePowerUp();
        }
        GetComponent<PowerUpHandler>().FirePowerUp();

    }
}
