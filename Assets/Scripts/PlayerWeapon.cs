using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public int attackDamage = 20;

    public EnemyHealth enemy;
    public Vector3 attackOffset;
    public float attackRange = 3f;
    public LayerMask attackMask;
    public Rigidbody2D rb;

    public void Start()
    {
        enemy = FindObjectOfType<EnemyHealth>();
    }

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {

            colInfo.GetComponent<EnemyHealth>().TakeDamage(attackDamage);


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