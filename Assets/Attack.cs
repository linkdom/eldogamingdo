using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform attackPos;
    public LayerMask enemies;
    public float attackrange;
    public int damage;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            anim.SetBool("isAttacking", true);
            FindObjectOfType<AudioManager>().Play("messer");
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackrange, enemies);
            for( int i = 0; i < enemiesToDamage.Length; i++) {
                enemiesToDamage[i].GetComponent<Enemy>().currentHealth -= damage;
                enemiesToDamage[i].GetComponent<Enemy>().healthBar.SetHealth(enemiesToDamage[i].GetComponent<Enemy>().currentHealth);
            }
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackrange);
    }
}
