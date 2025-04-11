using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 음식 뿐만이 아니라 회사 견학이라던지 관광 할 수 있는 것들에 대한 데이터 저장 방식으로 사용  
/// </summary>
public class FoodDataBase : MonoBehaviour
{
    public static Dictionary<int, FoodData> FoodData => _foodData;
    static Dictionary<int, FoodData> _foodData = new Dictionary<int, FoodData>();

    private void Awake()
    {
        // Todo : 음식 데이터 저장 
        AddData(0 , "Noodles");
        AddData(1 , "Rice");
        AddData(2 , "JamPong");
    }

    void AddData(int id, string path)
    {
        if (!_foodData.ContainsKey(id))
            _foodData.Add(id, Resources.Load<FoodData>($"Data/{path}"));
        else
            return;
    }


}
