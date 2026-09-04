using UnityEngine;

public class Tester : MonoBehaviour
{
    public void Toggle()
    {
        bool set = !gameObject.activeSelf;
        gameObject.SetActive(set);
    }
}
