using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthWall : MonoBehaviour
{
    public float maxEarthWallDistance;
    public GameObject earthWallPlatform;
    public LayerMask environmentHits;
    private float currentCooldown;
    public float fullCooldownTime;
    private RaycastHit2D platformRayHit;


    void Update()
    {
        Vector2 rayStart = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.6f);
        if (gameObject.transform.localScale.x > 0)
            platformRayHit = Physics2D.Raycast(rayStart, Vector2.right, maxEarthWallDistance);
        else
            platformRayHit = Physics2D.Raycast(rayStart, Vector2.left, maxEarthWallDistance);
       // RaycastHit2D[] qqq = Physics2D.RaycastAll(rayStart, Vector2.right, maxEarthWallDistance, layerMask:);

        if (currentCooldown <= 0)
        {
            if (Input.GetKeyDown("g"))
            {
                if (gameObject.GetComponent<PlayerController>().isGrounded)
                {
                    Vector2 earthSpawnPoint;
                    Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector2 raycastDirection = new Vector2(ray.x, 0f);
                    RaycastHit2D raycastHit = Physics2D.Raycast(gameObject.transform.position, raycastDirection, maxEarthWallDistance, environmentHits);
                    
                    if (raycastHit.collider != null && !raycastHit.collider.CompareTag("Player"))
                    {
                        earthSpawnPoint = earthSpawningPoint(raycastHit.point.x);
                    }
                    else
                    {
                        if (ray.x > 10f)
                        {
                            ray.x = 10.37f;
                            earthSpawnPoint = earthSpawningPoint(ray.x);
                        }
                        else
                        {
                            earthSpawnPoint = earthSpawningPoint(ray.x);
                        }
                    }
                    Instantiate(earthWallPlatform, earthSpawnPoint, Quaternion.identity);
                    currentCooldown = fullCooldownTime;
                }
            }
        }
        else
        {
            currentCooldown -= Time.deltaTime;
        }
    }

    Vector2 earthSpawningPoint(float xAxisPoint)
    {
        Vector2 earthVector = new Vector2(xAxisPoint - 0.37f, gameObject.transform.position.y + 2.101f);
        return earthVector;
    }
}


// PIVOTS
// Trigger collider to check if the player touching the thing can do it