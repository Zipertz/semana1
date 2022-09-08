using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        PrintScreenBalas();
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

    public void PerderBalas(){
        
        
        balas -=1;
        PrintScreenBalas();
    }
   private void PrintScreenScore(){
        scoreText.text = "Puntaje: " + score;

   }

   private void PrintScreenLives(){
        livesText.text = "Vida: " + lives;

   }

   private void PrintScreenBalas(){
       BalasText .text = "Balas: " + balas;

   }
}
