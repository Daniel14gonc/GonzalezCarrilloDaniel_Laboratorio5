/*
 * Autor: Daniel Gonzalez
 * Carne: 20293
 * Clase: ScoreManger
 * 
 * Descripcion: Clase que permite manejar el score de las instancias del jugador.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    static int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void setScore(int value)
    {
        //Cambia el valor del score del jugador.
        score = value;
    }

    public static int getScore()
    {
        //Obtiene el valor del score.
        return score;
    }
}
