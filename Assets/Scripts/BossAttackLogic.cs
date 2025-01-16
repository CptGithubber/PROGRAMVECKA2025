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
        Vector3 newPosition = new Vector3(player.position.x, -1.3f, player.position.z);
        Instantiate(vineSide, newPosition, Quaternion.identity);
        yield return new WaitForSeconds(1.5F);
        attacking = false;
        animator.ResetTrigger("Vine");
        

    }

    IEnumerator vineSideRoutine()
    {
        animator.SetTrigger("SideVine");
        Vector3 newPosition = new Vector3(player.position.x, -1.3f, player.position.z);
        Instantiate(vineSide, newPosition, Quaternion.identity);
        yield return new WaitForSeconds(1.5F);
        attacking = false;
        animator.ResetTrigger("SideVine");
        

    }

    IEnumerator vineWaveRoutine()
    {
        animator.SetTrigger("Vine");
        Vector3 newPosition = new Vector3(player.position.x, -1.3f, player.position.z);
        Instantiate(vineSide, newPosition, Quaternion.identity);
        yield return new WaitForSeconds(1.5F);
        attacking = false;
        animator.ResetTrigger("Vine");


    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public void Update()
    {
        if (!attacking)
        {
            int chooseattack = Random.Range(1, 4);
            Debug.Log("Random chooseattack: " + chooseattack);

            attacking = true;  // Start the attacking process

            // Choose an attack based on the random number
            switch (chooseattack)
            {
                case 1:
                    StartCoroutine(vineRoutine());
                    break;

                case 2:
                    StartCoroutine(vineWaveRoutine());
                    break;

                case 3:
                    StartCoroutine(vineSideRoutine());
                    break;
            }
        }
    }


}
