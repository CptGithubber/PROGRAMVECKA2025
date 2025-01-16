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
        Vector3 newPosition = new Vector3(player.position.x, -3.2f, player.position.z);
        Instantiate(vine, newPosition, Quaternion.identity);
        yield return new WaitForSeconds(1.5F);
        animator.ResetTrigger("Vine");
        attacking = false;


    }

    IEnumerator vineSideRoutine()
    {
        animator.SetTrigger("SideVine");
        Vector3 newPosition = new Vector3(transform.position.x + -4f, -3.2f, player.position.z);
        Instantiate(vineSide, newPosition, Quaternion.identity);
        yield return new WaitForSeconds(1.5F);
        animator.ResetTrigger("SideVine");
        attacking = false;

    }

    IEnumerator vineWaveRoutine()
    {
        animator.SetTrigger("Vine");
        float waveCount = 3.5f;
        for (int i = 0; i < 5; i++)
        {
           
            Vector3 newPosition = new Vector3(transform.position.x - waveCount, -3.2f, player.position.z);
            Instantiate(vine, newPosition, Quaternion.identity);
            waveCount = waveCount + 1.5f;
            yield return new WaitForSeconds(0.5F);
        }
        
        yield return new WaitForSeconds(1.5F);
        animator.ResetTrigger("Vine");
        attacking = false;

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
