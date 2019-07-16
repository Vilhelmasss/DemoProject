using System;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    public bool canReceiveDamage;

    public event Action<float> OnHealthPctChanged = delegate { };

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
            ModifyHealth(-10);
        if (Input.GetKeyDown(KeyCode.Y))
            ModifyHealth(10);

    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;

        float currentHealthPct = (float) currentHealth / (float) maxHealth;
        OnHealthPctChanged(currentHealthPct);

    }
    void ReceiveDamage()
    {

        
    }
}
