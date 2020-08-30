using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class completeLvl : MonoBehaviour
{

    /// <summary>
    /// В этом скрипте все действия срабатывают после прохождения уровня
    /// </summary>

    GameObject player;
    float time;
    public static bool value;
    bool timeEnd;
    float timen;
    int timen2;
   // int countStarsForOpenLvl = 1;
   // int countStars;

    [SerializeField] Text txt;
    [SerializeField] GameObject panelComplate;
    [SerializeField] Text timeThisLvl;
    [SerializeField] Text timeBest;
    [SerializeField] Button pauseButton;
    [SerializeField] GameObject animStar1;
    [SerializeField] GameObject animStar2;
    [SerializeField] GameObject animStar3;

    [SerializeField] GameObject finishEffect1, finishEffect2;
     AudioSource finishMusic;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        value = false;
        timeEnd = true;
        finishMusic = this.gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        timen += Time.deltaTime;
        if (timen > 1 && timeEnd == true && ButtonControll.pauseOn == false)
        {
            timen2 += 1;
            timen = 0;
        }
        txt.text = timen2.ToString() + " sec";
        if (value == true)
        {
            time += Time.deltaTime;
            if (time > 2)
            {
                if (timen2 > 20 )
                {
                    animStar1.SetActive(true);

                    if (PlayerPrefs.GetInt("BestTime" + SceneManager.GetActiveScene().name) >= 20)
                    {
                        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);
                    }
                }
                else if(timen2 < 20 && timen2 > 15)
                {
                    animStar2.SetActive(true);
                    if(PlayerPrefs.GetInt("BestTime" + SceneManager.GetActiveScene().name) < 20  && PlayerPrefs.GetInt("BestTime" + SceneManager.GetActiveScene().name) > 15)                   {
                        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 2);
                    }
                }
                else
                {
                    animStar3.SetActive(true);
                    PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 3);
                }
               // Debug.Log("COMPLATE!");//Следующий левл

                if (SceneManager.GetActiveScene().buildIndex - 1 == LevelManager.countOpneLvl)
                {
                    //for (int i = 0; i < LevelManager.lvl.Length; i++)
                    //{
                    //    countStars += PlayerPrefs.GetInt(LevelManager.lvl[i]);
                    //}
                    //Debug.Log("Кол-во звёзд: " + countStars);
                    //if (countStars >= PlayerPrefs.GetInt("CountOpenLvl")*2)//countStarsForOpenLvl
                    //{
                    //    Debug.Log("Нужно звёзд: " + PlayerPrefs.GetInt("CountOpenLvl") * 2);                       
                        LevelManager.countOpneLvl++;

                        PlayerPrefs.SetInt("CountOpenLvl", LevelManager.countOpneLvl);
                  //  }
                    //countStars = 0;
                }

                timeThisLvl.text = timen2.ToString() + " sec";
                if (PlayerPrefs.GetInt("BestTime" + SceneManager.GetActiveScene().name) < timen2 && PlayerPrefs.GetInt("BestTime" + SceneManager.GetActiveScene().name) != 0)
                {
                    timeBest.text = "Best: " + PlayerPrefs.GetInt("BestTime" + SceneManager.GetActiveScene().name).ToString() + " sec";
                }
                else
                {
                    timeBest.text = "Best: " + timen2 + " sec";
                    PlayerPrefs.SetInt("BestTime" + SceneManager.GetActiveScene().name, timen2);
                }
                timeEnd = false;
                panelComplate.SetActive(true);
                pauseButton.interactable = false;
                //отключаем крутящиеся палки
                if (GameObject.FindGameObjectWithTag("stick") == true)
                {
                    GameObject.FindGameObjectWithTag("stick").GetComponent<stickRotation>().enabled = false;
                }
                finishEffects();//Эффекты и музыка после оконьчания уровня
                //Здесь реклама
                
            }
        }
    }

    void finishEffects()
    {

        //Instantiate(finishEffect1, transform.position, transform.rotation);
        // Instantiate(finishEffect2, transform.position, transform.rotation);
        finishEffect1.SetActive(true);
        finishEffect2.SetActive(true);
        finishMusic.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
            if (col.gameObject == player)
            {
                value = true;
            }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject == player)//и куб должен проваляться там секунды 3
        {
            time = 0;
            value = false;
        }
    }
}
