using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantSwap : MonoBehaviour
{
    public float maxDistance;
    public float totalCooldown;
    private float currentCooldown;
    private bool swapCheck;
    private Transform savedTransform;
    public LayerMask detectableColliders;

    void Start()
    {
        swapCheck = false;
        currentCooldown = 0f;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown("t"))
        {
            swapCheck = true;
        }
    }

    void Update()
    {
        if (currentCooldown <= 0)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                Vector2 mouseDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
                RaycastHit2D rayhit = Physics2D.Raycast(gameObject.transform.position, mouseDirection, maxDistance, detectableColliders);
                Debug.Log(rayhit.collider.name);
                if (rayhit.collider != null && rayhit.collider.gameObject.layer.ToString() != "EnvironmentLayer")
                {
                    Vector2 savedPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
                    gameObject.transform.position = rayhit.collider.gameObject.transform.position;
                    rayhit.collider.gameObject.transform.position = savedPosition;
                    currentCooldown = totalCooldown;
                }
                swapCheck = false;
            }
        }
        else
        {
            currentCooldown -= Time.deltaTime;
        }
    }
}
