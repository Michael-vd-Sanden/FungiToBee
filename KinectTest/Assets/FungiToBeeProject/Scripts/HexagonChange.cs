using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonChange : MonoBehaviour
{
    private float maxActivationTimer = 5f;
    private float activationTimer;
    [SerializeField] private SpriteRenderer dirt;

    void Start()
    {
        dirt = GetComponentInChildren<SpriteRenderer>();
        activationTimer = maxActivationTimer;
        dirt.enabled = true;
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
    }

    private void OnTriggerStay(Collider other)
    {
        activationTimer -= Time.deltaTime;

        if(activationTimer < 0)
        {
            Debug.Log("Pressed");
            dirt.enabled = false;
            activationTimer = maxActivationTimer;
        }
    }
}
