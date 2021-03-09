using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InicioJuego : MonoBehaviour
{
    public static bool comienzo = false;

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
        OrdenInicial.numTienda = "Tienda01";
        //Debug.Log(OrdenInicial.numTienda);
        comienzo = true;
        ShoppingController.tituloGlobal.SetActive(false);
        //ShoppingController.logoJunta.SetActive(false);
        //ShoppingController.logoCooperativas.SetActive(false);
    }
    
    public void EmpezarGame()
    {
        SceneManager.LoadScene("OutTiendas");
    }
}
