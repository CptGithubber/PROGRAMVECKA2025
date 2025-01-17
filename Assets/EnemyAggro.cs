using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggro : StateMachineBehaviour
{

    public float aggroRange = 5f;

    Transform player;
    Rigidbody2D rb;
    Enemy enemy;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        enemy = animator.GetComponent<Enemy>();
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(player.position, rb.position) <= aggroRange)
            {
            animator.SetBool("WIthinRange", true);
            }
        }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
