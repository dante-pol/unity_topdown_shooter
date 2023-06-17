using UnityEngine;

class PlayerShooter
{
    private PlayerModel _playerModel;
    private int _currentNumberBullet;

    public PlayerShooter(PlayerModel playerModel)
    {
        _playerModel = playerModel;
        _currentNumberBullet = _playerModel.NumberBullet;
    }

    private Bullet CreateBullet()
    {
        return Object.Instantiate(_playerModel.PrefabBullet);
    }

    public void Shoot()
    {
        if (_currentNumberBullet == 0) return;

        var bullet = CreateBullet();
        
        bullet.transform.position = _playerModel.transform.position;

        bullet.AddForce(_playerModel.transform.right, _playerModel.SpeedBullet);
        
        _currentNumberBullet--;
    }
}

