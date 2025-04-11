using UnityEngine;

public class Player : MonoBehaviour
{
    public int PlayerThinkingID
    {
        get { return _playerThinkingID; }
        set
        {
            _playerThinkingID = value;
        }
    }

    [SerializeField] int _playerThinkingID;

    ThinkingImage _thinkingImage;
    private void Start()
    {
        _thinkingImage = GetComponentInChildren<ThinkingImage>();
        PlayerThinkingID = _thinkingImage.RandomThink;
    }
}
