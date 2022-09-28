using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;
public class Menu : MonoBehaviour
{
    public SpriteRenderer srCambioPersonaje;
    public Sprite[] sprites;
    private int next = 1;





    public void PlayGame ()
    {

       SceneManager.LoadScene(1);

    }

     public void CambioPersonaje ()
    {

       srCambioPersonaje.sprite = sprites[next];
       next++;
       if(next == sprites.Length)
       {
            next = 0;
       }

    }

}
