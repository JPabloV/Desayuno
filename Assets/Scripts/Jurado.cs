using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;

public class Jurado : MonoBehaviour
{
    //private readonly string rutaSprite = @"Sprites/Frutas/";
    public static IniciarTienda datosConcurso;
    public static List<TipoAlimento> datosTipoAlimentos;
    public static List<Alimento> datosAlimentos;
    public static List<Preguntas> datosPreguntas;
    public static List<Respuestas> datosRespuestas;
    public static List<Respuestas> datosRecetas;
    public static List<Puntuacion> datosPuntuacionFinal;
    public static int puntacionPlayer1, puntacionPlayer2, puntacionPlayer3, puntacionPlayer4;
    public GameObject player01, player02, player03, player04;
    public GameObject plato01, plato02, plato03, plato04;
    public GameObject platos;
    public GameObject juez;
    public static string whosTurn;
    public static GameObject btListo;
    private GameObject recetaBox, andaluzBox;   
    public static List<string> productsInPlate;
    public static List<Alimento> AlimentosAndaluces, AlimentosAndalucesReceta;
    private float estProd1x, estProd2x, estProd3x, estProd4x, estProd5x, estProd6x, estProd7x, estProd8x, estProd9x, estProd10x, estProd11x, estProd12x, estProd13x, estProd14x, estProd15x, estProd16x;
    private float estProd1y, estProd2y, estProd3y, estProd4y, estProd5y, estProd6y, estProd7y, estProd8y, estProd9y, estProd10y, estProd11y, estProd12y, estProd13y, estProd14y, estProd15y, estProd16y;

    // Start is called before the first frame update
 void Start()
    {
        estProd1x = GameObject.Find("EstProd1").GetComponent<Transform>().transform.position.x;
        estProd2x = GameObject.Find("EstProd2").GetComponent<Transform>().transform.position.x;
        estProd3x = GameObject.Find("EstProd3").GetComponent<Transform>().transform.position.x;
        estProd4x = GameObject.Find("EstProd4").GetComponent<Transform>().transform.position.x;
        estProd5x = GameObject.Find("EstProd5").GetComponent<Transform>().transform.position.x;
        estProd6x = GameObject.Find("EstProd6").GetComponent<Transform>().transform.position.x;
        estProd7x = GameObject.Find("EstProd7").GetComponent<Transform>().transform.position.x;
        estProd8x = GameObject.Find("EstProd8").GetComponent<Transform>().transform.position.x;
        estProd9x = GameObject.Find("EstProd9").GetComponent<Transform>().transform.position.x;
        estProd10x = GameObject.Find("EstProd10").GetComponent<Transform>().transform.position.x;
        estProd11x = GameObject.Find("EstProd11").GetComponent<Transform>().transform.position.x;
        estProd12x = GameObject.Find("EstProd12").GetComponent<Transform>().transform.position.x;
        estProd13x = GameObject.Find("EstProd13").GetComponent<Transform>().transform.position.x;
        estProd14x = GameObject.Find("EstProd14").GetComponent<Transform>().transform.position.x;
        estProd15x = GameObject.Find("EstProd15").GetComponent<Transform>().transform.position.x;
        estProd16x = GameObject.Find("EstProd16").GetComponent<Transform>().transform.position.x;

        estProd1y = GameObject.Find("EstProd1").GetComponent<Transform>().transform.position.y;
        estProd2y = GameObject.Find("EstProd2").GetComponent<Transform>().transform.position.y;
        estProd3y = GameObject.Find("EstProd3").GetComponent<Transform>().transform.position.y;
        estProd4y = GameObject.Find("EstProd4").GetComponent<Transform>().transform.position.y;
        estProd5y = GameObject.Find("EstProd5").GetComponent<Transform>().transform.position.y;
        estProd6y = GameObject.Find("EstProd6").GetComponent<Transform>().transform.position.y;
        estProd7y = GameObject.Find("EstProd7").GetComponent<Transform>().transform.position.y;
        estProd8y = GameObject.Find("EstProd8").GetComponent<Transform>().transform.position.y;
        estProd9y = GameObject.Find("EstProd9").GetComponent<Transform>().transform.position.y;
        estProd10y = GameObject.Find("EstProd10").GetComponent<Transform>().transform.position.y;
        estProd11y = GameObject.Find("EstProd11").GetComponent<Transform>().transform.position.y;
        estProd12y = GameObject.Find("EstProd12").GetComponent<Transform>().transform.position.y;
        estProd13y = GameObject.Find("EstProd13").GetComponent<Transform>().transform.position.y;
        estProd14y = GameObject.Find("EstProd14").GetComponent<Transform>().transform.position.y;
        estProd15y = GameObject.Find("EstProd15").GetComponent<Transform>().transform.position.y;
        estProd16y = GameObject.Find("EstProd16").GetComponent<Transform>().transform.position.y;
        
        //Tenemos todos los datos en estas variables
        datosConcurso = new IniciarTienda();
        productsInPlate = new List<string>();
        datosPuntuacionFinal = new List<Puntuacion>();
        
        //-------------------
        // INSTANCIAR OBJETOS
        //-------------------
        datosRecetas = new List<Respuestas>();
        player01 = GameObject.Find("Player01");
        player02 = GameObject.Find("Player02");
        player03 = GameObject.Find("Player03");
        player04 = GameObject.Find("Player04");

        platos = GameObject.Find("Platos");        
        plato01 = GameObject.Find("Plato01");
        plato02 = GameObject.Find("Plato02");
        plato03 = GameObject.Find("Plato03");
        plato04 = GameObject.Find("Plato04");
    
        juez = GameObject.Find("Juez");

        btListo = GameObject.Find("btListo");
        btListo.SetActive(false);
        
        recetaBox = GameObject.Find("RecetaBox");
        recetaBox.SetActive(false);

        andaluzBox = GameObject.Find("AndaluzBox");
        andaluzBox.SetActive(false);

        //-------------------
        // ORDEN DE JUGADORES
        //-------------------
        
        // pone los platos como hijos de sus respectivos jugadores para que se posicionen con ellos
        plato01.transform.SetParent(player01.transform);
        plato02.transform.SetParent(player02.transform);
        plato03.transform.SetParent(player03.transform);
        plato04.transform.SetParent(player04.transform);
        
        // Ordena los jugadores según sus nombres, para que concuerden con las listas de productos
        player01.GetComponent<Transform>().transform.position = new Vector3(90f, 630f, 0f);
        player02.GetComponent<Transform>().transform.position = new Vector3(90f, 450f, 0f);
        player03.GetComponent<Transform>().transform.position = new Vector3(90f, 270f, 0f);
        player04.GetComponent<Transform>().transform.position = new Vector3(90f, 90f, 0f);

        // vuelve a poner los platos como hijos de "platos". El gameObject "platos" es necesario para que al sacarlos de los players se posicionen bien en la jerarquía de capas
        plato01.transform.SetParent(platos.transform);
        plato02.transform.SetParent(platos.transform);
        plato03.transform.SetParent(platos.transform);
        plato04.transform.SetParent(platos.transform);

        //---------------------
        // MENSAJE INICIAL JUEZ
        //---------------------

        juez.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>().text = "¡Veamos vuestros desayunos! Primer consursante, elige como máximo seis ingredientes.";

        //--------------------------
        // ESTABLECE LE PRIMER TURNO
        //--------------------------

        //whosTurn = (OrdenInicial.playersOrder==null || OrdenInicial.playersOrder.Count<1) ? "Player1" : OrdenInicial.playersOrder[0];
        whosTurn = "Player01";
        Turning();

        //----------------------------------
        // OBTENCIÓN DE DATOS DE LAS TIENDAS
        //----------------------------------
        datosTipoAlimentos = Concurso4.datosTipoAlimentos;
        datosAlimentos = Concurso4.datosAlimentos;
        datosPreguntas = Concurso4.datosPreguntas;
        datosRespuestas = Concurso4.datosRespuestas;
        puntacionPlayer1 = Concurso4.puntacionPlayer1;
        puntacionPlayer2 = Concurso4.puntacionPlayer2;
        puntacionPlayer3 = Concurso4.puntacionPlayer3;
        puntacionPlayer4 = Concurso4.puntacionPlayer4;
        if (Concurso.datosAlimentos!=null)
        {
            AlimentosAndaluces = Concurso.datosAlimentos.Where(a=>a.IsAndaluz==true).ToList();
            AlimentosAndalucesReceta = Concurso.datosAlimentos.Where(a=>a.IsAndaluz==true).ToList();
        }
        

        //----------------------------
        // CAMBIO DE PLATOS DE HARVARD
        //----------------------------
        plato01.GetComponent<PlatoStats>().RepintarPlatos(mostrarAlimentosConseguidos(1));
        plato02.GetComponent<PlatoStats>().RepintarPlatos(mostrarAlimentosConseguidos(2));
        plato03.GetComponent<PlatoStats>().RepintarPlatos(mostrarAlimentosConseguidos(3));
        plato04.GetComponent<PlatoStats>().RepintarPlatos(mostrarAlimentosConseguidos(4));

        //Pintamos los productos del player 1
        pintarProductos(1);
    }

    //Muestra los alimentos conseguidos por jugador.
    public List<Respuestas> mostrarAlimentosConseguidos(int iPlayer)
    {
        return datosRespuestas?.Where(pl=>pl.Player==iPlayer)?.ToList();
    }

    public void pintarProductos(int iPlayer)
    {
        //Ir recorriendo datosRespuestas del jugador y mostrar las imágenes.
        var respuestasAcertadasPorPlayer = mostrarAlimentosConseguidos(iPlayer);
        int contador=1;

        while(contador<=16)
        {
            FindInActiveObjectByName("EstProd"+contador).SetActive(true);
            contador++;
        }
        contador=1;
        if (respuestasAcertadasPorPlayer!=null && respuestasAcertadasPorPlayer.Count>0)
        {
            foreach(var alimento in respuestasAcertadasPorPlayer)
            {
                cambiarImagen("EstProd"+contador, alimento.Alimento.ImageSource);
                //GameObject.Find("EstProd1").GetComponent<RectTransform>().sizeDelta = new Vector2(600f, 300f);
                GameObject.Find("EstProd"+contador).GetComponent<ProductoReceta>().IDProducto = alimento.Alimento.ID;
                GameObject.Find("EstProd"+contador).GetComponent<ProductoReceta>().IDPlayer = iPlayer;
                contador++;
            }
        }
        else //Un jugador no ha acertado nada de nada, saliese este mensaje y se activase el botón de "listo"
        {
            juez.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>().text = "¡Vaya! Parece que no conseguiste ningún producto (pulsa <¡Listo!> para continuar)";
            btListo.SetActive(true);
        }
        while(contador<=16)
        {
            //Desactivamos el resto de alimentos.
            GameObject.Find("EstProd"+contador).SetActive(false);
            contador++;
        }

    }

    GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }

    GameObject[] FindInActiveObjectsByTag(string tag)
    {   
        List<GameObject> validTransforms = new List<GameObject>();
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].gameObject.CompareTag(tag))
                {
                    validTransforms.Add(objs[i].gameObject);
                }
            }
        }
        return validTransforms.ToArray();
    }

    public void cambiarImagen(string sNombreObject, string sNuevaImage)
    {
        try
        {
            Image imageCambiar;
            imageCambiar =  GameObject.Find(sNombreObject).GetComponent<Image>();
 
            // Sprite mySprite = Resources.Load<Sprite>(rutaSprite + sNuevaImage);
            Sprite mySprite = Resources.Load<Sprite>(sNuevaImage);
            imageCambiar.sprite = mySprite;

            imageCambiar.SetNativeSize(); // redimensiona la imagen con el height y el width del sprite que incluye

            // Este grupo de condicionales sirve para ajustar la escala de cada producto, para que se vean de un tamaño
            // más o menos adecuado, ya que alguos estan pintados con una resolución más grande que otros, y si la escala
            // es la misma salen muy descompensados. Aquí las reescalo a las escalas que había usado en las tiendas para
            // cada producto. Faltan los que aún no tenemos sprite, que por defecto se están reescalando en el "else"
                if(imageCambiar.sprite.name == "conservas" ||  imageCambiar.sprite.name == "sandia")
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
                else if(imageCambiar.sprite.name == "pollo" || imageCambiar.sprite.name == "filete" || 
                imageCambiar.sprite.name == "aceite de oliva" || imageCambiar.sprite.name == "rosquillas" || 
                imageCambiar.sprite.name == "arroz_stewart" || imageCambiar.sprite.name == "pasta" || 
                imageCambiar.sprite.name == "garbanzos" || imageCambiar.sprite.name == "galletas_0")
                {
                imageCambiar.GetComponent<Transform>().localScale = new Vector3(0.3f, 0.3f, 0.3f);
                } 
                else if (imageCambiar.sprite.name == "maiz" || imageCambiar.sprite.name == "croisant_0" ||
                imageCambiar.sprite.name == "mantequilla" || imageCambiar.sprite.name == "queso" || imageCambiar.sprite.name == "yogur")
                {
                    imageCambiar.GetComponent<Transform>().localScale = new Vector3(0.4f, 0.4f, 0.42f);
                }
                else if (imageCambiar.sprite.name == "almendras" || imageCambiar.sprite.name == "arandanos" || imageCambiar.sprite.name == "harina")
                {
                    imageCambiar.GetComponent<Transform>().localScale = new Vector3(0.6f, 0.6f, 0.6f);
                }
                else if (imageCambiar.sprite.name == "azucar" || imageCambiar.sprite.name == "miel")
                {
                    imageCambiar.GetComponent<Transform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
                }
                else if(imageCambiar.sprite.name == "mermelada")
                {
                    imageCambiar.GetComponent<Transform>().localScale = new Vector3(0.2f, 0.2f, 0.2f);
                }
                else if(imageCambiar.sprite.name == "jamon")
                {
                    imageCambiar.GetComponent<Transform>().localScale = new Vector3(0.15f, 0.18f, 0.2f);
                }
                else
                {
                    imageCambiar.GetComponent<Transform>().localScale = new Vector3(0.2f, 0.2f, 0.2f);
                }

                //Colocamos los producto más arriba
                float AltoImagen = imageCambiar.GetComponent<RectTransform>() .sizeDelta.y;
                if(AltoImagen>410 && !imageCambiar.sprite.name.Equals("huevo"))
                {
                    imageCambiar.GetComponent<Transform>().position = new Vector3(imageCambiar.GetComponent<Transform>().position.x, imageCambiar.GetComponent<Transform>().position.y + 24, imageCambiar.GetComponent<Transform>().position.z);
                }
                
        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
        }
        
     }

     //Funcion al clicar los productos pintados
    public static void AñadirProductoReceta(int iPlayer, int iIDProducto)
    {
        var productoReceta = datosRespuestas.Where(pl=>pl.Player==iPlayer).
            Where(al=>al.Alimento.ID==iIDProducto).First();
        datosRecetas.Add(productoReceta);

        Debug.Log("Num. productos para la receta." + datosRecetas.Count);

    }

    //Creamos la puntacion con los datos de las recetas por Jugador.
    public static List<Puntuacion> ObtenerPuntuacion()
    {
        //Sumatorio por productos
        int puntacionPlayerSum1 = datosRecetas.Where(pl=>pl.Player==1).ToList().
            Sum(al=>al.Alimento.Puntuacion);
        
        //Por variedad
        var puntacionPlayerTipos1 = datosRecetas.Where(pl=>pl.Player==1).ToList().
            GroupBy(al=>al.Alimento.IDTipoAlimento).Count();

        //Por Andaluces
        var puntacionPlayerAndaluz1 = datosRecetas.Where(pl=>pl.Player==1).
            Where(pl=>pl.Alimento.IsAndaluz==true).Count();

        var multiplicadorTipos = getMultiplicadorTipos(puntacionPlayerTipos1);

        int PuntuacionPlayer1 = (puntacionPlayerSum1*multiplicadorTipos) + (puntacionPlayerAndaluz1*3);

        datosPuntuacionFinal.Add(new 
        Puntuacion(){
            Player=1,
            PuntuacionFinal = PuntuacionPlayer1,
            Alimentos = datosRecetas.Where(pl=>pl.Player==1).Select(a=>a.Alimento).ToList()
        });

        //----------------
        // JUGADOR 2

        //Sumatorio por productos
        int puntacionPlayerSum2 = datosRecetas.Where(pl=>pl.Player==2).ToList().
            Sum(al=>al.Alimento.Puntuacion);
        
        //Por variedad
        var puntacionPlayerTipos2 = datosRecetas.Where(pl=>pl.Player==2).ToList().
            GroupBy(al=>al.Alimento.IDTipoAlimento).Count();

        //Por Andaluces
        var puntacionPlayerAndaluz2 = datosRecetas.Where(pl=>pl.Player==2).
            Where(pl=>pl.Alimento.IsAndaluz==true).Count();

        var multiplicadorTipos2 = getMultiplicadorTipos(puntacionPlayerTipos2);

        int PuntuacionPlayer2 = (puntacionPlayerSum2*multiplicadorTipos2) + (puntacionPlayerAndaluz2*3);

        datosPuntuacionFinal.Add(new 
        Puntuacion(){
            Player=2,
            PuntuacionFinal = PuntuacionPlayer2,
            Alimentos = datosRecetas.Where(pl=>pl.Player==2).Select(a=>a.Alimento).ToList()
        });

        //----------------
        // JUGADOR 3

        //Sumatorio por productos
        int puntacionPlayerSum3 = datosRecetas.Where(pl=>pl.Player==3).ToList().
            Sum(al=>al.Alimento.Puntuacion);
        
        //Por variedad
        var puntacionPlayerTipos3 = datosRecetas.Where(pl=>pl.Player==3).ToList().
            GroupBy(al=>al.Alimento.IDTipoAlimento).Count();

        //Por Andaluces
        var puntacionPlayerAndaluz3 = datosRecetas.Where(pl=>pl.Player==3).
            Where(pl=>pl.Alimento.IsAndaluz==true).Count();

        var multiplicadorTipos3 = getMultiplicadorTipos(puntacionPlayerTipos3);

        int PuntuacionPlayer3 = (puntacionPlayerSum3*multiplicadorTipos3) + (puntacionPlayerAndaluz3*3);

        datosPuntuacionFinal.Add(new 
        Puntuacion(){
            Player=3,
            PuntuacionFinal = PuntuacionPlayer3,
            Alimentos = datosRecetas.Where(pl=>pl.Player==3).Select(a=>a.Alimento).ToList()
        });

        //----------------
        // JUGADOR 4

        //Sumatorio por productos
        int puntacionPlayerSum4 = datosRecetas.Where(pl=>pl.Player==4).ToList().
            Sum(al=>al.Alimento.Puntuacion);
        
        //Por variedad
        var puntacionPlayerTipos4 = datosRecetas.Where(pl=>pl.Player==4).ToList().
            GroupBy(al=>al.Alimento.IDTipoAlimento).Count();

        //Por Andaluces
        var puntacionPlayerAndaluz4 = datosRecetas.Where(pl=>pl.Player==4).
            Where(pl=>pl.Alimento.IsAndaluz==true).Count();

        var multiplicadorTipos4 = getMultiplicadorTipos(puntacionPlayerTipos4);

        int PuntuacionPlayer4 = (puntacionPlayerSum4*multiplicadorTipos4) + (puntacionPlayerAndaluz4*3);

        datosPuntuacionFinal.Add(new 
        Puntuacion(){
            Player=4,
            PuntuacionFinal = PuntuacionPlayer4,
            Alimentos = datosRecetas.Where(pl=>pl.Player==4).Select(a=>a.Alimento).ToList()
        });

        return datosPuntuacionFinal;

    }

    private static int getMultiplicadorTipos(int iTipos)
    {
        if (iTipos>4)
        {
            return 6;
        }
        else if (iTipos>2 && iTipos<=4)
        {
            return 4;
        }
        else if (iTipos>0 && iTipos<=2)
        {
            return 2;
        }
        return 1;
    }

    //  Este método controla que jugador debe girar
    public void Turning()
    {
        if(whosTurn == "Player01")
        {
            GeneralController.turnSpin = true;
            player01.GetComponent<TurningPlayer>().playerSpinning = true;
            player02.GetComponent<TurningPlayer>().playerSpinning = false;
            player03.GetComponent<TurningPlayer>().playerSpinning = false;
            player04.GetComponent<TurningPlayer>().playerSpinning = false;
        }
        else if(whosTurn == "Player02")
        {
            GeneralController.turnSpin = true;
            player01.GetComponent<TurningPlayer>().playerSpinning = false;
            player02.GetComponent<TurningPlayer>().playerSpinning = true;
            player03.GetComponent<TurningPlayer>().playerSpinning = false;
            player04.GetComponent<TurningPlayer>().playerSpinning = false;
        }
        else if(whosTurn == "Player03")
        {
            GeneralController.turnSpin = true;
            player01.GetComponent<TurningPlayer>().playerSpinning = false;
            player02.GetComponent<TurningPlayer>().playerSpinning = false;
            player03.GetComponent<TurningPlayer>().playerSpinning = true;
            player04.GetComponent<TurningPlayer>().playerSpinning = false;
        }
        else if(whosTurn == "Player04")
        {
            GeneralController.turnSpin = true;
            player01.GetComponent<TurningPlayer>().playerSpinning = false;
            player02.GetComponent<TurningPlayer>().playerSpinning = false;
            player03.GetComponent<TurningPlayer>().playerSpinning = false;
            player04.GetComponent<TurningPlayer>().playerSpinning = true;
        }
    }
    // Este método se activa al pulsar el botón "Listo" (objeto btListo)
    public void GuardarReceta()
    {
        Alimento resul = null;
        GeneralController.turnSpin = false;
        btListo.SetActive(false);
        recetaBox.SetActive(true);
        //Controlamos quien tiene el turno
        var result = new List<Alimento>();
        int randomInt = UnityEngine.Random.Range(0, 13);
        int productAndaluzBorrar = 0;
        if(datosRespuestas!=null)
        {
            if(whosTurn == "Player01")
            {
                result = AlimentosAndalucesReceta.Where(pA => !datosRespuestas.Where(pl=>pl.Player==1).Any(pl => pl.Alimento.ID == pA.ID)).ToList();
            }
            else if(whosTurn == "Player02")
            {
                result = AlimentosAndalucesReceta.Where(pA => !datosRespuestas.Where(pl=>pl.Player==2).Any(pl => pl.Alimento.ID == pA.ID)).ToList();
            }
            else if(whosTurn == "Player03")
            {
                result = AlimentosAndalucesReceta.Where(pA => !datosRespuestas.Where(pl=>pl.Player==3).Any(pl => pl.Alimento.ID == pA.ID)).ToList();
            }
            else if(whosTurn == "Player04")
            {
                result = AlimentosAndalucesReceta.Where(pA => !datosRespuestas.Where(pl=>pl.Player==4).Any(pl => pl.Alimento.ID == pA.ID)).ToList();
            }
        }
        else
        {
            result = AlimentosAndalucesReceta;
        }
        
        try
        {
            productAndaluzBorrar = result[randomInt].ID;
            resul = result[randomInt];
        }
        catch
        {
            resul = result[0];
        }
        
        // GameObject.Find("RecetaText").GetComponent<Text>().text = @"Podrias haber añadido a tu lista de productos, " + resul.Nombre
        //                         + " que es otro producto andaluz por excelencia y haber aumentado tu puntación"; 
        GameObject.Find("RecetaText").GetComponent<Text>().text = @"¡Enhorabuena! Has elegido unos productos muy saludables, pero para mejorar tu desayuno te proponemos " + resul.Nombre.ToLower()
                                   + " que es otro producto andaluz y habrías aumentado tu puntación";       
        //Cambiamos la imagen.
        Sprite mySprite = Resources.Load<Sprite>(resul.ImageSource);                    
        Image imageReceta = GameObject.Find("ImageReceta").GetComponent<Image>();
        imageReceta.sprite = mySprite;
        imageReceta.SetNativeSize();
        if(imageReceta.sprite.name == "pan_1")
        {
            imageReceta.GetComponent<Transform>().localScale = new Vector3(0.12f, 0.12f, 0.12f);
        } 
        else if(imageReceta.sprite.name == "jamon")
        {
            imageReceta.GetComponent<Transform>().localScale = new Vector3(0.2f, 0.2f, 0.2f);
        } 
        else
        {
            imageReceta.GetComponent<Transform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }

        //Borramos el alimento Andaluz
        AlimentosAndalucesReceta.RemoveAll(a=>a.ID == productAndaluzBorrar);
        juez.transform.GetChild(0).gameObject.SetActive(false);

    }

    // Este método se activa al pulsar el botón "Continuar" (objeto btContinuar)
    public void SiguienteTurno()
    {
        
        juez.transform.GetChild(0).gameObject.SetActive(true);
        Reordenar();
        recetaBox.SetActive(false);
        ProductoReceta.iterante = 0;
        if(whosTurn == "Player01")
        {
            whosTurn = "Player02";
            Turning();
            juez.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>().text = "Segundo consursante, elige como máximo seis ingredientes.";
            pintarProductos(2);
        }
        else if(whosTurn == "Player02")
        {
            whosTurn = "Player03";
            Turning();
            juez.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>().text = "Tercer consursante, elige como máximo seis ingredientes.";
            pintarProductos(3);
        }
        else if(whosTurn == "Player03")
        {
            whosTurn = "Player04";
            Turning();
            juez.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>().text = "Cuarto consursante, elige como máximo seis ingredientes.";
            pintarProductos(4);
        }
        else if(whosTurn == "Player04")
        {
            GameObject[] allprod;
            juez.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>().text = "¡Gracias por participar! ¡Puntuemos las recetas!";
            // con este allprod y el foreach se desactivan todos los productos, para que no se vean los del último jugador una vez ha terminado
            allprod = GameObject.FindGameObjectsWithTag("EstProduct");
            foreach(GameObject prod in allprod)
            {
            prod.SetActive(false);
            }

            StartCoroutine(EscenaFinal());
        }
        
        productsInPlate = new List<string>();
        
    }

    private IEnumerator EscenaFinal()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Ranking");
    }

    public void Reordenar()
    {
        foreach(string product in productsInPlate)
        {
            if(product == "EstProd1")
            {
                GameObject.Find(product).transform.position = new Vector3(estProd1x, estProd1y, 0f);
                GameObject.Find(product).GetComponent<ProductoReceta>().inPlate = false;
            }
            else if(product == "EstProd2")
            {
                GameObject.Find(product).transform.position = new Vector3(estProd2x, estProd2y, 0f);
                GameObject.Find(product).GetComponent<ProductoReceta>().inPlate = false;
            }
            else if(product == "EstProd3")
            {
                GameObject.Find(product).transform.position = new Vector3(estProd3x, estProd3y, 0f);
                GameObject.Find(product).GetComponent<ProductoReceta>().inPlate = false;
            }
            else if(product == "EstProd4")
            {
                GameObject.Find(product).transform.position = new Vector3(estProd4x, estProd4y, 0f);
                GameObject.Find(product).GetComponent<ProductoReceta>().inPlate = false;
            }
            else if(product == "EstProd5")
            {
                GameObject.Find(product).transform.position = new Vector3(estProd5x, estProd5y, 0f);
                GameObject.Find(product).GetComponent<ProductoReceta>().inPlate = false;
            }
            else if(product == "EstProd6")
            {
                GameObject.Find(product).transform.position = new Vector3(estProd6x, estProd6y, 0f);
                GameObject.Find(product).GetComponent<ProductoReceta>().inPlate = false;
            }
            else if(product == "EstProd7")
            {
                GameObject.Find(product).transform.position = new Vector3(estProd7x, estProd7y, 0f);
                GameObject.Find(product).GetComponent<ProductoReceta>().inPlate = false;
            }
            else if(product == "EstProd8")
            {
                GameObject.Find(product).transform.position = new Vector3(estProd8x, estProd8y, 0f);
                GameObject.Find(product).GetComponent<ProductoReceta>().inPlate = false;
            }
            else if(product == "EstProd9")
            {
                GameObject.Find(product).transform.position = new Vector3(estProd9x, estProd9y, 0f);
                GameObject.Find(product).GetComponent<ProductoReceta>().inPlate = false;
            }
            else if(product == "EstProd10")
            {
                GameObject.Find(product).transform.position = new Vector3(estProd10x, estProd10y, 0f);
                GameObject.Find(product).GetComponent<ProductoReceta>().inPlate = false;
            }
            else if(product == "EstProd11")
            {
                GameObject.Find(product).transform.position = new Vector3(estProd11x, estProd11y, 0f);
                GameObject.Find(product).GetComponent<ProductoReceta>().inPlate = false;
            }
            else if(product == "EstProd12")
            {
                GameObject.Find(product).transform.position = new Vector3(estProd12x, estProd12y, 0f);
                GameObject.Find(product).GetComponent<ProductoReceta>().inPlate = false;
            }
            else if(product == "EstProd13")
            {
                GameObject.Find(product).transform.position = new Vector3(estProd13x, estProd13y, 0f);
                GameObject.Find(product).GetComponent<ProductoReceta>().inPlate = false;
            }
            else if(product == "EstProd14")
            {
                GameObject.Find(product).transform.position = new Vector3(estProd14x, estProd14y, 0f);
                GameObject.Find(product).GetComponent<ProductoReceta>().inPlate = false;
            }
            else if(product == "EstProd15")
            {
                GameObject.Find(product).transform.position = new Vector3(estProd15x, estProd15y, 0f);
                GameObject.Find(product).GetComponent<ProductoReceta>().inPlate = false;
            }
            else if(product == "EstProd16")
            {
                GameObject.Find(product).transform.position = new Vector3(estProd16x, estProd16y, 0f);
                GameObject.Find(product).GetComponent<ProductoReceta>().inPlate = false;
            }

        }
    }
    public void MostrarProductosAndaluces()
    {
        andaluzBox.SetActive(true);
    }
    public void OcultarProductosAndaluces()
    {
        andaluzBox.SetActive(false);
    }
 }
