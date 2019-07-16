using UnityEngine;

public class WindArea : MonoBehaviour
{
    public float windStrength;
    public Vector2 direction;
    public Vector2 thisWindForce;
    private Rigidbody2D rb;
    private bool playerInWindArea;

    void Start()
    {
        playerInWindArea = false;
        thisWindForce = direction * windStrength;
    }

    void FixedUpdate()
    {
        if(playerInWindArea)
        rb.AddForce(thisWindForce, ForceMode2D.Force);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            rb = other.gameObject.GetComponent<Rigidbody2D>();
            playerInWindArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInWindArea = false;
        }
    }
}