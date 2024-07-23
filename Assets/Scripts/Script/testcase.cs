using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testcase : MonoBehaviour
{
    public Transform player;

    public LayerMask whatIsPlayer;

    public float health;
    public int damage;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private Rigidbody rb;
    public float thrust;

    private void Awake()
    {
        player = GameObject.Find("PlayerObj").transform;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            MoveTowardsPlayer();
        }
        if (playerInAttackRange && playerInSightRange)
        {
            AttackPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        rb.AddForce(direction * thrust);
    }

    private void AttackPlayer()
    {
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            // Attack code here
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            // End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

