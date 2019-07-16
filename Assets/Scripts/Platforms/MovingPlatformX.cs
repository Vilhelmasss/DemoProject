using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformX : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float platformSpeed;
    private bool movingRight;

    void Start()
    {
        movingRight = true;
    }

    void FixedUpdate()
    {
        if (gameObject.transform.position.x < maxX && movingRight)
        {
            transform.Translate(Vector2.right * Time.deltaTime * platformSpeed);
        }
        else if (gameObject.transform.position.x >= maxX)
        {
            movingRight = false;
        }

        if (gameObject.transform.position.x > minX && !movingRight)
        {
            transform.Translate(Vector2.left * Time.deltaTime * platformSpeed);
        }
        else if (gameObject.transform.position.x <= minX)
        {
            movingRight = true;
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
