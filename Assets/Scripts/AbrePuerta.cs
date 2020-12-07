using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Este script simplemente cambia el sprite de la tienda, con la puerta cerrada a con la
puerta abierta una vez el primer jugador en la fila entre en contacto con el EdgeCollider2D
del objeto "AbrePuerta" */

public class AbrePuerta : MonoBehaviour
{

    public GameObject panaderia; // la variable panaderia que contiene el GameObject Panadería
    public Sprite sprite1; // la variable sprite1 contiene el sprite de la tienda cerrada
    public Sprite sprite2; // la variable sprite2 contiene el sprite de la tienda abierta

    /* OnTriggerEnter2D maneja la colision del EdgeCollider2D del objeto "AbrePuerta" y el 
    BoxCollider2D del jugador. Dado que el script está ligado al objeto "AbrePuerta", la colision
    se maneja desde el punto de vista de este objeto, de ahí que se busque la colision con un
    objeto de tipo "Jugador" */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jugador") // Si la colision es con un objeto con tag "Jugador"
        {
            panaderia.GetComponent<SpriteRenderer>().sprite = sprite2; // Cambia el sprite de panaderia

            StartCoroutine(CloseDoor());  // Llama al IEnumerator CloseDoor()

        }
    }

    IEnumerator CloseDoor() // Espera 3 segundos y cambia el sprite de "panaderia" al de puerta cerrada
    {
        yield return new WaitForSeconds(4);
        panaderia.GetComponent<SpriteRenderer>().sprite = sprite1; // Cambia el sprite de panaderia
    }
}
