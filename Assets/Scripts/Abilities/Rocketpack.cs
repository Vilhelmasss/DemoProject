using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocketpack : MonoBehaviour
{
    private Rigidbody2D rb;

    public float time;
    public float cooldown;
    private float remainingCooldown;
    public float speed;
    private bool isRocketActive;

    void Start()
    {
        remainingCooldown = 0;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetKeyDown("z") && !GetComponent<PlayerController>().otherMovement)
        {
            if (remainingCooldown <= 0)
            {
                isRocketActive = true;
                remainingCooldown = cooldown;
                GetComponent<PlayerController>().otherMovement = true;
                Invoke("NoRocketPack", 5);
            }
        }
        else if (isRocketActive == false)
        {
            remainingCooldown -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if (isRocketActive && time > 0)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
            float coff = Mathf.Abs(mousePos.x) + Mathf.Abs(mousePos.y);
            coff = speed / coff;

            Vector2 velocityVector = new Vector2(mousePos.x * coff, mousePos.y * coff);
            rb.AddForce(velocityVector, ForceMode2D.Force);

            time -= Time.deltaTime;
        }
        else
        {
            time = 5;
            isRocketActive = false;
        }
    }

    void NoRocketPack()
    {
        GetComponent<PlayerController>().otherMovement = false;
    }
}
