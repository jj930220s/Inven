using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    public TextMeshProUGUI txtAttack;
    public TextMeshProUGUI txtArmor;
    public TextMeshProUGUI txtHp;
    public TextMeshProUGUI txtCritical;
    public Button btnBack;

    void Start()
    {
        btnBack.onClick.AddListener(UIManager.Instance.OpenMainMenu);
        RefreshUI();
    }

    public void RefreshUI()
    {
        txtAttack.text = $"{GameManager.Instance.player.attack}";
        txtArmor.text = $"{GameManager.Instance.player.armor}";
        txtHp.text = $"{GameManager.Instance.player.hp}";
        txtCritical.text = $"{GameManager.Instance.player.critical}";
    }
}
