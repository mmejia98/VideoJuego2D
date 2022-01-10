using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public GameObject[] vidas;
    public int contadorVidas = 3;
    public GameObject motorCarretera;
    public MotorCarreteras motorCarreterasScript;
    public Cronometro cronometroScript;
    void Start()
    {
        motorCarretera = GameObject.Find("MotorCarretera");
        motorCarreterasScript = motorCarretera.GetComponent<MotorCarreteras>();
        cronometroScript = GameObject.Find("Cronometro").GetComponent<Cronometro>();
    }

    // Update is called once per frame
    void Update()
    {
        if(contadorVidas == 2 && motorCarreterasScript.juegoTerminado == false){
            vidas[2].SetActive(false);
        }
        if(contadorVidas == 1){
            vidas[1].SetActive(false);
        }
        if(contadorVidas == 0 && motorCarreterasScript.juegoTerminado == false){
            vidas[0].SetActive(false);
            motorCarreterasScript.juegoTerminado = true;
            cronometroScript.cronometroEncendido = false;
            motorCarreterasScript.JuegoTerminadoEstado();
        }
    }
}
