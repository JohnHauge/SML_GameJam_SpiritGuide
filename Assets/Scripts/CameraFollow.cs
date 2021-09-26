using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Camera _camera;
    [SerializeField] private Transform bodyTransform;
    [SerializeField] private float maxBodyHeight;
    [SerializeField] private float minBodyHeight;

    [SerializeField] private float maxCameraHeight;
    [SerializeField] private float MinCameraHeight;

    private void Awake() {
        _camera = Camera.main;
    }

    private void Update() {
        float cameraLerp = Mathf.InverseLerp(minBodyHeight,maxBodyHeight,bodyTransform.position.y);

        _camera.transform.position = new Vector3(0f, Mathf.Lerp(MinCameraHeight,maxCameraHeight, cameraLerp), -10f);
    }
}