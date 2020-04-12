using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    private bool isZoomed = false;

    [SerializeField] private float max = 5f;
    [SerializeField] private Camera cam;

    public IEnumerator Shake(float duration, float magnitude)
    {
        isZoomed = !isZoomed;
       if (isZoomed)
        {

            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, -max, cam.orthographicSize * Time.deltaTime); //* Time.deltaTime
            Invoke("Zoom", 3f * Time.deltaTime);

        }
            yield return null;
        }

    
    void Zoom()
    {
        cam.orthographicSize = 5 ;
    }
}
