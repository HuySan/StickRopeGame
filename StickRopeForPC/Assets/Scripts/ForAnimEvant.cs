using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForAnimEvant : MonoBehaviour
{

    /// <summary>
    /// Отвечает за анимацию звёзд после прохождения уровня
    /// </summary>

    [SerializeField] GameObject impactEffect;
    GameObject star1;
    GameObject star2;
    GameObject star3;

    private void Start()
    {
         star1 = GameObject.FindGameObjectWithTag("star1");
         star2 = GameObject.FindGameObjectWithTag("star2");
         star3 = GameObject.FindGameObjectWithTag("star3");
    }

    public void Effect1()
    {
        Instantiate(impactEffect, star1.transform.position, star1.transform.rotation) ;
    }
    public void Effect2()
    {
        Instantiate(impactEffect, star2.transform.position, star2.transform.rotation);
    }
    public void Effect3()
    {
        Instantiate(impactEffect, star3.transform.position, star3.transform.rotation);
    }
}
