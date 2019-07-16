using UnityEngine;
using System.Collections;

public class ThrowHook : MonoBehaviour
{
    public GameObject hook;
    public bool ropeActive;
    public float distance;
    GameObject curHook;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (ropeActive == false && GetComponent<PlayerController>().otherMovement == false)
            {
                Vector2 destiny = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                curHook = (GameObject)Instantiate(hook, transform.position, Quaternion.identity);
                curHook.GetComponent<RopeScript>().destiny = destiny;
                GetComponent<PlayerController>().otherMovement = true;
                ropeActive = true;
            }
            else
            {
                DestroyCurHook();
                ropeActive = false;
            }
        }
    }
    void DestroyCurHook()
    {
        GetComponent<PlayerController>().otherMovement = false;
        Destroy(curHook);
    }

}