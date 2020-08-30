using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push : MonoBehaviour
{
    /// <summary>
    /// Скрипт "врага" на определённых уровнях
    /// </summary>


    [SerializeField] float thrust = 10;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<Rigidbody2D>().AddForce((transform.position - col.transform.position).normalized * thrust, ForceMode2D.Impulse);
            Destroy(throwhook.curHook);
            throwhook.ropeActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            throwhook.ropeActive = false;
        }
    }
}
