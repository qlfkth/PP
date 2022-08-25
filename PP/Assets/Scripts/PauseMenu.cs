using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseUi;

    private bool Paused = false;
    void Start()
    {
        PauseUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Paused = !Paused;
        }
        if (Paused)
        {
            PauseUi.SetActive(true);
            Time.timeScale = 0;
        }

        if (!Paused)
        {
            PauseUi.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
