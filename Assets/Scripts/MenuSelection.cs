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
	    
	}

    private void ChangeSelection(int newSelection)
    {
        currentlySelected = newSelection;
        transform.position = buttons[currentlySelected].transform.position;
    }

}
