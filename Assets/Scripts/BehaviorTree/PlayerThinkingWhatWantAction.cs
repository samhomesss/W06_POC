using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "PlayerThinkingWhatWant", story: "[Self] is Thinking What He Want", category: "Action", id: "2ae850b4940aa5bdf91f94aad5d080ba")]
public partial class PlayerThinkingWhatWantAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<Boolean> CustomerIsThinking;

    CustomerRandomThinking _customerThinking;
    float _timer = 0;
    protected override Status OnStart()
    {
        _customerThinking = Self.Value.GetComponent<CustomerRandomThinking>();
        _customerThinking.RandomThinking();
        
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        //Todo : 드드드 거리면 바꿔야 됨 
        _timer += Time.deltaTime;

        if (_timer > 2f)
        {
            CustomerIsThinking.Value = false;
            return Status.Success;
        }

        return Status.Running;
    }

    protected override void OnEnd()
    {
        _timer = 0;
    }
}

