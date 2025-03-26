using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectUI : MonoBehaviour
{
    public void OnClickStage(int stage)
    {
        GameManager.Instance.curStage = stage;
        SceneManager.LoadScene("GameScene");
    }
}
