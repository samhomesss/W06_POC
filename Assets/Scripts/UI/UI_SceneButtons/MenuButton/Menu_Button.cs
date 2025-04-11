using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Button : MonoBehaviour
{
    Button _button;
    UI_Menu _uiMenu; // 메뉴창 
    TMP_Text _menuText; // 메뉴창 텍스트 

    void Start()
    {
        _uiMenu = FindAnyObjectByType<UI_Menu>();
        _menuText = GetComponentInChildren<TMP_Text>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ButtonClick);
    }

    void ButtonClick()
    {
        _uiMenu.GetComponent<Canvas>().enabled = !_uiMenu.GetComponent<Canvas>().enabled;

        if (_uiMenu.GetComponent<Canvas>().enabled)
            _menuText.text = "뒤로";
        else
            _menuText.text = "메뉴창";
    }
}
