using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pollunate : MonoBehaviour
{
    bool collided;
    private HexagonChange change;

    private void Awake()
    {
        change = GetComponent<HexagonChange>();
    }
    IEnumerator OnTriggerEnter(Collider collider)
    {
        collided = true;
        yield return new WaitForSeconds(2);
        if (collided)
        {
            change.SetNextTiles();
        }
    }

    void OnCollisionExit()
    {
        collided = false;
    }
}
