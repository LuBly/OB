using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterDescUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameTxt;
    [SerializeField] private TextMeshProUGUI gradeTxt;
    [SerializeField] private TextMeshProUGUI speedTxt;
    [SerializeField] private TextMeshProUGUI healthTxt;
    [SerializeField] private Button exit;
    public TextMeshProUGUI NameTxt => nameTxt;
    public TextMeshProUGUI GradeTxt => gradeTxt;
    public TextMeshProUGUI SpeedTxt => speedTxt;
    public TextMeshProUGUI HealthTxt => healthTxt;

    private void Awake()
    {
        exit.onClick.RemoveAllListeners();
        exit.onClick.AddListener(CloseUI);
    }

    public void InitUI(MonsterData monsterData)
    {
        gameObject.SetActive(true);
        nameTxt.text = $"Name : {monsterData.Name}";
        gradeTxt.text = $"Grade : {monsterData.Grade}";
        speedTxt.text = $"Speed : {monsterData.Speed}";
        healthTxt.text = $"Health : {monsterData.MaxHealth}";
    }

    private void CloseUI()
    {
        gameObject.SetActive(false);
    }
}
