using UnityEngine;

public class PlatformOnPlayer : MonoBehaviour
{
    public bool inWindArea;
    private Vector2 windForce;
    private Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        inWindArea = false;
        windForce = new Vector2(0f, 0f);
    }

    void FixedUpdate()
    {
        WindArea();
    }

    private void WindArea()
    {
        if (inWindArea)
        {
            rb.AddForce(windForce * Time.deltaTime, ForceMode2D.Force);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "WindArea")
        {
            windForce = other.GetComponent<WindArea>().thisWindForce;
            inWindArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "WindArea")
        {
            inWindArea = false;
        }
    }
}
