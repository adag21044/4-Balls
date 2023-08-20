
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    public bool isTouchingSlider = false;

    void Start()
    {
        SetupSliderTouchCheck();
    }

    void Update()
    {
        CheckSliderTouch();
    }

    void SetupSliderTouchCheck()
    {
        Slider slider = GetComponent<Slider>();
        if (slider != null)
        {
            EventTrigger eventTrigger = slider.gameObject.GetComponent<EventTrigger>();
            if (eventTrigger == null)
            {
                eventTrigger = slider.gameObject.AddComponent<EventTrigger>();
            }

            EventTrigger.Entry pointerDownEntry = new EventTrigger.Entry();
            pointerDownEntry.eventID = EventTriggerType.PointerDown;
            pointerDownEntry.callback.AddListener((data) => { OnPointerDelegate((PointerEventData)data, true); });
            eventTrigger.triggers.Add(pointerDownEntry);

            EventTrigger.Entry pointerUpEntry = new EventTrigger.Entry();
            pointerUpEntry.eventID = EventTriggerType.PointerUp;
            pointerUpEntry.callback.AddListener((data) => { OnPointerDelegate((PointerEventData)data, false); });
            eventTrigger.triggers.Add(pointerUpEntry);
        }
    }

    public void OnPointerDelegate(PointerEventData eventData, bool isDown)
    {
        isTouchingSlider = isDown;
        if (isDown)
        {
            Debug.Log("Slider'a dokunuldu.");
        }
        else
        {
            Debug.Log("Slider'dan el çekildi.");
        }
    }

    public void CheckSliderTouch()
    {
        if (isTouchingSlider)
        {
            isTouchingSlider = true;
        }
        else
        {
            // Slider'a dokunulmuyorsa burada yapılacak işlemleri gerçekleştir
        }
    }
}
