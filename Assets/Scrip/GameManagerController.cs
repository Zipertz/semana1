using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
public class GameManagerController : MonoBehaviour
{
    public Text BalasText;
    public Text scoreText;
    public Text livesText;
    
    private int score;
    private int lives;
    private int balas;
    // Start is called before the first frame update
    void Start()
    {
        score=0;
        lives=3;
        balas=5;
        PrintScreenScore();
        PrintScreenLives();
        PrintScoreInScreen();
    }

    public void SaveGame(){


    }

    public void LoadGame(){

        
    }


    public int Score(){

        return score;

    }
      public int Lives(){

        return lives;

    }
      public int Balas(){

        return balas;

    }
   public void GanarPuntos(int puntos){

    score += puntos;
    PrintScreenScore();
   }
    public void PerderVida(){

    lives -=1;
    PrintScreenLives();
   }

    public void perderBala(int balas){
     this.balas-=1;
     PrintScoreInScreen();
    }

   
   private void PrintScreenScore(){
        scoreText.text = "Puntaje: " + score;

   }

   private void PrintScreenLives(){
        livesText.text = "Vida: " + lives;

   }

  
    private void PrintScoreInScreen(){
        BalasText.text = "Balas: " + balas;
    }
}




