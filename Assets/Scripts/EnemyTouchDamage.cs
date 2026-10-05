// using UnityEngine;

// public class EnemyTouchDamage : MonoBehaviour
// {
//     public float damage = 1;
//     public float damageCooldown = 1f;
//     private float lastDamageTime;

//     void OnCollisionStay2D(Collision2D collision)
//     {
//        if (!collision.gameObject.CompareTag("Player"))
//            return;
       
//        if (Time.time >= lastDamageTime + damageCooldown)
//        {
//            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
//            if (playerHealth != null)
//            {
//                playerHealth.TakeDamage(damage);
//                lastDamageTime = Time.time;
//            }
//        }
//     }
// }
