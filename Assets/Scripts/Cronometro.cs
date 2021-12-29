using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour
{
    public GameObject motorCarreterasGO;
    public MotorCarreteras motorCarreteraScript;
    public float tiempo;
    public float distancia;
    public Text txtTiempo;
    public Text txtDistancia;
    public Text txtDistanciaFinal;

    void Start()
    {
        motorCarreterasGO = GameObject.Find("MotorCarretera");
        motorCarreteraScript = motorCarreterasGO.GetComponent<MotorCarreteras>();
        txtTiempo.text = "2:00";
        txtDistancia.text = "0";
        tiempo = 120;
    }

    void Update()
    {
        if (motorCarreteraScript.iniciaJuego == true && motorCarreteraScript.juegoTerminado == false)
        {
            CalculoTiempoDistancia();
        }

        if (tiempo <= 0 && motorCarreteraScript.juegoTerminado == false)
        {
            
            motorCarreteraScript.juegoTerminado = true;
            motorCarreteraScript.JuegoTerminadoEstado();
            txtDistanciaFinal.text = ((int)distancia).ToString() + "mts";
            txtTiempo.text = "0:00";
        }
    }

    void CalculoTiempoDistancia()
    {
        distancia += Time.deltaTime * motorCarreteraScript.velocidad;
        txtDistancia.text = ((int)distancia).ToString();
        tiempo -= Time.deltaTime;
        int minutos = (int)tiempo / 60;
        int segundos = (int)tiempo % 60;
        txtTiempo.text = minutos.ToString() + ":" + segundos.ToString().PadLeft(2, '0');
    }
}
