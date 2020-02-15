using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    AudioSource fuenteDeAudio;
    public AudioClip audioGolpe;

    private Animator anim;
    public GameObject panelDaño;
    //VELOCIDAD MOVIMIENTO
    public float velocidadMovimiento = 5.0f;
    //VELOCIDAD ROTACION
    public float velocidadRotacion = 200.0f;

    //SABER SI ESTA QUIETO O EN MOVIMIENTO
    public float x, y;

	private GameObject personaje;
	private Rigidbody rb;

    void Start()
    {
        anim = GetComponent<Animator>();
		personaje = GameObject.Find("Personaje");
		rb = GetComponent<Rigidbody>();
        fuenteDeAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //MOVER PERSONAJE (ELIMINAR PARA EL ENEMIGO)
      //  x = Input.GetAxis("Horizontal");
       // y = Input.GetAxis("Vertical");

        //FUNCION PARA ROTAR
        //transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
		transform.LookAt(personaje.transform);
		transform.position = Vector3.MoveTowards(transform.position, personaje.transform.position, velocidadMovimiento * Time.deltaTime);
        //FUNCION PARA QUE SE DESPLAZE
        //transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);
		//rb.velocity = new Vector3 (velocidadMovimiento, rb.velocity.y, velocidadMovimiento);
       
        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);		
    }

	
		void OnCollisionEnter(Collision col)
    {
		if(col.gameObject.name == "Personaje"){			
			col.gameObject.SendMessage("RecibirDanio",  5);
            panelDaño.SetActive(true);
            fuenteDeAudio.clip = audioGolpe;
            fuenteDeAudio.Play();
        }
        else
        {
            panelDaño.SetActive(false);
        }
	}
	


        
}

