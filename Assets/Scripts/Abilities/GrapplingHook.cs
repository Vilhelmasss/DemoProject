using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public GameObject hook;
    public GameObject hookHolder;

    public float hookTravelSpeed;
    public float playerTravelSpeed;

    public static bool fired;
    public bool hooked;
    public bool otherMovement;
    public GameObject hookedObject;
    
    public float maxDistance;
    private float currentDistance;

    private Vector2 velocityVector;
    void Start()
    {
        velocityVector = new Vector2(0,0);
    }

    void Update()
    {
        otherMovement = GetComponent<PlayerController>().otherMovement;
        if (Input.GetKeyDown("x") && !fired && !otherMovement)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
            float coff = Mathf.Abs(mousePos.x) + Mathf.Abs(mousePos.y);
            coff = hookTravelSpeed / coff;
            velocityVector = new Vector2(mousePos.x * coff, mousePos.y * coff);
            fired = true;
        }

        if (fired && !hooked)
        {
            hook.transform.Translate(velocityVector * Time.deltaTime);
            currentDistance = Vector2.Distance(transform.position, hook.transform.position);

            if(currentDistance >= maxDistance)
                ReturnHook();
        }

        if (hooked)
        {
            GetComponent<PlayerController>().otherMovement = true;
            hook.transform.parent = hookedObject.transform;
            transform.position = Vector2.MoveTowards(transform.position, hook.transform.position, playerTravelSpeed * Time.deltaTime);
            float distanceToHook = Vector2.Distance(transform.position, hook.transform.position);

            GetComponent<Rigidbody2D>().gravityScale = 0f;


            if (distanceToHook < 1)
            {
                ReturnHook();
            }
        }
        else
        {
            hook.transform.parent = hookHolder.transform;
            GetComponent<Rigidbody2D>().gravityScale = 1f;
        }
    }

    void ReturnHook()
    {
        GetComponent<PlayerController>().otherMovement = false;
        hook.transform.position = hookHolder.transform.position;
        fired = false;
        hooked = false;
    }
}
