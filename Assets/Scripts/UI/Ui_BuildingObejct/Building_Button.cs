using UnityEngine;
using UnityEngine.UI;

public class Building_Button : MonoBehaviour
{
    Button _button;
    UI_BuildingObject _uiBuildingObj;

    void Start()
    {
        _uiBuildingObj = FindAnyObjectByType<UI_BuildingObject>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ButtonClick);
    }

    void ButtonClick()
    {
        // Todo : 여기서 클릭했을때 마우스 위치에 건축물 건설 할 수 있으면 됨 
        // Todo : 오브젝트 다꺼지는거 Action으로 연결 해야 될 듯?
        _uiBuildingObj.GetComponent<Canvas>().enabled = false;
    }
}
