using UnityEngine;
using UnityEngine.EventSystems;

public class MonsterUIController : MonoBehaviour, IPointerClickHandler
{
    private Monster monster;
    private MonsterDescUI monsterDescUI;

    public void Init(Monster monster)
    {
        this.monster = monster;
        monsterDescUI = GameManager.Instance.UI.MonsterDescUI;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        monsterDescUI.gameObject.SetActive(true);
        monsterDescUI.InitUI(monster.DataHandler.MonsterData);
    }
}
