using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BlackBallControl : MonoBehaviour
{
    Vector2 startPos, endPos, direction;
    float touchTimeStart, touchTimeFinish, timeInterval;
    bool canDragBall = true; // Topun sürüklenip sürüklenmediğini kontrol eden değişken

    [Range(5f, 15f)]
    public float throwForce;

    // Slider referansı
    public Slider slider;

    // UI layer'ı
    public LayerMask uiLayer;

    void Update()
    {
        throwForce = slider.value * 15.0f;

        if (EventSystem.current.IsPointerOverGameObject(0))
        {
            canDragBall = false;
        }
        else
        {
            canDragBall = true;
        }

        // UI üzerinde değilken dokunmatik girişleri işle
        if (canDragBall && Input.touchCount > 0 && Input.GetTouch(0).position.y > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                touchTimeStart = Time.time;
                startPos = Input.GetTouch(0).position;
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                touchTimeFinish = Time.time;
                timeInterval = touchTimeFinish - touchTimeStart;
                endPos = Input.GetTouch(0).position;
                direction = startPos - endPos;

                Vector3 force = new Vector3(-direction.x, 0, -direction.y).normalized * throwForce;
                GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
            }
        }
    }
}