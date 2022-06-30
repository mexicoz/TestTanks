

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
        _playerModel.Fire += Fire; 
    }
    public void Unsubscribe()
    {
        _playerModel.Death -= Death;
        _playerModel.SetCurrentHp -= SetHp;
        _playerModel.Fire -= Fire;
    }

    public void SetDamage(int hp)
    {
        _playerModel.SetHp(hp);
    }
    public void SetHp(int hp)
    {
        _playerView.SetHp(hp);
    }
    public void StartFire()
    {
        _playerModel.StartFire();
    }
    private void Death()
    {
        _playerView.Death();
        Unsubscribe();
    }
    public void Fire()
    {
        _playerView.Fire();
    }

}
