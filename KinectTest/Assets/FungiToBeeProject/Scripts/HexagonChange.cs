using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonChange : MonoBehaviour
{
    public enum StateEnum {Blossum, Wither1, Wither, Mycelium};
    public StateEnum state;
    [SerializeField] private GameObject gameManager;
    public int previousState;

    public bool isGreen;
    public bool isDead;

    [SerializeField] private GameObject tile3;
    [SerializeField] private GameObject tile2;
    [SerializeField] private GameObject tile1;
    [SerializeField] private GameObject tileDirt;
    [SerializeField] private GameObject tileMycelium;

    [SerializeField] private BoxCollider hexCollider;
    [SerializeField] private float WitherTimer = 0;

    public List<HexagonChange> tilesNextTo;

    void Start()
    {
        isGreen = false;
        isDead = true;
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        WitherTimer = Random.Range(11f,22f);
        CheckState();
        previousState = 0;
    }
    void Update()
    {
        //CheckState();
    }

    public bool GetisGreen()
    {
        return isGreen;
    }

    public bool GetisDead()
    {
        return isDead;
    }

    public void CheckState()
    {
        switch (state)
        {
            case StateEnum.Blossum: BlossumState();
                break;
            case StateEnum.Wither1: Wither1State();
                break;
            case StateEnum.Wither:;
                break;
            case StateEnum.Mycelium: MyceliumState();
                break;
        }
    }

    private void BlossumState()
    {
        if (previousState == 0)
        {
            isDead = false;
            isGreen = true;
            SetSpriteToFalse();
            tile3.SetActive(true);
            hexCollider.enabled = true;
            previousState = 1;
            Invoke("Wither1State", WitherTimer);
        }
    }

    private void Wither1State()
    {
        if (previousState == 1)
        {
            isDead = false;
            isGreen = true;
            SetSpriteToFalse();
            tile2.SetActive(true);
            hexCollider.enabled = false;
            previousState = 2;
            Invoke("Wither2State", WitherTimer);
        }
    }

    private void Wither2State()
    {
        if (previousState == 2)
        {
            isDead = false;
            isGreen = true;
            SetSpriteToFalse();
            tile1.SetActive(true);
            previousState = 3;
            Invoke("DirtState", WitherTimer);
        }
    }

    private void DirtState()
    {
        if (previousState == 3)
        {
            isDead = true;
            isGreen = false;
            SetSpriteToFalse();
            tileDirt.SetActive(true);
            previousState = 4;
        }
    }

    private void MyceliumState()
    {
        isDead = true;
        isGreen = false;
        SetSpriteToFalse();
        tileMycelium.SetActive(true);
        hexCollider.enabled = false;
        previousState = 5;
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
            h.previousState = 0;
            h.BlossumState();
        }
    }
}
