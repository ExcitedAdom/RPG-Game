// using UnityEngine;
// using System.Collections;
// using System.Collections.Generic;

// public class RoomEnterTrigger : MonoBehaviour
// {
//     public EnemyAI[] enemiesInRoom;
//     public GameObject[] doorBarriers;
//     private bool triggered = false;
//     private bool roomCleared = false;


//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         if (!other.CompareTag("Player") || triggered)
//             return;

//         foreach (EnemyAI enemy in enemiesInRoom)
//         {
//             if (enemy != null)
//                 enemy.enabled = true;
//         }
//         foreach (GameObject barrier in doorBarriers)
//         {
//             if (barrier != null)
//                 barrier.SetActive(true);
//         }

//         triggered = true;
//     }

//     private void Update()
//     {
//         if (!triggered || roomCleared)
//             return;

//         bool allEnemiesDefeated = true;
//         foreach (EnemyAI enemy in enemiesInRoom)
//         {
//             if (enemy != null && enemy.gameObject.activeSelf)
//             {
//                 allEnemiesDefeated = false;
//                 break;
//             }
//         }

//         if (allEnemiesDefeated)
//         {
//             foreach (GameObject barrier in doorBarriers)
//             {
//                 if (barrier != null)
//                     barrier.SetActive(false);
//             }
//             roomCleared = true;
//         }
//     }
// }
