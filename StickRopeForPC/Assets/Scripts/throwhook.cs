using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class throwhook : MonoBehaviour
{
    [SerializeField] GameObject hook;
    public static GameObject curHook;
    [SerializeField] GameObject tap;
    [SerializeField] GameObject clickButton;
    [SerializeField] GameObject tapAgain;

    public static bool ropeActive;

    void FixedUpdate()
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        Vector3 destiny = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit2D hit = Physics2D.Linecast(transform.position, destiny,layerMask);

            if (ropeActive == false && hit == false && completeLvl.value == false && ButtonControll.pauseOn == false)
            {
                curHook = Instantiate(hook, transform.position, Quaternion.identity) as GameObject;
                curHook.GetComponent<ropeScript>().destiny = destiny;
                ropeActive = true;
                //Только для первого уровня
                if (SceneManager.GetActiveScene().name == "lvl1")
                {
                    tap.SetActive(false);
                    clickButton.SetActive(true);
                }
            }

            else
            {
                //delete rope
                Destroy(curHook);
                    if (SceneManager.GetActiveScene().name == "lvl1")
                    {   
                        tapAgain.SetActive(false);
                    }
                ropeActive = false;
            }

            
        }
    }

}
