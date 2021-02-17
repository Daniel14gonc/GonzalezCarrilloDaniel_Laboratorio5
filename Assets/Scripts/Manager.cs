/*
 * Autor: Daniel Gonzalez
 * Carne: 20293
 * Clase: Manger
 * 
 * Descripcion: Clase que permite manejar las instancias de la pelota, su asignacion de camara y la muestra
 *  del score al usuario.
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour

{

    public GameObject spawn;
    public GameObject player;
    public GameObject gem;
    public GameObject currentPlayer;
    public GameObject cam;
    public GameObject pauseMenu;
    public GameObject soundMenu;

    public AudioClip death;
    public AudioClip morty;
    public AudioClip coin;

    static AudioSource audio;

    static AudioClip deathS;
    static AudioClip mortyS;
    static AudioClip coinS;

    public GameObject bocina;

    CameraMovement camMov;
    public Text scoreText;

    bool sound;



    // Start is called before the first frame update
    void Start()
    {
        //Se envian como argumentos las posiciones que debe seguir la camara cuando se instancia la pelota.
        camMov = cam.GetComponent<CameraMovement>();
        currentPlayer = Instantiate(player, spawn.transform.position, Quaternion.identity);
        camMov.lookTarget = currentPlayer.transform;
        camMov.camTarget = currentPlayer.transform;
        Time.timeScale = 1.0f;

        audio = GetComponent<AudioSource>();
        deathS = death;
        mortyS = morty;
        coinS = coin;
    }

    // Update is called once per frame
    void Update()
    {
        //Si se ingresa escape, se muestra el menu.
        if (Input.GetKeyDown(KeyCode.Escape) && !sound)
        {
            togglePause();
        }

        //Se crea de nuevo la pelota, en caso haya muerto.
        if (spawn && Input.GetKeyDown(KeyCode.Return) && player)
        {
            if (currentPlayer == null)
            {
                currentPlayer = Instantiate(player, spawn.transform.position, Quaternion.identity);
                camMov.lookTarget = currentPlayer.transform;
                camMov.camTarget = currentPlayer.transform;
            }
        }

        scoreText.text = "Score\n" + ScoreManager.getScore();

    }

    public void togglePause()
    {
        //Metodo que, si existe, permite mostrar el menu de pausa y detener el juego.
        if (pauseMenu)
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            Time.timeScale = (pauseMenu.activeSelf) ? 0.0f : 1.0f;

            if (pauseMenu.activeSelf)
            {
                bocina.GetComponent<AudioSource>().Pause();
            }
            else
            {
                bocina.GetComponent<AudioSource>().UnPause();
            }
                
        }
    }

    public void mainMenu()
    {
        //Metodo que permite regresar al menu principal.
        SceneManager.LoadScene(0);
        ScoreManager.setScore(0);
    }

    public void restart()
    {
        ScoreManager.setScore(0);
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }

    public static void deathSound()
    {
        if (deathS && mortyS)
        {
            audio.PlayOneShot(mortyS);
            audio.PlayOneShot(deathS);
        }
    }

    public static void coinSound()
    {
        if (coinS)
        {
            audio.PlayOneShot(coinS);
        }
    }

    public void soundM()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        soundMenu.SetActive(!soundMenu.activeSelf);
        if (soundMenu.activeSelf) 
        {
            sound = true;
        }
        else
        {
            sound = false;
        }
             
    }

}
