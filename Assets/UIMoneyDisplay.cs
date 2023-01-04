using TMPro;
using UnityEngine;

public class UIMoneyDisplay : MonoBehaviour
{
    private Player _player;
    private TMP_Text _text;

    void Awake()
    {
        _player = FindObjectOfType<Player>();
        _text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.SetText("$" + _player.Money);
    }
}
