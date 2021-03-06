﻿using UnityEngine;
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
    public string buttonNameJump;
    private bool stopMovingBool = true;
    public float angularVelocityFactor;
    public float coolDownJump = 1;
    private float timeSinceLastJump;
    private float timeElapsed;
    private Rigidbody rb;
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 movement = new Vector3(speed, 0.0f, 0.0f);
        rb.velocity = movement;
        timeElapsed = 100;
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


            gameObject.transform.FindChild("MeshHolder").GetComponent<Transform>().Rotate(0, -rb.velocity.x * angularVelocityFactor, 0 );
        }
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (Input.GetButtonDown(buttonNameFire))
        {
            GetComponent<PowerUpHandler>().FirePowerUp();
        }
        if (Input.GetButtonDown(buttonNameJump) && timeElapsed > coolDownJump)
        {
            timeElapsed = 0;
            //timeSinceLastJump = Time.time - timeElapsed;
            Vector3 jump = new Vector3(0.0f, 300.0f, 0.0f);
            rb.AddForce(jump);
        }
    }

    public void StopMoving()
    {
        stopMovingBool = true;
        rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        GetComponentInChildren<Light>().enabled = false;
        GetComponent<Placement>().enabled = false;
    }
    public void StartMoving()
    {
        stopMovingBool = false;
    }
}
