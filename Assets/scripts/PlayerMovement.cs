using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] bool facingRight;
    public Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animController;
    public CapsuleCollider2D playerCollider;
    float horizontalValue;
    float movementSpeed = 400f;

    [SerializeField] bool canJump;
    int countJump;
   float jumpForce = 10f;

    public static PlayerMovement instance;

    private void Awake()
    {
        if (instance != null)
        {
            //Debug.LogWarning("il y a plus d'une instance Player dans la scene");
            return;
        }
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalValue = Input.GetAxis("Horizontal");

       
        FlipCharacter();
        animController.SetFloat("Speed", Mathf.Abs(horizontalValue));


        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump")) && canJump && countJump > 0)
        {

            Jump();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalValue * Time.deltaTime * movementSpeed,rb.velocity.y);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Plateform")
        {
            animController.SetBool("Jumping", false);
            countJump = 2;
            canJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (countJump == 2)
        {
            countJump = 0;
            animController.SetBool("Jumping", true);
        }
    }

    void Jump()
    {
        
        animController.SetBool("Jumping", true);
     
        countJump -= 1;
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

    }

    void FlipCharacter()
    {
        if((horizontalValue < 0 && facingRight) || (horizontalValue > 0 && !facingRight))
        {
            facingRight = !facingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    
}
