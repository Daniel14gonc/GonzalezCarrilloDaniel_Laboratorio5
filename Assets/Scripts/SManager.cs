/*
 * Autor: Daniel Gonzalez
 * Carne: 20293
 * Clase: SManager
 * 
 * Descripcion: Clase que permite manejar las escenas.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class SManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startGame()
    {
        //Se inicia la escena del juego.
        SceneManager.LoadScene(1);
    }

    public void finishGame()
    {
        //Se termina el juego.
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
