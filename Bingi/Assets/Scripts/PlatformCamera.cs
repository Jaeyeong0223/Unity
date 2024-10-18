using UnityEngine;

public class PlatformCamera : MonoBehaviour
{
    public Transform bingi; // 따라갈 오브젝트의 Transform
    public float smoothTime = 0.3f; // 부드럽게 따라가는 데 걸리는 시간

    private Vector3 velocity = Vector3.zero; // 현재 속도, SmoothDamp에서 사용

    private void Update()
    {
        if (bingi.position.x >= -3)
        {
            // 목표 위치 계산 (bingi의 위치)
            Vector3 targetPosition = new Vector3(bingi.position.x + 6, 0, transform.position.z);

            // 카메라의 위치를 부드럽게 업데이트
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
