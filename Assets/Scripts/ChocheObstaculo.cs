using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocheObstaculo : MonoBehaviour
{
    public GameObject cronometroGO;
    public Cronometro cronometroScript;

    public GameObject audioFXGO;
    public AudioFX audioFXScript;

    public GameObject vida;
    public Vida vidaScript;
    void Start()
    {
        cronometroGO = GameObject.FindObjectOfType<Cronometro>().gameObject;
        cronometroScript = cronometroGO.GetComponent<Cronometro>();

        audioFXGO = GameObject.FindObjectOfType<AudioFX>().gameObject;
        audioFXScript = audioFXGO.GetComponent<AudioFX>();

        vida = GameObject.Find("HealthController");
        vidaScript = vida.GetComponent<Vida>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Coche>() != null)
        {
            audioFXScript.FXSonidoChoque();
            vidaScript.contadorVidas = vidaScript.contadorVidas - 1;
            Destroy(this.gameObject);
        }
    }
}
