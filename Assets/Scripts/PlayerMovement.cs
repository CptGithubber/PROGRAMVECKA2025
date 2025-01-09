using System.Collections;
using System.Collections.Generic;
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
    float moveVelocity;
    float speedMultiplier = 1;

    Rigidbody2D rb;

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

    public void OnCollisionEnter2D(Collision2D col)
    {
        isGrounded = true;
    }
    public void OnCollisionExit2D(Collision2D col)
    {
        isGrounded = false;
    }


    void Update()
    {

        if (canControl == true)
        {

            if (isGrounded == true)
            {
                coyotyTimeCounter = coyotyTime;
            }
            else
            {
                coyotyTimeCounter -= Time.deltaTime;


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


            //Check if grounded and allows jumping
            if (coyotyTimeCounter > 0f && jumpBufferTimeCounter > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, jump);
            }

            moveVelocity = 0;

            //Left/Right Movement
            if (Input.GetKey(KeyCode.A))
            {
                speedMultiplier = -1;
                moveVelocity = speed * speedMultiplier;
                anim.SetBool("isRunning", true);
            }
            if (Input.GetKey(KeyCode.D))
            {
                speedMultiplier = 1;
                moveVelocity = speed * speedMultiplier;
                anim.SetBool("isRunning", true);
            }

            //Rolling
            if (Input.GetKey(KeyCode.LeftShift))
            {
                    canControl = false;
                    StartCoroutine(roller());
                    anim.SetBool("isRolling", true);

            }

            //Attack
            if (Input.GetKey(KeyCode.F))
            {
               

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

            GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

        }

        //Check if grounded
        void OnCollisionEnter2D(Collision2D col)
        {
            isGrounded = true;
        }
        void OnCollisionExit2D(Collision2D col)
        {
            isGrounded = false;
        }
    }
}

