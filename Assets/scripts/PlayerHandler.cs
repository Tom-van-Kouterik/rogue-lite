using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    private float baseDamage = 5f;
    public float currentDamage;
    private float baseHealth = 20f;
    private float currentHealth;
    public float summonMultiplier;
    private BaseNPC baseNPC;

    private void Start()
    {
        currentHealth = baseHealth;
        currentDamage = baseDamage;
    }

    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            BaseNPC baseNPC = collision.GetComponent<BaseNPC>();
            float damage = baseNPC.DealDammage();
            currentHealth -= damage;
        }
    }
}
