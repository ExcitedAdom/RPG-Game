// using UnityEngine;

// public class PlayerItemCollector : MonoBehaviour
// {
//     public enum PickupType {Health, Key, Coin}
//     public PickupType type;
//     public int value = 20;

//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         if (!other.CompareTag("Player"))
//             return;

//         switch (type)
//         {
//             case PickupType.Health:
//                 PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
//                 if (playerHealth != null)
//                     playerHealth.Heal(value);
//                 break;

//             case PickupType.Key:
//                 GameManager.Instance.HasKey = true;
//                 break;
            
//             case PickupType.Coin:
//                 GameManager.Instance.Coins += value;
//                 break;
//         }
//         Destroy(gameObject);
//     }
// }
