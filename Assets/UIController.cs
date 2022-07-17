using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("Equipment Previewers")]
    [SerializeField] private Image elementImage;
    [SerializeField] private Image weaponImage;
    [SerializeField] private Image[] playerHealth = new Image[5];
    [SerializeField] private GameObject player;

    int counterGambiarra = 5;

    private void Update()
    {
        if(player != null)
        {
            counterGambiarra = player.GetComponent<PlayerLife>().health;
        }
        else
        {
            playerHealth[0].enabled = false;
        }

        if(counterGambiarra <= 4)
        {
            playerHealth[counterGambiarra].enabled = false;
        }
    }

    public void SetElementAndWeapon(Sprite element, Sprite weapon)
    {
        elementImage.sprite = element;
        weaponImage.sprite = weapon;
    }
}
