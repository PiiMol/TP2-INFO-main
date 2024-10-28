using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveCubePhysics : MonoBehaviour
{
    public float Velocidad = 10f;
    public float velocidadRotacion = 20f;
    // Start is called before the first frame update
    void Start()
    {
    }
    //Metodo para incluir las instrucciones fenomenos fisicos del objeto
    private void FixedUpdate()
    {
        //Instrucciones para el movimiento del objeto del juego usando física.
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.GetComponent<Rigidbody>().MovePosition(gameObject.GetComponent<Rigidbody>().position +Vector3.forward * Velocidad * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            gameObject.GetComponent<Rigidbody>().MovePosition(gameObject.GetComponent<Rigidbody>().position + Vector3.back * Velocidad * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            gameObject.GetComponent<Rigidbody>().MovePosition(gameObject.GetComponent<Rigidbody>().position + Vector3.left * Velocidad * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            gameObject.GetComponent<Rigidbody>().MovePosition(gameObject.GetComponent<Rigidbody>().position + Vector3.right * Velocidad * Time.deltaTime);
        }
        //Instrucciones para rotar el cubo
        if (Input.GetKey(KeyCode.Q))
        {
            gameObject.GetComponent<Transform>().Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            gameObject.GetComponent<Transform>().Rotate(Vector3.down * velocidadRotacion * Time.deltaTime);
        }
    }
    //Funciones de Colisiones ==> Despues de la funcion FixedUpdate() y antes de la funcion de Update()
    private void OnCollisionEnter(Collision collision)//Funcion para saber cuando se inicia la colision con otro objeto
    {
        Debug.Log(collision.gameObject.name);//Sentencia para saber con cual objeto del juego esta colisionando. Se imprime en consola
    }
    private void OnCollisionStay(Collision collision)//Funcion para saber el numero de colisiones con el objeto cada vez que se mueve el cubo.
    {
        Debug.Log(collision.gameObject.name);//Sentencia para saber con cual objeto del juego esta colisionando. Se imprime en consola
    }
    private void OnCollisionExit(Collision collision)// Funcion para saber cuando finaliza una colision deja de existir
    {
        Debug.Log(collision.gameObject.name);//Sentencia para saber con cual objeto del juego esta colisionando. Se imprime en consola
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}