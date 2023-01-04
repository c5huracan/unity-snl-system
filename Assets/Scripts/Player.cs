using UnityEngine;

public class Player : MonoBehaviour, ISaveState
{

    [SerializeField] float _speed = 3f;

    public int Money { get; private set; }

    Rigidbody _rigidbody;

    void Awake() => _rigidbody = GetComponent<Rigidbody>();


    public void Save()
    {
        // Debug.Log("You are in OnDisable().");
        var json = JsonUtility.ToJson(transform.position);
        // Debug.Log(json);
        PlayerPrefs.SetString("PlayerPosition", json);

        var velocityJson = JsonUtility.ToJson(_rigidbody.velocity);
        PlayerPrefs.SetString("PlayerVelocity", velocityJson);
        PlayerPrefs.SetInt("PlayerMoney", Money);

    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("PlayerPosition"))
        {
            // Debug.Log("You are in OnEnable().");
            transform.position = JsonUtility.FromJson<Vector3>(PlayerPrefs.GetString("PlayerPosition"));
            // Debug.Log(transform.position);

            _rigidbody.velocity = JsonUtility.FromJson<Vector3>(PlayerPrefs.GetString("PlayerVelocity"));
            Money = PlayerPrefs.GetInt("PlayerMoney");
        }

    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 velocity = new Vector3(horizontal, 0, vertical).normalized;
        // if (velocity.magnitude > 0)
        _rigidbody.velocity = velocity * _speed;
    }

    public void AddMoney()
    {
        Money++;
    }

}