using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackLogic : MonoBehaviour
{
    
    public float attackRange = 0.2f;

    Animator animator;
    public GameObject vine;
    public GameObject vineSide;
    Transform player;
    Rigidbody2D rb;
    Enemy enemy;
    bool attacking = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        rb = animator.GetComponent<Rigidbody2D>();
        enemy = animator.GetComponent<Enemy>();

    }

    IEnumerator vineRoutine()
    {
        animator.SetTrigger("Vine");
        GameObject projectilespawn = Instantiate(vine, player.position + new Vector3(0, -1.5f, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.900F);
        attacking = false;
        animator.ResetTrigger("Vine");
        
    }

    IEnumerator vineSideRoutine()
    {
        animator.SetTrigger("SideVine");
        GameObject projectilespawn = Instantiate(vineSide, player.position + new Vector3(0, -1.5f, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.900F);
        attacking = false;
        animator.ResetTrigger("SideVine");

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public void Update()
    {
        if (attacking == false)
        {

            int chooseattack = Random.Range(1, 4);

            if (chooseattack == 1)
            {
                StartCoroutine(vineRoutine());
                attacking = true;
            }

            if (chooseattack == 2)
            {
                StartCoroutine(vineRoutine());
                attacking = true;
            }


            if (chooseattack == 3)
            {
                StartCoroutine(vineSideRoutine());
                attacking = true;
            }


        }
    }
  
}
