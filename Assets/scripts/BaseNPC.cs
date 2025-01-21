using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
public class BaseNPC : MonoBehaviour
{
    public float speed = 2f;
    public float offSet = 0f;
    public float currentHealth;
    private float baseHealth = 15f;
    public float currentDamage;
    private float baseDamage = 4f;
    private float modifier;
    private float currentTime;

    public virtual void Awake()
    {
        modifier = currentTime / 500;

        if (modifier >= 1)
        {
            this.currentHealth = currentHealth * modifier;
            this.currentDamage = currentDamage * modifier;
        }
        else if (modifier < 1)
        {
        this.currentHealth = baseHealth;
        this.currentDamage = baseDamage;
        }

    }
    public virtual void Update()
    {
        currentTime += Time.deltaTime;
    }

    public virtual void MoveToTarget(GameObject target, float offSet)
    {
        float distanceFromTarget = Vector2.Distance(target.transform.position, transform.position);
        if (distanceFromTarget >= offSet)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        else if (distanceFromTarget <= offSet)
        {

        }
    }
    public virtual float TakeDamage(float currentHealth, float dammageTaken)
    {
        float HPResult = currentHealth - dammageTaken;
        return HPResult;
    }

    public virtual float DealDammage()
    {
        float damage = currentDamage;
        return damage;
    }

    public virtual void OnDeath()
    {

    }

}