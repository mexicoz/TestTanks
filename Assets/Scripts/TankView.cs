
using UnityEngine;

public class TankView : MonoBehaviour
{
    TankPresenter _presenter;

    [SerializeField] private int _speed;

    private void Awake()
    {
        _presenter = new TankPresenter(this);
        _presenter.Subscribe();
    }

    public virtual void Moving(int speed)
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
