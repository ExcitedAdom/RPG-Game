using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public float damage = 1;
    public float attackCooldown = 1f;
    private float lastAttackTime;
    private Animator animator;
    private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        if (Time.time >= lastAttackTime + attackCooldown)
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                lastAttackTime = Time.time;
                if (animator != null)
                {
                    animator.SetTrigger("Attack");
                }
            }
        }
    }
}
