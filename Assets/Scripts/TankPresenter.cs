

public class TankPresenter
{

    private TankModel _playerModel = new TankModel();
    private TankView _playerView;

    public TankPresenter(TankView view)
    {
        
        _playerView = view;
    }
    public void Subscribe()
    {
        _playerModel.Death += Death;
        _playerModel.SetCurrentHp += SetHp;
    }
    public void Unsubscribe()
    {
        _playerModel.Death -= Death;
        _playerModel.SetCurrentHp -= SetHp;
    }

    public void SetDamage(int hp)
    {
        _playerModel.SetHp(hp);
    }
    public void SetHp(int hp)
    {
        _playerView.SetHp(hp);
    }
    private void Death()
    {
        _playerView.Death();
        Unsubscribe();
    }

}
