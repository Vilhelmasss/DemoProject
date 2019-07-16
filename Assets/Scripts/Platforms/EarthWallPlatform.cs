using UnityEngine;

public class EarthWallCrumble : MonoBehaviour
{
    public float lifetime;

    void Start()
    {
        Invoke("DestroyItself", lifetime);
    }

    void DestroyItself()
    {
        Destroy(gameObject);
    }
}