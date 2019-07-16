using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Chronomancy : MonoBehaviour
{
    public List<Vector2> PositionsList;
    public List<int> health;

    private int i;

    void Start()
    {
        PositionsList = new List<Vector2>();
        health = new List<int>();
        i = 0;
        PositionsList = Enumerable.Repeat((Vector2)gameObject.transform.position, 250).ToList();
        health = Enumerable.Repeat(gameObject.GetComponent<PlayerController>().health, 250).ToList();

        Invoke("ResetTimer", 4.97f);
    }

    void FixedUpdate()
    {
        i++;
        PositionsList[i] = (Vector2)gameObject.transform.position;
        health[i] = gameObject.GetComponent<PlayerController>().health;
        if (Input.GetKeyDown("e"))
        {
            BackInTime();
        }
    }

    void ResetTimer()
    {
        i = 0;
        Invoke("ResetTimer", 4.97f);
    }

    void BackInTime()
    {
        gameObject.transform.position = PositionsList[i + 1];
        gameObject.GetComponent<PlayerController>().health = health[i + 1];
        Start();
    }
}
