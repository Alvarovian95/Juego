using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanioCura : MonoBehaviour
{
    public bool esDanio;
    public float danio = 10;    

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
            col.SendMessage((esDanio) ? "RecibirDanio" : "CurarDanio", Time.deltaTime * danio);        
    }
}
