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
    private GameObject winningBox, winningBox2, AndaluzBox;
        
    // Start is called before the first frame update
    void Start()
    {
        winningBox = GameObject.Find("WinningBox");
        winningBox2 = GameObject.Find("WinningBox2");
        winningBox.SetActive(false);
        winningBox2.SetActive(false);
        datosPuntuacionFinal = Jurado.ObtenerPuntuacion();

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
                imageCambiar.SetNativeSize(); // redimensiona la imagen con el height y el width del sprite que incluye

                if(imageCambiar.sprite.name == "conservas" || imageCambiar.sprite.name == "sandia")
                {
                    imageCambiar.GetComponent<Transform>().localScale = new Vector3(0.1f, 0.1f, 0.1f);
                }
                else if(imageCambiar.sprite.name == "huevo")
                {
                    imageCambiar.GetComponent<Transform>().localScale = new Vector3(0.05f, 0.05f, 0.05f);
                }
                else if(imageCambiar.sprite.name == "pan_1" || imageCambiar.sprite.name == "patatas" )
                {
                    imageCambiar.GetComponent<Transform>().localScale = new Vector3(0.12f, 0.12f, 0.12f);
                } 
                else if(imageCambiar.sprite.name == "pollo" || imageCambiar.sprite.name == "aceite de oliva" || 
                imageCambiar.sprite.name == "arroz_stewart" || imageCambiar.sprite.name == "pasta" || 
                imageCambiar.sprite.name == "garbanzos" || imageCambiar.sprite.name == "manzana")
                {
                    imageCambiar.GetComponent<Transform>().localScale = new Vector3(0.3f, 0.3f, 0.3f);
                } 
                else if (imageCambiar.sprite.name == "maiz" || imageCambiar.sprite.name == "galletas_0" || imageCambiar.sprite.name == "croisant_0"
                || imageCambiar.sprite.name == "mantequilla" || imageCambiar.sprite.name == "filete" || imageCambiar.sprite.name == "queso")
                {
                    imageCambiar.GetComponent<Transform>().localScale = new Vector3(0.4f, 0.4f, 0.4f);
                }
                else if (imageCambiar.sprite.name == "almendras" || imageCambiar.sprite.name == "arandanos" || imageCambiar.sprite.name == "harina" )
                {
                    imageCambiar.GetComponent<Transform>().localScale = new Vector3(0.6f, 0.6f, 0.6f);
                }
                else if (imageCambiar.sprite.name == "azucar" || imageCambiar.sprite.name == "yogur" || imageCambiar.sprite.name == "miel")
                {
                    imageCambiar.GetComponent<Transform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
                }
                else if(imageCambiar.sprite.name == "mermelada")
                {
                    imageCambiar.GetComponent<Transform>().localScale = new Vector3(0.15f, 0.15f, 0.15f);
                }
                else if(imageCambiar.sprite.name == "jamon")
                {
                    imageCambiar.GetComponent<Transform>().localScale = new Vector3(0.15f, 0.18f, 0.2f);
                }
                else
                {
                    imageCambiar.GetComponent<Transform>().localScale = new Vector3(0.3f, 0.3f, 0.3f);
                }
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
        var listaJugadores = datosPuntuacionFinal.OrderBy(p=>p.PuntuacionFinal).ToList();
        //Comprobar que los dos primeros no tienen la misma puntuacion
        if (listaJugadores[3].PuntuacionFinal == listaJugadores[2].PuntuacionFinal)
        {
            //Los dos primeros tienen los mismos puntos
            winningBox2.SetActive(true);
            string nameSprite1 = string.Empty;
            string nameSprite2 = string.Empty;
            //control del jugador
            switch(Order[3].name.ToLower())
            {
                case "player01":
                    nameSprite1 = "interna_winner";
                break;
                case "player02":
                nameSprite1 = "rubio_winner";
                break;
                case "player03":
                nameSprite1 = "guapilla_winner";
                break;
                case "player04":
                nameSprite1 = "moderno_winner";
                break;
            }
            switch(Order[2].name.ToLower())
            {
                case "player01":
                    nameSprite2 = "interna_winner";
                break;
                case "player02":
                nameSprite2 = "rubio_winner";
                break;
                case "player03":
                nameSprite2 = "guapilla_winner";
                break;
                case "player04":
                nameSprite2 = "moderno_winner";
                break;
            }
            Sprite winnerSprite = Resources.Load<Sprite>("Personajes/" + nameSprite1);
            Sprite winnerSprite2 = Resources.Load<Sprite>("Personajes/" + nameSprite2);
            //GameObject.Find("WinningPlayer").GetComponent<Image>().sprite = GameObject.Find(Order[3].name+"_winner").GetComponent<Image>().sprite;
            GameObject.Find("WinningPlayer2_1").GetComponent<Image>().sprite = winnerSprite;
            GameObject.Find("WinningPlayer2_2").GetComponent<Image>().sprite = winnerSprite2;
            GameObject.Find("btFinalizar").SetActive(false);
        }
        else
        {
            winningBox.SetActive(true);
            string nameSprite = string.Empty;
            //control del jugador
            switch(Order[3].name.ToLower())
            {
                case "player01":
                    nameSprite = "interna_winner";
                break;
                case "player02":
                nameSprite = "rubio_winner";
                break;
                case "player03":
                nameSprite = "guapilla_winner";
                break;
                case "player04":
                nameSprite = "moderno_winner";
                break;
            }
            Sprite winnerSprite = Resources.Load<Sprite>("Personajes/" + nameSprite);
            //GameObject.Find("WinningPlayer").GetComponent<Image>().sprite = GameObject.Find(Order[3].name+"_winner").GetComponent<Image>().sprite;
            GameObject.Find("WinningPlayer").GetComponent<Image>().sprite = winnerSprite;
            GameObject.Find("btFinalizar").SetActive(false);
        }
        
    }

    public void SceneFinal()
    {
        SceneManager.LoadScene("final");
    }
   
}
