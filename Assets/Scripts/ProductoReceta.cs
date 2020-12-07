using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ProductoReceta : MonoBehaviour
{
    private float oriX, oriY, oriZ;
    public bool enableMove = false;
    public static string productoEscogido;
    public static string ProductoTag;
    public static bool productSelected = false;
    public int numProductos = 0;
    //public GameObject playerActive;
    public Transform[] targets;
    public Transform target;
    public static int iterante = 0;
    public bool inPlate = false;
    public static bool returning = false;
    public int IDProducto;
    public int IDPlayer;

    // Start is called before the first frame update
    void Start()
    {
        oriX = this.gameObject.transform.position.x;
        oriY = this.gameObject.transform.position.y;
        oriZ = this.gameObject.transform.position.z;

        targets = new Transform[6];
        targets[0] = GameObject.Find("Target01").GetComponent<Transform>();
        targets[1] = GameObject.Find("Target02").GetComponent<Transform>();
        targets[2] = GameObject.Find("Target03").GetComponent<Transform>();
        targets[3] = GameObject.Find("Target04").GetComponent<Transform>();
        targets[4] = GameObject.Find("Target05").GetComponent<Transform>();
        targets[5] = GameObject.Find("Target06").GetComponent<Transform>();

        target = targets[0];       
    }

    // Update is called once per frame
    void Update()
    {
        if(enableMove == true) // Si enableMove es true corre el método MoveSelected, que controla la translación y la rotación del producto seleccionado
        {
            
            MoveSelected();
            if(this.gameObject.transform.position == target.position) // Controla si el producto ya ha llegado a las coordenadas del Target. Si es así inactiva el movimiento y lo rota a su posición original.
            {
                enableMove = false;
                //playerActive = GameObject.Find(GeneralController.whosTurn);
                this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                productSelected = false;
                iterante += 1;
                inPlate = true;

                if(Jurado.btListo.activeSelf == false)
                {
                    Jurado.btListo.SetActive(true);
                }
            }
        }     
    }

    public void OnMouseDown()
    {
        Jurado.productsInPlate.Add(this.gameObject.name);
        
        if(productSelected == false && inPlate == false) // Controla que el Target exista y que no haya ningún producto seleccionado para activar el movimiento 
        {
            target = targets[iterante];
            productoEscogido = this.gameObject.name;
            ProductoTag = this.gameObject.tag;
            enableMove = true; // Activa el movimiento del producto seleccionado
            productSelected = true; // cambia la variable productSelected del GeneralController a true
            Jurado.AñadirProductoReceta(this.IDPlayer, this.IDProducto);
        } 
        else
        {
            Debug.Log("Espera a colocar el producto anterior en el plato"); // Mero aviso de que ya has seleccionado un objeto y no puedes seleccionar otro. Lo puse como comprobación de que funcionaba. Podremos borrarlo.
        }
    }     
    
    public void MoveSelected() // controla la translación y la rotación del producto seleccionado hacia el plato de harvard
    {
        float speed = 500f;
        float spinning = 400f;
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, target.position, speed * Time.deltaTime); // mueve el producto seleccionado desde su posisicón inicial a la del Target
        this.gameObject.transform.RotateAround(this.gameObject.transform.position, Vector3.forward, spinning * Time.deltaTime); // gira el producto seleccionado sobre su eje z
    }
}
