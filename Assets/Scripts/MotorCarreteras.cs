using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorCarreteras : MonoBehaviour
{
    public GameObject contenedorCallesGO;
    public GameObject[] contenedorCarreteraArray;
    public GameObject musica;
    public float velocidad;
    public bool iniciaJuego;
    public bool juegoTerminado;
    int contadorCalles = 0;
    int numeroSelectorCalles;
    public GameObject calleAnterior;
    public GameObject calleNueva;
    public float sizeCalle;
    public Vector3 medidaLimitePantalla;
    public bool salioDePantalla;
    public GameObject mCamGo;
    public Camera mCamcomp;

    public GameObject cocheGO;
    public GameObject audioFXGO;
    public AudioFX audioFXScript;
    public GameObject bgFinalGO;
    void Start()
    {
        InicioJuego();
    }
    
    void InicioJuego()
    {
        contenedorCallesGO = GameObject.Find("ContenedorCalles");

        mCamGo = GameObject.Find("MainCamera");
        mCamcomp = mCamGo.GetComponent<Camera>();

        cocheGO = GameObject.Find("Coche");
        bgFinalGO = GameObject.Find("PanelGameOver");
        bgFinalGO.SetActive(false);

        audioFXGO = GameObject.Find("AudioFX");
        audioFXScript = audioFXGO.GetComponent<AudioFX>();

        musica = GameObject.Find("Musica");

        VelocidadMotorCarretera();
        MedirPantalla();
        BuscoCalles();
    }

    public void JuegoTerminadoEstado()
    {
        cocheGO.GetComponent<AudioSource>().Stop();
        musica.GetComponent<AudioSource>().Stop();
        audioFXScript.FXMusic();
        bgFinalGO.SetActive(true);
    }

    void VelocidadMotorCarretera()
    {
        velocidad = 13;
    }
    void BuscoCalles()
    {
        contenedorCarreteraArray = GameObject.FindGameObjectsWithTag("Calle");
        for (int i = 0; i < contenedorCarreteraArray.Length; i++)
        {
            contenedorCarreteraArray[i].gameObject.transform.parent = contenedorCallesGO.transform;
            contenedorCarreteraArray[i].gameObject.SetActive(false);
            contenedorCarreteraArray[i].gameObject.name = "CalleOFF_" + i;
        }

        CrearCalles();
    }
    void CrearCalles()
    {
        contadorCalles++;
        numeroSelectorCalles = Random.Range(0, contenedorCarreteraArray.Length);
        GameObject Calle = Instantiate(contenedorCarreteraArray[numeroSelectorCalles]);
        Calle.SetActive(true);
        Calle.name = "Calle" + contadorCalles;
        Calle.transform.parent = gameObject.transform;
        PosicionoCalles();
    }
    void PosicionoCalles()
    {
        calleAnterior = GameObject.Find("Calle" + (contadorCalles - 1));
        calleNueva = GameObject.Find("Calle" + (contadorCalles));
        MidoCalle();
        calleNueva.transform.position = new Vector3(calleAnterior.transform.position.x, calleAnterior.transform.position.y + sizeCalle, 0);
        salioDePantalla = false;
    }
    void MidoCalle()
    {
        for (int i = 0; i < calleAnterior.transform.childCount; i++)
        {
            if (calleAnterior.transform.GetChild(i).gameObject.GetComponent<Pieza>() != null)
            {
                float sizePieza = calleAnterior.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
                sizeCalle = sizeCalle + sizePieza;
            }
        }
    }
    void MedirPantalla()
    {
        medidaLimitePantalla = new Vector3(0, mCamcomp.ScreenToWorldPoint(new Vector3(0, 0, 0)).y - 0.5f, 0);
    }
    void Update()
    {
        if (iniciaJuego == true && juegoTerminado == false)
        {
            transform.Translate(Vector3.down * velocidad * Time.deltaTime);
            if (calleAnterior.transform.position.y + sizeCalle < medidaLimitePantalla.y && salioDePantalla == false)
            {
                salioDePantalla = true;
                DestruyoCalles();
            }
        }
    }
    void DestruyoCalles()
    {
        Destroy(calleAnterior);
        sizeCalle = 0;
        calleAnterior = null;
        CrearCalles();
    }
}