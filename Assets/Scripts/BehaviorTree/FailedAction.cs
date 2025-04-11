using System;
using Unity.Behavior;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "FailedAction", story: "Failed Action", category: "Action", id: "7f5b239424836326d2cd0f3992afd7c0")]
public partial class FailedAction : Action
{
    protected override Status OnStart()
    {
        return Status.Failure;
    }
}

