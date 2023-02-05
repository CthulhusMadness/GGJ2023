using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float zoomSpeedMultiplier;
    [SerializeField] private AnimationCurve zoomCurve;

    private Coroutine coroutine;

    private void Start()
    {
        cam.orthographicSize = 5f;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        Vector3 movementDir = new Vector3(transform.position.x - target.position.x, 0, 0);
        if (Mathf.Abs(transform.position.x - target.position.x) > 0)
            transform.Translate(-Vector3.right * moveSpeed * movementDir.x, Space.World);
    }

    public void Zoom(bool zoomIn)
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
        coroutine = StartCoroutine(ZoomDelay(zoomIn));
    }

    private IEnumerator ZoomDelay(bool zoomIn)
    {
        float sizeTarget = zoomIn ? 3f : 5f;

        float timer = 0f;
        float curveValue = 0f;
        while (curveValue < 1)
        {
            timer += Time.fixedDeltaTime * zoomSpeedMultiplier;
            curveValue = zoomCurve.Evaluate(timer);
            Debug.Log(curveValue);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, sizeTarget, curveValue);
            yield return null;
        }
        cam.orthographicSize = sizeTarget;
    }
}
