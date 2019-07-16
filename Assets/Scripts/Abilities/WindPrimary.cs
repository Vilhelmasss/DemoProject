using UnityEngine;

public class WindPrimary : MonoBehaviour
{
    private GameObject blastedWind;
    public bool attached;
    public bool isWorking;
    void Start()
    {
        Invoke("StartActing", 1f);
        Invoke("DestroyItself", 15f);
    }

    void Update()
    {
        if (blastedWind != null)
        {
            gameObject.transform.position = blastedWind.transform.position;
        }
    }

    void StartActing()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        isWorking = true;
    }

    void OnColliderEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Enemy") && isWorking)
        {
            Debug.Log("Hmm, wind blows?");
            other.collider.GetComponent<CharacterHealth>().ModifyHealth(-3);
        }
    }

    public void CarryWindPrimary(GameObject windBlast)
    {
        if (attached != true)
        {
            attached = true;
        }
        blastedWind = windBlast;
    }

    public void DestroyItself()
    {
        Destroy(gameObject);
    }
}
