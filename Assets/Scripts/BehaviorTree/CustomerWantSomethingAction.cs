using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "CustomerWantSomething", story: "[Self] is WantSomething and Go", category: "Action", id: "6809af87f86a2d2edffcd4d3e5fb7d6c")]
public partial class CustomerWantSomethingAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<Boolean> CustomerIsArrive;

    Player _player;
    FoodBuilding[] _foodBuildings;

    Vector2 _playerTargetPos; // 플레이어가 가야 하는 위치
    float _moveSpeed = 2f;    // 이동 속도
    bool _isMovingX = true;   // X축 이동 중인지 여부
    bool _isMoveFinished = false;

    int _buildingIDCheck; // 현재 가고 있는 건물의 ID를 체크 

    protected override Status OnStart()
    {
        _player = Self.Value.GetComponent<Player>();
        _foodBuildings = GameObject.FindObjectsByType<FoodBuilding>(FindObjectsSortMode.None);

        _player = GameObject.GetComponent<Player>();
        if (_player == null)
        {
            return Status.Failure;
        }

        if (_foodBuildings.Length == 0)
        {
            _isMoveFinished = true;
            return Status.Failure;
        }

        foreach (FoodBuilding building in _foodBuildings)
        {
            if (_player.PlayerThinkingID == building.buildingID)
            {
                _playerTargetPos = building.transform.position;
                _buildingIDCheck = building.buildingID;
                break;
            }
        }

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (_player.PlayerThinkingID != _buildingIDCheck)
        {
            _foodBuildings = GameObject.FindObjectsByType<FoodBuilding>(FindObjectsSortMode.None);

            foreach (FoodBuilding building in _foodBuildings)
            {
                if (_player.PlayerThinkingID == building.buildingID)
                {
                    _playerTargetPos = building.transform.position;
                    _buildingIDCheck = building.buildingID;
                    break;
                }
            }
        }

        if (_isMoveFinished) return Status.Failure;

        Vector2 currentPos = Self.Value.transform.position;

        if (_isMovingX)
        {
            float newX = Mathf.MoveTowards(currentPos.x, _playerTargetPos.x, _moveSpeed * Time.deltaTime);
            Self.Value.transform.position = new Vector2(newX, currentPos.y);

            if (Mathf.Approximately(newX, _playerTargetPos.x)) // 근사치 비교 
            {
                _isMovingX = false; // X축 이동 완료
            }
        }
        else
        {
            float newY = Mathf.MoveTowards(currentPos.y, _playerTargetPos.y, _moveSpeed * Time.deltaTime);
            Self.Value.transform.position = new Vector2(currentPos.x, newY);

            if (Mathf.Approximately(newY, _playerTargetPos.y))
            {
                _isMoveFinished = true;
                CustomerIsArrive.Value = true;
                return Status.Success;
            }
        }

        return Status.Running;
    }

    protected override void OnEnd()
    {
        _isMovingX = true;   // X축 이동 중인지 여부
        _isMoveFinished = false;
    }
}

