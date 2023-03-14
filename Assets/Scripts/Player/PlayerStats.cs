using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Player Data y Ui Controller
 
public class PlayerStats : MonoBehaviour
{
    public int hp,amountOfAmmo,lifes;
    public Image shieldImage,ammoImage;
    public Text amountOfAmmoText,lifesText,winnerText;
    private PlayerAttack playerAttack;
    public Transform respawnPoint;
    public GameObject winPanel,brokenTankPrefab;
    public string attackerId;

    private void Awake()
    {
        playerAttack = transform.GetComponent<PlayerAttack>();
        winPanel.SetActive(false);
        lifes = 3;
    }
    private void Update()
    {
        statsController();
        UiController();
    }
    private void UiController()
    {
        amountOfAmmo = playerAttack.amountOfAmmo;
        ammoImage.fillAmount = playerAttack.actualtime / playerAttack.readytime;
        amountOfAmmoText.text = amountOfAmmo.ToString();
        lifesText.text = lifes.ToString();
        if (hp > 1) shieldImage.enabled = true;
        else shieldImage.enabled = false;
    }
    private void statsController()
    {
        hp = Mathf.Clamp(hp, 0, 2);
        if (hp < 1)
        {
            lifes--;
            hp = 1;
            Instantiate(brokenTankPrefab, transform.position, Quaternion.identity);
            transform.position = respawnPoint.position;
        }
        if (lifes < 1)
        {
            winPanel.SetActive(true);
            winnerText.text = attackerId;
        }
    }
}
