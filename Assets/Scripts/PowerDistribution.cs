using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerDistribution : MonoBehaviour {
    public List<GameObject> FirstPlacedPowerPool = new List<GameObject>();
    public List<GameObject> SecondPlacedPowerPool = new List<GameObject>();
    public List<GameObject> ThirdPlacedPowerPool = new List<GameObject>();
    public List<GameObject> FourthPlacedPowerPool = new List<GameObject>();

    private List<GameObject> playersVisited = new List<GameObject>();
    // Use this for initialization
    void Start () {
	}

    // Update is called once per frame
    void OnTriggerEnter(Collider unit)
    {
        if (unit.CompareTag("Player"))
        {           
            bool givePower = true;
            foreach (GameObject player  in playersVisited)
            {
                if (player == unit.gameObject)
                {
                    givePower = false;
                }
            }
            if (givePower)
            {
                // Give power here!
                Debug.Log("Give player power");
            }
        }
    }
}
