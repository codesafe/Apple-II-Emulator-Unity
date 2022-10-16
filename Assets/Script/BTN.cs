
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BTN : Button
{
    [SerializeField] Machine machine;

    public void SetMachine(Machine machine)
    {
        this.machine = machine;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        machine.OnPushBtn(name);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        machine.OnReleaseBtn(name);
    }
}
