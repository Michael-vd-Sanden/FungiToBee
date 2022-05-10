using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonChange : MonoBehaviour
{
    public enum StateEnum { Blossum, Wither1, Wither2, Dirt, Mycelium};
    public StateEnum state;
    public Stage stage;
    [SerializeField] private GameObject gameManager;

    [SerializeField] private GameObject tile3;
    [SerializeField] private GameObject tile2;
    [SerializeField] private GameObject tile1;
    [SerializeField] private GameObject tileDirt;
    [SerializeField] private GameObject tileMycelium;

    [SerializeField] private BoxCollider hexCollider;
    [SerializeField] private float WitherTimer = 0;
    private float maxActivationTimer = 2f;
    private float activationTimer;

    public List<HexagonChange> tilesNextTo;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        activationTimer = maxActivationTimer;
        WitherTimer = Random.Range(5f, 20f);
        CheckStage();
    }
    void Update()
    {
        CheckStage();
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
            // startWitherTimer();
            SetNextTiles();
            CheckStage();
            activationTimer = maxActivationTimer;
        }
    }

    public void CheckStage()
    {
        switch (state)
        {
            case StateEnum.Blossum: StartCoroutine(Blossum());
                break;
            case StateEnum.Wither1: StartCoroutine(Wither1());
                break;
            case StateEnum.Wither2: StartCoroutine(Wither2());
                break;
            case StateEnum.Dirt: StartCoroutine(Dirt());
                break;
            case StateEnum.Mycelium: StartCoroutine(Mycelium());
                break;
        }
        //switch (stage.GetStage())
        //{
        //    case 0:
        //        hexCollider.enabled = true;
        //        SetSpriteToFalse();
        //        tile3.SetActive(true);
        //        break;
        //    case 1:
        //        hexCollider.enabled = false;
        //        SetSpriteToFalse();
        //        tile2.SetActive(true);
        //        break;
        //    case 2:
        //        hexCollider.enabled = false;
        //        SetSpriteToFalse();
        //        tile1.SetActive(true);
        //        break;
        //    case 3:
        //        hexCollider.enabled = false;
        //        SetSpriteToFalse();
        //        tileDirt.SetActive(true);
        //        break;
        //    case 4:
        //        hexCollider.enabled = false;
        //        SetSpriteToFalse();
        //        tileMycelium.SetActive(true);
        //        break;
        //}
    }

    private IEnumerator Blossum()
    {
        SetSpriteToFalse();
        tile3.SetActive(true);
        hexCollider.enabled = true;

        yield return new WaitForSeconds(WitherTimer);
        state = StateEnum.Wither1;
    }

    private IEnumerator Wither1()
    {
        SetSpriteToFalse();
        tile2.SetActive(true);
        hexCollider.enabled = false;

        yield return new WaitForSeconds(WitherTimer);
        state = StateEnum.Wither2;
    }

    private IEnumerator Wither2()
    {
        SetSpriteToFalse();
        tile1.SetActive(true);
        hexCollider.enabled = false;

        yield return new WaitForSeconds(WitherTimer);
        state = StateEnum.Dirt;
    }

    private IEnumerator Dirt()
    {
        SetSpriteToFalse();
        tileDirt.SetActive(true);
        hexCollider.enabled = false;

        yield return null;
    }

    private IEnumerator Mycelium()
    {
        SetSpriteToFalse();
        tileMycelium.SetActive(true);
        hexCollider.enabled = false;

        yield return null;
    }

    public void SetSpriteToFalse()
    {
        tile3.SetActive(false);
        tile2.SetActive(false);
        tile1.SetActive(false);
        tileDirt.SetActive(false);
        tileMycelium.SetActive(false);
    }

    public void SetNextTiles()
    {
        foreach(HexagonChange h in tilesNextTo)
        {
            h.state = StateEnum.Blossum;
            //h.stage.SetStage(0);
            //h.startWitherTimer();
        }
    }
}
