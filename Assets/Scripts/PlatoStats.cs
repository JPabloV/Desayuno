using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatoStats : MonoBehaviour
{

    public bool adicionPuntoPlatos;
    public int tipoAlimento;
    public int pProteinas;
    public int pCereales;
    public int pVegetales;
    public int pFrutas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
         if(adicionPuntoPlatos == true)
        {
            if(tipoAlimento == 1 || tipoAlimento == 10)
            {
                pCereales += 1;
                this.gameObject.transform.GetChild(2).gameObject.GetComponent<Text>().text = pCereales.ToString();
            }
            else if(tipoAlimento == 5 || tipoAlimento == 6 || tipoAlimento == 7 || tipoAlimento == 8 || tipoAlimento == 9)
            {
                pProteinas += 1;
                this.gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = pProteinas.ToString();
            }
            else if(tipoAlimento == 2)
            {
                pFrutas += 1;
                this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = pFrutas.ToString();
            }
            else if(tipoAlimento == 3 || tipoAlimento == 4 || tipoAlimento == 11)
            {
                pVegetales += 1;
                this.gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text = pVegetales.ToString();
            }
            adicionPuntoPlatos = false;
        }

    }

    public void RepintarPlatos(List<Respuestas>  pListaRespuestas)
    {
        //añadimos los productos que ya tiene cada jugador.
        if (pListaRespuestas!=null)
        {
            foreach (var plato in pListaRespuestas)
            {
                tipoAlimento = plato.Alimento.IDTipoAlimento;
                if(tipoAlimento == 1)
                {
                    pCereales += 1;
                    this.gameObject.transform.GetChild(2).gameObject.GetComponent<Text>().text = pCereales.ToString();
                }
                else if(tipoAlimento == 5 || tipoAlimento == 6 || tipoAlimento == 7 || tipoAlimento == 8 || tipoAlimento == 9)
                {
                    pProteinas += 1;
                    this.gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = pProteinas.ToString();
                }
                else if(tipoAlimento == 2)
                {
                    pFrutas += 1;
                    this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = pFrutas.ToString();
                }
                else if(tipoAlimento == 3 || tipoAlimento == 4 || tipoAlimento == 11)
                {
                    //el 4 y el 11 no tenían asignado ninguno, son los lacteos los asigno mientras a los Vegetales
                    pVegetales += 1;
                    this.gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text = pVegetales.ToString();
                }
            }
        }
        
    }
}
