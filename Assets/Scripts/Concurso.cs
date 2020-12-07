using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Concurso : MonoBehaviour
{
    public static IniciarTienda datosConcurso;
    public static List<TipoAlimento> datosTipoAlimentos;
    public static List<Alimento> datosAlimentos;
    public static List<Preguntas> datosPreguntas;
    public static List<Respuestas> datosRespuestas;
    public static List<Respuestas> datosRecetas;
    public static int ProductoActual;
    public static int PreguntaActualID;
    public static string TextActual;
    public int playerActive;
    public GameObject panel;
    public GameObject[] inactiveChildrem;
    public GameObject questionText;
    public static int puntacionPlayer1, puntacionPlayer2, puntacionPlayer3, puntacionPlayer4;
    public static bool aciertopl01, aciertopl02, aciertopl03, aciertopl04;
    public GameObject player01, player02, player03, player04;
    public GameObject plato01, plato02, plato03, plato04;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //Tenemos todos los datos en estas variables
        //datosConcurso = new IniciarTienda();
        datosConcurso = new IniciarTienda();
            
        player01 = GameObject.Find("Player01");
        player02 = GameObject.Find("Player02");
        player03 = GameObject.Find("Player03");
        player04 = GameObject.Find("Player04");
        plato01 = GameObject.Find("Plato01");
        plato02 = GameObject.Find("Plato02");
        plato03 = GameObject.Find("Plato03");
        plato04 = GameObject.Find("Plato04");
    
        datosTipoAlimentos = datosConcurso.RellenarCategorias();
        datosAlimentos = datosConcurso.RellenarAlimentos();
        datosPreguntas = datosConcurso.RellenarPreguntas();
        datosRespuestas = new List<Respuestas>();
        puntacionPlayer1 = 0;
        puntacionPlayer2 = 0;
        puntacionPlayer3 = 0;
        puntacionPlayer4 = 0;
        
    }

    public void getTextPregunta(int iID)
    {
        //Los almacenamos en una variable global porque al estar inactivos no los podemos usar
        //desde GetComponent.
        PreguntaActualID = datosPreguntas.Where(p=>p.ID==iID).First().ID;
        TextActual = datosPreguntas.Where(p=>p.ID==PreguntaActualID).First().Pregunta;
        GeneralController.questionBox.SetActive(true);
        GameObject.Find("QuestionText").GetComponent<Text>().text = TextActual;
        GeneralController.questionBox.SetActive(false);

    }

    public void ActualProduct(int pID)
    {
        ProductoActual = datosAlimentos.Where(p=>p.ID==pID).First().ID;
    }

    public void TratarRespuestas()
    {
        //En datosRespuestas tenemos todas las respuestas correctas de los jugadores.
        if(GeneralController.resuelto == false)
        {
            bool response = datosPreguntas.Where(p=>p.ID==PreguntaActualID).First().Respuesta;
            int cantidadProducto = datosAlimentos.Where(p=>p.ID==ProductoActual).First().Unidades;
            int puntuacionProducto = datosAlimentos.Where(p=>p.ID==ProductoActual).First().Puntuacion;
            int tipoAlimento = datosAlimentos.Where(p=>p.ID==ProductoActual).First().IDTipoAlimento;

            //Tenemos la respuesta correcta.
            //Vemos las respuestas de los usuarios.
            // toman los GameObject de los botones Verdadero y Falso de cada player
            
            player01.GetComponent<PlayerStats>().responsePlayer = GeneralController.qtplayer01.GetComponent<PlayerGeneralController>().pushed == "V" ? true : false;
            player02.GetComponent<PlayerStats>().responsePlayer = GeneralController.qtplayer02.GetComponent<PlayerGeneralController>().pushed == "V" ? true : false;
            player03.GetComponent<PlayerStats>().responsePlayer = GeneralController.qtplayer03.GetComponent<PlayerGeneralController>().pushed == "V" ? true : false;
            player04.GetComponent<PlayerStats>().responsePlayer = GeneralController.qtplayer04.GetComponent<PlayerGeneralController>().pushed == "V" ? true : false;
            
            GeneralController.unidadesProducto = cantidadProducto;

            /* Entre este parentesis comentado esta todo lo del procesado de la respuesta que hiciste tu, 
            con las variables que tu habias creado "responsePlayer1-4" 
            Yo he creado un script llamado PlayerStats que simplemente contiene las variables
            responsePlayer, aciertoPlayer y puntuacionPlayer. Puse este script en cada GameObject Player01-04
            de modo que se guardan estos tres valores. Creo que así es más facil, aunque más largo, a la hora de referirse a ellos
            en otros scripts.*/
            //-------------------------------
             int iTurnoActual = GeneralController.whosTurn == "Player01" ? 1 : GeneralController.whosTurn == "Player02" ? 2 :
             GeneralController.whosTurn == "Player03" ? 3 : 4;
            for(var i=1; i<=4; i++)
            {
                //PLAYER 1
                if(player01.GetComponent<PlayerStats>().responsePlayer==true && response && iTurnoActual==1)
                {
                    //JUGADOR1 Activo y su respuesta y la respuesta son TRUE
                    //Coge el producto si o si
                    player01.GetComponent<PlayerStats>().aciertoPlayer = true;
                    player01.GetComponent<PlayerStats>().puntuacionPlayer += puntuacionProducto;
                    plato01.GetComponent<PlatoStats>().tipoAlimento = tipoAlimento;
                    if (cantidadProducto>=1)
                    {
                        Respuestas respuesta = new Respuestas()
                        {
                            Player = 1,
                            Alimento = datosAlimentos.Where(p=>p.ID==ProductoActual).First(),
                            Pregunta = datosPreguntas.Where(p=>p.IDAlimento==ProductoActual).First(),
                            Acertada = true
                        };
                        //Quitamos uno en los restantes
                        datosAlimentos.Where(p=>p.ID==ProductoActual).First().Unidades -=1;
                        cantidadProducto--;
                        datosRespuestas.Add(respuesta);
                    }
                }
                else if(player01.GetComponent<PlayerStats>().responsePlayer==false && !response && iTurnoActual==1)
                {
                    //JUGADOR1 Activo y su respuesta y la respuesta son FALSE
                    //Coge el producto si o si
                    player01.GetComponent<PlayerStats>().aciertoPlayer = true;
                    player01.GetComponent<PlayerStats>().puntuacionPlayer += puntuacionProducto;
                    plato01.GetComponent<PlatoStats>().tipoAlimento = tipoAlimento;
                    if (cantidadProducto>=1)
                    {
                        Respuestas respuesta = new Respuestas()
                        {
                            Player = 1,
                            Alimento = datosAlimentos.Where(p=>p.ID==ProductoActual).First(),
                            Pregunta = datosPreguntas.Where(p=>p.IDAlimento==ProductoActual).First(),
                            Acertada = true
                        };
                        //Quitamos uno en los restantes productos
                        datosAlimentos.Where(p=>p.ID==ProductoActual).First().Unidades -=1;
                        cantidadProducto--;
                        datosRespuestas.Add(respuesta);
                    }
                }
                else if(iTurnoActual==1)
                {
                    player01.GetComponent<PlayerStats>().aciertoPlayer = false;  
                }

                //-------------------------------
                //PLAYER 2
                if(player02.GetComponent<PlayerStats>().responsePlayer==true && response && iTurnoActual==2)
                {
                    //JUGADOR1 Activo y su respuesta y la respuesta son TRUE
                    //Coge el producto si o si
                    player02.GetComponent<PlayerStats>().aciertoPlayer = true;
                    player02.GetComponent<PlayerStats>().puntuacionPlayer += puntuacionProducto;
                    plato02.GetComponent<PlatoStats>().tipoAlimento = tipoAlimento;
                    if (cantidadProducto>=1)
                    {
                        Respuestas respuesta = new Respuestas()
                        {
                            Player = 2,
                            Alimento = datosAlimentos.Where(p=>p.ID==ProductoActual).First(),
                            Pregunta = datosPreguntas.Where(p=>p.IDAlimento==ProductoActual).First(),
                            Acertada = true
                        };
                        //Quitamos uno en los restantes productos
                        datosAlimentos.Where(p=>p.ID==ProductoActual).First().Unidades -=1;
                        cantidadProducto--;
                        datosRespuestas.Add(respuesta);
                    }
                }
                else if(player02.GetComponent<PlayerStats>().responsePlayer==false && !response && iTurnoActual==2)
                {
                    //JUGADOR1 Activo y su respuesta y la respuesta son FALSE
                    //Coge el producto si o si
                    player02.GetComponent<PlayerStats>().aciertoPlayer = true;
                    player02.GetComponent<PlayerStats>().puntuacionPlayer += puntuacionProducto;
                    plato02.GetComponent<PlatoStats>().tipoAlimento = tipoAlimento;
                    if (cantidadProducto>=1)
                    {
                        Respuestas respuesta = new Respuestas()
                        {
                            Player = 2,
                            Alimento = datosAlimentos.Where(p=>p.ID==ProductoActual).First(),
                            Pregunta = datosPreguntas.Where(p=>p.IDAlimento==ProductoActual).First(),
                            Acertada = true
                        };
                        //Quitamos uno en los restantes productos
                        datosAlimentos.Where(p=>p.ID==ProductoActual).First().Unidades -=1;
                        cantidadProducto--;
                        datosRespuestas.Add(respuesta);
                    }

                }
                else if(iTurnoActual==2)
                {
                    player02.GetComponent<PlayerStats>().aciertoPlayer = false;  
                }

                //-------------------------------
                //PLAYER 3
                if(player03.GetComponent<PlayerStats>().responsePlayer==true && response && iTurnoActual==3)
                {
                    //JUGADOR1 Activo y su respuesta y la respuesta son TRUE
                    //Coge el producto si o si
                    player03.GetComponent<PlayerStats>().aciertoPlayer = true;
                    player03.GetComponent<PlayerStats>().puntuacionPlayer += puntuacionProducto;
                    plato03.GetComponent<PlatoStats>().tipoAlimento = tipoAlimento;
                    if (cantidadProducto>=1)
                    {
                        Respuestas respuesta = new Respuestas()
                        {
                            Player = 3,
                            Alimento = datosAlimentos.Where(p=>p.ID==ProductoActual).First(),
                            Pregunta = datosPreguntas.Where(p=>p.IDAlimento==ProductoActual).First(),
                            Acertada = true
                        };
                        //Quitamos uno en los restantes productos
                        datosAlimentos.Where(p=>p.ID==ProductoActual).First().Unidades -=1;
                        cantidadProducto--;
                        datosRespuestas.Add(respuesta);
                    }
                }
                else if(player03.GetComponent<PlayerStats>().responsePlayer==false && !response && iTurnoActual==3)
                {
                    //JUGADOR1 Activo y su respuesta y la respuesta son FALSE
                    //Coge el producto si o si
                    player03.GetComponent<PlayerStats>().aciertoPlayer = true;
                    player03.GetComponent<PlayerStats>().puntuacionPlayer += puntuacionProducto;
                    plato03.GetComponent<PlatoStats>().tipoAlimento = tipoAlimento;
                    if (cantidadProducto>=1)
                    {
                        Respuestas respuesta = new Respuestas()
                        {
                            Player = 3,
                            Alimento = datosAlimentos.Where(p=>p.ID==ProductoActual).First(),
                            Pregunta = datosPreguntas.Where(p=>p.IDAlimento==ProductoActual).First(),
                            Acertada = true
                        };
                        //Quitamos uno en los restantes productos
                        datosAlimentos.Where(p=>p.ID==ProductoActual).First().Unidades -=1;
                        cantidadProducto--;
                        datosRespuestas.Add(respuesta);
                    }
                }
                else if(iTurnoActual==3)
                {
                    //No ha acertado da igual turno y cantidad de alimentos
                    player03.GetComponent<PlayerStats>().aciertoPlayer = false;
                }

                //-------------------------------
                //PLAYER 4
                if(player04.GetComponent<PlayerStats>().responsePlayer==true && response && iTurnoActual==4)
                {
                    //JUGADOR1 Activo y su respuesta y la respuesta son TRUE
                    //Coge el producto si o si
                    player04.GetComponent<PlayerStats>().aciertoPlayer = true;
                    player04.GetComponent<PlayerStats>().puntuacionPlayer += puntuacionProducto;
                    plato04.GetComponent<PlatoStats>().tipoAlimento = tipoAlimento;
                    if (cantidadProducto>=1)
                    {
                        Respuestas respuesta = new Respuestas()
                        {
                            Player = 4,
                            Alimento = datosAlimentos.Where(p=>p.ID==ProductoActual).First(),
                            Pregunta = datosPreguntas.Where(p=>p.IDAlimento==ProductoActual).First(),
                            Acertada = true
                        };
                        //Quitamos uno en los restantes productos
                        datosAlimentos.Where(p=>p.ID==ProductoActual).First().Unidades -=1;
                        cantidadProducto--;
                        datosRespuestas.Add(respuesta);
                    }
                }
                else if(player04.GetComponent<PlayerStats>().responsePlayer==false && !response && iTurnoActual==4)
                {
                    //JUGADOR1 Activo y su respuesta y la respuesta son FALSE
                    //Coge el producto si o si
                    player04.GetComponent<PlayerStats>().aciertoPlayer = true;    
                    player04.GetComponent<PlayerStats>().puntuacionPlayer += puntuacionProducto;   
                    plato04.GetComponent<PlatoStats>().tipoAlimento = tipoAlimento;
                    if (cantidadProducto>=1)
                    {
                        Respuestas respuesta = new Respuestas()
                        {
                            Player = 4,
                            Alimento = datosAlimentos.Where(p=>p.ID==ProductoActual).First(),
                            Pregunta = datosPreguntas.Where(p=>p.IDAlimento==ProductoActual).First(),
                            Acertada = true
                        };
                        //Quitamos uno en los restantes productos
                        datosAlimentos.Where(p=>p.ID==ProductoActual).First().Unidades -=1;
                        cantidadProducto--;
                        datosRespuestas.Add(respuesta);
                    }
                }
                else if(iTurnoActual==4)
                {
                    //No ha acertado da igual turno y cantidad de alimentos
                    player04.GetComponent<PlayerStats>().aciertoPlayer = false;
                }

                //Incrementamos el iTurnoActual;
                if (iTurnoActual==4)
                {
                    iTurnoActual=1;
                }
                else
                {
                    iTurnoActual++;
                }
            }
            
        }
    }

    //Muestra los alimentos conseguidos por jugador.
    public List<Respuestas> mostrarAlimentosConseguidos(int iPlayer)
    {
        return datosRespuestas?.Where(pl=>pl.Player==iPlayer)?.ToList();
    }

}
