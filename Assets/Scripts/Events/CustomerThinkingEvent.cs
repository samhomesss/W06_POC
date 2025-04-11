using System;

/// <summary>
/// 하루를 시작 하거나 손님들이 생성될때 해당 손님이 생각하는 것이 어떤건지에 대한 Action
/// 손님들에 대한 Action을 만들면 안됨 해당 손님들이 생각을 공유할 수 있기 때문에 사용하면 안된다.
/// </summary>
public class CustomerThinkingEvent
{
    public Action<int> OnCustomerThinkingEvent; // 손님이 생각 이후에 어떤걸 하는지 연결 해주면 됨 
    public Action<int> OnCustomerThinkingChangeEvent; // 손님이 생각하는거 바꾸기
    /// <summary>
    /// 손님이 생각하고 잇는 것들에 대한 것 
    /// </summary>
    /// <param name="customerIdea"></param>
    public void CustomerThinking(int customerIdea)
    {
        OnCustomerThinkingEvent?.Invoke(customerIdea);
    }

    /// <summary>
    /// 손님이 먹고싶은거 바꾸기 이렇게 바꾸면 안됨 -> 손님 마다 다른걸 생각해야 하는데 같은걸 생각함 
    /// </summary>
    /// <param name="thinkingID"></param>
    public void CustomerThinkingChange(int thinkingID)
    {
        OnCustomerThinkingChangeEvent?.Invoke(thinkingID);
    }
}
