using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManagerController : MonoBehaviour
{

    public Text scoreText;
    public Text livesText;
    private int score;
    private int lives;
    // Start is called before the first frame update
    void Start()
    {
        score=0;
        lives=3;
        PrintScreenScore();
        PrintScreenLives();
    }

    public int Score(){

        return score;

    }
      public int Lives(){

        return lives;

    }
   public void GanarPuntos(int puntos){

    score += puntos;
    PrintScreenScore();
   }
    public void PerderVida(){

    lives -=1;
    PrintScreenLives();
   }

   private void PrintScreenScore(){
        scoreText.text = "Puntaje: " + score;

   }

   private void PrintScreenLives(){
        livesText.text = "Vida: " + lives;

   }
}
