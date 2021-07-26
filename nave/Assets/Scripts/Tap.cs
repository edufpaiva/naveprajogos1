using UnityEngine;
using System.Collections;

public class Tap : MonoBehaviour {
    private bool foi = true;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (foi)
        {
            foi = false;
            Destroy(gameObject, 1f);
        }
    }

}
