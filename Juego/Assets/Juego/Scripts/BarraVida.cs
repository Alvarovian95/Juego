using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Image VidaActual;
    public Text RatioTexto;

    private float puntosVida = 150;
    private float putosVidaMaximo = 150;
	private bool GameIsPaused = true;   

    [SerializeField]private GameObject gameOverUI;



    private void Start()
    {
        ActualizarVida();		
    }

	private void Update()
    {
        ActualizarVida();

		if(puntosVida == 150){
		Time.timeScale = 1f;
		}
    }

    private void ActualizarVida()
    {
        float ratio = puntosVida / putosVidaMaximo;
        VidaActual.rectTransform.localScale = new Vector3(ratio, 1, 1);
        RatioTexto.text = (ratio * 100).ToString("0") + '%';

    }

    public void RecibirDanio(float danio)
    {
        puntosVida -= danio;       
        if (puntosVida < 0)
        {
            puntosVida = 0;
            gameOverUI.SetActive(true);
			Time.timeScale = 0f;
			GameIsPaused = false;
        }

        ActualizarVida();
    }

    public void CurarDanio(float cura)
    {
        puntosVida += cura;

        if (puntosVida > putosVidaMaximo)
        {
            puntosVida = putosVidaMaximo;
        }

        ActualizarVida();

    }
}
