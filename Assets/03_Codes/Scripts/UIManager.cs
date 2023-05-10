using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text moneyTXT;
    public Text levelsTXT;
    public Text hpTXT;
    public Text WaveTXT;
    public Text TimeRemainTXT;
    const string format = "{0}";
    public void Uimanager(int money, int levels, int hp, int waves, float timeremain)
    {
        int convertedValue = Mathf.RoundToInt(timeremain);
        moneyTXT.text = string.Format(format, money);
        levelsTXT.text = string.Format(format, levels);
        hpTXT.text = string.Format(format, hp);
        WaveTXT.text = string.Format(format, waves);
        TimeRemainTXT.text = string.Format(format, convertedValue);
    }
}
