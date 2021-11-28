using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public int level;
    public List<GameObject> LevelList;
    private void Start()
    {
        level=PlayerPrefs.GetInt("level");
        if (level>=3)
        {
            level = 0;
        }
        Instantiate(LevelList[level]);
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }
    public void NextLevelButton()
    {
        level++;
        PlayerPrefs.SetInt("level", level);
        SceneManager.LoadScene(0);
    }
}
