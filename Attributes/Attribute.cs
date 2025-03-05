using Godot;

namespace Runis.Attributes;
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
    
    private float _baseValue;
    private float _currentValue;

    public float BaseValue
    {
        get => _baseValue;
        set
        {
            EmitSignal(SignalName.PreBaseValueChanged, _currentValue, value);
            var oldValue = _currentValue;
            _currentValue = value;
            EmitSignal(SignalName.BaseValueChanged, oldValue, _currentValue);
        }
    }

    public float CurrentValue
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
    
}