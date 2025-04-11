using UnityEngine;

public class Tester_CityCrafting : MonoBehaviour
{
    BuildingListParent _buildingList;
    GameObject _buildList;


    void Start()
    {
        _buildingList = FindAnyObjectByType<BuildingListParent>();
        _buildList = Resources.Load<GameObject>("UI/BuildingList");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject go = Instantiate(_buildList);
            go.transform.parent = _buildingList.transform;
        }
    }


}
