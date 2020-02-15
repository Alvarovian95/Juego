using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Personaje : MonoBehaviour
{
    private Animator anim;
    AudioSource fuenteDeAudio;
    public AudioClip audioManzana;

    //VELOCIDAD MOVIMIENTO
    public float velocidadMovimiento = 5.0f;
    //VELOCIDAD ROTACION
    public float velocidadRotacion = 200.0f;

    //SABER SI ESTA QUIETO O EN MOVIMIENTO
    public float x, y;

    //PARA MOVER LA CAMARA CON EL RATON
    public float h, v;
    public Camera FPSCamera;
    public float horizontalSpeed;
    public float verticalSpeed;


    //Inicializo el contador de coleccionables recogidos y los puntos
    public Text TextoPuntuacion;
    private int contador;
    private int puntos;

    public bool huir = false;
    private float tiempo;

    void Start()
    {
        anim = GetComponent<Animator>();
        fuenteDeAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //MOVER PERSONAJE
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");


        //FUNCION PARA ROTAR
        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        //FUNCION PARA QUE SE DESPLAZE
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocidadMovimiento = 8.0f;
        }
        else
        {
            velocidadMovimiento = 5.0f;
        }

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        //PARA MOVER LA CAMARA CON EL RATON
        h = horizontalSpeed * Input.GetAxis("Mouse X");
        v = verticalSpeed * Input.GetAxis("Mouse Y");

        transform.Rotate(0, h, 0);
        FPSCamera.transform.Rotate(-v, 0, 0);

        //Si los enemigos están huyendo y nos e ha acabado el tiempo, decremento el tiempo
        if (huir && tiempo > 0)
        {
            tiempo -= Time.deltaTime;
            //Lo muestro en consola
            Debug.Log(tiempo);
        }
        else
        {
            huir = false;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable")) //MANZANA
        {
            other.gameObject.SetActive(false);
            contador = contador + 1;
            puntos = contador * 100;
            fuenteDeAudio.clip = audioManzana;
            fuenteDeAudio.Play();

            //Actualizo el texto puntos
            setTextoPuntos();
        }

        //Cuando tocamos una botella
        if (other.gameObject.CompareTag("Botella"))
        {
            new WaitForSeconds(2);
            other.gameObject.SetActive(false);
            //Inicio el contador hacia atrás y pongo a true el booleano
            tiempo = 10;
            huir = true;
        }

        if (other.gameObject.CompareTag("Puniala"))
        {
            new WaitForSeconds(2);
            other.gameObject.SetActive(false);
        }

    }

    //Actualizo el texto del contador (O muestro el de ganar si las ha cogido todas)
    void setTextoPuntos()
    {
        TextoPuntuacion.text = "SCORE: " + puntos.ToString();
    }


}
