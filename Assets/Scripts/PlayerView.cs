
using UnityEngine;

public class PlayerView : MonoBehaviour, ITankView
{
    PlayerPresenter _presenter;
    PlayerModel _model;

    private void Awake()
    {
        _model = new PlayerModel();
        _presenter = new PlayerPresenter(_model, this);
        _presenter.Subscribe();
    }

    public void Moving(int speed)
    {
        throw new System.NotImplementedException();
    }

    public void Fire()
    {
        throw new System.NotImplementedException();
    }
    public void Death()
    {
        Debug.Log("Death");
    }

    public void SetHp(int damage)
    {
        Debug.Log(damage);
    }
    public void SetDamage(int damage)
    {
        _presenter.SetDamage(damage);
    }
    void OnMouseDown()
    {
        SetDamage(1);
    }
}
