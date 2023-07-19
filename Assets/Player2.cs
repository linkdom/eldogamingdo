using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody2D rb;
    public float jumpHeight = 10;
    private bool isGrounded = false;
    private Animator animator;
    private Vector3 rotation;

    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rotation = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        float richtung = Input.GetAxis("Horizontal");

        if(richtung != 0) {
            animator.SetBool("isRunning", true);
        } else {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            transform.eulerAngles = rotation + new Vector3(0, 180, 0);
            transform.Translate(Vector2.right * speed * -richtung * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            transform.eulerAngles = rotation;
            transform.Translate(Vector2.right * speed * richtung * Time.deltaTime);
        }

        if (isGrounded == false) {
            animator.SetBool("isJumping", true);
            FindObjectOfType<AudioManager>().Play("Waffe");
        } else {
            animator.SetBool("isJumping", false);
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rb.AddForce((Vector2.up * jumpHeight), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "ground") {
            isGrounded = true;
        }
    }
}
