using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] Image curHPBar;
    [SerializeField] Image expBar;
    [SerializeField] TextMeshProUGUI goldTxt;
    [SerializeField] TextMeshProUGUI stageTxt;
    [SerializeField] TextMeshProUGUI levelTxt;

    private void Start()
    {
        GameManager.Instance.gameUI = this;
        GameManager.Instance.player.statHandler.UpdateAtStart(this);
        UpdateGold(GameManager.Instance.Gold);
        UpdateStage(GameManager.Instance.curStage);
    }
    public void UpdateHP(float value)
    {
        curHPBar.fillAmount = value;
    }
    public void UpdateExp(float value)
    {
        expBar.fillAmount = value;
    }
    public void UpdateGold(int value)
    {
        goldTxt.text = value.ToString();
    }
    public void UpdateStage(int value)
    {
        stageTxt.text = value.ToString();
    }
    public void UpdateLevel(int value)
    {
        levelTxt.text = value.ToString();
    }

}
