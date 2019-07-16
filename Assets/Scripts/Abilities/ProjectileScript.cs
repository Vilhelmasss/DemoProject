using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask whatIsSolid;
    public GameObject destroyEffect;
    public Vector2 VectorUpOrDown;
    public int damage;

    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
        VectorUpOrDown = new Vector2(0, 1);
    }


    void FixedUpdate()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if(hitInfo.collider != null && !hitInfo.collider.CompareTag("Player"))
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
                DestroyProjectile();
            }
            DestroyProjectile();
        }
        transform.Translate(VectorUpOrDown * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
       //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
