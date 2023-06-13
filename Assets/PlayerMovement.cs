using UnityEngine;

class PlayerMovement
{
    private PlayerModel _playerModel;
    private float _orientation;

    public PlayerMovement(PlayerModel playerModel)
    {
        _playerModel= playerModel;
        _orientation = 0;
    }

    public void Movement()
    {
        Debug.Log(GetDirectionMovement());
        var velocity = GetDirectionMovement() * _playerModel.SpeedMovement;
        _playerModel.GetRigidbody2D.velocity = velocity;
    }

    public void Rotation(int direction)
    {
        _playerModel.GetRigidbody2D.rotation += _playerModel.SpeedRotation * direction;
    }

    public Vector2 GetDirectionMovement()
    {
        return _playerModel.transform.right;
    }
}
