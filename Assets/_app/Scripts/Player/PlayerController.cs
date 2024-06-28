using _app.Scripts.Interfaces;
using _app.Scripts.Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _app.Scripts.Player {
    [RequireComponent(typeof(PlayerInput), typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour, IDamageable {
        // ===== Fields =====

        [Header("Singleton Reference")]
        public static PlayerController Instance { get; private set; }

        [Header("Components")]
        public Rigidbody2D rb { get; private set; }

        [Header("Movement Values")]
        public float movementSpeed;

        [Header("Health Fields")]
        [field: SerializeField] public float MaxHealth { get; set; }
        public float CurrentHealth { get; set; }

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
            CurrentHealth = MaxHealth;
            UIManager.Instance.DisplayHealth(CurrentHealth);
        }

        // ===== Player Input Events =====
        public void OnPlayerMove(InputAction.CallbackContext context) {
            rb.velocity = context.ReadValue<Vector2>() * movementSpeed;
        }

        // ===== IDamageable Methods =====
        public void Damage(float damage) {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0) {
                CurrentHealth = 0;
                Die();
            }
            UIManager.Instance.DisplayHealth(CurrentHealth);
        }

        public void Die() {
            UIManager.Instance.DisplayGameOver();
            gameObject.SetActive(false);
        }

        // ===== Methods =====
    }
}
