using UnityEngine;

public class EarthWallPlatform : MonoBehaviour
{
    public float lifetime;
    public float maxSize;
    public LayerMask objectsStoppingGrowth;

    void Start()
    {
        Invoke("DestroyItself", lifetime);
    }

    void FixedUpdate()
    {

    }

    void DestroyItself()
    {
        Destroy(gameObject);
    }
}