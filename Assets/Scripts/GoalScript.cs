using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {
    private int counter = 0;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(counter == 3)
            {
                //Debug.Log("Jo fan du vann!WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW");
                GameObject[] list = GameObject.FindGameObjectsWithTag("Player");
                int listLength = list.Length;
                //Debug.Log(listLength);
                for (int i = 0; i < listLength; i++)
                {
                    if(list[i]==other)
                    {
                        //sätt grabben uppe på pallfan
                        //Debug.Log("Denna vann!!");
                    }
                    else
                    {
                        //Debug.Log("Denna vann inte=(!");
                        // sätt förloraren där nere.
                    }
                }
            }
            else if(counter !=3)
            {
                ++counter;
            }
        }

    }
}
