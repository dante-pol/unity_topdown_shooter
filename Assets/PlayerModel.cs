using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerModel : MonoBehaviour
{
    #region Properties
    public int HeatPoint => _heatPoint;

    public float SpeedMovement => _speedMovement;
    public float SpeedRotation => _speedRotation;

    public Bullet PrefabBullet => _prefabBullet;
    public int NumberBullet => _numberBullet;
    public float SpeedBullet => _speedBullet;
    public float ReloadBullet => _reloadBullet;

    public Rigidbody2D GetRigidbody2D => _rigidbody;
    #endregion

    #region Field inspector
    [Header("Player data")]
    [SerializeField] private int _heatPoint;

    [Header("Movement data")]
    [SerializeField] [Range(1, 10)] private float _speedMovement;
    [SerializeField] [Range(1, 10)] private float _speedRotation;

    [Header("Shooter data")]
    [SerializeField] private Bullet _prefabBullet;
    [SerializeField] private int _numberBullet;
    [SerializeField] [Range(1, 10)] private float _speedBullet;
    [SerializeField] [Range(0.1f, 1.5f)] private float _reloadBullet;
    
    #endregion

    #region Player links
    private PlayerMovement _playerMovement;
    private PlayerInputSystem _playerInputSystem;
    private PlayerShooter _playerShooter;

    private Rigidbody2D _rigidbody;
    #endregion

    #region Unity's methods
    private void Start()
    {
        _rigidbody= GetComponent<Rigidbody2D>();

        _playerMovement = new PlayerMovement(this);
        _playerInputSystem = new PlayerInputSystem(this);
        _playerShooter = new PlayerShooter(this);
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

        if (_playerInputSystem.IsDownFire)
            _playerShooter.Shoot();

        _playerInputSystem.ResetSystem();

        
    }
    #endregion
}

