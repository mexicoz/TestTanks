

public class PlayerPresenter
{

    private PlayerModel _playerModel;
    private PlayerView _playerView;

    public PlayerPresenter(PlayerModel model, PlayerView view)
    {
        _playerModel = model;
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
