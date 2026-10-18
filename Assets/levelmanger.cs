using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelmanger : MonoBehaviour
{
    // Start is called before the first frame update


public GameObject currentcheckpoint;

    void Start()
    {
        currentcheckpoint = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
public void Respawnplayer()
    {
       FindObjectOfType<PlayerController>().transform.position = currentcheckpoint.transform.position;

       }



}
