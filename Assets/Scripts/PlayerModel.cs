

using System;

public class PlayerModel
{
    public event Action Death;
    public event Action<int> SetCurrentHp;

    private int _maxHp = 10;
    private int _currentHp;

    public PlayerModel()
    {
        _currentHp = _maxHp;
    }

    public void SetHp(int damage)
    {
        _currentHp -= damage;
        if (_currentHp > 0)
            SetCurrentHp?.Invoke(_currentHp);
        else
            Death?.Invoke();
    }
}
