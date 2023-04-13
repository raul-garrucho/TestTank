using System.Collections;
using System.Collections.Generic;
using Tankprototipe;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    public void cactusDestroy()
    {
        GetComponentInParent<CactusManager>().DestroyCactus();
        Destroy(gameObject);
    }
    
}
