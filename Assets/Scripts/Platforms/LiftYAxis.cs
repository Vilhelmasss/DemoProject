using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftYAxis : MonoBehaviour
{
    public float startY;
    public float endY;
    public float moveSpeed;
    public Vector2 moveDirection;
    private bool moveLift;
    private bool moveUp;

     void Start()
     {
         moveLift = false;
     }

    void FixedUpdate()
    {

        if (moveLift)
        {
            if (gameObject.transform.position.y >= endY)
            {
                gameObject.transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
            }
            else
            {
                moveLift = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Collider2D>().transform.SetParent(transform);
            moveLift = true;
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
