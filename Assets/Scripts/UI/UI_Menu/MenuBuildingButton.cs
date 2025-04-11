using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 추후에 다 닫히도록 해야 될듯?
/// </summary>
public class MenuBuildingButton : MonoBehaviour
{
    UI_BuildingObject _uiBuildingObj; // 건축 UI
    Button _button;

    private void Start()
    {
        _uiBuildingObj = FindAnyObjectByType<UI_BuildingObject>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ButtonClick);
    }

    void ButtonClick()
    {
        _uiBuildingObj.GetComponent<Canvas>().enabled = !_uiBuildingObj.GetComponent<Canvas>().enabled;
    }
}
