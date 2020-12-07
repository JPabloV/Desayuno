using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alimento 
{
    public int ID {get;set;}
    public int IDTipoAlimento {get;set;}
    public string Nombre {get;set;}
    public int Unidades {get;set;}
    public int Puntuacion {get;set;}
    public string Observaciones {get; set;}
    public string ImageSource {get;set;}
    public bool IsAndaluz {get;set;}

    //public GameObject Imagen {get;set;}
}


//CATEGORIAS
public class TipoAlimento
{
    public int ID {get;set;}
    public string Nombre {get;set;}
    public string Descripcion {get;set;}
    public string Frecuencia {get;set;}
}

public class Preguntas
{
    public int ID {get;set;}
    public int IDAlimento {get;set;}
    public int IDTipoAlimento {get;set;}
    public string Pregunta {get;set;}
    public bool Respuesta {get;set;}
}