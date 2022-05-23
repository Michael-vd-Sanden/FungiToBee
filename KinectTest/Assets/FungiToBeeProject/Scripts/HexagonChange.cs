using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonChange : MonoBehaviour
{
    public enum StateEnum {Blossum, Wither, Mycelium};
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
        CheckState();
    }
    void Update()
    {
        //CheckState();
    }

    public void CheckState()
    {
        switch (state)
        {
            case StateEnum.Blossum: BlossumState();
                break;
            case StateEnum.Wither:;
                break;
            case StateEnum.Mycelium: MyceliumState();
                break;
        }
    }

    private void BlossumState()
    {
        SetSpriteToFalse();
        tile3.SetActive(true);
        hexCollider.enabled = true;
        Invoke("Wither1State", WitherTimer);
    }

    private void Wither1State()
    {
        tile3.SetActive(false);
        tile2.SetActive(true);
        hexCollider.enabled = false;
        Invoke("Wither2State", WitherTimer);
    }

    private void Wither2State()
    {
        tile2.SetActive(false);
        tile1.SetActive(true);
        Invoke("DirtState", WitherTimer);
    }

    private void DirtState()
    {
        tile1.SetActive(false);
        tileDirt.SetActive(true);
    }

    private void MyceliumState()
    {
        SetSpriteToFalse();
        tileMycelium.SetActive(true);
        hexCollider.enabled = false;
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
            h.BlossumState();
        }
    }
}
