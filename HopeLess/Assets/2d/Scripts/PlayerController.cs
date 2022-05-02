using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject codePanel, closedSafe, openedSafe;

    public GameObject LevelWithMask;
    public GameObject NormalLevel,LevelChangerPanelMask, LevelChangerPanel;

    public static bool isSafeOpened = false;
    public static bool isSafeOpened2 = false;

    private int amountOfJumpLeft;
    private int facingDirection=1;
    private int lastWallJumpDirectiom;


    private float jumpTimer;
    private float turnTimer ;
    private float movmentInputDirection;
    private float wallJumpTimer;

    public int amountOfJumps = 1;
    

    public static float cruentTime = 10f;
    public int secTime;

    public static bool IsMask=false;


    private bool isFacingRight = true;
    private bool isWalking;
    private bool isGrounded;
    private bool isTouchingWall;
    private bool canNormalJump;
    private bool canWallJump;
    private bool isWallSliding;
    private bool checkJumpMultiplier;
    private bool isAttemptoJump;
    private bool canMove;
    public static bool canFlip;
    private bool hasWallJumped;
    private bool IsPushing;

    private Rigidbody2D rb;
    private Animator anim;

    private bool timer = false;

    public static float movementSpeed = 7.0f;
    [SerializeField]
    public static float jumpForce = 20.0f;
    public float groundCheckRadius;
    public float wallCheckDistance;
    public float wallSlidingSpeed;
    public float movmentForceInAir;
    public float airDragMultiplier = 0.95f;
    public float varibleJumpHeightMultiplier = 0.5f;
    public float wallHopForce;
    public float wallJumpForce;
    public float jumpTimerSet = 0.15f;
    public float turinTimeSet = 0.1f;
    public float wallJumpTimerSet=0.5f;

    private bool Colider = false;




    public Vector2 wallHopDirection;
    public Vector2 wallJumpDirection;

    public Transform groundCheck;
    public Transform wallCheck;


    public LayerMask whatIsGround;

   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        amountOfJumpLeft = amountOfJumps;
        wallHopDirection.Normalize();
        wallJumpDirection.Normalize();


        codePanel.SetActive(false);
        closedSafe.SetActive(true);
        openedSafe.SetActive(false);

       

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb.velocity.x);
        if (timer)
        {
            cruentTime = cruentTime - Time.deltaTime;
          //  Debug.Log(cruentTime);
        }

            if (Input.GetKey(KeyCode.E) && IsMask == true)
        {

            timer = true;
        }

        if (Input.GetKey(KeyCode.W) && IsMask == true)
        {

            timer = false;
            cruentTime = 10f;
        }


        if (cruentTime <= 0  || Colider==true)
        {
            FindObjectOfType<DudioManger>().Play("Dying");
            cruentTime = 10f;
            timer = false;
            anim.SetBool("DieMask", true);    
            movementSpeed = 0;


            Invoke("Death", 3f);
        }


        CheckInput();
        CheckMovmentDirection();
        updateAnimation();
        CheckIfCanJump();
        CheckIfWallSliding();
        checkJump();
        ChangLevel();

        if (Input.GetKey(KeyCode.E) && IsMask == true)
        {
            anim.SetBool("WearingMask", true);
        }
        if (Input.GetKey(KeyCode.W) && IsMask == true)
        {
           
                anim.SetBool("WearingMask", false);
            
        }

        if (isSafeOpened2)
        {
            codePanel.SetActive(false);
            if (colect.istake == false)
            {

                openedSafe.SetActive(true);
            }
            if (colect.istake == true)
            {

                openedSafe.SetActive(false);

            }
            closedSafe.SetActive(false);
            
        }

            if (isSafeOpened)
        {
            Invoke("Diable", 2f);
           
        }

    }

    void Diable()
    {
             codePanel.SetActive(false);
             closedSafe.SetActive(false);
             openedSafe.SetActive(true);
    }

    void FixedUpdate()
    {
        ApplyMovment();
        CheckSrounding(); 
       
    }


    void CheckIfWallSliding()
    {
        if( isTouchingWall && movmentInputDirection == facingDirection && rb.velocity.y < 0)
        {
            isWallSliding = true;
        }
        else
        {
            isWallSliding = false;
        }
    }

    void CheckSrounding()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,whatIsGround);

        isTouchingWall = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsGround);
    }

    void CheckIfCanJump()
    {
        if(isGrounded && rb.velocity.y <= 0.01f) 
        {
            amountOfJumpLeft = amountOfJumps;
        }

        if (isTouchingWall)
        {
            checkJumpMultiplier = false;
            canWallJump = true;

        }

        if (amountOfJumpLeft <= 0)
        {
            canNormalJump = false;
        }

        else
        {
            canNormalJump = true;
        }
    }
    void CheckMovmentDirection()
    {
        if(isFacingRight && movmentInputDirection < 0)
        {
            flip();
        }

        else if (!isFacingRight && movmentInputDirection > 0)
        {
            flip();
        }

        if (rb.velocity.x != 0 )
        {
            isWalking = true;
        }
        else 
        {
            isWalking = false;
        }

    }

    void updateAnimation()
    {
        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("isWallSliding", isWallSliding);
        anim.SetBool("IsPushing", IsPushing);
    }
    private void CheckInput()
    {
        movmentInputDirection = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            FindObjectOfType<DudioManger>().Play("Jump");

            if (isGrounded || (amountOfJumpLeft > 0 && isTouchingWall))
            {
                
                normalJump();
            }
            else
            {
                jumpTimer = jumpTimerSet;
                isAttemptoJump = true;
            }
        }

        if(Input.GetButtonDown("Horizontal") && isTouchingWall)
        {
            if(!isGrounded && movmentInputDirection != facingDirection)
            {
                canMove = false;
                canFlip = false;

                turnTimer = turinTimeSet;
            }
        }

        if (!canMove)
        {
            turnTimer -= Time.deltaTime;

            if(turnTimer <= 0.1)
            {
                canMove = true;
                canFlip = true;
            }
        }

        if ( checkJumpMultiplier && !Input.GetButton("Jump"))
        {
            checkJumpMultiplier = false;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * varibleJumpHeightMultiplier);
        }
    }

    void checkJump()
    {
        if (jumpTimer > 0)
        {
            if (!isGrounded && isTouchingWall && movmentInputDirection !=0 && movmentInputDirection !=facingDirection)
            {
                wallJump();
            }
            else if (isGrounded)
            {
                normalJump();
            }
        }

        if (isAttemptoJump)
        {
            jumpTimer -= Time.deltaTime;
        }

        if(wallJumpTimer > 0)
        {
            if(hasWallJumped && movmentInputDirection == -lastWallJumpDirectiom)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0.0f);
                hasWallJumped = false;
            }
            else if (wallJumpTimer <= 0)
            {
                hasWallJumped = false;
            }
            else
            {
                wallJumpTimer -= Time.deltaTime;
            }
        }
       
    }

    private void normalJump()
    {
        if (canNormalJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            FindObjectOfType<DudioManger>().Play("Jump");
            amountOfJumpLeft--;
            jumpTimer = 0;
            isAttemptoJump = false;
            checkJumpMultiplier = true;

        }

    }

    private void wallJump()
    {
        if (canWallJump)
        {
            FindObjectOfType<DudioManger>().Play("Jump");
            rb.velocity = new Vector2(rb.velocity.x, 0.0f);
           // isWallSliding = false;
            amountOfJumpLeft = amountOfJumps;
            amountOfJumpLeft--;
            Vector2 forceToAdd = new Vector2(wallHopForce * wallJumpDirection.x * movmentInputDirection, wallJumpForce * wallJumpDirection.y);
            rb.AddForce(forceToAdd, ForceMode2D.Impulse);
            jumpTimer = 0;
            isAttemptoJump = false;
            checkJumpMultiplier = true;
            turnTimer = 0;
            canMove = true;
            canFlip = true;
            hasWallJumped = true;
            wallJumpTimer = wallJumpTimerSet;
            lastWallJumpDirectiom = -facingDirection;
        }
    }

    private void ApplyMovment()
    {
        if (!isGrounded && !isWallSliding && movmentInputDirection == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x * airDragMultiplier, rb.velocity.y);
        }

        else if(canMove)
        {

        rb.velocity = new Vector2(movementSpeed * movmentInputDirection, rb.velocity.y);

        }

        if (isWallSliding && canFlip)
        {
            if(rb.velocity.y < -wallSlidingSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, -wallSlidingSpeed);
            }
           
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift)){
                rb.velocity = new Vector2(movementSpeed * 1.5f * movmentInputDirection, rb.velocity.y);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity = new Vector2(movementSpeed * 1.5f * movmentInputDirection, rb.velocity.y);
            }
        }
    }

    void flip()
    {
        if (!isWallSliding && canFlip)
        {
        facingDirection *= -1;
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);

        }
    }

  

 
  /*  private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Book")
        {
            if (collision.gameObject.CompareTag("Book") && Input.GetKeyDown(KeyCode.Q))
            {
                IsPushing = true;
                movementSpeed = 0.5f;
             
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
            IsPushing = false;
        movementSpeed = 10f;
        jumpForce = 16.0f;
        canFlip = true;

    }*/
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        Gizmos.DrawLine(wallCheck.position, new Vector3( wallCheck.position.x + wallCheckDistance, wallCheck.position.y, wallCheck.position.z ));
    }

    
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag=="Comp" && !isSafeOpened)
        {
            if (Input.GetKey(KeyCode.R))
            {

            codePanel.SetActive(true);
            }

            if (Input.GetKey(KeyCode.Escape))
            {
                codePanel.SetActive(false);
            }
        }

        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Comp"  )
        {
            codePanel.SetActive(false);
        }
    }


    void ChangLevel()
    {
        if (Input.GetKey(KeyCode.E) && IsMask ==true) {

            
           
            LevelChangerPanel.SetActive(false);
            LevelChangerPanelMask.SetActive(true);
            LevelWithMask.SetActive(true);
            NormalLevel.SetActive(false);

        }

        if (Input.GetKey(KeyCode.W) && IsMask == true)
        {
            LevelChangerPanelMask.SetActive(false);
            LevelChangerPanel.SetActive(true);
            LevelWithMask.SetActive(false);
            NormalLevel.SetActive(true);
        }

    }

    

    void Death()
    {

        anim.SetBool("WearingMask", false);
        anim.SetBool("DieMask", false);
        Colider = false;
        transform.position = new Vector3(-6.79f, -13.53f, 0f);
        movementSpeed = 10f;
        LevelChangerPanelMask.SetActive(false);
        LevelChangerPanel.SetActive(true);
        LevelWithMask.SetActive(false);
        NormalLevel.SetActive(true);
        CancelInvoke();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "collectibles")
        {
            PlayerController.cruentTime += 1;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obestcal nail")
        {
            Colider = true;

            Debug.Log("hit");
        }

        if (collision.gameObject.tag == "Die")
        {
            transform.position = new Vector3(-3.77f, -2.24f,0);
        }
    }
}
