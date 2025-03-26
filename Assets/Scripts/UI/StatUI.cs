using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatUI : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] GameObject statWindow;

    [SerializeField] TextMeshProUGUI attackTxt;
    [SerializeField] TextMeshProUGUI attackSpeedTxt;
    [SerializeField] TextMeshProUGUI speedTxt;
    [SerializeField] TextMeshProUGUI maxHPTxt;


    private void Start()
    {
        button.onClick.AddListener(ClickStatButton);
    }
    void ClickStatButton()
    {
        statWindow.SetActive(!statWindow.activeSelf);
    }
    public void UpdateAttack(int value)
    {
        attackTxt.text = value.ToString();
    }
    public void UpdateAttackSpeed(float value)
    {
        attackSpeedTxt.text = value.ToString();
    }
    public void UpdateSpeed(float value)
    {
        speedTxt.text = value.ToString();
    }
    public void UpdateMaxHP(int value)
    {
        maxHPTxt.text = value.ToString();
    }
}
