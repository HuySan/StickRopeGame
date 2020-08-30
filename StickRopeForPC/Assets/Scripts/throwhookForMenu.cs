using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwhookForMenu : MonoBehaviour
{
    [SerializeField] GameObject hook;
    GameObject curHook;
    void Start()
    {
        Vector2 destiny = new Vector2(0.88f, 2.6f);
        curHook = Instantiate(hook, transform.position, Quaternion.identity) as GameObject;
        curHook.GetComponent<ropeScriptForMenu>().destiny = destiny;//эта позиция передаётся другому скрипту,где теперь такие же координаты
    }

    void Update()
    {
        Debug.Log(Input.mousePosition);


    }
}
