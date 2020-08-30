using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicContinue : MonoBehaviour
{
    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("BackgroundMus").Length == 1)
        {
            DontDestroyOnLoad(transform.gameObject);

        }
        else {
            Destroy(this.gameObject);
        }
    }

}
