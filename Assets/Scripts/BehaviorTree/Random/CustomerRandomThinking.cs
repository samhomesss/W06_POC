using UnityEngine;
using UnityEngine.UI;

public class CustomerRandomThinking : MonoBehaviour
{
    Player _player;
    ThinkingImage _customerThinkingImage;
    int _random;
    const int FOOD_CATEGORY = 3;

    private void Start()
    {
        _player = GetComponent<Player>();
        _customerThinkingImage = Util.FindChild<ThinkingImage>(this.gameObject, "ThinkingImage", true);
        RandomThinking();
    }

    public int RandomThinking()
    {
        _random = Random.Range(0, FOOD_CATEGORY);
        _player.PlayerThinkingID = _random;
        _customerThinkingImage.RandomThink = _random;
        return _random;
    }
}
