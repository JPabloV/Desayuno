using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningPlayer : MonoBehaviour
{
    private float spinning = 50f;
    //public static bool turnSpin = true;
    public bool playerSpinning = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GeneralController.turnSpin == true && playerSpinning == true)
        {
            Turning();
        }
        else if(GeneralController.turnSpin == false)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        
    }

    void Turning()
    {
        this.gameObject.transform.RotateAround(this.gameObject.transform.position, this.gameObject.transform.up, spinning * Time.deltaTime);
    }
}
