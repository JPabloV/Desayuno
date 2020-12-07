using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugadores 
{
    public int ID {get;set;}
    public string Alias {get;set;}
}
public class CarroJugador
{
    public int ID {get;set;}
    public int JugadorID {get;set;}
    public List<Alimento> Alimentos {get;set;}
}
