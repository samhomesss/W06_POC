using UnityEngine;

/// <summary>
/// 건축 버튼을 누르면 나올 UI의 자식 오브젝트 
/// 도시 관광 개발을 누르게 되면 추후에 List에 추가 하는 방식으로 생각하고 구조를 만들어야 됨 
/// </summary>
public class BuildingList : MonoBehaviour
{
    Building_Text _infoText; // 건축물의 설명 
    Building_Image _buildingImage; // 건축물 이미지
    Building_Button _building_Button; // 건축 하기 버튼 

    private void Start()
    {
        _infoText = GetComponentInChildren<Building_Text>();
        _buildingImage = GetComponentInChildren<Building_Image>();
        _building_Button = GetComponentInChildren<Building_Button>();


    }
}
