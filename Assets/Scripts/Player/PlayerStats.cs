using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int lifes,amountOfAmmo;
    public Image shieldImage,ammoImage;
    public Text amountOfAmmoText;
    private PlayerAttack playerAttack;

    private void Awake()
    {
        playerAttack = transform.GetComponent<PlayerAttack>();
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
        if (lifes > 1) shieldImage.enabled = true;
        else shieldImage.enabled = false;
    }
    private void statsController()
    {
       lifes = Mathf.Clamp(lifes, 0, 2);
            if (lifes < 1)
            {
                //Dead
            }
    }
}
