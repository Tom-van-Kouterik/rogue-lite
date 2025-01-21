using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : BaseNPC
{
    private GameObject player;
    private PlayerHandler playerHandler;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHandler = player.GetComponent<PlayerHandler>();
    }

    public override void Update()
    {
        base.Update();
        MoveToTarget(player, offSet);
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public override void Awake()
    {
        base.Awake();
        offSet = 4.5f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        float damageTaken = playerHandler.currentDamage;
        Debug.Log(damageTaken);
        if (collision.CompareTag("Player"))
        {
            currentHealth = TakeDamage(currentHealth, damageTaken);
        }
    }
}
