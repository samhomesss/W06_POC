using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 행동 트리에서 사용하기 위한 Instanciate
/// </summary>
public class InstanciateForTree : MonoBehaviour
{
    GameObject _foodEffect;
    Player _player;

    int foodID;

    private void Start()
    {
        _player = GetComponent<Player>();
        _foodEffect = Resources.Load<GameObject>($"Effect/FoodEffect{_player.PlayerThinkingID}");
    }

    private void Update()
    {
        if (foodID == _player.PlayerThinkingID)
            return;

        _foodEffect = Resources.Load<GameObject>($"Effect/FoodEffect{_player.PlayerThinkingID}");
        foodID = _player.PlayerThinkingID;
    }

    public GameObject InstantiateObject()
    {
        return Instantiate(_foodEffect, transform.position, Quaternion.identity);
    }

    public void DestoryObj(GameObject go , float destroyTime = 0)
    {
        Destroy(go , destroyTime);
    }
}
