using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.PackageManager;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class HorizontalSlash : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    private int moveInput;
    private bool shouldSlice;
    private Vector2 SlicingDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown("f") && !GetComponent<PlayerController>().otherMovement)
        {
            SlicingPreparations();
            GetComponent<PlayerController>().otherMovement = true;
        }
    }

    void FixedUpdate()
    {
        if (shouldSlice)
        {
            Slicing();
        }
    }

    void SlicingPreparations()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        Invoke("SlicingStart", 1);
    }

    void SlicingStart()
    {

        if (gameObject.transform.localScale.x > 0)
            moveInput = 1;
        else
            moveInput = -1;
        SlicingDirection = new Vector2(moveInput, 0f);
        GetComponent<PlayerController>().otherMovement = true;

        rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

        shouldSlice = true;
        Invoke("StopSlicing", 1f);
    }

    void Slicing()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

        rb.AddForce(SlicingDirection * dashSpeed, ForceMode2D.Impulse);
    }

    void StopSlicing()
    {
        rb.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponent<PlayerController>().otherMovement = false;
        shouldSlice = false;
    }
}
