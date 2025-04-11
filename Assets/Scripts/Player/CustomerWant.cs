using UnityEngine;

public class CustomerWant : MonoBehaviour
{
    Player _player;
    FoodBuilding[] _foodBuildings;

    Vector2 _playerTargetPos; // 플레이어가 가야 하는 위치
    float _moveSpeed = 2f;    // 이동 속도
    bool _isMovingX = true;   // X축 이동 중인지 여부
    bool _isMoveFinished = false;

    private void Start()
    {
        _player = GetComponent<Player>();
        if (_player == null)
        {
            Debug.LogError("Player component not found!");
            enabled = false; // 스크립트 비활성화
            return;
        }

        _foodBuildings = GameObject.FindObjectsByType<FoodBuilding>(FindObjectsSortMode.None);
        if (_foodBuildings.Length == 0)
        {
            _isMoveFinished = true;
            return;
        }

        foreach (var building in _foodBuildings)
        {
            if (_player.PlayerThinkingID == building.buildingID)
            {
                _playerTargetPos = building.transform.position;
                break;
            }
        }

    }

    private void Update()
    {
        if (_isMoveFinished) return;

        Vector2 currentPos = transform.position;
        if (_isMovingX)
        {
            float newX = Mathf.MoveTowards(currentPos.x, _playerTargetPos.x, _moveSpeed * Time.deltaTime);
            transform.position = new Vector2(newX, currentPos.y);

            if (Mathf.Approximately(newX, _playerTargetPos.x)) // 근사치 비교 
            {
                _isMovingX = false; // X축 이동 완료
            }
        }
        else
        {
            float newY = Mathf.MoveTowards(currentPos.y, _playerTargetPos.y, _moveSpeed * Time.deltaTime);
            transform.position = new Vector2(currentPos.x, newY);

            if (Mathf.Approximately(newY, _playerTargetPos.y))
            {
                _isMoveFinished = true;
            }
        }
    }
}
