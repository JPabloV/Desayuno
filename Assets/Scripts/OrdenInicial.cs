using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdenInicial : MonoBehaviour
{
    public static List<string> playersOrder = new List<string>();
    // Start is called before the first frame update
    public static string numTienda = "Inicio";
    public static OrdenInicial instance;

    void Awake()
    {
       if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
        //DontDestroyOnLoad(this.gameObject);
    }
}
