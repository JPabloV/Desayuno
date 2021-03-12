using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scape : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Debug.Log("Salimos de la aplicación.");
            Application.Quit();
        }
    }
}
