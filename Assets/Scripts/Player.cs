using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Animator animator;
    private Rigidbody2D rb;

    private BoxCollider2D bc;


    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpSpeed = 0.1f;

    private float onGround;
    private bool jumping = false;
    private bool falling = false;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        onGround = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.instance.isGameOver == false)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Vector3 currScale = transform.localScale;
                transform.localScale = new Vector3(-Mathf.Abs(currScale.x), currScale.y, currScale.z);
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                animator.SetBool("isRunning", true);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                Vector3 currScale = transform.localScale;
                transform.localScale = new Vector3(Mathf.Abs(currScale.x), currScale.y, currScale.z);
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }

            if (Input.GetKey(KeyCode.UpArrow) && !jumping && !falling && rb.velocity.y == 0)
            {
                //ransform.position += Vector3.up * jumpSpeed * Time.deltaTime;
                rb.velocity += new Vector2(0, 1) * jumpSpeed;
                animator.SetBool("isJumping", true);
                jumping = true;
            }

            if (jumping && (rb.velocity.y < -0.1 && transform.position.y >= onGround + 1))
            {
                animator.SetBool("isFalling", true);
                jumping = false;
                falling = true;
            }

            if (!jumping && falling && transform.position.y >= onGround - 0.1 && transform.position.y <= onGround + 0.1)
            {
                animator.SetBool("isJumping", false);
                animator.SetBool("isFalling", false);
                falling = false;
            }

        }
    }


    public void GetPooped()
    {
        GetComponent<SpriteRenderer>().color = new Color(0.77f, 0.52f, 0f);
        bc.size = new Vector2(bc.size.x, 0.627f);
        animator.SetBool("isHit", true);
        //0.763f
    }
}
