using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassablePlatform : MonoBehaviour
{
    private PlatformEffector2D effector;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown("s") && GetComponent<PlayerController>().groundCheck)
        {
            effector.rotationalOffset = 180f;
        }

        
    }

    void OnColisionEnter2D(Collider2D other)
    {

    }
}
