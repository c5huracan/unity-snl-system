using UnityEngine;

public class Money : MonoBehaviour, ISaveState
// public class Money : MonoBehaviour
{
    [SerializeField] float _RotationSpeed = 5f;

    // void Update() => transform.Rotate(0, _RotationSpeed * Time.deltaTime, 0);
    void Update() => transform.Rotate(0, _RotationSpeed, 0);

    public string PickedUpKey => $"Money-{gameObject.name}-Pickedup";

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            player.AddMoney();
            gameObject.SetActive(false);
        }
    }

    public void Save() => PlayerPrefs.SetInt(PickedUpKey, gameObject.activeSelf ? 0 : 1);

    public void Load()
    {
        int wasPickedUp = PlayerPrefs.GetInt(PickedUpKey);
        gameObject.SetActive(wasPickedUp == 0);
    }

}