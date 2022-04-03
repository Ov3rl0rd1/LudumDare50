using UnityEngine;

public class Upgrade
{
    public string Name => _name;

    public string Description => _description;

    public Sprite Icon => _icon;

    public int Cost => _cost;

    public bool IsInfinity => _isInfinity;

    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _cost;
    [SerializeField] private bool _isInfinity;
}
