using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed;
    [Header("Zoom")]
    [SerializeField] private float maxOrthographicSize = 5f;
    [SerializeField] private float minOrthographicSize = 3f;
    [SerializeField] private float zoomSpeedMultiplier;
    [SerializeField] private AnimationCurve zoomCurve;

    private Coroutine coroutine;

    private void Start()
    {
        cam.orthographicSize = maxOrthographicSize;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        FollowTarget();
    }

    public void SetTarget(Transform newTarget) => target = newTarget;

    private void FollowTarget()
    {
        Vector2 movementDir = transform.position - target.position;
        Debug.Log(movementDir.magnitude);
        if (movementDir.magnitude > 0)
        {
            var newPos = Vector3.MoveTowards(transform.position, target.position, moveSpeed * movementDir.magnitude);
            newPos.z = -10f;
            transform.position = newPos;
        }
    }

    public void Zoom(bool zoomIn)
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
        coroutine = StartCoroutine(ZoomDelay(zoomIn));
    }

    private IEnumerator ZoomDelay(bool zoomIn)
    {
        float sizeTarget = zoomIn ? minOrthographicSize : maxOrthographicSize;

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
