using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeMove : MonoBehaviour
{

    /// <summary>
    /// Движение "врага" на определённых уровнях
    /// </summary>

    [SerializeField] float speed =  4;
    float time;
    float distance;
    [SerializeField] int angle = 90;
    [SerializeField] float way = 5;
    public static bool alive;
    void Start()
    {
        alive = true;
    }


    void Update()
    {
        if (alive)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            time += Time.deltaTime;
            distance = time * speed;//сколько прошёл куб 
            if (distance > way)
            {
                distance = 0;
                time = 0;
                transform.Rotate(0, 0, angle);
            }
        }
    }

    //private void OnCollisionEnter2D(Collision2D col)
    //{
    //    if (col.gameObject.tag == "Player")
    //    {
    //        throwhook.ropeActive = false;
    //    }

    //}

    //private void OnCollisionExit2D(Collision2D col)
    //{
    //    if (col.gameObject.tag == "Player")
    //    {
    //        throwhook.ropeActive = true;
    //    }

    //}

}
