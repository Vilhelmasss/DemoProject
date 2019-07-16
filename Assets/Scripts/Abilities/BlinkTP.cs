using UnityEngine;

public class BlinkTP : MonoBehaviour
{
    public int totalCharges;
    private int currentCharges;
    public float maxBlinkDistance;
    [SerializeField] private float totalCooldown;
    private float currentCooldown;
    public LayerMask unblinkableObjects;

    void Start()
    {
        currentCooldown = 0f;
        currentCharges = totalCharges;
    }
    void Update()
    {
        CooldownAndCharges();
        BlinkEffect();
    }

    private void BlinkEffect()
    {
        if (Input.GetKeyDown("space") && !GetComponent<PlayerController>().otherMovement && currentCharges > 0)
        {
            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
            RaycastHit2D blinkHit =
                Physics2D.Raycast(gameObject.transform.position, ray, maxBlinkDistance, unblinkableObjects);
            if (blinkHit.collider == null)
            {
                float coff = Mathf.Abs(ray.x) + Mathf.Abs(ray.y);
                coff = maxBlinkDistance / coff;
                Vector2 newPlayerPos = new Vector2(ray.x * coff, ray.y * coff);
                gameObject.transform.position += (Vector3) newPlayerPos;
            }
            else
            {
                gameObject.transform.position = blinkHit.point;
            }

            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }

    private void CooldownAndCharges()
    {
        if (currentCharges < totalCharges)
        {
            if (currentCooldown <= 0)
            {
                currentCharges++;
                currentCooldown = totalCooldown;
            }
            else
            {
                currentCooldown -= Time.deltaTime;
            }
        }
    }
}