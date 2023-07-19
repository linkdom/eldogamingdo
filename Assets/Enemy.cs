using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public float rechts;
    public float links;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public Transform player;
    public float followDistance = 20.0f; // The distance within which the enemy will start to follow the player.
    public float attackRange = 2f; // The range within which the enemy will start to attack the player.
    public int attackDamage = 10; // The damage that enemy attacks will do.
    public float attackDelay = 1f; // The delay between enemy attacks.

    private Vector3 rotation;
    private float lastAttackTime;

    // Start is called before the first frame update
    void Start()
    {
        rechts = transform.position.x + rechts;
        links = transform.position.x - links;
        rotation = transform.eulerAngles;
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;

        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        float playerDistance = Vector3.Distance(transform.position, player.position);
        Vector3 direction = player.position - transform.position;

        if (direction.x >= 0) 
        {
            transform.eulerAngles = new Vector3(0, 0, 0); // If the player is to the right, face right.
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0); // If the player is to the left, face left.
        }
        // If the player is within the followDistance, the enemy will move towards the player.
        if (player != null && playerDistance <= followDistance)
        {
            // If the player is within the attackRange and enough time has passed since the last attack, the enemy will attack.
            if (playerDistance <= attackRange && Time.time - lastAttackTime >= attackDelay)
            {
                AttackPlayer();
                lastAttackTime = Time.time; // Reset the last attack time.
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
        }

        if(currentHealth <= 0) 
        {
            Destroy(gameObject);
        }
    }

    void AttackPlayer()
    {
        // Assume the player script is named "Player" and it has a method "TakeDamage" to reduce the player's health.
        Player playerScript = player.GetComponent<Player>();
        if (playerScript != null) // If the player script is attached to the player.
        {
            playerScript.TakeDamage(attackDamage);
        }
    }
}