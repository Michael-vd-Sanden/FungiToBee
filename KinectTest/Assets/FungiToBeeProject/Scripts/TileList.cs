using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileList : MonoBehaviour
{
    public List<GameObject> Tiles;

    public void GetSurrounding(Vector3 thisPosition)
    {
        float xPosThis = thisPosition.x;
        float yPosThis = thisPosition.y;
        foreach (GameObject g in Tiles)
        {
            float xPosI = g.transform.position.x;
            float yPosI = g.transform.position.y;
            if ((xPosThis - xPosI) < 1 && (xPosThis - xPosI) > -1 ||
                (yPosThis - yPosI) < 1 && (yPosThis - yPosI) > -1 &&
                xPosThis != xPosI && yPosThis != yPosI)
            {
                g.GetComponent<Stage>().SetStage(0);
                g.GetComponent<HexagonChange>().startWitherTimer();
            }
        }
    }
}
