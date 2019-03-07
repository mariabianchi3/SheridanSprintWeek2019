using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public string levelname;

    public void loadLevel()
    {
        SceneManager.LoadScene(levelname);
    }

    public void togglePanel(GameObject go)
    {
        go.SetActive(!go.activeSelf);
    }
}
