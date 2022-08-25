using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instanse;
    public GameObject menuSet;
   

    public bool isGameover = false;
    public TextMeshProUGUI timeText;
    public GameObject gameoverUi;
    

    private float surviveTime;
    private bool isGamever;

    private void Awake()
    {
        if (instanse == null)
        {
            instanse = this;
        }
        else
        {
            Debug.LogWarning("���� �� �� �̻��� ���� �Ŵ����� �����մϴ�!");
            Destroy(gameObject);
        }
    }
    void Start()
    {
        surviveTime = 0;
        isGameover = false;
        
        


    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time:" + (int)surviveTime;
        }

        if (isGameover && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
                menuSet.SetActive(false);
            else
                menuSet.SetActive(true);

            ;
                

        }
    }
    public void OnPlayerDead()
    {
        
        isGameover = true;
        gameoverUi.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene
            (SceneManager.GetActiveScene().name);
    }
    public void Exit()
    {
        Application.Quit();
    }

}
