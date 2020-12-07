using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SalirTienda : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        if(OrdenInicial.numTienda == "Tienda01")
        {
            OrdenInicial.numTienda = "Terminado";
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
}
