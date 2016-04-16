using UnityEngine;
using System.Collections;

public class Placement : MonoBehaviour {
    public int place = 0;
    void Update()
    {
        if (place == 3)
        {
            GetComponentInChildren<Light>().enabled = true;
        }
        else
        {
            GetComponentInChildren<Light>().enabled = false;
        }
    }
}
