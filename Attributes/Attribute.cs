using Godot;

namespace Runis.Attributes;
[Tool]
[GlobalClass]
public partial class Attribute : Node
{
    [Signal]
    public delegate void PreBaseValueChangedEventHandler(float oldValue, float newValue);
    [Signal]
    public delegate void BaseValueChangedEventHandler(float oldValue, float newValue);
    [Signal]
    public delegate void PreCurrentValueChangedEventHandler(float oldValue, float newValue);
    [Signal]
    public delegate void CurrentValueChangedEventHandler(float oldValue, float newValue);
    
    private float _currentValue;
    private float _baseValue;

    [Export] public float CurrentValue
    {
        get => _currentValue;
        set
        {
            EmitSignal(SignalName.PreCurrentValueChanged, _currentValue, value);
            var oldValue = _currentValue;
            _currentValue = value;
            EmitSignal(SignalName.CurrentValueChanged, oldValue, _currentValue);
        }
    }
    
    [Export] public float BaseValue
    {
        get => _baseValue;
        set
        {
            EmitSignal(SignalName.PreBaseValueChanged, _baseValue, value);
            var oldValue = _baseValue;
            _baseValue = value;
            EmitSignal(SignalName.BaseValueChanged, oldValue, _baseValue);
        }
    }
}