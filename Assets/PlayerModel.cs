using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerModel : MonoBehaviour
{
    #region Properties
    public int HeatPoint => _heatPoint;

    public float SpeedMovement => _speedMovement;
    public float SpeedRotation => _speedRotation;

    public Rigidbody2D GetRigidbody2D => _rigidbody;
    #endregion

    #region Field inspector
    [Header("Player data")]
    [SerializeField] private int _heatPoint;

    [Header("Movement data")]
    [SerializeField] [Range(1, 10)] private float _speedMovement;
    [SerializeField] [Range(1, 10)] private float _speedRotation;
    #endregion

    #region Player links
    private PlayerMovement _playerMovement;
    private PlayerInputSystem _playerInputSystem;
    private Rigidbody2D _rigidbody;
    #endregion

    #region Unity's methods
    private void Start()
    {
        _rigidbody= GetComponent<Rigidbody2D>();

        _playerMovement = new PlayerMovement(this);
        _playerInputSystem = new PlayerInputSystem(this);
    }

    private void Update()
    {
        _playerInputSystem.UpdateSystem();
    }

    private void FixedUpdate()
    {
        if (_playerInputSystem.IsForward)
            _playerMovement.Movement();

        if (_playerInputSystem.IsDownLeft)
            _playerMovement.Rotation(1);

        if (_playerInputSystem.IsDownRight)
            _playerMovement.Rotation(-1);

        _playerInputSystem.ResetSystem();
    }
    #endregion
}
