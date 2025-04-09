using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Food")]
public class FoodData : ScriptableObject
{
    public int foodID; // 음식 ID
    public Sprite foodImage; // 음식 이미지 
}
