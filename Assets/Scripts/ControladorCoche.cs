using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCoche : MonoBehaviour
{
    public GameObject cocheGo;
    public Rigidbody2D cocheRB;
    public float anguloDeGiro;
    public float velocidad;
    public bool isLeft = false, isRight = false; 
    float giroEnZ = 0f;
    void Start()
    {
        cocheGo = GameObject.Find("Coche");
        cocheRB = cocheGo.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float giroEnZ = 0;
        transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * velocidad * Time.deltaTime);
        giroEnZ = Input.GetAxis("Horizontal") * -anguloDeGiro;
        cocheGo.transform.rotation = Quaternion.Euler(0, 0, giroEnZ);
        /*if(isLeft){
            transform.Translate(Vector2.right * -1 * velocidad * Time.deltaTime);
            cocheGo.transform.rotation = Quaternion.Euler(0, 0, anguloDeGiro);
        }
        if(isRight){
            transform.Translate(Vector2.right * velocidad * Time.deltaTime);
            cocheGo.transform.rotation = Quaternion.Euler(0, 0, -anguloDeGiro);
        }*/
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            float screenHalf = Screen.width / 2;
            if(touch.position.x > screenHalf){
                transform.Translate(Vector2.right * velocidad * Time.deltaTime);
                cocheGo.transform.rotation = Quaternion.Euler(0, 0, -anguloDeGiro);
            }else{
                transform.Translate(Vector2.right * -1 * velocidad * Time.deltaTime);
                cocheGo.transform.rotation = Quaternion.Euler(0, 0, anguloDeGiro);
            }
        }
    }

    public void ClickRight(){
        isRight = true;
    }
    public void ReleaseRight(){
        isRight = false;
    }
    public void ClickLeft(){
        isLeft = true;
    }
    public void ReleaseLeft(){
        isLeft = false;
    }
}
