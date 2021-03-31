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

    public void Salir()
    {
        Debug.Log("Regresamos al inicio.");
        InicioJuego inicio = new InicioJuego();
        inicio.RestartGame();
    }

    public void SalirJuego()
    {
        Debug.Log("Salimos de la aplicación a través del botón.");
        InicioJuego inicio = new InicioJuego();
        Application.Quit();
    }

}
