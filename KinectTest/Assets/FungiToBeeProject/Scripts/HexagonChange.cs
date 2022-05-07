using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonChange : MonoBehaviour
{
    public Stage stage;
    [SerializeField] private GameObject gameManager;
    public TileList list;

    [SerializeField] private GameObject tile3;
    [SerializeField] private GameObject tile2;
    [SerializeField] private GameObject tile1;
    [SerializeField] private GameObject tileDirt;
    [SerializeField] private GameObject tileMycelium;

    [SerializeField] private BoxCollider hexCollider;
    [SerializeField] private float WitherTimer = 0;
    private float maxActivationTimer = 2f;
    private float activationTimer;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        list = gameManager.GetComponent<TileList>();
        activationTimer = maxActivationTimer;
        CheckStage();
    }
    void Update()
    {
    }

    IEnumerator Wither()
    {
        stage.SetStage(0);
        CheckStage();

        yield return new WaitForSeconds(WitherTimer);
        stage.SetStage(1);
        CheckStage();

        yield return new WaitForSeconds(WitherTimer);
        stage.SetStage(2);
        CheckStage();

        yield return new WaitForSeconds(WitherTimer);
        stage.SetStage(3);
        CheckStage();
    }

    public void startWitherTimer()
    {
        WitherTimer = Random.Range(5f, 20f);
        StartCoroutine(Wither());
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
            list.GetSurrounding(this.transform.position);
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
                hexCollider.enabled = false;
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
