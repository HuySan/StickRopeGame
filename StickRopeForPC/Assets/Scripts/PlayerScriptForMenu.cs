using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScriptForMenu : MonoBehaviour
{
    [SerializeField] float force = 5;
    float timeing;
    void Start()
    {
        StartCoroutine(time());
    }

    void Update()
    {
        timeing = Random.Range(0, 2);
    }

    IEnumerator time()
    {
        while (true)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * force, ForceMode2D.Impulse);
            yield return new WaitForSeconds(timeing);
        }
    }
}
