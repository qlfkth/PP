using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 5f;
    
    private void Update()
    {
        if (!GameManager.instanse.isGameover)
        {
             transform.Translate(Vector3.left * speed * Time.deltaTime);            
        }
    }
}
