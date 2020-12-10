using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShoppingController : MonoBehaviour
{
    
    // Aquí creo las variables GameObject que contendrán los jugadores
    //private List<GameObject> jugadores;
    private GameObject[] jugadores;
    //private GameObject jugador01, jugador02, jugador03, jugador04, jugador05;
    private float[] posicion; // Este es un vector que contendrá las cuatro posiciones de la fila
    public int[] orden; // Este vector contendrá los numeros de 0 a 3 de forma aleatoria
    private string numTienda;
    private float speed = 200f;
    private GameObject del, campo, a, la, mesa, titulo01, titulo02, txcomenzar, logoEA, logoConocer;
    private Text text;
    public static GameObject tituloGlobal;
    private Transform target;
  
    void Start()
    {
        numTienda = OrdenInicial.numTienda;
        target = GameObject.Find("Target").GetComponent<Transform>();

        jugadores = new GameObject[5];
        jugadores[0] = GameObject.Find("Player01");
        jugadores[1] = GameObject.Find("Player02");
        jugadores[2] = GameObject.Find("Player03");
        jugadores[3] = GameObject.Find("Player04");
        jugadores[4] = GameObject.Find("Phantom");

        tituloGlobal = GameObject.Find("TituloGlobal");
        titulo01 = GameObject.Find("txTitulo01");
        titulo02 = GameObject.Find("txTitulo02");
        titulo02.SetActive(false);

        txcomenzar = GameObject.Find("txComenzar");
        txcomenzar.SetActive(false);

        logoEA = GameObject.Find("logoEA");
        logoEA.SetActive(false);

        logoConocer = GameObject.Find("logoConocer");
        logoConocer.SetActive(false);
        tituloGlobal.SetActive(false);

        if(numTienda == "Inicio")
        {
            tituloGlobal.SetActive(true);
            Shuffle(orden);
            Shuffle(orden);
            Shuffle(orden);
            Shuffle(orden);
            Shuffle(orden);

            // del = GameObject.Find("txDel"); //  341.8 600
            // campo = GameObject.Find("txCampo"); // 609.8 600
            // a = GameObject.Find("txA"); // 824.5 600
            // la = GameObject.Find("txLa"); // 936.7 600
            // mesa = GameObject.Find("txMesa"); // 1139.7 600            
            
            // añado las posiciones al vector
            posicion = new float[5];
            posicion[0] = -100f;
            posicion[1] = -220f;
            posicion[2] = -340f;
            posicion[3] = -460f;
            posicion[4] = -300f;

            // reposiciono los jugadores de acuerdo a las posiciones aleatorias.
            jugadores[0].GetComponent<Transform>().position = new Vector3(posicion[orden[0]], 200f, 0);
            jugadores[1].GetComponent<Transform>().position = new Vector3(posicion[orden[1]], 200f, 0);
            jugadores[2].GetComponent<Transform>().position = new Vector3(posicion[orden[2]], 200f, 0);
            jugadores[3].GetComponent<Transform>().position = new Vector3(posicion[orden[3]], 200f, 0);
            jugadores[4].GetComponent<Transform>().position = new Vector3(posicion[4], 200f, 0);

            posicion = new float[5];
            posicion[0] = 500f;
            posicion[1] = 380f;
            posicion[2] = 260f;
            posicion[3] = 140f;
            posicion[4] = 310f;
        }
        /*else if(numTienda == "Tienda01")
        {          
           // añado las posiciones al vector
            posicion = new float[5];
            posicion[0] = 500f;
            posicion[1] = 380f;
            posicion[2] = 260f;
            posicion[3] = 140f;
            posicion[4] = 310f;
                        
            // reposiciono los jugadores de acuerdo a las posiciones aleatorias.
            jugadores[0].GetComponent<Transform>().position = new Vector3(posicion[orden[0]], 200f, 0);
            jugadores[1].GetComponent<Transform>().position = new Vector3(posicion[orden[1]], 200f, 0);
            jugadores[2].GetComponent<Transform>().position = new Vector3(posicion[orden[2]], 200f, 0);
            jugadores[3].GetComponent<Transform>().position = new Vector3(posicion[orden[3]], 200f, 0);
            jugadores[4].GetComponent<Transform>().position = new Vector3(posicion[4], 200f, 0);
        }*/
        else if(numTienda == "Tienda02")
        {
            posicion = new float[5];
            posicion[0] = 2360f;
            posicion[1] = 2240f;
            posicion[2] = 2120f;
            posicion[3] = 2000f;
            posicion[4] = 2200f;

            jugadores = new GameObject[5];
            jugadores[0] = GameObject.Find(OrdenInicial.playersOrder[1]);
            jugadores[1] = GameObject.Find(OrdenInicial.playersOrder[2]);
            jugadores[2] = GameObject.Find(OrdenInicial.playersOrder[3]);
            jugadores[3] = GameObject.Find(OrdenInicial.playersOrder[0]);
            jugadores[4] = GameObject.Find("Phantom");

            // reposiciono los jugadores de acuerdo a las posiciones aleatorias.
            jugadores[0].GetComponent<Transform>().position = new Vector3(posicion[orden[0]], 200f, 0);
            jugadores[1].GetComponent<Transform>().position = new Vector3(posicion[orden[1]], 200f, 0);
            jugadores[2].GetComponent<Transform>().position = new Vector3(posicion[orden[2]], 200f, 0);
            jugadores[3].GetComponent<Transform>().position = new Vector3(posicion[orden[3]], 200f, 0);
            jugadores[4].GetComponent<Transform>().position = new Vector3(posicion[4], 200f, 0);
        }
        else if(numTienda == "Tienda03")
        {
            posicion = new float[5];
            posicion[0] = 3660f;
            posicion[1] = 3540f;
            posicion[2] = 3420f;
            posicion[3] = 3300f;
            posicion[4] = 3500f;

            jugadores = new GameObject[5];
            jugadores[0] = GameObject.Find(OrdenInicial.playersOrder[2]);
            jugadores[1] = GameObject.Find(OrdenInicial.playersOrder[3]);
            jugadores[2] = GameObject.Find(OrdenInicial.playersOrder[0]);
            jugadores[3] = GameObject.Find(OrdenInicial.playersOrder[1]);
            jugadores[4] = GameObject.Find("Phantom");

            // reposiciono los jugadores de acuerdo a las posiciones aleatorias.
            jugadores[0].GetComponent<Transform>().position = new Vector3(posicion[orden[0]], 200f, 0);
            jugadores[1].GetComponent<Transform>().position = new Vector3(posicion[orden[1]], 200f, 0);
            jugadores[2].GetComponent<Transform>().position = new Vector3(posicion[orden[2]], 200f, 0);
            jugadores[3].GetComponent<Transform>().position = new Vector3(posicion[orden[3]], 200f, 0);
            jugadores[4].GetComponent<Transform>().position = new Vector3(posicion[4], 200f, 0);
        }
        else if(numTienda == "Tienda04")
        {
            posicion = new float[5];
            posicion[0] = 5060f;
            posicion[1] = 4940f;
            posicion[2] = 4820f;
            posicion[3] = 4700f;
            posicion[4] = 4900f;

            jugadores = new GameObject[5];
            jugadores[0] = GameObject.Find(OrdenInicial.playersOrder[3]);
            jugadores[1] = GameObject.Find(OrdenInicial.playersOrder[0]);
            jugadores[2] = GameObject.Find(OrdenInicial.playersOrder[1]);
            jugadores[3] = GameObject.Find(OrdenInicial.playersOrder[2]);
            jugadores[4] = GameObject.Find("Phantom");

            // reposiciono los jugadores de acuerdo a las posiciones aleatorias.
            jugadores[0].GetComponent<Transform>().position = new Vector3(posicion[orden[0]], 200f, 0);
            jugadores[1].GetComponent<Transform>().position = new Vector3(posicion[orden[1]], 200f, 0);
            jugadores[2].GetComponent<Transform>().position = new Vector3(posicion[orden[2]], 200f, 0);
            jugadores[3].GetComponent<Transform>().position = new Vector3(posicion[orden[3]], 200f, 0);
            jugadores[4].GetComponent<Transform>().position = new Vector3(posicion[4], 200f, 0);
        }
        else if(numTienda == "Terminado")
        {
            posicion = new float[5];
            posicion[0] = 6360f;
            posicion[1] = 6240f;
            posicion[2] = 6120f;
            posicion[3] = 6000f;
            posicion[4] = 6200f;

            jugadores = new GameObject[5];
            jugadores[0] = GameObject.Find(OrdenInicial.playersOrder[0]);
            jugadores[1] = GameObject.Find(OrdenInicial.playersOrder[1]);
            jugadores[2] = GameObject.Find(OrdenInicial.playersOrder[2]);
            jugadores[3] = GameObject.Find(OrdenInicial.playersOrder[3]);
            jugadores[4] = GameObject.Find("Phantom");

            // reposiciono los jugadores de acuerdo a las posiciones aleatorias.
            jugadores[0].GetComponent<Transform>().position = new Vector3(posicion[orden[0]], 200f, 0);
            jugadores[1].GetComponent<Transform>().position = new Vector3(posicion[orden[1]], 200f, 0);
            jugadores[2].GetComponent<Transform>().position = new Vector3(posicion[orden[2]], 200f, 0);
            jugadores[3].GetComponent<Transform>().position = new Vector3(posicion[orden[3]], 200f, 0);
            jugadores[4].GetComponent<Transform>().position = new Vector3(posicion[4], 200f, 0);
        }
    } 

    void FixedUpdate()
    {
        if(InicioJuego.comienzo == false && numTienda == "Inicio")
        {
            float fixedSpeed = speed * Time.deltaTime; // la velocidad a la que se mueve el producto seleccionado. el Time.deltaTime es para condicionar la velocidad a la capacidad del ordenador               
            // del.transform.position = Vector3.MoveTowards(del.transform.position, new Vector3(341.8f, 600f, 0f), fixedSpeed*1.5f);
            // campo.transform.position = Vector3.MoveTowards(campo.transform.position, new Vector3(609.8f, 600f, 0f), fixedSpeed*1.5f);
            // a.transform.position = Vector3.MoveTowards(a.transform.position, new Vector3(824.5f, 600f, 0f), fixedSpeed*1.5f);
            // la.transform.position = Vector3.MoveTowards(la.transform.position, new Vector3(936.7f, 600f, 0f), fixedSpeed*1.5f);
            // mesa.transform.position = Vector3.MoveTowards(mesa.transform.position, new Vector3(1139.7f, 600f, 0f), fixedSpeed*1.5f);   

            // if(mesa.transform.position == new Vector3(1139.7f, 600f, 0f))
            // {
                titulo02.SetActive(true);
                jugadores[0].transform.position = Vector3.MoveTowards(jugadores[0].transform.position, new Vector3(posicion[orden[0]], 200f, 0f), fixedSpeed); // mueve el producto seleccionado desde su posisicón inicial a la del Target
                jugadores[1].transform.position = Vector3.MoveTowards(jugadores[1].transform.position, new Vector3(posicion[orden[1]], 200f, 0f), fixedSpeed); // mueve el producto seleccionado desde su posisicón inicial a la del Target
                jugadores[2].transform.position = Vector3.MoveTowards(jugadores[2].transform.position, new Vector3(posicion[orden[2]], 200f, 0f), fixedSpeed); // mueve el producto seleccionado desde su posisicón inicial a la del Target
                jugadores[3].transform.position = Vector3.MoveTowards(jugadores[3].transform.position, new Vector3(posicion[orden[3]], 200f, 0f), fixedSpeed); // mueve el producto seleccionado desde su posisicón inicial a la del Target
                jugadores[4].transform.position = Vector3.MoveTowards(jugadores[4].transform.position, new Vector3(posicion[4], 200f, 0f), fixedSpeed); // mueve el producto seleccionado desde su posisicón inicial a la del Target
            // }
            
            if(jugadores[0].transform.position == new Vector3(posicion[orden[0]], 200f, 0f) && numTienda == "Inicio")
            {   
                logoEA.SetActive(true);
                logoConocer.SetActive(true);
                txcomenzar.SetActive(true);
                text = GameObject.Find("txComenzar").GetComponent<Text>();
                numTienda = "StandBy";
                StartCoroutine(Inicio());
            }

        }   

        if(jugadores[3].transform.position == target.position)
        {
            SceneManager.LoadScene("Jurado");
        }
    }
    IEnumerator Inicio()
    {
        yield return new WaitForSeconds(0.5f);
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0f);
        yield return new WaitForSeconds(0.5f);
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1f);
        numTienda = "Inicio";
    }

    void Shuffle(int[] a)
    {
        // Loops through array
        for (int i = a.Length - 1; i > 0; i--)
        {
            // Randomize a number between 0 and i (so that the range decreases each time)
            int rnd = UnityEngine.Random.Range(0, i);

            // Save the value of the current i, otherwise it'll overright when we swap the values
            int temp = a[i];

            // Swap the new and old values
            a[i] = a[rnd];
            a[rnd] = temp;
        }
    }
}
