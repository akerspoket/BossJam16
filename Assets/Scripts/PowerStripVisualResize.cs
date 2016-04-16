using UnityEngine;
using System.Collections;

public class PowerStripVisualResize : MonoBehaviour {
    private GameObject groundPart;

    public void SetGroundPart(GameObject part)
    {
        groundPart = part;
    }

    public void ResizeToFitGround()
    {
        Vector3 scale = new Vector3(groundPart.transform.localScale.z, 0.1f, 2); // A bit wierd but its becaus its rotated to fit texture
        transform.localScale = scale; 
    }
}
