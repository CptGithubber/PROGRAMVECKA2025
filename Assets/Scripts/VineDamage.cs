using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineDamage : MonoBehaviour
{
    public int attackDamage = 20;

    public PlayerMovement player;
    public Vector3 attackOffset;
    public Vector3 attackRange;
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

        Collider2D colInfo = Physics2D.OverlapBox(pos, attackRange, attackMask);
        if (colInfo != null)
        {


            if (player.preParry == true)
            {
                
                colInfo.GetComponent<PlayerMovement>().Parry();

            }
            else
            {
                colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            }

        }
    }

    public void UnparryableAttack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapBox(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }


    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireCube(pos, attackRange);
    }
}