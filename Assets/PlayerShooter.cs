using UnityEngine;

class PlayerShooter
{
    private PlayerModel _playerModel;
    
    private int _currentNumberBullet;
    private bool _isShoot;

    private float _timerShoot;

    public PlayerShooter(PlayerModel playerModel)
    {
        _playerModel = playerModel;
        _currentNumberBullet = _playerModel.NumberBullet;

        _timerShoot = 0;
    }

    public void UpdateShooter()
    {
        _timerShoot += Time.deltaTime; 

        if (_timerShoot > _playerModel.TimeReloadBullet)
        {
            _isShoot = true;
        }    
    }

    public void Shoot()
    {
        if (_currentNumberBullet == 0  || !_isShoot) return;

        Bullet bullet = CreateBullet();
   
        bullet.AddForce(_playerModel.transform.right, _playerModel.SpeedBullet);
        
        _currentNumberBullet--;

        ResetReloadShoot();
    }

    private void ResetReloadShoot()
    {
        _isShoot = false;
        _timerShoot = 0;
    }

    private Bullet CreateBullet()
    {
        return Object.Instantiate(
            _playerModel.PrefabBullet,
            _playerModel.BulletContainer.transform.position,
            Quaternion.identity,
            _playerModel.BulletContainer.transform);
    }
}

