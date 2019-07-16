using UnityEngine;

public class SummonHawk : MonoBehaviour
{
    public GameObject summonedHawk;
    public float totalCooldown;
    public float currentCooldown;

    void Start()
    {
        currentCooldown = 0f;
    }

    void Update()
    {
        if (currentCooldown <= 0f)
        {
            if (Input.GetKeyDown(KeyCode.V) && GetComponent<PlayerController>().otherMovement == false)
            {
                GetComponent<PlayerController>().otherMovement = true;
                Instantiate(summonedHawk);
                currentCooldown = totalCooldown;
            }
        }
        else
        {
            currentCooldown -= Time.deltaTime;
        }
    }
}
