using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCoche : MonoBehaviour
{
    public GameObject cocheGo;
    public float anguloDeGiro;
    public float velocidad;
    void Start()
    {
        cocheGo = GameObject.Find("Coche");
    }
    void Update()
    {
        float giroEnZ = 0;
        transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * velocidad * Time.deltaTime);
        giroEnZ = Input.GetAxis("Horizontal") * -anguloDeGiro;
        cocheGo.transform.rotation = Quaternion.Euler(0, 0, giroEnZ);
    }
}
