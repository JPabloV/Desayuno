using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalking : MonoBehaviour
{

    private float speed = 300f;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Target").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(InicioJuego.comienzo == true)
        {
            float fixedSpeed = speed * Time.deltaTime; // la velocidad a la que se mueve el producto seleccionado. el Time.deltaTime es para condicionar la velocidad a la capacidad del ordenador
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, target.position, fixedSpeed); // mueve el producto seleccionado desde su posisicón inicial a la del Target
        }        
    }
}
