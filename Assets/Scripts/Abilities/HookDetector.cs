using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookDetector : MonoBehaviour
{
    public GameObject player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Environment")
        {
            //player.GetComponent<GrapplingHook>().hooked = true;
           // player.GetComponent<GrapplingHook>().hookedObject = other.gameObject;
        }
    }
}
