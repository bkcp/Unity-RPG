using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
   

    public GameObject player;
    
    // called once
    void Start()
    {
        if(PlayerController.instance == null)
        {
            Instantiate(player);
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
