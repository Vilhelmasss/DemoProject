using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformY : MonoBehaviour
{
    public float minY;
    public float maxY;
    public float platformSpeed;
    private bool movingUp;
    

    void Start()
    {
        movingUp = true;
    }

    void FixedUpdate()
    {
        if (gameObject.transform.position.y < maxY && movingUp)
        {
            transform.Translate(Vector2.up * Time.deltaTime * platformSpeed);
        }
        else if (gameObject.transform.position.y >= maxY)
        {
            movingUp = false;
        }

        if (gameObject.transform.position.y > minY && !movingUp)
        {
            transform.Translate(Vector2.down * Time.deltaTime * platformSpeed);
        }
        else if (gameObject.transform.position.y <= minY)
        {
            movingUp = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Collider2D>().transform.SetParent(transform);
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Collider2D>().transform.SetParent(null);
        }
    }
}
