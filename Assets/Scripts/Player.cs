using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveForce = 10f;
    public float jumpForce = 10f;
    
    private Rigidbody2D rb;
    
    private SpriteRenderer sr;
    
    private Animator animator;

    private float moveX;
    public bool isGrounded = true;
    private string WALK_ANIMATION = "Walk";
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";

    private Vector2 touchOrigin = -Vector2.one;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        PlayerAnim();
        PlayerJump();

    }
   
    void PlayerMoveKeyboard()
    {
#if UNITY_STANDALONE || UNITY_WEBPLAYER
        moveX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(moveX, 0f, 0f) * Time.deltaTime * moveForce;
#else
        if(Input.touchCount>0)
        {
            Touch mytouch = Input.touches[0];
            if(mytouch.phase==TouchPhase.Began)
            {
                touchOrigin = mytouch.position;
            }
            else if (mytouch.phase == TouchPhase.Ended && touchOrigin.x >= 0)
            {
                Vector2 touchEnd = mytouch.position;
                float x=touchEnd.x-touchOrigin.x;
                float y=touchEnd.y-touchOrigin.y;
                touchOrigin.x = -1;
                if(Mathf.Abs(x)>Mathf.Abs(y)) {
                    moveX = x > 0 ? 1 : -1;
                }
            }
            transform.position += new Vector3(moveX, 0f, 0f) * Time.deltaTime * moveForce;
        }
#endif

    }
    void PlayerAnim()
    {
        if (moveX > 0)
        {
            animator.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if (moveX < 0)
        {
            animator.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else animator.SetBool(WALK_ANIMATION, false);
    }
    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump")&&isGrounded==true) {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
            
        }
        else if(Input.touchCount==2&&isGrounded==true)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG)) 
        
            isGrounded = true;

        if (collision.gameObject.CompareTag(ENEMY_TAG))
            Destroy(gameObject);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(ENEMY_TAG)) 
            Destroy(gameObject);
    }
}
