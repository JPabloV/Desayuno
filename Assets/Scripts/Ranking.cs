using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ranking : MonoBehaviour
{
    //public static int puntacionPlayer1, puntacionPlayer2, puntacionPlayer3, puntacionPlayer4;
    public GameObject player01, player02, player03, player04;
    public int puntuacionPlayer1, puntuacionPlayer2, puntuacionPlayer3, puntuacionPlayer4;
   // public int[] puntuaciones;
    //public GameObject[] jugadores;
    public Dictionary<GameObject, int> rankingPlayers = new Dictionary<GameObject, int>();
    public GameObject[] Order;
    private int x = 0;
    private List<Puntuacion> datosPuntuacionFinal;
    private GameObject winningBox;
        
    // Start is called before the first frame update
    void Start()
    {
        winningBox = GameObject.Find("WinningBox");
        winningBox.SetActive(false);
        datosPuntuacionFinal = Jurado.ObtenerPuntuacion();
        /*
        puntuacionPlayer1 = datosPuntuacionFinal[0].PuntuacionFinal;
        puntuacionPlayer2 = datosPuntuacionFinal[1].PuntuacionFinal;
        puntuacionPlayer3 = datosPuntuacionFinal[2].PuntuacionFinal;
        puntuacionPlayer4 = datosPuntuacionFinal[3].PuntuacionFinal;
      
        GameObject.Find("Puntuacion1").GetComponent<Text>().text = datosPuntuacionFinal[0].PuntuacionFinal.ToString();
        GameObject.Find("Puntuacion2").GetComponent<Text>().text = datosPuntuacionFinal[1].PuntuacionFinal.ToString();
        GameObject.Find("Puntuacion3").GetComponent<Text>().text = datosPuntuacionFinal[2].PuntuacionFinal.ToString();
        GameObject.Find("Puntuacion4").GetComponent<Text>().text = datosPuntuacionFinal[3].PuntuacionFinal.ToString();
        */
        //-------------------
        // INSTANCIAR OBJETOS
        //-------------------

        player01 = GameObject.Find("Player01");
        player02 = GameObject.Find("Player02");
        player03 = GameObject.Find("Player03");
        player04 = GameObject.Find("Player04");

        rankingPlayers.Add(player01, datosPuntuacionFinal[0].PuntuacionFinal);
        rankingPlayers.Add(player02, datosPuntuacionFinal[1].PuntuacionFinal);
        rankingPlayers.Add(player03, datosPuntuacionFinal[2].PuntuacionFinal);
        rankingPlayers.Add(player04, datosPuntuacionFinal[3].PuntuacionFinal);

        //-------------------
        // ORDEN DE JUGADORES
        //-------------------

        Order = new GameObject[4];     
        foreach(KeyValuePair<GameObject, int> puntos in rankingPlayers.OrderBy(key => key.Value))
        {
            Order[x] = puntos.Key;
            x++;
        }

        Order[3].GetComponent<Transform>().transform.position = new Vector3(90f, 567f, 0f);
        Order[2].GetComponent<Transform>().transform.position = new Vector3(90f, 408f, 0f);
        Order[1].GetComponent<Transform>().transform.position = new Vector3(90f, 251f, 0f);
        Order[0].GetComponent<Transform>().transform.position = new Vector3(90f, 95f, 0f);

        // Esto no estaba funcionando, así que lo comento. Añadí los puntos de otra forma al inicio del start
        //Recorrer la puntuacion final por jugador para pintar productos y poner su valor
        
        foreach (var item in datosPuntuacionFinal.OrderBy(p=>p.PuntuacionFinal))
        {
            pintarProductos(item.Alimentos, item.Player);
            GameObject.Find("Puntuacion"+item.Player).GetComponent<Text>().text = item.PuntuacionFinal.ToString();
        }
        
    }

    public void pintarProductos(List<Alimento> lAlimentos, int iPlayer)
    {
        //Ir recorriendo Datos receta del jugador y mostrar las imágenes.
        int contador=1;
        if (lAlimentos!=null)
        {
            foreach(var alimento in lAlimentos)
            {
                Image imageCambiar;
                imageCambiar =  GameObject.Find("Player0"+iPlayer.ToString()).transform.Find("Prod"+contador).gameObject.GetComponent<Image>();
 
                // Sprite mySprite = Resources.Load<Sprite>(rutaSprite + sNuevaImage);
                Sprite mySprite = Resources.Load<Sprite>(alimento.ImageSource);
                imageCambiar.sprite = mySprite;
                contador++;
            }
        }
        while(contador<=6)
        {
            //Desactivamos el resto de alimentos.
            GameObject.Find("Player0"+iPlayer.ToString()).transform.Find("Prod"+contador).gameObject.SetActive(false);
            contador++;
        }

    }

    public void Ganador()
    {
        winningBox.SetActive(true);
        GameObject.Find("WinningPlayer").GetComponent<Image>().sprite = GameObject.Find(Order[3].name).GetComponent<Image>().sprite;
        GameObject.Find("btFinalizar").SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
