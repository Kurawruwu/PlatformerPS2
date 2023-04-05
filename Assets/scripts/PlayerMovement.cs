using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animController;
    public CapsuleCollider2D playerCollider;
    float horizontalValue;
    float movementSpeed = 400f;

    bool canJump;
    int countJump;
    float jumpForce = 12f;

    public static PlayerMovement instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("il y a plus d'une instance Player dans la scene");
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

        if (horizontalValue > 0) sr.flipX = false;
        else if (horizontalValue < 0) sr.flipX = true;

        if (Input.GetKeyDown(KeyCode.Space) && canJump && countJump > 0)
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
}
