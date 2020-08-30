using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    /// <summary>
    /// Сцена с уровнями
    /// </summary>

    public static int countOpneLvl = 1;
    public static string[] lvl = new string[21];
    int countStars;

    [SerializeField] GameObject starDefault;
    [SerializeField] GameObject star1;
    [SerializeField] GameObject star2;
    [SerializeField] GameObject star3;

    [SerializeField] Sprite unlockedLvl;
    [SerializeField] Sprite lockedLvl;

//    [SerializeField] Text countStarsTxt;

    public int ColumnCount = 7;
    public int RowCount = 3;

    float posStar = -2.38f;
    float posStarY = -0.83f;
    int rowLvl;

    //private void Update()
    //{
    //    countStarsTxt.text = ("/" + PlayerPrefs.GetInt("CountOpenLvl") * 2).ToString();
    //}


    void Start()
    {

     // PlayerPrefs.DeleteAll();

        if(PlayerPrefs.GetInt("CountOpenLvl") > 0)
        {
            countOpneLvl = PlayerPrefs.GetInt("CountOpenLvl");
        }
            
        //cоздаём массив с названиями уровней
        for (int i = 0;i < 21; i++)
        {
           // countLvl = i;
            lvl[i] = "lvl" + (i + 1).ToString();
            Debug.Log(lvl[i]);
        }
        

        for(int i=0;i < transform.childCount; i++)
        {
            //Заменяем текст кнопок на соответствующий и имя
            int numLvl = i + 1;
            transform.GetChild(i).gameObject.name = numLvl.ToString();
            transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = numLvl.ToString();

            if(i < countOpneLvl)
            {
                transform.GetChild(i).GetComponent<Image>().sprite = unlockedLvl;
                transform.GetChild(i).GetComponent<Button>().interactable = true;
            }
            else
            {
                transform.GetChild(i).GetComponent<Image>().sprite = lockedLvl;
                transform.GetChild(i).GetComponent<Button>().interactable = false;
                transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = " ";
            }
        }
        //--------------------------------------------------------------------------------
            for (int i = 0; i < lvl.Length; i++)
            {
                countStars = PlayerPrefs.GetInt(lvl[i]);
                Debug.Log(countStars);
                if (countStars == 1)
                {
                Instantiate(star1, new Vector3(posStar, posStarY,100), transform.rotation);
                }
                else if (countStars == 2)
                {
                Instantiate(star2, new Vector3(posStar, posStarY, 100), transform.rotation);
                }
                else if(countStars == 3)
                {
                Instantiate(star3, new Vector3(posStar, posStarY, 100), transform.rotation);
                }
            else
            {
                Instantiate(starDefault, new Vector3(posStar, posStarY, 100), transform.rotation);
            }
            rowLvl += 1;//Cистема перехода.Когда пройдено 7 уровней,то меняем координаты появления звёзд.
            posStar += 3.168f;
            if (rowLvl == 7)
            {
                posStarY -= 3.601f;
                posStar = -2.38f;
            }
            if(rowLvl == 14)
            {
                posStarY -= 3.601f;
                posStar = -2.38f;
            }
            
            }
    }

}
