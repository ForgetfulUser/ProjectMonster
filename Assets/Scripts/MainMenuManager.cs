using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void Overworld()
    {
        SceneManager.LoadScene("Overworld");
    }

    public void Maker()
    {
        SceneManager.LoadScene("Monster Maker Scene");
    }
}
