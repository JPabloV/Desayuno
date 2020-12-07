using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Este script hace que los jugadores desaparezcan una vez lleguen a la puerta de la tienda.
Para ello puse un EdgeCollider2D en el objeto "EntraTienda". Cuando los jugadores van entrando
en contacto con este EdgeCollider2D van desapareciendo. */

public class EntraTienda : MonoBehaviour
{
    private string numTienda;

    // Creo una variable para cada uno de los jugadores, que contendrán sus GameObject
    //private GameObject jugador01, jugador02, jugador03, jugador04;

    /* OnTriggerEnter2D maneja la colision del EdgeCollider2D del objeto "EntraTienda" y el 
    BoxCollider2D de cada jugador. Dado que el script está ligado al objeto "EntraTienda", la colision
    se maneja desde el punto de vista de este objeto, de ahí que se busque la colision con un
    objeto de tipo "Jugador" */
    //public static List<string> players = new List<string>();
            
    private void OnTriggerEnter2D(Collider2D collision)
    {
        numTienda = OrdenInicial.numTienda;
        if (collision.gameObject.tag == "Jugador" || collision.gameObject.tag == "Phantom") // Si la colision es con un objeto con tag "Jugador"
        {
            if (numTienda == "Tienda01" && collision.gameObject.tag != "Phantom")
            {
                OrdenInicial.playersOrder.Add(collision.gameObject.name);
            }
            collision.gameObject.SetActive(false);
            StartCoroutine(ChangeScene()); // Ejecuta el IEnumerator ChangeScene()
        }
    }

    IEnumerator ChangeScene() // Espera 7 segundos y cambia la escena a "IntTienda..."
    {
        
        yield return new WaitForSeconds(3);
        if(numTienda == "Tienda01")
        {
            SceneManager.LoadScene("IntTienda01");
        }
        else if(numTienda == "Tienda02")
        {
            SceneManager.LoadScene("IntTienda02");
        }  
        else if(numTienda == "Tienda03")
        {
            SceneManager.LoadScene("IntTienda03");
        }
        if(numTienda == "Tienda04")
        {
            SceneManager.LoadScene("IntTienda04");
        }
    }
}
