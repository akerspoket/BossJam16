using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuSelection : MonoBehaviour {
    public List<GameObject> buttons = new List<GameObject>();
    private int currentlySelected;
	// Use this for initialization
	void Start () {
        ChangeSelection(0);
	}
	
	// Update is called once per frame
	void Update () {
        float y = Input.GetAxis("Vertical");
        if (y > 0.5)
        {
            ChangeSelection(currentlySelected - 1);
        }
        else if (y < -0.5)
        {
            ChangeSelection(currentlySelected + 1);
        }
        if (Input.GetButtonDown("Jump1") || Input.GetButtonDown("Jump2")
            || Input.GetButtonDown("Jump3") || Input.GetButtonDown("Jump4"))
        {
            buttons[currentlySelected].GetComponent<ButtonEffect>().LoadTheScene();
        }
	}

    private void ChangeSelection(int newSelection)
    {
        if (newSelection < 0 || newSelection > buttons.Count - 1)
        {
            return;
        }
        currentlySelected = newSelection;
        transform.position = buttons[currentlySelected].transform.position;
    }

}
