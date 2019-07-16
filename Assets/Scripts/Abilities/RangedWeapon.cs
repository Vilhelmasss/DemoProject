using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    public GameObject player;
    public float offset;
    public GameObject projectile;
    public Transform shotPoint;
    public int maxRotation;
    public int minRotation;
    private float timeReloading;
    public float startTimeShot;

    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        if (timeReloading <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeReloading = startTimeShot;
            }
        }
        else
            timeReloading -= Time.deltaTime;
    }
}
