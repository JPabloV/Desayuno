using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGeneralController : MonoBehaviour
{
    private GameObject btTrue, btFalse; // los GameObject de los botones Verdero y Falso
    public string pushed = "none"; // Variable que controla el botón pulsado. También servirá como respuesta
    public Sprite vNormal, vSelected, vRight, vWrong, xNormal, xSelected, xRight, xWrong; // Los sprites de los botones Verdadero y Falso en sus cuatro colores cada uno

    
    // Start is called before the first frame update
    void Start()
    {
        btTrue = transform.GetChild(0).gameObject; // Carga el botón verdadero a través del objeto padre
        btFalse = transform.GetChild(1).gameObject; // Carga el botón falso a través del objeto padre
    }

    // Update is called once per frame
    void Update()
    {
        if(pushed == "V") // Si pushed toma el valor "V" se asegura de que el btFalse este en gris y cambia el sprite del btTrue a negro;
        {
            btTrue.GetComponent<Image>().sprite = vSelected;
            btFalse.GetComponent<Image>().sprite = xNormal;
        }
        else if(pushed == "F") // Si pushed toma el valor "F" se asegura de que el btTrue este en gris y cambia el sprite del btFalse a negro;
        {
            btTrue.GetComponent<Image>().sprite = vNormal;
            btFalse.GetComponent<Image>().sprite = xSelected;
        }
        /*if(pushed == "VV") // Acertamos verdadero
        {
            btTrue.GetComponent<Image>().sprite = vSelected;
            btFalse.GetComponent<Image>().sprite = xNormal;
        }
        else if(pushed == "FF") // Acertamos el Falso
        {
            btTrue.GetComponent<Image>().sprite = vNormal;
            btFalse.GetComponent<Image>().sprite = xSelected;
        }
        if(pushed == "VF") // Fallamos la verdadera
        {
            btTrue.GetComponent<Image>().sprite = vSelected;
            btFalse.GetComponent<Image>().sprite = xNormal;
        }
        else if(pushed == "FV") // Fallamos la falsa
        {
            btTrue.GetComponent<Image>().sprite = vNormal;
            btFalse.GetComponent<Image>().sprite = xSelected;
        }  */
    }

    public void Resolver()
    {
        pushed = "none";
    }

    public void RestartQuestionBox()
    {
        btTrue.GetComponent<Image>().sprite = vNormal;
        btFalse.GetComponent<Image>().sprite = xNormal;
    }
}
