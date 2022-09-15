using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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
        LoadGame();
    }



    public void SaveGame(){
        var filePath = Application.persistentDataPath + "/semana2.dat";
        FileStream file;

        if(File.Exists(filePath))
            file = File.OpenWrite(filePath);
        else    
            file = File.Create(filePath);

        GameData data = new GameData();
        data.Score = score;
        data.Balas = balas;
        data.Lives = lives;
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file,data);
        file.Close();

    }

    public void LoadGame(){
            var filePath = Application.persistentDataPath + "/semana2.dat";
        FileStream file;

        if(File.Exists(filePath)){
            file = File.OpenRead(filePath);
        }
        else    {
            Debug.LogError("No se encontreo archivo");
            return;
        }
        BinaryFormatter bf = new BinaryFormatter();
        GameData data = (GameData) bf.Deserialize(file);
        file.Close();

        //utilizar los datos guardados
        score = data.Score;
        balas = data.Balas;
        lives = data.Lives;
        PrintScoreInScreen();
        PrintScreenScore();
        PrintScreenLives();
        
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

    this.lives -=1;
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




