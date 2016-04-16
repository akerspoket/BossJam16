using UnityEngine;
using System.Collections;

public class PowerUpHandler : MonoBehaviour {
    int powerUpInt = 0; // 0 = None, 1 = SpeedUp, 2 = SpeedDown, 3 = SpeedRocket, 4 = SlowRocket.
    public float speedUp = 1;
    public float speedDown = 1;
    // Use this for initialization
    void Start ()
    {
        powerUpInt = 1;
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    public void SetPowerUp(int p_powerUpId)
    {
        powerUpInt = p_powerUpId;
    }
    public void FirePowerUp()
    {
        if(powerUpInt ==0)
        {
            //inte ett smack
        }
        else if(powerUpInt==1)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(speedUp, 0.0f, 0.0f));
            // Speedup
        }
        else if(powerUpInt==2)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(-speedDown, 0.0f, 0.0f));
            //SpeedDown
        }
        else if(powerUpInt==3)
        {
            //SpeedRocket
        }
        else if(powerUpInt==4)
        {
            //SlowRocket
        }
        powerUpInt = 0;
    }
}
