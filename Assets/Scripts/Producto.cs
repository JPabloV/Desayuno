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
    
    void Start()
    {  
        // las 3 "ori..." guardan las coordenadas originales del producto. Por ahora solo sirven para mostrar en la consola estas coordenadas
        oriX = this.gameObject.transform.position.x;
        oriY = this.gameObject.transform.position.y;
        oriZ = this.gameObject.transform.position.z;
        target = GameObject.Find("Target").GetComponent<Transform>(); // toma el transform del objeto Target, para saber donde debe moverse el producto seleccioando
        garbage = GameObject.Find("Garbage").GetComponent<Transform>();
        tendero = GameObject.Find("Tendero");
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
                ReturningPlace();
                if(this.gameObject.transform.position == new Vector3(oriX, oriY, oriZ))
                {
                    this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    enableMove = false;
                    GeneralController.productoGanado = "wait";
                    //GameObject.Find("GeneralController").GetComponent<GeneralController>().numQuestions -= 1;
                    //GeneralController.cambioTurno = true;
                    GeneralController.repartoGanadores = true;
                }
            }
            else if(GeneralController.numAcertantes == 0)
            {
                LosingProduct();
                if(this.gameObject.transform.position == garbage.position) // Controla si el producto ya ha llegado a las coordenadas del Target. Si es así inactiva el movimiento y lo rota a su posición original.
                {
                    Destroy(this.gameObject);
                    enableMove = false;
                    //toGarbage = false;
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
                //GameObject.Find("GeneralController").GetComponent<GeneralController>().numQuestions -= 1;
                //GeneralController.cambioTurno = true;
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
  
    void ReturningPlace() // Retorna el producto a su sitio si el jugador con turno falla
    {
        float speed = 500f;
        float spinning = 400f;
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, new Vector3(oriX, oriY, oriZ), speed * Time.deltaTime); // mueve el producto seleccionado desde su posisicón inicial a la del Target
        this.gameObject.transform.RotateAround(this.gameObject.transform.position, Vector3.forward, spinning * Time.deltaTime); // gira el producto seleccionado sobre su eje z
    }

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
}
