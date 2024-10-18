using UnityEngine;

public class PlatformCamera : MonoBehaviour
{
    public Transform bingi; // ���� ������Ʈ�� Transform
    public float smoothTime = 0.3f; // �ε巴�� ���󰡴� �� �ɸ��� �ð�

    private Vector3 velocity = Vector3.zero; // ���� �ӵ�, SmoothDamp���� ���

    private void Update()
    {
        if (bingi.position.x >= -3)
        {
            // ��ǥ ��ġ ��� (bingi�� ��ġ)
            Vector3 targetPosition = new Vector3(bingi.position.x + 6, 0, transform.position.z);

            // ī�޶��� ��ġ�� �ε巴�� ������Ʈ
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
