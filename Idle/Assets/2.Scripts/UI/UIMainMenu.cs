using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    public TextMeshProUGUI txtName;
    public TextMeshProUGUI txtLv;
    public TextMeshProUGUI txtExp;
    public TextMeshProUGUI txtMoney;
    public Image imgExp;
    public GameObject goButtons;
    public Button btnStatus;
    public Button btnInventory;

    void Start()
    {
        btnStatus.onClick.AddListener(UIManager.Instance.OpenStatus);
        btnInventory.onClick.AddListener(UIManager.Instance.OpenInventory);
        RefreshUI();
    }

    public void RefreshUI()
    {
        txtName.text = GameManager.Instance.player.name;
        txtLv.text = $"{GameManager.Instance.player.lv}";
        txtExp.text = $"{GameManager.Instance.player.exp}/{GameManager.Instance.player.expMax}";
        txtMoney.text = GameManager.Instance.player.money.ToString("N0");
        imgExp.fillAmount = (float)GameManager.Instance.player.exp / (float)GameManager.Instance.player.expMax;
    }
}
