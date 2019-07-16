using UnityEngine;

public class Windblade : MonoBehaviour
{
    public Transform swordPoint;
    
    private float timeBetweenAttack;
    public float timeAttackCooldown;
    public int damage;
    public float offset;
    public GameObject windTornado;
    public GameObject windBlast;
    public Transform attackPosition;
    public float attackRange;
    public LayerMask whatIsDamagable;

    public GameObject Player;

    void Update()
    {
        MeleeAttack();
        if (Input.GetKeyDown(KeyCode.U))
        {
            
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ - offset -5f);
            
            for (int i = 0; i < 10; i++)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, rotZ - offset + i);

                Instantiate(windBlast, swordPoint.position, transform.rotation);
            }
        }
        CreateWindBlast();
    }

    private void CreateWindBlast()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            for (int i = 0; i < 180; i++)
            {
                Quaternion blastDir = Quaternion.Euler(0f, 0f, i * 2);
                Instantiate(windBlast, gameObject.transform.position, blastDir);
            }
        }
    }

    private void MeleeAttack()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        if (timeBetweenAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Instantiate(windTornado, gameObject.transform.position, Quaternion.identity);

                Collider2D[] enemiesToDamage =
                    Physics2D.OverlapCircleAll(attackPosition.position, attackRange, whatIsDamagable);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().health -= damage;
                }
            }

            timeBetweenAttack = timeAttackCooldown;
        }
        else
        {
            timeBetweenAttack -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }   
}
