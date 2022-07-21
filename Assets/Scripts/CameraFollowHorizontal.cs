using UnityEngine;

public class CameraFollowHorizontal : MonoBehaviour {

    private Camera _camera;
    [SerializeField] private Transform bodyTransform;
    [SerializeField] private float BodyMaxLeft;
    [SerializeField] private float BodyMaxRight;

    [SerializeField] private float CameraMaxLeft;
    [SerializeField] private float CameraMaxRight;

    private void Awake() {
        _camera = Camera.main;
    }

    private void Update() {
        float cameraLerp = Mathf.InverseLerp(BodyMaxRight, BodyMaxLeft,bodyTransform.position.x);

        _camera.transform.position = new Vector3(Mathf.Lerp(CameraMaxRight,CameraMaxLeft, cameraLerp), 0f, -10f);
    }
}