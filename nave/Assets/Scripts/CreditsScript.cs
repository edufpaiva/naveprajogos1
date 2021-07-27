using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScript : MonoBehaviour
{
    public GameObject menuPause;
    public void Credito(){
        menuPause.SetActive(!menuPause.active);
    }
}
