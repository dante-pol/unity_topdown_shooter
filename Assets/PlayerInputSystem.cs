using UnityEngine;

class PlayerInputSystem
{
    public bool IsDownLeft { get; private set; } = false;
    public bool IsDownRight { get; private set; } = false;
    public bool IsForward { get; private set; } = false;

    private PlayerModel _playerModel;

    public PlayerInputSystem() { }
    public PlayerInputSystem(PlayerModel playerModel) 
    {
        _playerModel = playerModel;
    }

    public void UpdateSystem()
    {
        if (Input.GetKey(KeyCode.W))
        {
            IsForward = true;
        }

        if (Input.GetKey(KeyCode.A))
            IsDownLeft = true;

        if (Input.GetKey(KeyCode.D))
            IsDownRight = true;

    }

    public void ResetSystem()
    {
        IsForward = false;
        IsDownLeft = false;
        IsDownRight = false;
    }
}