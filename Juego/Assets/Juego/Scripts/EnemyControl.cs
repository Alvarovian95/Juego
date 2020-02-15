using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

	[SerializeField] GameObject enemigo;
	public int numeroEnemigos;
    public float esperaInicial;
    public float esperaEntreEnemigos;
    public float esperaEntreOlas;

    // Start is called before the first frame update
    void Start()
    {
        //LLamo a la rutina de crear enemigos
			StartCoroutine(crearEnemigos());
    }

    IEnumerator crearEnemigos()
    {
       //Espero un tiempo antes de crear enemigos
       yield return new WaitForSeconds(esperaInicial);

        //Bucle durante toda la vida del juego
        while (true)
        {
            //Bucle de número de enemigos
            for (int i = 0; i < numeroEnemigos; i++)
            {
                //Instancio el enemigo en una posición aleatoria del tablero
                Vector3 posicionEnemigo = new Vector3(Random.Range(12, 60), 20, Random.Range(16, 60));
                Quaternion rotacionEnemigo = Quaternion.identity;
                Instantiate(enemigo, posicionEnemigo, rotacionEnemigo);

                //Espero un tiempo entre la creación de cada enemigo
                yield return new WaitForSeconds(esperaEntreEnemigos);
            }

            //Espero un tiempo entre oleadas de enemigos
            yield return new WaitForSeconds(esperaEntreOlas);
        }
    }
}
