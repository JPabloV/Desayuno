using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script controla el pulsado de los botones "btVerdadero" de cada player. Al pulsarlo, la variable "pushed" del PlayerGeneralControler adquiere el valor "V"

public class BotonTrue : MonoBehaviour
{
    private PlayerGeneralController player;
    
    void Start()
    {  
        player = transform.parent.GetComponent<PlayerGeneralController>();
    }

    public void OnMouseDown()
    {
        player.pushed = "V";
    }
}
