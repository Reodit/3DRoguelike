using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart_hy : MonoBehaviour
{
    public GameObject gameStart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            gameStart.SetActive(false);
            SceneManager.LoadScene("UI2_hy");

        }
    }
}
