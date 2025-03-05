using System.Collections.Generic;
using Godot;

namespace Runis.Attributes;
[GlobalClass]
public partial class AttributeSet: Node
{
    [Signal]
    public delegate void AttributeAddedEventHandler(Attribute attribute);
    [Signal]
    public delegate void AttributeRemovedEventHandler(Attribute attribute);
    public Godot.Collections.Dictionary<string, Attribute> Attributes { get; set; } = [];
    
    public override void _Ready()
    {
        base._Ready();
        InitializeAttributesFromChildren();
    }

    public void InitializeAttributesFromChildren()
    {
        foreach (var child in GetChildren())
        {
            if (child is Attribute attribute)
            {
                this.Add(attribute);
            }
        }
    }
    
    public void Add(Attribute attribute)
    {
        var res = Attributes.TryAdd(attribute.Name, attribute);
        if (res) EmitSignal(SignalName.AttributeAdded, attribute);
        attribute.Reparent(this);
    }

    public void Remove(Attribute attribute, bool shouldDestroy = true)
    {
        var res = Attributes.Remove(attribute.Name);
        if (res) EmitSignal(SignalName.AttributeRemoved, attribute);
        if (shouldDestroy) attribute.QueueFree();
    }
}