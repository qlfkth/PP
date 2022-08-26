using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform1 : MonoBehaviour
{
    public GameObject[] obstacles;
    private bool stepped = false;

    private void OnEnable()
    {
        stepped = false;

        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].SetActive(Random.Range(0, 10) == 0 ? true : false);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && !stepped)
        {
            stepped = true;
        }
    }
}
