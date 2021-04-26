using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Concurso2 : MonoBehaviour
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
    public bool unAcierto = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //Tenemos todos los datos en estas variables
        datosConcurso = new IniciarTienda();
            
        player01 = GameObject.Find("Player01");
        player02 = GameObject.Find("Player02");
        player03 = GameObject.Find("Player03");
        player04 = GameObject.Find("Player04");
        plato01 = GameObject.Find("Plato01");
        plato02 = GameObject.Find("Plato02");
        plato03 = GameObject.Find("Plato03");
        plato04 = GameObject.Find("Plato04");
    
        datosTipoAlimentos = Concurso.datosTipoAlimentos;
        datosAlimentos = Concurso.datosAlimentos;
        datosPreguntas = Concurso.datosPreguntas;
        datosRespuestas = Concurso.datosRespuestas;
        puntacionPlayer1 = Concurso.puntacionPlayer1;
        puntacionPlayer2 = Concurso.puntacionPlayer2;
        puntacionPlayer3 = Concurso.puntacionPlayer3;
        puntacionPlayer4 = Concurso.puntacionPlayer4;
        
        //Cambiamos los platos de Harvard
        plato01.GetComponent<PlatoStats>().RepintarPlatos(mostrarAlimentosConseguidos(1));
        plato02.GetComponent<PlatoStats>().RepintarPlatos(mostrarAlimentosConseguidos(2));
        plato03.GetComponent<PlatoStats>().RepintarPlatos(mostrarAlimentosConseguidos(3));
        plato04.GetComponent<PlatoStats>().RepintarPlatos(mostrarAlimentosConseguidos(4));

        //Repintar jugadores preguntas
        RepintarOrdenJugadoresPreguntas();
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
        unAcierto = false;
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
            string iTurnoActual = GeneralController.whosTurn == "Player01" ? "Player01" : GeneralController.whosTurn == "Player02" ? "Player02" :
            GeneralController.whosTurn == "Player03" ? "Player03" : "Player04";
            for(var i=1; i<=4; i++)
            {
                //PLAYER 1
                if(player01.GetComponent<PlayerStats>().responsePlayer==true && response && iTurnoActual=="Player01")
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
                        unAcierto = true;
                    }
                    //Cambiamos la imagen del acierto
                    Sprite mySprite = Resources.Load<Sprite>("Personajes/win_interna");
                    GeneralController.qtplayer01.GetComponent<Image>().sprite = mySprite;
                }
                else if(player01.GetComponent<PlayerStats>().responsePlayer==false && !response && iTurnoActual=="Player01")
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
                        unAcierto = true;
                    }
                    //Cambiamos la imagen del acierto
                    Sprite mySprite = Resources.Load<Sprite>("Personajes/win_interna");
                    GeneralController.qtplayer01.GetComponent<Image>().sprite = mySprite;
                }
                else if(iTurnoActual=="Player01")
                {
                    //No ha acertado da igual turno y cantidad de alimentos
                    player01.GetComponent<PlayerStats>().aciertoPlayer = false;  
                }

                //-------------------------------
                //PLAYER 2
                if(player02.GetComponent<PlayerStats>().responsePlayer==true && response && iTurnoActual=="Player02")
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
                        unAcierto = true;
                    }
                    //Cambiamos la imagen del acierto
                    Sprite mySprite = Resources.Load<Sprite>("Personajes/win_rubio");
                    GeneralController.qtplayer02.GetComponent<Image>().sprite = mySprite;
                }
                else if(player02.GetComponent<PlayerStats>().responsePlayer==false && !response && iTurnoActual=="Player02")
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
                        unAcierto = true;
                    }
                    //Cambiamos la imagen del acierto
                    Sprite mySprite = Resources.Load<Sprite>("Personajes/win_rubio");
                    GeneralController.qtplayer02.GetComponent<Image>().sprite = mySprite;
                }
                else if(iTurnoActual=="Player02")
                {
                    //No ha acertado da igual turno y cantidad de alimentos
                    player02.GetComponent<PlayerStats>().aciertoPlayer = false;  
                }

                //-------------------------------
                //PLAYER 3
                if(player03.GetComponent<PlayerStats>().responsePlayer==true && response && iTurnoActual=="Player03")
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
                        unAcierto = true;
                    }
                    //Cambiamos la imagen del acierto
                    Sprite mySprite = Resources.Load<Sprite>("Personajes/win_guapilla");
                    GeneralController.qtplayer03.GetComponent<Image>().sprite = mySprite;
                }
                else if(player03.GetComponent<PlayerStats>().responsePlayer==false && !response && iTurnoActual=="Player03")
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
                        unAcierto = true;
                    }
                    //Cambiamos la imagen del acierto
                    Sprite mySprite = Resources.Load<Sprite>("Personajes/win_guapilla");
                    GeneralController.qtplayer03.GetComponent<Image>().sprite = mySprite;
                }
                else if(iTurnoActual=="Player03")
                {
                    //No ha acertado da igual turno y cantidad de alimentos
                    player03.GetComponent<PlayerStats>().aciertoPlayer = false;
                }

                //-------------------------------
                //PLAYER 4
                if(player04.GetComponent<PlayerStats>().responsePlayer==true && response && iTurnoActual=="Player04")
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
                        unAcierto = true;
                    }
                    //Cambiamos la imagen del acierto
                    Sprite mySprite = Resources.Load<Sprite>("Personajes/win_modernillo");
                    GeneralController.qtplayer04.GetComponent<Image>().sprite = mySprite;
                }
                else if(player04.GetComponent<PlayerStats>().responsePlayer==false && !response && iTurnoActual=="Player04")
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
                        unAcierto = true;
                    }
                    //Cambiamos la imagen del acierto
                    Sprite mySprite = Resources.Load<Sprite>("Personajes/win_modernillo");
                    GeneralController.qtplayer04.GetComponent<Image>().sprite = mySprite;
                }
                else if(iTurnoActual=="Player04")
                {
                    //No ha acertado da igual turno y cantidad de alimentos
                    player04.GetComponent<PlayerStats>().aciertoPlayer = false;
                }

                if(iTurnoActual == OrdenInicial.playersOrder[0])
                {
                    iTurnoActual = OrdenInicial.playersOrder[1];
                }
                else if(iTurnoActual == OrdenInicial.playersOrder[1])
                {
                    iTurnoActual = OrdenInicial.playersOrder[2];
                }
                else if(iTurnoActual == OrdenInicial.playersOrder[2])
                {
                    iTurnoActual = OrdenInicial.playersOrder[3];
                }
                else if(iTurnoActual == OrdenInicial.playersOrder[3])
                {
                    iTurnoActual = OrdenInicial.playersOrder[0];
                }
            }
            
            if(unAcierto == false) 
            {
                datosAlimentos.Where(p=>p.ID==ProductoActual).First().Unidades -=1;
            }
        }
    }

    //Muestra los alimentos conseguidos por jugador.
    public List<Respuestas> mostrarAlimentosConseguidos(int iPlayer)
    {
        return datosRespuestas?.Where(pl=>pl.Player==iPlayer)?.ToList();
    }

    private void RepintarOrdenJugadoresPreguntas()
    {
        Vector3 temp;
        //Pintado imagenes orden inicial
        for (int i = 0; i < OrdenInicial.playersOrder.Count ; i++)
        {
            switch(OrdenInicial.playersOrder[i])
            {
                case "Player01":
                    switch(i)
                    {
                        case 0:
                        temp = new Vector3(GeneralController.qtplayer01.transform.position.x+600, GeneralController.qtplayer01.transform.position.y, 0.0f);
                        GeneralController.qtplayer01.transform.position = temp;
                        break;
                        case 1:
                        //Posicion inicial
                        break;
                        case 2:
                        temp = new Vector3(GeneralController.qtplayer01.transform.position.x+200, GeneralController.qtplayer01.transform.position.y, 0.0f);
                        GeneralController.qtplayer01.transform.position = temp;
                        break;
                        case 3:
                        temp = new Vector3(GeneralController.qtplayer01.transform.position.x+400, GeneralController.qtplayer01.transform.position.y, 0.0f);
                        GeneralController.qtplayer01.transform.position = temp;
                        break;
                    }
                    break;
                case "Player02":
                    switch(i)
                    {
                        case 0:
                        temp = new Vector3(GeneralController.qtplayer02.transform.position.x+400, GeneralController.qtplayer02.transform.position.y, 0.0f);
                        GeneralController.qtplayer02.transform.position = temp;
                        break;
                        case 1:
                        temp = new Vector3(GeneralController.qtplayer02.transform.position.x-200, GeneralController.qtplayer02.transform.position.y, 0.0f);
                        GeneralController.qtplayer02.transform.position = temp;
                        break;
                        case 2:
                        //Posicion inicial
                        break;
                        case 3:
                        temp = new Vector3(GeneralController.qtplayer02.transform.position.x+200, GeneralController.qtplayer02.transform.position.y, 0.0f);
                        GeneralController.qtplayer02.transform.position = temp;
                        break;
                    }
                    break;
                case "Player03":
                    switch(i)
                    {
                        case 0:
                        temp = new Vector3(GeneralController.qtplayer03.transform.position.x+200, GeneralController.qtplayer03.transform.position.y, 0.0f);
                        GeneralController.qtplayer03.transform.position = temp;
                        break;
                        case 1:
                        temp = new Vector3(GeneralController.qtplayer03.transform.position.x-400, GeneralController.qtplayer03.transform.position.y, 0.0f);
                        GeneralController.qtplayer03.transform.position = temp;
                        break;
                        case 2:
                        temp = new Vector3(GeneralController.qtplayer03.transform.position.x-200, GeneralController.qtplayer03.transform.position.y, 0.0f);
                        GeneralController.qtplayer03.transform.position = temp;
                        break;
                        case 3:
                        //posición inicial
                        break;
                    }
                    break;
                case "Player04":
                    switch(i)
                    {
                        case 0:
                        //posición inicial
                        break;
                        case 1:
                        temp = new Vector3(GeneralController.qtplayer04.transform.position.x-600, GeneralController.qtplayer04.transform.position.y, 0.0f);
                        GeneralController.qtplayer04.transform.position = temp;
                        break;
                        case 2:
                        temp = new Vector3(GeneralController.qtplayer04.transform.position.x-400, GeneralController.qtplayer04.transform.position.y, 0.0f);
                        GeneralController.qtplayer04.transform.position = temp;
                        break;
                        case 3:
                        temp = new Vector3(GeneralController.qtplayer04.transform.position.x-200, GeneralController.qtplayer04.transform.position.y, 0.0f);
                        GeneralController.qtplayer04.transform.position = temp;
                        break;
                    }
                    break;
            }
        }
    }

}
