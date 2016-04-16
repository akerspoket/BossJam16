using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {
    private int counter = 0;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Debug.Log("En går i mål!");

                ++counter;
            if (counter == 3)
            {
                //Debug.Log("Jo fan du vann!");
                GameObject[] list = GameObject.FindGameObjectsWithTag("Player");
                int listLength = list.Length;
                //Debug.Log(listLength);
                for (int i = 0; i < listLength; i++)
                {
                    if(list[i]==other.gameObject)
                    {
                        other.gameObject.transform.position = gameObject.transform.FindChild("VictoryScreen").position;

                        //Remove forward update.
                        other.GetComponent<PowerUpHandler>().FirePowerUp();
                    }
                    else
                    {
                        //Debug.Log("Denna vann inte=(!");
                        // sätt förloraren där nere.
                    }
                }
            }

        }

    }
}
