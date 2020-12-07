using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pregunta
{
    public int ID {get;set;}
    public string Texto {get;set;}
    public Alimento Alimento {get;set;}
    public bool Respuesta {get;set;}
    public bool Acertada {get;set;}

}
public class ListadoPreguntas
{
    public List<Pregunta> preguntas {get; set;}
}

