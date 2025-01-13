using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public int attackDamage = 20;

    public PlayerMovement player;
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
    public Rigidbody2D rb;

    public void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
              
            if (player.preParry == true)
            {
                Vector2 difference = (transform.position - player.transform.position).normalized;
                Vector2 force = difference * 5;
                rb.AddForce(force, ForceMode2D.Impulse);
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