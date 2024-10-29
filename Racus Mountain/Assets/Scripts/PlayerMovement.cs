using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator animate;
    private BoxCollider2D boxCollider;
    private float wallJumpTimer;
    private float horizontalInput;
    public GameObject attackPoint;
    public float radius;
    public LayerMask enemies;
    [SerializeField] private AudioClip sword;
    [SerializeField] private AudioClip jump;
    

    //Setting up body and animation
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        
        //Flip depending on the direction player moves
        if(horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if(horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1,1,1);
        }

        //Animation parameters
        animate.SetBool("run", horizontalInput != 0);
        animate.SetBool("grounded", isGrounded());

        if(Input.GetMouseButtonDown(0))
        {
            animate.SetBool("isAttacking", true);
        }

        if(wallJumpTimer > 0.2f)
        {
           
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if(holdWall() && !isGrounded())
            {
                //Slowly fall when grabbing the wall
                body.gravityScale = 1;
                body.velocity = Vector2.zero;
                Debug.Log("On Wall");
            }
            else {
                body.gravityScale = 2;
                
            }
            
            if(Input.GetKey(KeyCode.Space))
            {
                Jump();   
            }
        }
        else {
           wallJumpTimer += Time.deltaTime; 
        }
    }

    //Stopping the attack animation
    public void endAttack()
    {
       animate.SetBool("isAttacking", false); 
    }
    
    public void attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);

        AudioManager.instance.PlaySound(sword);
        foreach(Collider2D enemyGameObject in enemy)
        {
            Debug.Log("Hit enemy");
            //AudioManager.instance.PlaySound(pain);
            enemyGameObject.GetComponent<EnemyHealth>().health -= 1;
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }

    //Jump function
    private void Jump()
    {
        //Make sure the player is on the ground before jumping
        if(isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            animate.SetTrigger("jump");
            AudioManager.instance.PlaySound(jump);
        }
        //Check if player is holding onto wall
        else if (holdWall() && !isGrounded())
        {
            if(horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 8, 3);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                Debug.Log("Jump away");
                AudioManager.instance.PlaySound(jump);
            }
            else {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
                Debug.Log("Jump up");
                AudioManager.instance.PlaySound(jump);
            }
            wallJumpTimer = 0;
            
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

    }
    //Tests to see if the player is touching the ground or not
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    //Tests to see if the player is touching a wall or not
    private bool holdWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }


}
