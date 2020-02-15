using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavEnemigo : MonoBehaviour
{	

	NavMeshAgent agente;
    GameObject jugador;
    private MeshRenderer meshRenderer;
    public float velocidadMovimiento = 5.0f;
	bool inicio = true;

    // Start is called before the first frame update
    void Start()
    {
		jugador = GameObject.FindWithTag("Player");
        
		//Capturamos en nav mesh agent del enemigo
        agente = this.GetComponent<NavMeshAgent>();

        //Capturamos el SkinnedMeshRenderer del children del enemigo para cambiarle el material
        meshRenderer = GetComponent<MeshRenderer>();
		//Capturamos en nav mesh agent del enemigo
        agente = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Muevo el enemigo hacia el jugador (si no lo han matado aún)
        //if (jugador != null)
        //{
		//if(inicio){transform.position = new Vector3 (transform.position.x, jugador.position.y, transform.position.z);
                //Persigue al jugador
          //      agente.Warp(this.transform.position); inicio = false;}
           // if (jugador.GetComponent<Personaje>().huir)
           // {
                //Huye del jugador
         //       agente.SetDestination(transform.position - jugador.transform.position);
                //Color temporal
        //        meshRenderer.material.color = Color.blue;
        //    }
       //     else
        //    {   
                
                agente.SetDestination(jugador.transform.position);
                //transform.position = Vector3.MoveTowards(transform.position, jugador.transform.position, velocidadMovimiento);
                //Color original
                meshRenderer.material.color = Color.red;
        //    }

        //}
    }

	private void OnTriggerEnter(Collider other)
    {

        //Si se choca con el jugador
        if (other.gameObject.tag == "Player")
        {
            if (jugador.GetComponent<Personaje>().huir)
            {
                //Destruyo al enemigo
                Destroy(gameObject);
            }
            else
            {
                //Destruyo al jugador
                Destroy(other.gameObject);
                //Paro el tiempo del juego para que no se creen más enemigos
                Time.timeScale = 0;
            }
        }
    }
}
