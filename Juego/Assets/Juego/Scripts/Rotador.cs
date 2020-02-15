using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotador : MonoBehaviour
{
    void Update()
    {

        //Rota el elemento una cantidad diferente en cada dirección y enc ada intervalo de tiempo
        transform.Rotate(new Vector3(50, 35, 45) * Time.deltaTime);
    }
}
