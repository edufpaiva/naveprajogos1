using UnityEngine;
using System.Collections;

public class SoundOFF : MonoBehaviour {
    private AudioSource sons;
    public float volume;
    // Use this for initialization
    void Awake() {
        sons = GetComponent<AudioSource>();
    }
        

	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        

        if (GameManager.Instance.GetMudo())
        {
            sons.volume = 0;
        }
        else {
            sons.volume = volume;
            
        }
    }
}
