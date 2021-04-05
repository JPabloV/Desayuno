using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Producto : MonoBehaviour
{
    private float oriX, oriY, oriZ; // guardarán las coordenadas originales del producto (donde comienza)
    private Transform target; // punto al que se moverá el producto una vez sea seleccionado. esta posición cambiará para cada jugador
    public bool enableMove = false; // permite o prohibe el movimiento del producto
    public static string productoEscogido;
    public GameObject playerActive;
    public GameObject tendero;
    public static string ProductoTag;
    public static bool toGarbage = false;
    public static Transform garbage;
    public string nextWinner; // sirve para buscar al primer jugador por orden de turno que haya acertado una pregunta cuando el jugador con turno la ha fallado

    public GameObject plato01, plato02, plato03, plato04; //los gameobject de los platos
    public static bool searching = false; // searching se activa cuando el jugador con turno falla una pregunta y hay que buscar al siguiente jugador por orden de turno que la haya acertado
    
    void Start()
    {  
        // las 3 "ori..." guardan las coordenadas originales del producto. Por ahora solo sirven para mostrar en la consola estas coordenadas
        oriX = this.gameObject.transform.position.x;
        oriY = this.gameObject.transform.position.y;
        oriZ = this.gameObject.transform.position.z;
        target = GameObject.Find("Target").GetComponent<Transform>(); // toma el transform del objeto Target, para saber donde debe moverse el producto seleccioando
        garbage = GameObject.Find("Garbage").GetComponent<Transform>();
        tendero = GameObject.Find("Tendero");

        plato01 = GameObject.Find("Plato01");
        plato02 = GameObject.Find("Plato02");
        plato03 = GameObject.Find("Plato03");
        plato04 = GameObject.Find("Plato04");

        

    }

    public void FixedUpdate()
    {
        
        if(enableMove == true && GeneralController.productoGanado == "wait") // Si enableMove es true corre el método MoveSelected, que controla la translación y la rotación del producto seleccionado
        {
            MoveSelected();
            if(this.gameObject.transform.position == target.position) // Controla si el producto ya ha llegado a las coordenadas del Target. Si es así inactiva el movimiento y lo rota a su posición original.
            {
                enableMove = false;
                GeneralController.turnSpin = false;
                playerActive = GameObject.Find(GeneralController.whosTurn);
                this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
        else if(enableMove == true && GeneralController.productoGanado == "no")
        {
            
            if(GeneralController.numAcertantes > 0)
            {
                nextWinner = GeneralController.whosTurn; // Aquí colocamos en nextWinner el jugador que tiene el turno actual
                searching = true; // activamos searching para que funcione el bucle while
                while(searching == true) // este bucle se repite ejecutando NextWinner hasta que encuentra al primer jugador que haya acertado la pregunta. Cuando lo hace, ejecuta la funcion OtherWinner y pasa searching a false para parar el bucle.
                {
                    NextWinner();
                    if(GameObject.Find(nextWinner).GetComponent<PlayerStats>().aciertoPlayer == true)
                    {
                        OtherWinner(nextWinner);
                        searching = false;
                    }
                }
                
                // Estos if siguientes sirven para destruir el producto cuando alcanza el plato de harvard que le corresponda, y vuelve a reactivar las variables necesarias para que continue el juego.
                if(nextWinner == "Player01")
                {
                    if(this.gameObject.transform.position == plato01.transform.position)
                    {
                        Destroy(this.gameObject);
                        enableMove = false;
                        GeneralController.productoGanado = "wait";
                        GeneralController.repartoGanadores = true;
                    }
                }
                else if(nextWinner == "Player02")
                {
                    if(this.gameObject.transform.position == plato02.transform.position)
                    {
                        Destroy(this.gameObject);
                        enableMove = false;
                        GeneralController.productoGanado = "wait";
                        GeneralController.repartoGanadores = true;
                    }
                }
                else if(nextWinner == "Player03")
                {
                    if(this.gameObject.transform.position == plato03.transform.position)
                    {
                        Destroy(this.gameObject);
                        enableMove = false;
                        GeneralController.productoGanado = "wait";
                        GeneralController.repartoGanadores = true;
                    }
                }
                else if(nextWinner == "Player04")
                {
                    if(this.gameObject.transform.position == plato04.transform.position)
                    {
                        Destroy(this.gameObject);
                        enableMove = false;
                        GeneralController.productoGanado = "wait";
                        GeneralController.repartoGanadores = true;
                    }
                }

                // Comento estas líneas porque en principio han quedado en desuso al haber cambiado la forma en que se mueve el producto seleccionado
                // ReturningPlace();
                // if(this.gameObject.transform.position == new Vector3(oriX, oriY, oriZ))
                // {
                //     this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                //     enableMove = false;
                //     GeneralController.productoGanado = "wait";
                //     GeneralController.repartoGanadores = true;
                // }
            }

            else if(GeneralController.numAcertantes == 0)
            {
                LosingProduct();
                if(this.gameObject.transform.position == garbage.position) // Controla si el producto ya ha llegado a las coordenadas del Target. Si es así inactiva el movimiento y lo rota a su posición original.
                {
                    Destroy(this.gameObject);
                    enableMove = false;
                    GeneralController.productoGanado = "wait";
                    playerActive = GameObject.Find(GeneralController.whosTurn);
                    GeneralController.repartoGanadores = true;
                }
            }

        }

        else if(enableMove == true && GeneralController.productoGanado == "yes")
        {
            Won();
            if(this.gameObject.transform.localScale.x <= 0)
            {
                Destroy(this.gameObject);
                enableMove = false;  
                GeneralController.productoGanado = "wait";
                GeneralController.unidadesProducto -= 1;
                GeneralController.repartoGanadores = true;
            }
        }
        else if(enableMove == true && toGarbage == true)
        {
            LosingProduct();
            if(this.gameObject.transform.position == garbage.position) // Controla si el producto ya ha llegado a las coordenadas del Target. Si es así inactiva el movimiento y lo rota a su posición original.
            {
                Destroy(this.gameObject);
                enableMove = false;
                toGarbage = false;
                playerActive = GameObject.Find(GeneralController.whosTurn);
            }
        }
    }
        
    public void OnMouseDown()
    {
        if(GeneralController.productSelected == false && target != null) // Controla que el Target exista y que no haya ningún producto seleccionado para activar el movimiento 
        {
            tendero.transform.GetChild(0).gameObject.SetActive(false);
            productoEscogido = this.gameObject.name;
            ProductoTag = this.gameObject.tag;
            enableMove = true; // Activa el movimiento del producto seleccionado
            GeneralController.productSelected = true; // cambia la variable productSelected del GeneralController a true
            StartCoroutine("SelectionComplete"); // Da comienzo el IEnumerator que espera 2 segundos antes de activar la ventana de preguntas y los botones de respuesta
        } 
        else
        {
            Debug.Log("Ya has seleccionado un producto"); // Mero aviso de que ya has seleccionado un objeto y no puedes seleccionar otro. Lo puse como comprobación de que funcionaba. Podremos borrarlo.
        }
    } 

    private IEnumerator SelectionComplete() // Espera 2 segundos y activa el menu de preguntas
    {
        yield return new WaitForSeconds(2);
        GeneralController.questionBox.SetActive(true); // Activa la ventana de preguntas     
    }

    public void MoveSelected() // controla la translación y la rotación del producto seleccionado hacia el plato de harvard
    {
        float speed = 500f;
        float spinning = 400f;
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, target.position, speed * Time.deltaTime); // mueve el producto seleccionado desde su posisicón inicial a la del Target
        this.gameObject.transform.RotateAround(this.gameObject.transform.position, Vector3.forward, spinning * Time.deltaTime); // gira el producto seleccionado sobre su eje z
    }
  
    // He comentado esta función ya que en principio ha quedado en desuso
    // void ReturningPlace() // Retorna el producto a su sitio si el jugador con turno falla
    // {
    //     float speed = 500f;
    //     float spinning = 400f;
    //     this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, new Vector3(oriX, oriY, oriZ), speed * Time.deltaTime); // mueve el producto seleccionado desde su posisicón inicial a la del Target
    //     this.gameObject.transform.RotateAround(this.gameObject.transform.position, Vector3.forward, spinning * Time.deltaTime); // gira el producto seleccionado sobre su eje z
    // }

    public void Won() // Introduce el objeto en el plato de harvard si el jugador con turno acierta
    {
        float spinning = 800f;
        this.gameObject.transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
        this.gameObject.transform.RotateAround(this.gameObject.transform.position, Vector3.forward, spinning * Time.deltaTime); // gira el producto seleccionado sobre su eje z
    }

    void LosingProduct()
    {
        float speed = 500f;
        float spinning = 400f;
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, garbage.position, speed * Time.deltaTime); // mueve el producto seleccionado desde su posisicón inicial a la del Target
        this.gameObject.transform.RotateAround(this.gameObject.transform.position, Vector3.forward, spinning * Time.deltaTime); // gira el producto seleccionado sobre su eje z
    }

    // En caso de que el jugador con turno falle una pregunta, pero acierten otros jugadores, esta función envía el producto que el jugador con turno había elegido hacia el primer jugador acertante en orden de turno
    void OtherWinner(string nextWinner)
    {
        float speed = 500f;
        float spinning = 400f;

        if(nextWinner == "Player01")
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, plato01.transform.position, speed * Time.deltaTime); // mueve el producto seleccionado desde su posisicón inicial a la del Target
            this.gameObject.transform.RotateAround(this.gameObject.transform.position, Vector3.forward, spinning * Time.deltaTime); // gira el producto seleccionado sobre su eje z
        }
        else if(nextWinner == "Player02")
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, plato02.transform.position, speed * Time.deltaTime); // mueve el producto seleccionado desde su posisicón inicial a la del Target
            this.gameObject.transform.RotateAround(this.gameObject.transform.position, Vector3.forward, spinning * Time.deltaTime); // gira el producto seleccionado sobre su eje z
        }
        else if(nextWinner == "Player03")
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, plato03.transform.position, speed * Time.deltaTime); // mueve el producto seleccionado desde su posisicón inicial a la del Target
            this.gameObject.transform.RotateAround(this.gameObject.transform.position, Vector3.forward, spinning * Time.deltaTime); // gira el producto seleccionado sobre su eje z
        }
        else if(nextWinner == "Player04")
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, plato04.transform.position, speed * Time.deltaTime); // mueve el producto seleccionado desde su posisicón inicial a la del Target
            this.gameObject.transform.RotateAround(this.gameObject.transform.position, Vector3.forward, spinning * Time.deltaTime); // gira el producto seleccionado sobre su eje z
        }
    }

    // Itera en la lista de turno eligiendo al siguiente en el turno
    void NextWinner()
    {
        if(nextWinner == OrdenInicial.playersOrder[0])
        {
            nextWinner = OrdenInicial.playersOrder[1];
        }
        else if(nextWinner == OrdenInicial.playersOrder[1])
        {   
            nextWinner = OrdenInicial.playersOrder[2];
        }
        else if(nextWinner == OrdenInicial.playersOrder[2])
        {
            nextWinner = OrdenInicial.playersOrder[3];
        }
        else if(nextWinner == OrdenInicial.playersOrder[3])
        {
            nextWinner = OrdenInicial.playersOrder[0];  
        }
    }
}
