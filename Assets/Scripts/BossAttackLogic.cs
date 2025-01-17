using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossAttackLogic : MonoBehaviour
{
    
    public float attackRange = 0.2f;

    public Image healthBar; Animator animator;
    public GameObject vine;
    public GameObject vineSide;
    Transform player;
    Rigidbody2D rb;
    Enemy enemy;
    bool attacking = false;
    public AudioSource attackSound;
    

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

        attackSound = GetComponent<AudioSource>();
        attackSound.pitch = (Random.Range(0.6f, .9f));
        attackSound.Play();

        Vector3 newPosition = new Vector3(player.position.x, -3.33f, player.position.z);
        Instantiate(vine, newPosition, Quaternion.identity);
        yield return new WaitForSeconds(1.5F);
        animator.ResetTrigger("Vine");
        attacking = false;


    }

    IEnumerator vineSideRoutine()
    {
        animator.SetTrigger("SideVine");

        attackSound = GetComponent<AudioSource>();
        attackSound.pitch = (Random.Range(0.6f, .9f));
        attackSound.Play();

        Vector3 newPosition = new Vector3(transform.position.x + -3.6f, -3.33f, player.position.z);
        Instantiate(vineSide, newPosition, Quaternion.identity);
        yield return new WaitForSeconds(1.5F);
        animator.ResetTrigger("SideVine");
        attacking = false;

    }

    IEnumerator vineWaveRoutine()
    {
        animator.SetTrigger("Vine");

        attackSound = GetComponent<AudioSource>();
        attackSound.pitch = (Random.Range(0.6f, .9f));
        attackSound.Play();

        float waveCount = 3f;
        for (int i = 0; i < 5; i++)
        {
           
            Vector3 newPosition = new Vector3(transform.position.x - waveCount, -3.33f, player.position.z);
            Instantiate(vine, newPosition, Quaternion.identity);
            waveCount = waveCount + 1.1f;
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
