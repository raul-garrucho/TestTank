using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUi : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text timeText;
    [SerializeField] private List<Text> hpText = new List<Text>();
    [SerializeField] private List<Text> ammoText = new List<Text>();
    [SerializeField] private List<Image> shieldImg = new List<Image>();
    private void OnEnable()
    {
        CactusManager.cactusDestroy += UpdateCactusUI;
        PlayerStats.hpUpdate += UpdateHpUI;
        PlayerStats.ammoUpdate += UpdateAmmoUI;
    }
    private void OnDisable()
    {
        CactusManager.cactusDestroy -= UpdateCactusUI;
        PlayerStats.hpUpdate -= UpdateHpUI;
        PlayerStats.ammoUpdate -= UpdateAmmoUI;
    }
    private void UpdateCactusUI(int cactuses)
    {
        scoreText.text = cactuses.ToString();
    }
    private void UpdateHpUI(int player, int hp,int lifes)
    {
        if (hp > 1) shieldImg[player].enabled = true;
        else shieldImg[player].enabled = false;
        hpText[player].text = lifes.ToString();
    }
    private void UpdateAmmoUI(int player, int ammo)
    {
        ammoText[player].text = ammo.ToString();
    }
}
