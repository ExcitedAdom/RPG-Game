using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HealthUI : MonoBehaviour
{
    public Sprite fullHeart, emptyHeart, halfHeart;
    Image heartImage;

    private void Awake()
    {
        heartImage = GetComponent<Image>();
    }

    public void SetHeartImage(HeartStatus status)
    {
        switch (status)
        {
            case HeartStatus.Full:
                heartImage.sprite = fullHeart;
                break;
            case HeartStatus.Half:
                heartImage.sprite = halfHeart;
                break;
            case HeartStatus.Empty:
                heartImage.sprite = emptyHeart;
                break;
        }
    }
}

public enum HeartStatus
{
    Full = 2,
    Half = 1,
    Empty = 0
}