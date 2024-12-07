using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chest1 : MonoBehaviour
{
   
    [SerializeField] private AudioClip chest;
    [SerializeField] ScreenFader next;
    private int fadeCount = 0;
    private bool nextLevel = false;

    bool fading = false;

   
    public void Update()
    {
        if(nextLevel)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                LoadNextScnene();
                nextLevel = false;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(fadeCount == 0)
            {
                next.FadeToColor();
                AudioManager.instance.PlaySound(chest);
                fadeCount++;
                nextLevel = true;
            }

        }
    }

    public void LoadNextScnene()
    {
        SceneManager.LoadScene("Level3");
    }

 
}
