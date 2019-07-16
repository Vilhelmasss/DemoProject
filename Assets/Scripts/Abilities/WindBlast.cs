using UnityEngine;

public class WindBlast : MonoBehaviour
{
    private float speed = 10f;
    public GameObject windVortex;
    public LayerMask destructableObjects;
    private bool attached = false;

    void FixedUpdate()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
            if (other.CompareTag("WindVortex"))
        {
            other.GetComponent<WindPrimary>().CarryWindPrimary(gameObject);
            windVortex = other.gameObject;
            other.transform.position = gameObject.transform.position;
        }
        if (other.CompareTag("Environment"))
        {
            if (windVortex != null)
            {
                windVortex.GetComponent<WindPrimary>().DestroyItself();
            }
            DestroyItself();
        }
    }

    void DestroyItself()
    {
        Destroy(gameObject);
    }
}
