using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody2D rb;
    public float jumpHeight = 10;
    private bool isGrounded = false;
    private Animator animator;
    private Vector3 rotation;
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public GameObject respawn;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rotation = transform.eulerAngles;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        float richtung = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.A) 
        || Input.GetKeyDown(KeyCode.D)
        || Input.GetKeyDown(KeyCode.LeftArrow)
        || Input.GetKeyDown(KeyCode.RightArrow)){
            FindObjectOfType<AudioManager>().Play("laufen");
        }

        if(Input.GetKeyUp(KeyCode.A) 
        || Input.GetKeyUp(KeyCode.D)
        || Input.GetKeyUp(KeyCode.LeftArrow)
        || Input.GetKeyUp(KeyCode.RightArrow)){
            FindObjectOfType<AudioManager>().Stop("laufen");
        }

        if(richtung != 0) {
            animator.SetBool("isRunning", true);
        } else {
            animator.SetBool("isRunning", false);
        }

        if (richtung < 0) {
            transform.eulerAngles = rotation + new Vector3(0, 180, 0);
            transform.Translate(Vector2.right * speed * -richtung * Time.deltaTime);
        }

        if (richtung > 0) {
            transform.eulerAngles = rotation;
            transform.Translate(Vector2.right * speed * richtung * Time.deltaTime);
        }

        if (isGrounded == false) {
            animator.SetBool("isJumping", true);
            FindObjectOfType<AudioManager>().Play("landen");
        } else {
            animator.SetBool("isJumping", false);
            FindObjectOfType<AudioManager>().Play("springen");
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rb.AddForce((Vector2.up * jumpHeight), ForceMode2D.Impulse);
            isGrounded = false;
        }

        if(currentHealth <= 0) {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "ground") {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Coin") {
            FindObjectOfType<AudioManager>().Play("muenze");
            Destroy(other.gameObject);
        }
    }

}
