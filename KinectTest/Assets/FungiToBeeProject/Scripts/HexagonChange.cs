using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonChange : MonoBehaviour
{
    public Stage stage;

    [SerializeField] private GameObject tile3;
    [SerializeField] private GameObject tile2;
    [SerializeField] private GameObject tile1;
    [SerializeField] private GameObject tileDirt;
    [SerializeField] private GameObject tileMycelium;

    [SerializeField] private BoxCollider hexCollider;
    [SerializeField] private float WitherTimer = 0;
    private float maxActivationTimer = 2f;
    private float activationTimer;

    private float timeStage3 = 12;
    private float timeStage2 = 8;
    private float timeStage1 = 4;
    private float timeDirt = 0;

    void Start()
    {
        activationTimer = maxActivationTimer;
        CheckStage();
    }
    void Update()
    {
        WitherTimer -= Time.deltaTime;
        if (WitherTimer > timeStage3)
        {
            stage.SetStage(0);
        }
        if (WitherTimer < timeStage2)
        {
            stage.SetStage(1);
        }
        if (WitherTimer < timeStage1)
        {
            stage.SetStage(2);
        }
        if (WitherTimer < timeDirt)
        {
            stage.SetStage(3);
        }
        CheckStage();
    }

    public void startWitherTimer()
    {
        WitherTimer = Random.Range(5f, 20f);
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
            startWitherTimer();
            CheckStage();
            activationTimer = maxActivationTimer;
        }
    }

    public void CheckStage()
    {
        switch (stage.GetStage())
        {
            case 0:
                hexCollider.enabled = true;
                SetSpriteToFalse();
                tile3.SetActive(true);
                break;
            case 1:
                hexCollider.enabled = false;
                SetSpriteToFalse();
                tile2.SetActive(true);
                break;
            case 2:
                hexCollider.enabled = false;
                SetSpriteToFalse();
                tile1.SetActive(true);
                break;
            case 3:
                hexCollider.enabled = false;
                SetSpriteToFalse();
                tileDirt.SetActive(true);
                break;
            case 4:
                hexCollider.enabled = true;
                SetSpriteToFalse();
                tileMycelium.SetActive(true);
                break;
        }
    }

    public void SetSpriteToFalse()
    {
        tile3.SetActive(false);
        tile2.SetActive(false);
        tile1.SetActive(false);
        tileDirt.SetActive(false);
        tileMycelium.SetActive(false);
    }
}
