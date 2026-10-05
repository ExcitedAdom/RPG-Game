using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public float damage = 1;
    public float attackCooldown = 1f;
    private float lastAttackTime;
    private PlayerHealth target;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetTarget(PlayerHealth playerHealth)
    {
        target = playerHealth;
    }
    public void DealDamage()
    {
        if (target ==null)
        return;
        
        if (Time.time < lastAttackTime + attackCooldown)
        return;
            
        target.TakeDamage(damage);
        target.ApplyKnockBack(transform.position);
        lastAttackTime = Time.time;
    }
}
