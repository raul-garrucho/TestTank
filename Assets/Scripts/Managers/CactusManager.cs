using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CactusManager : MonoBehaviour
{
    [SerializeField] GameObject cactusPrefab;
    [SerializeField] Gameplay gameplay;
    public int destroyedCactus, nCactus;
    public Text cactusNumText,timeText;
    
    private void OnEnable()
    {
        AddCactus();
        AddCactus();
        AddCactus();
        AddCactus();
        AddCactus();    
    }
    private void AddCactus()
    {
      
            nCactus++;
            float xOffset, zOffset;
            xOffset = Random.Range(75, -75);
            zOffset = Random.Range(75, -75);
            Vector3 ramdonPosition = transform.position + new Vector3(xOffset, 0, zOffset);
            Instantiate(cactusPrefab, ramdonPosition, Quaternion.identity, transform);
      
    }
    public void DestroyCactus()
    {
        destroyedCactus++;
        nCactus--;
        AddCactus();
        if (destroyedCactus >= 20)
        {
           destroyedCactus = 0;
           gameplay.ChangeToExit();
        }
    }
    private void Update()
    {
        UiManager();
    }
    private void UiManager()
    {
        cactusNumText.text = destroyedCactus.ToString();
        float minutes = Mathf.FloorToInt(gameplay.currentTime/ 60);
        float seconds = Mathf.FloorToInt(gameplay.currentTime % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
