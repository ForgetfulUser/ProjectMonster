using UnityEngine;
using System.Collections.Generic;

public class CanvasManager : MonoBehaviour
{
    public List<Canvas> CanvasList;

    public void SwitchToCanvas(int id)
    {
        for (int i = 0; i < CanvasList.Count; i++)
        {
            CanvasList[i].gameObject.SetActive(i == id);
        }
    }
}
