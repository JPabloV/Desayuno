using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

// Este script maneja procesos generales del desarrollo de la escena. Contiene las variables y objetos estaticos.

public class GeneralController : MonoBehaviour
{
    public static bool productSelected = false; // controla que no haya un producto seleccionado. Si es true "desactiva" el OnMouseDown del script Producto
    public static GameObject questionBox; // el GameObject de la ventana de preguntas
    public static GameObject btTrue01, btFalse01, btTrue02, btFalse02, btTrue03, btFalse03, btTrue04, btFalse04; // los botones de verdadero y falso de cada uno de los jugadores
    public Sprite vNormal, vSelected, vRight, vWrong, xNormal, xSelected, xRight, xWrong; // Los sprites de los botones Verdadero y Falso en sus cuatro colores cada uno
    private GameObject player01, player02, player03, player04; // GameObjects de los jugadores
    public static GameObject qtplayer01, qtplayer02, qtplayer03, qtplayer04; // GameObjects de los jugadores
    private TurningPlayer player01s, player02s, player03s, player04s; // GameObjects de los jugadores
    private Transform target;
    private GameObject btResolver; // GameObject del boton btResolver
    public static bool resuelto = false;
    public static string whosTurn;
    public static bool turnSpin = true;
    public int numQuestions;
    private Transform garbage;
    public GameObject tendero;
    public static bool repartoGanadores;
    public static string acertante;
    public static int numAcertantes;
    public static int unidadesProducto;
    public static string productoGanado = "wait";
    public static bool cambioTurno = false;
    public GameObject plato01, plato02, plato03, plato04;
    public GameObject platos;
    public static GameObject[] leftovers;

    // Start is called before the first frame update
    void Start()
    {
        // ------------------        
        // INSTANCIAR OBJETOS
        // ------------------
        garbage = GameObject.Find("Garbage").GetComponent<Transform>();
        target = GameObject.Find("Target").GetComponent<Transform>(); // toma el transform del objeto Target, para saber donde debe moverse el producto seleccioando
        questionBox = GameObject.Find("QuestionBox"); // toma el GameObject de la ventana de preguntas
        btResolver = GameObject.Find("btResolver"); // toma el GameObject del botón para resolver la pregunta
                
        // toman los GameObject de los jugadores de la QuestionBox
        qtplayer01 = GameObject.Find("qtPlayer01");
        qtplayer02 = GameObject.Find("qtPlayer02");
        qtplayer03 = GameObject.Find("qtPlayer03");
        qtplayer04 = GameObject.Find("qtPlayer04");

        // toman los GameObject de los jugadores de la izquierda
        player01 = GameObject.Find("Player01");
        player02 = GameObject.Find("Player02");
        player03 = GameObject.Find("Player03");
        player04 = GameObject.Find("Player04");

        player01s = player01.GetComponent<TurningPlayer>();
        player02s = player02.GetComponent<TurningPlayer>();
        player03s = player03.GetComponent<TurningPlayer>();
        player04s = player04.GetComponent<TurningPlayer>();

        plato01 = GameObject.Find("Plato01");
        plato02 = GameObject.Find("Plato02");
        plato03 = GameObject.Find("Plato03");
        plato04 = GameObject.Find("Plato04");

        tendero = GameObject.Find("Tendero");
        numQuestions = 4;

        platos = GameObject.Find("Platos");
        plato01.transform.SetParent(player01.transform);
        plato02.transform.SetParent(player02.transform);
        plato03.transform.SetParent(player03.transform);
        plato04.transform.SetParent(player04.transform);

        //-----------------------------------------------------------------
        // ORDENA LOS JUGADORES POR ORDEN DE TURNO Y ASIGNA EL PRIMER TURNO
        //-----------------------------------------------------------------

        if(OrdenInicial.numTienda == "Tienda01")
        {
            tendero.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>().text = "!Bienvenidos a la panadería y bollería! Primer cliente, ¿Qué deseas?";
            GameObject.Find(OrdenInicial.playersOrder[0]).GetComponent<Transform>().transform.position = new Vector3(90f, 630f, 0f);
            GameObject.Find(OrdenInicial.playersOrder[1]).GetComponent<Transform>().transform.position = new Vector3(90f, 450f, 0f);
            GameObject.Find(OrdenInicial.playersOrder[2]).GetComponent<Transform>().transform.position = new Vector3(90f, 270f, 0f);
            GameObject.Find(OrdenInicial.playersOrder[3]).GetComponent<Transform>().transform.position = new Vector3(90f, 90f, 0f);
            whosTurn = OrdenInicial.playersOrder[0];
        }
        else if(OrdenInicial.numTienda == "Tienda02")
        {
            tendero.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>().text = "!Bienvenidos a la frutería y verdulería! Primer cliente, ¿Qué deseas?";
            GameObject.Find(OrdenInicial.playersOrder[1]).GetComponent<Transform>().transform.position = new Vector3(90f, 630f, 0f);
            GameObject.Find(OrdenInicial.playersOrder[2]).GetComponent<Transform>().transform.position = new Vector3(90f, 450f, 0f);
            GameObject.Find(OrdenInicial.playersOrder[3]).GetComponent<Transform>().transform.position = new Vector3(90f, 270f, 0f);
            GameObject.Find(OrdenInicial.playersOrder[0]).GetComponent<Transform>().transform.position = new Vector3(90f, 90f, 0f);       
            whosTurn = OrdenInicial.playersOrder[1];
        }
        else if(OrdenInicial.numTienda == "Tienda03")
        {
            tendero.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>().text = "!Bienvenidos a la lechería! Primer cliente, ¿Qué deseas?";
            GameObject.Find(OrdenInicial.playersOrder[2]).GetComponent<Transform>().transform.position = new Vector3(90f, 630f, 0f);
            GameObject.Find(OrdenInicial.playersOrder[3]).GetComponent<Transform>().transform.position = new Vector3(90f, 450f, 0f);
            GameObject.Find(OrdenInicial.playersOrder[0]).GetComponent<Transform>().transform.position = new Vector3(90f, 270f, 0f);
            GameObject.Find(OrdenInicial.playersOrder[1]).GetComponent<Transform>().transform.position = new Vector3(90f, 90f, 0f);
            whosTurn = OrdenInicial.playersOrder[2];
        }
        if(OrdenInicial.numTienda == "Tienda04")
        {
            tendero.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>().text = "!Bienvenidos a Variedades! Primer cliente, ¿Qué deseas?";
            GameObject.Find(OrdenInicial.playersOrder[3]).GetComponent<Transform>().transform.position = new Vector3(90f, 630f, 0f);
            GameObject.Find(OrdenInicial.playersOrder[0]).GetComponent<Transform>().transform.position = new Vector3(90f, 450f, 0f);
            GameObject.Find(OrdenInicial.playersOrder[1]).GetComponent<Transform>().transform.position = new Vector3(90f, 270f, 0f);
            GameObject.Find(OrdenInicial.playersOrder[2]).GetComponent<Transform>().transform.position = new Vector3(90f, 90f, 0f);
            whosTurn = OrdenInicial.playersOrder[3];
        }

        plato01.transform.SetParent(platos.transform);
        plato02.transform.SetParent(platos.transform);
        plato03.transform.SetParent(platos.transform);
        plato04.transform.SetParent(platos.transform);

        Turning();
        Debug.Log("El jugador con el turno es: " + whosTurn);

        // ----------------------------
        // DESACTIVAR OBJETOS AL INICIO
        // ----------------------------

        btResolver.SetActive(false); 
        questionBox.SetActive(false); 

        // -----------------------
        // INICIAR EL PRIMER TURNO
        // -----------------------
        /*
        if(OrdenInicial.numTienda == "Tienda01")
        {
            whosTurn = OrdenInicial.playersOrder[0];
        }
        else if(OrdenInicial.numTienda == "Tienda02")
        {
            whosTurn = OrdenInicial.playersOrder[1];
        }
        else if(OrdenInicial.numTienda == "Tienda03")
        {
            whosTurn = OrdenInicial.playersOrder[2];
        }
        else if(OrdenInicial.numTienda == "Tienda04")
        {
            whosTurn = OrdenInicial.playersOrder[3];
        } */
    }

    // Update is called once per frame
    void FixedUpdate()
    {   

        if(repartoGanadores == true)
        {
            StartCoroutine(Reparto());
            //StartCoroutine(RepartoPuntos());
            repartoGanadores = false;
        }

        if(numQuestions == 0)
        {
            StartCoroutine(Despedida());
        }
        else if(numQuestions > 0)
        {
            // Si el producto ya ha sido seleccionado, y todos los jugadores han elegido respuesta, aparece el botón para resolver la pregunta
            if(productSelected == true)
            {
                if(qtplayer01.GetComponent<PlayerGeneralController>().pushed != "none" && qtplayer02.GetComponent<PlayerGeneralController>().pushed != "none" && qtplayer03.GetComponent<PlayerGeneralController>().pushed != "none" && qtplayer04.GetComponent<PlayerGeneralController>().pushed != "none")
                {
                    btResolver.SetActive(true);
                }
            } 

            if(cambioTurno == true)
            {
                if(whosTurn == OrdenInicial.playersOrder[0])
                {
                    whosTurn = OrdenInicial.playersOrder[1];
                    Turning();
                }
                else if(whosTurn == OrdenInicial.playersOrder[1])
                {
                    whosTurn = OrdenInicial.playersOrder[2];
                    Turning();
                }
                else if(whosTurn == OrdenInicial.playersOrder[2])
                {
                    whosTurn = OrdenInicial.playersOrder[3];
                    Turning();
                }
                else if(whosTurn == OrdenInicial.playersOrder[3])
                {
                    whosTurn = OrdenInicial.playersOrder[0];
                    Turning();
                }
                tendero.transform.GetChild(0).gameObject.SetActive(true);
                tendero.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>().text = "Siguiente cliente, ¿Qué deseas?";
                cambioTurno = false; 
            }
        }
    }

    private IEnumerator Reparto()
    {
        Debug.Log("El producto en juego es: " + Producto.ProductoTag);
        if(numAcertantes != 0)
        {
            yield return new WaitForSeconds(0.3f);
            if(GameObject.Find(whosTurn).GetComponent<PlayerStats>().aciertoPlayer == true)
            {   
                Debug.Log("El jugador con turno ha acertado y se lleva el producto");
                numAcertantes -= 1;
            }
            else
            {
                Debug.Log("El jugador con turno NO ha acertado y se queda sin producto");
            }
            leftovers = GameObject.FindGameObjectsWithTag(Producto.ProductoTag);
            Debug.Log("¿Cuantos productos quedan?: " + leftovers.Length);
            Debug.Log("¿Cuantos han acertado sin contar al jugador con turno?: " + numAcertantes);
            if(leftovers.Length > numAcertantes)
            {
            
                for(int i = 1; i <= numAcertantes; i++)
                {
                    yield return new WaitForSeconds(0.3f);
                    Destroy(GameObject.FindWithTag(Producto.ProductoTag));
                }
            
            }
            else if(leftovers.Length <= numAcertantes)
            {
            
                for(int i = 1; i <= leftovers.Length; i++)
                {
                    yield return new WaitForSeconds(0.3f);
                    Destroy(GameObject.FindWithTag(Producto.ProductoTag));
                }
            }
            if(GameObject.Find(whosTurn).GetComponent<PlayerStats>().aciertoPlayer == true)
            {
                numAcertantes += 1;
            }

           
        }
        StartCoroutine(RepartoPuntos());
        
    }


    private IEnumerator RepartoPuntos()
    {
        if(numAcertantes != 0)
        {
            Debug.Log("¿Cuantos han acertado en total?: " + numAcertantes);
            string acertante = whosTurn;
            int limitante;
            if(leftovers.Length >= numAcertantes && GameObject.Find(whosTurn).GetComponent<PlayerStats>().aciertoPlayer == true)
            {
                limitante = numAcertantes;
            }
            else if (leftovers.Length >= numAcertantes && GameObject.Find(whosTurn).GetComponent<PlayerStats>().aciertoPlayer == false)
            {
                limitante = numAcertantes;
            }
            else if (leftovers.Length < numAcertantes && GameObject.Find(acertante).GetComponent<PlayerStats>().aciertoPlayer == true)
            {
                limitante = leftovers.Length + 1;
            }
            else
            {
                limitante = leftovers.Length;
            }
            if(limitante == 0 && GameObject.Find(acertante).GetComponent<PlayerStats>().aciertoPlayer == true)
            {
                limitante++;
            }

            Debug.Log("Los puntos a repartir son: " + limitante);
            for(int i = 1; i <= limitante; i++)
            {
                Debug.Log("Jugador a puntuar: " + acertante);
                yield return new WaitForSeconds(0.1f);
                if(GameObject.Find(acertante).GetComponent<PlayerStats>().aciertoPlayer == true)
                {
                    if(acertante == "Player01")
                    {  
                        plato01.GetComponent<PlatoStats>().adicionPuntoPlatos = true;
                        Debug.Log("Player01 se llevó 1 punto");
                    }
                    else if(acertante == "Player02")
                    {
                        plato02.GetComponent<PlatoStats>().adicionPuntoPlatos = true;
                        Debug.Log("Player02 se llevó 1 punto");
                    }
                    else if(acertante == "Player03")
                    {
                        plato03.GetComponent<PlatoStats>().adicionPuntoPlatos = true;
                        Debug.Log("Player03 se llevó 1 punto");
                    }
                    else if(acertante == "Player04")
                    {
                        plato04.GetComponent<PlatoStats>().adicionPuntoPlatos = true;
                        Debug.Log("Player04 se llevó 1 punto");
                    }               
                } 
                else
                {
                    i -= 1;
                }

                yield return new WaitForSeconds(0.1f);

                if(acertante == OrdenInicial.playersOrder[0])
                {
                    acertante = OrdenInicial.playersOrder[1];
                }
                else if(acertante == OrdenInicial.playersOrder[1])
                {   
                    acertante = OrdenInicial.playersOrder[2];
                }
                else if(acertante == OrdenInicial.playersOrder[2])
                {
                    acertante = OrdenInicial.playersOrder[3];
                }
                else if(acertante == OrdenInicial.playersOrder[3])
                {
                    acertante = OrdenInicial.playersOrder[0];  
                }
                yield return new WaitForSeconds(0.1f);    
            }

        }
        
        yield return new WaitForSeconds(0.01f);
        cambioTurno = true;
        numQuestions -= 1;
        numAcertantes = 0;
    }

    public void OnMouseDown()
    {
        if(resuelto == false)
        {
            Debug.Log("Selección del jugador 1: " + qtplayer01.GetComponent<PlayerGeneralController>().pushed);
            Debug.Log("Selección del jugador 2: " + qtplayer02.GetComponent<PlayerGeneralController>().pushed);
            Debug.Log("Selección del jugador 3: " + qtplayer03.GetComponent<PlayerGeneralController>().pushed);
            Debug.Log("Selección del jugador 4: " + qtplayer04.GetComponent<PlayerGeneralController>().pushed);
            btResolver.transform.GetChild(0).GetComponent<Text>().text = "Continuar";
            
            // Comportamiento botones player 01
            if(player01.GetComponent<PlayerStats>().responsePlayer == true && player01.GetComponent<PlayerStats>().aciertoPlayer == true) 
            {
                qtplayer01.transform.GetChild(0).GetComponent<Image>().sprite = vRight;
            }
            else if(player01.GetComponent<PlayerStats>().responsePlayer == false && player01.GetComponent<PlayerStats>().aciertoPlayer == true) 
            {
                qtplayer01.transform.GetChild(1).GetComponent<Image>().sprite = xRight;
            }
            else if(player01.GetComponent<PlayerStats>().responsePlayer == true && player01.GetComponent<PlayerStats>().aciertoPlayer == false) 
            {
                qtplayer01.transform.GetChild(0).GetComponent<Image>().sprite = vWrong;
            }
            else if(player01.GetComponent<PlayerStats>().responsePlayer == false && player01.GetComponent<PlayerStats>().aciertoPlayer == false) 
            {
                qtplayer01.transform.GetChild(1).GetComponent<Image>().sprite = xWrong;
            }

            // Comportamiento botones player 02
            if(player02.GetComponent<PlayerStats>().responsePlayer == true && player02.GetComponent<PlayerStats>().aciertoPlayer == true) 
            {
                qtplayer02.transform.GetChild(0).GetComponent<Image>().sprite = vRight;
            }
            else if(player02.GetComponent<PlayerStats>().responsePlayer == false && player02.GetComponent<PlayerStats>().aciertoPlayer == true) 
            {
                qtplayer02.transform.GetChild(1).GetComponent<Image>().sprite = xRight;
            }
            else if(player02.GetComponent<PlayerStats>().responsePlayer == true && player02.GetComponent<PlayerStats>().aciertoPlayer == false) 
            {
                qtplayer02.transform.GetChild(0).GetComponent<Image>().sprite = vWrong;
            }
            else if(player02.GetComponent<PlayerStats>().responsePlayer == false && player02.GetComponent<PlayerStats>().aciertoPlayer == false) 
            {
                qtplayer02.transform.GetChild(1).GetComponent<Image>().sprite = xWrong;
            }

            // Comportamiento botones player 03
            if(player03.GetComponent<PlayerStats>().responsePlayer == true && player03.GetComponent<PlayerStats>().aciertoPlayer == true) 
            {
                qtplayer03.transform.GetChild(0).GetComponent<Image>().sprite = vRight;
            }
            else if(player03.GetComponent<PlayerStats>().responsePlayer == false && player03.GetComponent<PlayerStats>().aciertoPlayer == true) 
            {
                qtplayer03.transform.GetChild(1).GetComponent<Image>().sprite = xRight;
            }
            else if(player03.GetComponent<PlayerStats>().responsePlayer == true && player03.GetComponent<PlayerStats>().aciertoPlayer == false) 
            {
                qtplayer03.transform.GetChild(0).GetComponent<Image>().sprite = vWrong;
            }
            else if(player03.GetComponent<PlayerStats>().responsePlayer == false && player03.GetComponent<PlayerStats>().aciertoPlayer == false) 
            {
                qtplayer03.transform.GetChild(1).GetComponent<Image>().sprite = xWrong;
            }

            // Comportamiento botones player 04
            if(player04.GetComponent<PlayerStats>().responsePlayer == true && player04.GetComponent<PlayerStats>().aciertoPlayer == true) 
            {
                qtplayer04.transform.GetChild(0).GetComponent<Image>().sprite = vRight;
            }
            else if(player04.GetComponent<PlayerStats>().responsePlayer == false && player04.GetComponent<PlayerStats>().aciertoPlayer == true) 
            {
                qtplayer04.transform.GetChild(1).GetComponent<Image>().sprite = xRight;
            }
            else if(player04.GetComponent<PlayerStats>().responsePlayer == true && player04.GetComponent<PlayerStats>().aciertoPlayer == false) 
            {
                qtplayer04.transform.GetChild(0).GetComponent<Image>().sprite = vWrong;
            }
            else if(player04.GetComponent<PlayerStats>().responsePlayer == false && player04.GetComponent<PlayerStats>().aciertoPlayer == false) 
            {
                qtplayer04.transform.GetChild(1).GetComponent<Image>().sprite = xWrong;
            }

            // ¿El jugador con turno acertó?
            if(GameObject.Find(whosTurn).GetComponent<PlayerStats>().aciertoPlayer == true)
            {
                productoGanado = "yes";
            }
            else if(GameObject.Find(whosTurn).GetComponent<PlayerStats>().aciertoPlayer == false)
            {
                productoGanado = "no";
            }

            qtplayer01.GetComponent<PlayerGeneralController>().Resolver();
            qtplayer02.GetComponent<PlayerGeneralController>().Resolver();
            qtplayer03.GetComponent<PlayerGeneralController>().Resolver();
            qtplayer04.GetComponent<PlayerGeneralController>().Resolver();

            resuelto = true;
        }
        else if(resuelto == true)
        {
            qtplayer01.GetComponent<PlayerGeneralController>().RestartQuestionBox();
            qtplayer02.GetComponent<PlayerGeneralController>().RestartQuestionBox();
            qtplayer03.GetComponent<PlayerGeneralController>().RestartQuestionBox();
            qtplayer04.GetComponent<PlayerGeneralController>().RestartQuestionBox();
            btResolver.transform.GetChild(0).GetComponent<Text>().text = "Resolver";
            btResolver.SetActive(false);
            questionBox.SetActive(false);
            conteoAcertantes();
            resuelto = false;
            productSelected = false;
            GameObject.Find(Producto.productoEscogido).GetComponent<Producto>().enableMove = true;
        }
    }

    public void Turning()
    {
        if(whosTurn == "Player01")
        {
            turnSpin = true;
            player01s.playerSpinning = true;
            player02s.playerSpinning = false;
            player03s.playerSpinning = false;
            player04s.playerSpinning = false;
            //target.GetComponent<Transform>().position = new Vector3(231f, 630f, 0f);
            target.position = plato01.transform.position;
        }
        else if(whosTurn == "Player02")
        {
            turnSpin = true;
            player01s.playerSpinning = false;
            player02s.playerSpinning = true;
            player03s.playerSpinning = false;
            player04s.playerSpinning = false;
            //target.GetComponent<Transform>().position = new Vector3(231f, 450f, 0f);
            target.position = plato02.transform.position;
        }
        else if(whosTurn == "Player03")
        {
            turnSpin = true;
            player01s.playerSpinning = false;
            player02s.playerSpinning = false;
            player03s.playerSpinning = true;
            player04s.playerSpinning = false;
            //target.GetComponent<Transform>().position = new Vector3(231f, 270f, 0f);
            target.position = plato03.transform.position;
        }
        else if(whosTurn == "Player04")
        {
            turnSpin = true;
            player01s.playerSpinning = false;
            player02s.playerSpinning = false;
            player03s.playerSpinning = false;
            player04s.playerSpinning = true;
            //target.GetComponent<Transform>().position = new Vector3(231f, 90f, 0f);
            target.position = plato04.transform.position;
        }
    }

    private IEnumerator Despedida()
    {
        cambioTurno = false;
        tendero.transform.GetChild(0).gameObject.SetActive(true);
        tendero.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>().text = "Gracias por comprar aquí. ¡Hasta la próxima!";
        yield return new WaitForSeconds(3);
        if(OrdenInicial.numTienda == "Tienda01")
        {
            OrdenInicial.numTienda = "Tienda02";
            //Debug.Log(OrdenInicial.numTienda);
            GeneralController.productSelected = false;
            SceneManager.LoadScene("OutTiendas");
        }
        else if(OrdenInicial.numTienda == "Tienda02")
        {
            OrdenInicial.numTienda = "Tienda03";
            //Debug.Log(OrdenInicial.numTienda);
            GeneralController.productSelected = false;
            SceneManager.LoadScene("OutTiendas");
        }
        else if(OrdenInicial.numTienda == "Tienda03")
        {
            OrdenInicial.numTienda = "Tienda04";
            //Debug.Log(OrdenInicial.numTienda);
            GeneralController.productSelected = false;
            SceneManager.LoadScene("OutTiendas");
        }
        else if(OrdenInicial.numTienda == "Tienda04")
        {
            OrdenInicial.numTienda = "Terminado";
            //Debug.Log(OrdenInicial.numTienda);
            GeneralController.productSelected = false;
            SceneManager.LoadScene("OutTiendas");
        }
    }

    public void EmpezarGame()
    {
        SceneManager.LoadScene("OutTiendas");
    }
    /*
    public void conteoAcertantes()
    {
        if(player01.GetComponent<PlayerStats>().aciertoPlayer == true && whosTurn != "Player01")
        {
            numAcertantes += 1;
        }
        if(player02.GetComponent<PlayerStats>().aciertoPlayer == true && whosTurn != "Player02")
        {
            numAcertantes += 1;
        }
        if(player03.GetComponent<PlayerStats>().aciertoPlayer == true && whosTurn != "Player03")
        {
            numAcertantes += 1;
        }
        if(player04.GetComponent<PlayerStats>().aciertoPlayer == true && whosTurn != "Player04")
        {
            numAcertantes += 1;
        }
    }
    */

    public void conteoAcertantes()
    {
        if(player01.GetComponent<PlayerStats>().aciertoPlayer == true)
        {
            numAcertantes += 1;
        }
        if(player02.GetComponent<PlayerStats>().aciertoPlayer == true)
        {
            numAcertantes += 1;
        }
        if(player03.GetComponent<PlayerStats>().aciertoPlayer == true)
        {
            numAcertantes += 1;
        }
        if(player04.GetComponent<PlayerStats>().aciertoPlayer == true)
        {
            numAcertantes += 1;
        }
    }

}
