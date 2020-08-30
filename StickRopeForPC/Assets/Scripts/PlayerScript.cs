using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float force = 5;
    [SerializeField] GameObject clickButton;
    [SerializeField] GameObject tapAgain;
    public static bool isClicked;

    [SerializeField] AudioSource soundFall;

    void Start()
    {
        soundFall = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (throwhook.ropeActive && Input.GetKey(KeyCode.D))
        {
            if (SceneManager.GetActiveScene().name == "lvl1")
            {
                clickButton.SetActive(false);
                tapAgain.SetActive(true);
            }
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * force, ForceMode2D.Impulse);
        }
    }



    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.relativeVelocity.magnitude > 2)
        {
            soundFall.Play();
            soundFall.pitch = Random.Range(0.9f, 2);
        }
        
    }

}
