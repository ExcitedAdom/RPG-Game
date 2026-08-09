// using UnityEngine;

// public class GameManager : MonoBehaviour
// {
//     public static GameManager Instance;
//     public bool HasKey;
//     public int Coins;
//     public GameObject gameOverPanel;
//     public GameObject winPanel;

//     private void Awake()
//     {
//         if (Instance == null)
//         {
//             Instance = this;
//             DontDestroyOnLoad(gameObject);
//         }
//         else
//         {
//             Destroy(gameObject);
//         }
//     }

//     void Start()
//     {
//         gameOverPanel.SetActive(false);
//         winPanel.SetActive(false);
//     }

//     public void GameOver()
//     {
//         gameOverPanel.SetActive(true);
//         Time.timeScale = 0f;
//     }

//     public void WinGame()
//     {
//         winPanel.SetActive(true);
//         Time.timeScale = 0f;
//     }
// }
