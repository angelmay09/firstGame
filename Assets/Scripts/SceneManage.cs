using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public void GameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Appquit()
    {
        Application.Quit();
    }
}
