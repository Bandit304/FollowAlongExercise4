using UnityEngine;
using UnityEngine.InputSystem;

namespace _app.Scripts.Player {
    [RequireComponent(typeof(PlayerInput), typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour {
        // ===== Fields =====

        [Header("Singleton Reference")]
        public static PlayerController Instance { get; private set; }

        [Header("Components")]
        public Rigidbody2D rb { get; private set; }

        [Header("Movement Values")]
        public float movementSpeed;

        // ===== Unity Events =====

        // Awake is called once before the first execution of Start after the MonoBehaviour is created
        void Awake() {
            if (!Instance)
                Instance = this;
            else
                Destroy(this);
        }

        void Start() {
            rb = GetComponent<Rigidbody2D>();
        }

        // ===== Player Input Events =====
        public void OnPlayerMove(InputAction.CallbackContext context) {
            rb.velocity = context.ReadValue<Vector2>() * movementSpeed;
        }

        // ===== Methods =====
    }
}
