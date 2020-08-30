using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicScript : MonoBehaviour
{
    [SerializeField] Sprite musOn,musOff;
    Button btnMus;
    void Start()
    {
        btnMus = GetComponent<Button>();
        if(PlayerPrefs.GetString("Mus") == "off")
        {
            btnMus.image.sprite = musOff;
            btnMus.image.color = new Color32(212, 162, 29, 255);
            GameObject.FindGameObjectWithTag("BackgroundMus").GetComponent<AudioSource>().enabled = false;
        }
    }

    public void Music()
    {

         if (PlayerPrefs.GetString("Mus") == "off")//Действие при нажатии на кнопку звука
         {
            btnMus.image.sprite = musOn;
            btnMus.image.color = new Color32(255, 185, 0, 255);
            PlayerPrefs.SetString("Mus", "on");
            GameObject.FindGameObjectWithTag("BackgroundMus").GetComponent<AudioSource>().enabled = true;
        }
        else
        {
            btnMus.image.sprite = musOff;
            btnMus.image.color = new Color32(212, 162, 29, 255);
            PlayerPrefs.SetString("Mus", "off");
            GameObject.FindGameObjectWithTag("BackgroundMus").GetComponent<AudioSource>().enabled = false;
        }

    }
}
