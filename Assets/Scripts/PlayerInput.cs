using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
    public float speed = 1;
    public float turnSpeed = 1;
    public float maxTurnSpeed = 1;
    public float turnDecay = 1;
    public float retardation = 1;
    public float acceleration = 1;
    public string buttonName;
    public string buttonNameFire;
    private bool stopMovingBool = false;
    public float angularVelocityFactor;
    private Rigidbody rb;
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 movement = new Vector3(speed, 0.0f, 0.0f);
        rb.velocity = movement;

    }
	
    void FixedUpdate()
    {
        if(!stopMovingBool)
        {
            float turn = Input.GetAxis(buttonName) * -1;
            float oldTurnVelo = rb.velocity.z;
            float oldForwVelo = rb.velocity.x;
            if (rb.velocity.z < -maxTurnSpeed && turn < 0)
            {
                // gör inte ett piss ditt groggluder
            }
            else if (rb.velocity.z > maxTurnSpeed && turn > 0)
            {
                // gör itne ett puss diriajsrpijaspljasd
            }
            else if (turn != 0)
            {
                rb.AddForce(new Vector3(0.0f, 0.0f, turn * turnSpeed * Time.deltaTime));
            }
            else if (turn == 0)
            {
                rb.AddForce(new Vector3(0.0f, 0.0f, -rb.velocity.z * turnDecay * Time.deltaTime));
            }

            Vector3 movement = new Vector3(acceleration * Time.deltaTime, 0.0f, 0.0f);

            rb.AddForce(movement);
            if (Input.GetButtonDown(buttonNameFire))
            {
                GetComponent<PowerUpHandler>().FirePowerUp();
            }
            gameObject.transform.FindChild("MeshHolder").GetComponent<Transform>().Rotate(0, -rb.velocity.x * angularVelocityFactor, 0 );
        }

    }
    public void StopMoving()
        {
            stopMovingBool = true;
            rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }
