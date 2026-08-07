    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;

    public class MenuController : MonoBehaviour
    {
        public GameObject menuCanvas;
        
        void Start()
        {
            menuCanvas.SetActive(false);
        }

        void Update()
        {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            menuCanvas.SetActive(!menuCanvas.activeSelf);
        }
        }
    }
