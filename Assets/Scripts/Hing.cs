using UnityEngine;

public class Hing : MonoBehaviour {
    private bool canUpdate = true;
    private HingeJoint2D hingleJoing2D;

    [SerializeField] private Camera mainCamera;

    void Start() {
        hingleJoing2D = gameObject.GetComponent<HingeJoint2D>();
        mainCamera = Camera.main;
    }

    void Update() {
        if (canUpdate) {
            // Checks touchs on screen
            foreach (Touch touch in Input.touches) {
                // Checks if touch the hing
                RaycastHit2D hit = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(touch.position), Vector2.zero);
                if (hit.collider != null && hit.collider.gameObject == gameObject) {
                    this.CutHing();
                }
            }
        }
    }

    private void CutHing() {
        Debug.Log("Cut the Hing");
        canUpdate = false;
        hingleJoing2D.breakForce = 0f;
    }
}
