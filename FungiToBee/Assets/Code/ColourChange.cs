using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagons : MonoBehaviour
{
    SpriteRenderer sprite;
    [SerializeField] private float Timer;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        Timer = 0;
    }

    void Update()
    {

        Timer -= Time.deltaTime;
        if(Timer > 12)
        {
            sprite.color = Color.red;
        }

        if(Timer < 7)
        {
            sprite.color = Color.blue;
        }

        if(Timer < 0)
        {
            sprite.color = Color.black;
        }

    }

    public void startTimer()
    {
        Timer = Random.Range(5f, 20f);
        Debug.Log("start");
    }

    private void OnMouseDown()
    {
        startTimer();
    }
}
