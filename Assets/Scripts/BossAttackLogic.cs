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

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        enemy = animator.GetComponent<Enemy>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public void Update()
    {

      
            int chooseattack = Random.Range(3, 0);

            if (chooseattack == 1)
            {
                animator.SetTrigger("Vine");
                GameObject projectilespawn = Instantiate(vine, player.position, Quaternion.identity);
            }

            if (chooseattack == 2)
            {
                animator.SetTrigger("VineWave");
            }


            if (chooseattack == 3)
            {
                animator.SetTrigger("SideVine");
                GameObject projectilespawn = Instantiate(vineSide, player.position, Quaternion.identity);
            }

        
    }

  
}
