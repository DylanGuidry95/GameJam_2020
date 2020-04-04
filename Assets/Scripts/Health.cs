using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float  MaxHealth;
    public float CurrentHealth;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    private void Update()
    {
        if (CurrentHealth == 0)
            Destroy(this.gameObject);
    }

    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
    }
}
