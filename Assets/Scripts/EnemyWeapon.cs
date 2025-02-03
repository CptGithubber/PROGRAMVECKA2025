using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public int attackDamage = 20;

    public PlayerMovement player;
    public Vector3 attackOffset;
    public float attackRange = 3f;
    public LayerMask attackMask;
    public Rigidbody2D rb;
    public AudioSource attackSound;

    private Animator anim;

    public void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        anim = GetComponent<Animator>();
    }

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        attackSound = GetComponent<AudioSource>();
        
        attackSound.pitch = (Random.Range(0.6f, .9f));
        attackSound.Play();

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            
              
            if (player.preParry == true)
            {
                Vector2 difference = (transform.position - player.transform.position).normalized;
                Vector2 force = difference * 2;
                rb.AddForce(force, ForceMode2D.Impulse);
                anim.SetBool("Parried", true);
                colInfo.GetComponent<PlayerMovement>().Parry();
                
            }
           else
            {
                colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            }
            
        }
    }

    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }
}