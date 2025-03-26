using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatHandler : BaseStatHandler
{
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
        
    }
    public void UpdateAtStart(GameUI gameUI)
    {
        gameUI.UpdateHP(CurHP / ((float)MaxHP));
        gameUI.UpdateLevel(Level);
        gameUI.UpdateExp(((float)Exp) / MaxExp);
    }
    protected override void CurHPChange(int value)
    {
        base.CurHPChange(value);
        GameManager.Instance.gameUI.UpdateHP(CurHP/((float)MaxHP));
    }
    protected override void LevelUp(int value)
    {
        base.LevelUp(value);
        GameManager.Instance.gameUI.UpdateLevel(Level);
    }
    protected override void GainExp(int value)
    {
        base.GainExp(value);
        GameManager.Instance.gameUI.UpdateExp(((float)Exp)/MaxExp);
    }
}
