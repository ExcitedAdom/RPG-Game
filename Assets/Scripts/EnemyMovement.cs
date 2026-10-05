using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private bool startsFacingRight = true;
    private float baseScaleX;
    private int facingDirection;
    private Rigidbody2D rb;
    private Transform player;
    private PlayerHealth playerHealth; 
    private Animator animator;
    private EnemyCombat enemyCombat;
    private EnemyState enemyState;

    public float speed;
    public float attackRange = 2f;

    void Start()
    {   
        baseScaleX = Mathf.Abs(transform.localScale.x);
        facingDirection = startsFacingRight ? 1 : -1;

        Vector3 initialScale = transform.localScale;
        initialScale.x = baseScaleX * facingDirection;
        transform.localScale = initialScale;

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enemyCombat = GetComponent<EnemyCombat>();
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.transform;
        playerHealth = playerObject.GetComponent<PlayerHealth>();
        ChangeState(EnemyState.Idle);
    }
    
    void FixedUpdate()
    {
        if (player == null || rb == null)
            return;

        float distance = Vector2.Distance(transform.position, player.position); 

        if (distance <= attackRange)
        {
            ChangeState(EnemyState.Attacking);
            rb.linearVelocity = Vector2.zero; // STAWP moving while attacking and listen to Micheal Jackson, "Stop! In the name of love!"
            
            if (enemyCombat != null && playerHealth != null)

                enemyCombat.SetTarget(playerHealth);
        }

        else
        {
            ChangeState(EnemyState.Moving);
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * speed;
               if (player.position.x > transform.position.x && facingDirection == -1
            || player.position.x < transform.position.x && facingDirection == 1)
                {
                Flip();
                }
        }
     
    }

    void Flip()
    {
        facingDirection *= -1;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;   
    }

    void ChangeState(EnemyState newState)
    {
        // If we're indeed in the state we wanna be in, don't do anything, just chill, bro.
        if (enemyState == newState)
            return;

        // Exit whatever state animation we're currently in
        if (enemyState == EnemyState.Idle)
            animator.SetBool("isIdle", false);
        else if (enemyState == EnemyState.Moving)
            animator.SetBool("isMoving", false);
        else if (enemyState == EnemyState.Attacking)
            animator.SetBool("isAttacking", false);
        
        enemyState = newState;

        // Simply enter new era, ok diva?
        if (enemyState == EnemyState.Idle)
            animator.SetBool("isIdle", true);
        else if (enemyState == EnemyState.Moving)
            animator.SetBool("isMoving", true);
        else if (enemyState == EnemyState.Attacking)
            animator.SetBool("isAttacking", true);
    }
}

public enum EnemyState
    {
        Idle,
        Moving,
        Attacking,
    }