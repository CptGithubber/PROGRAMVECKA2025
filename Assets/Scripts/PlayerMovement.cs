using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IInteractable
{
    void interact(GameObject interactor);
    
}


public class PlayerMovement : MonoBehaviour

{
    //movement variables
    public float jump;
    public float speed;
    public float rollspeed;
    bool isRunning_D;
    bool isRunning_A;
    float moveVelocity;
    float yVelocity;
    float speedMultiplier = 1;
    public float fallSpeed;
    public bool preParry;
    public ParticleSystem parryEffect;
    public AudioSource parrySound;
    public AudioClip parryClip;

    Rigidbody2D rb;
    BoxCollider2D box;

    bool isGrounded;
    bool rolling;
    bool canControl = true;
    public static bool interacting = false;

    float coyotyTimeCounter;
    public float coyotyTime = 0.2f;

    public float jumpBufferTime = 0.2f;
    float jumpBufferTimeCounter;



    private Animator anim;

    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        StartCoroutine(roller());       
        
    }

    IEnumerator roller()
    {
        moveVelocity = rollspeed * speedMultiplier;
        yield return new WaitForSeconds(0.500F);
        anim.SetBool("isRolling", false);
        moveVelocity = 0;
        canControl = true;
    }

    IEnumerator parry()
    {
        anim.SetTrigger("StartParry");
        preParry = true;
        yield return new WaitForSeconds(0.2F);
        canControl = true;
        preParry = false;
        anim.ResetTrigger("StartParry");
        anim.ResetTrigger("ParrySuccess");

    }

    IEnumerator attack()
    {
        anim.SetTrigger("Attack1");
        yield return new WaitForSeconds(0.8F);
        canControl = true;
        anim.ResetTrigger("Attack1");

    }

    public void Parry()
    {
        preParry = false;

        parrySound = GetComponent<AudioSource>();
        parrySound.clip = parryClip;
        parrySound.pitch = (Random.Range(0.6f, .9f));
        parrySound.Play();

        
        anim.SetTrigger("ParrySuccess");
        var emitParams = new ParticleSystem.EmitParams();
        emitParams.applyShapeToPosition = true;
        emitParams.position = transform.position;
        parryEffect.Emit(emitParams, 5);
       


    }


    void Update()
    {

        if (canControl == true)
        {
            if (isGrounded == true)
            {
                coyotyTimeCounter = coyotyTime;
                anim.SetBool("isJumping", false);
            }
            else
            {
                coyotyTimeCounter -= Time.deltaTime;
                anim.SetBool("isJumping", true);
            }

            Debug.Log(coyotyTimeCounter);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpBufferTimeCounter = jumpBufferTime;
            }
            else
            {
                jumpBufferTimeCounter -= Time.deltaTime;
            }

            //Left/Right Movement
            if (Input.GetKey(KeyCode.A))
            {
                isRunning_A = true;
            }
            else
            {
                isRunning_A = false;
            }
            if (Input.GetKey(KeyCode.D))
            {
                isRunning_D = true;
            }
            else
            {
                isRunning_D = false;
            }


            //Rolling
            if (Input.GetKey(KeyCode.LeftShift))
            {
                    canControl = false;
                    StartCoroutine(roller());
                    anim.SetBool("isRolling", true);
            }

            //Parry
            if (Input.GetKey(KeyCode.F) && preParry != true)
            {
                canControl = false;
                StartCoroutine(parry());
                
            }

            //Attack
            if (Input.GetKey(KeyCode.E))
            {
                canControl = false;
                StartCoroutine(attack());

            }

        }
    }


    //Checks if the player is tuching the ground and changs isGrounded based on it
    public void OnCollisionEnter2D(Collision2D col)
    {
        isGrounded = true;
    }
    public void OnCollisionExit2D(Collision2D col)
    {
        isGrounded = false;
    }

    void FixedUpdate()
    {

        //Check if grounded and allows jumping
        if (coyotyTimeCounter > 0f && jumpBufferTimeCounter > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            anim.SetBool("isJumping", true);
            Debug.Log(rb.velocity.y);
        }

        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));

        

            if (rb.velocity.y < 0)
            {
                yVelocity = rb.velocity.y * fallSpeed;
            }
            else
            {
                yVelocity = rb.velocity.y;
            }



        moveVelocity = 0;

        //Left/Right Movement
        if (isRunning_A == true)
        {
            speedMultiplier = -1;
            moveVelocity = speed * speedMultiplier;
            anim.SetBool("isRunning", true);
        }
        if (isRunning_D == true)
        {
            speedMultiplier = 1;
            moveVelocity = speed * speedMultiplier;
            anim.SetBool("isRunning", true);
        }

        //Animation Handling + Flipping

        if (moveVelocity == 0)
        {
            anim.SetBool("isRunning", false);
        }

        if (speedMultiplier < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (speedMultiplier > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        rb.velocity = new Vector2(moveVelocity, yVelocity);
    }
}

