using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "CustomerIsEatingFood", story: "[Self] is EatingFood", category: "Action", id: "120a1eb0740d16572ea926e1316a5fde")]
public partial class CustomerIsEatingFoodAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<Boolean> CustomerIsArrive;
    [SerializeReference] public BlackboardVariable<Boolean> CustomerIsThinking;

    InstanciateForTree _instanceObj;
    GameObject go;
    float _timer = 0;

    protected override Status OnStart()
    {
        _instanceObj = Self.Value.GetComponent<InstanciateForTree>();
        go =  _instanceObj.InstantiateObject();

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        _timer += Time.deltaTime;

        if (_timer > 3f)
        {
            Debug.Log(_timer);
            _instanceObj.DestoryObj(go);
            CustomerIsArrive.Value = false;
            CustomerIsThinking.Value = true;
            return Status.Success;
        }

        return Status.Running;
    }

    protected override void OnEnd()
    {
        _timer = 0;
    }
}

