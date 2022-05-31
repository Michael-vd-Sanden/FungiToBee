using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pollunate : MonoBehaviour
{
    bool collided;
    private HexagonChange change;
    public enum tileEnum {Flower, Bush};
    public tileEnum tile;
    public Score score;
    [SerializeField] private GameObject gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        score = gameManager.GetComponent<Score>();
        change = GetComponent<HexagonChange>();
    }
    IEnumerator OnTriggerEnter(Collider collider)
    {
        collided = true;
        yield return new WaitForSeconds(1.5f);
        if (collided)
        {
            change.SetNextTiles();
            if (collider.name == "BeePlayer")
            {
                score.upScoreByOne("Bee");
                //if (tile == tileEnum.Bush)
                //{
                //    score.upScoreByOne("Bee");
                //}
                //else if(tile == tileEnum.Flower)
                //{
                //    score.upScoreByTwo("Bee");
                //}
            }
            if (collider.name == "ButterflyPlayer")
            {
                score.upScoreByOne("Butterfly");
                //if (tile == tileEnum.Bush)
                //{
                //    score.upScoreByTwo("Butterfly");
                //}
                //else if (tile == tileEnum.Flower)
                //{
                //    score.upScoreByOne("Butterfly");
                //}
            }
        }
    }

    public void OnTriggerExit()
    {
        collided = false;
    }
}
