using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerDistribution : MonoBehaviour {
    public List<int> FirstPlacedPowerPool = new List<int>();
    public List<int> SecondPlacedPowerPool = new List<int>();
    public List<int> ThirdPlacedPowerPool = new List<int>();
    public List<int> FourthPlacedPowerPool = new List<int>();

    private List<GameObject> playersVisited = new List<GameObject>();
    // Use this for initialization
    void Start () {
	}
    
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
                PowerUpHandler puphandler = unit.GetComponent<PowerUpHandler>();
                Placement placement = unit.GetComponent<Placement>();
                if (puphandler != null && placement != null)
                {
                    int powerToGive = PowerToGive(placement.place);
                    puphandler.SetPowerUp(powerToGive);
                }
                else
                {
                    Debug.Log("A unit with tag player didnt have a pup handler");
                }
                playersVisited.Add(unit.gameObject);
            }
        }
    }

    private int PowerToGive(int placement)
    {
        int power = 0;
        if (placement == 1)
        {
            if (FirstPlacedPowerPool.Count == 0)
            {
                Debug.Log("No powerups in first player pool");
                return 0;
            }
            int powerIndex = Random.Range(0, FirstPlacedPowerPool.Count);
            power = FirstPlacedPowerPool[powerIndex];
        }
        else if (placement == 2)
        {
            if (SecondPlacedPowerPool.Count == 0)
            {
                Debug.Log("No powerups in second player pool");
                return 0;
            }
            int powerIndex = Random.Range(0, SecondPlacedPowerPool.Count);
            power = SecondPlacedPowerPool[powerIndex];
        }
        else if (placement == 3)
        {
            if (ThirdPlacedPowerPool.Count == 0)
            {
                Debug.Log("No powerups in third player pool");
                return 0;
            }
            int powerIndex = Random.Range(0, ThirdPlacedPowerPool.Count);
            power = ThirdPlacedPowerPool[powerIndex];
        }
        else if (placement == 4)
        {
            if (FourthPlacedPowerPool.Count == 0)
            {
                Debug.Log("No powerups in fourht player pool");
                return 0;
            }
            int powerIndex = Random.Range(0, FourthPlacedPowerPool.Count);
            power = FourthPlacedPowerPool[powerIndex];
        }
        return power;
    }
}
