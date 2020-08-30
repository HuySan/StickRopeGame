using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonControll : MonoBehaviour
{
    /// <summary>
    /// Отвечает за все нажатия на кнопки
    /// </summary>

     [SerializeField]  GameObject menu;
     [SerializeField] AudioSource soundForMainButton;
     [SerializeField] AudioSource soundForLevelButton;
    public static bool pauseOn;
    GameObject player;
    private void Start()
    {
        pauseOn = false;
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    public void ReplayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Pause()
    {
        menu.SetActive(true);
        pauseOn = true;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        cubeMove.alive = false;
        if (GameObject.FindGameObjectWithTag("stick") == true)
        {
            GameObject.FindGameObjectWithTag("stick").GetComponent<stickRotation>().enabled = false;
        }
    }

    
    public void SoundForMain()
    {
        soundForMainButton.Play();
    }

    public void SoundForLevel()
    {
        soundForLevelButton.Play();
    }


    public void Resume()
    {
        //Тут мы снова должны включить ранее выключенные компоненты
        pauseOn = false;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        menu.SetActive(false);
        if (GameObject.FindGameObjectWithTag("stick") == true)
        {
            GameObject.FindGameObjectWithTag("stick").GetComponent<stickRotation>().enabled = true;
        }
        cubeMove.alive = true;
    }

    public void ChangeScene(int number)
    {
        SceneManager.LoadScene(number);
    }

}
