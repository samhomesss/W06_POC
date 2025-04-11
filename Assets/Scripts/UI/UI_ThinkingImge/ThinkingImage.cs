using UnityEngine;
using UnityEngine.UI;

public class ThinkingImage : MonoBehaviour
{
    public int RandomThink
    {
        get { return _randomThink; }
        set 
        {
            _randomThink = value;
            ChangeObejctImage(_randomThink);
        }
    }
    Player _player;
    Image _image;

    int _randomThink;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Start()
    {
        _player = transform.parent.parent.parent.parent.GetComponent<Player>();

        _image.sprite = FoodDataBase.FoodData[_player.PlayerThinkingID].foodImage;
    }

    void ChangeObejctImage(int thinkingid)
    {
        _image.sprite = FoodDataBase.FoodData[thinkingid].foodImage;
    }


}
