using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int curStage;
    public Player player;
    public GameUI gameUI;

    private int gold;
    public int Gold
    {
        get { return gold; }
        set
        {
            gold = value;
            gameUI?.UpdateGold(Gold);
        }
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
