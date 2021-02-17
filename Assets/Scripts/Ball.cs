/*
 * Autor: Daniel Gonzalez
 * Carne: 20293
 * Clase: Ball
 * 
 * Descripcion: Clase que permite manipular con fisica el movimiento de la pelota.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    public float force = 5.0f;
    Rigidbody rb;
    float positionY;

    public AudioClip coinSound;

    AudioSource audio;
    


    // Start is called before the first frame update
    void Start()
    {
        //Se inicia el score.
        //ScoreManager.setScore(score);

        
        rb = GetComponent<Rigidbody>();
        positionY = rb.position.y;

        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (rb)
        {
            //En caso se desee salta, se aplica una fuerza que crea un impulso en la pelota.
            if(Input.GetKeyDown(KeyCode.Space) && (Mathf.Abs(rb.velocity.y) <= 0.05f))
                rb.AddForce(0, force * Time.deltaTime *150, 0, ForceMode.Impulse); 
        }
    }

    private void FixedUpdate()
    {
        //Se mueve la pelota en el laberinto.
        if (rb)
            rb.AddForce(Input.GetAxis("Horizontal")*force, 0, Input.GetAxis("Vertical")*force);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Cuando ingresa a un trigger de tag lava, si no tiene 6 gemas, destruye al jugador.
        if (other.gameObject.CompareTag("Lava"))
        {
            if(ScoreManager.getScore() < 6)
            {
                Manager.deathSound();
                Destroy(gameObject);
            }
        }
        else if (other.gameObject.CompareTag("Gem")) //De lo contrario, sube su score en uno.
        {
            ScoreManager.setScore(ScoreManager.getScore()+1);
            other.gameObject.SetActive(false);
            Manager.coinSound();
        }
    }

}
