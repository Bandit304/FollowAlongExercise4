using _app.Scripts.Enemy.States;
using _app.Scripts.Enemy.States.ConcreteStates;
using _app.Scripts.Interfaces;
using UnityEngine;

namespace _app.Scripts.Enemy {
    [RequireComponent(typeof(Rigidbody2D))]
    public class Enemy : MonoBehaviour, IDamageable, IEnemyMovable, ITriggerCheckable {
        // ===== Fields =====
        [Header("Enemy State Fields")]
        // State Machine
        private EnemyStateMachine StateMachine;
        // Concrete States
        public EnemyIdleState IdleState;
        public EnemyChaseState ChaseState;

        [Header("Health Fields")]
        public float MaxHealth { get; set; }
        public float CurrentHealth { get; set; }

        [Header("Movement Fields")]
        public float MovementSpeed;
        public float RandomMovementRange;
        public bool IsFacingRight;
        
        [Header("Trigger Checking Fields")]
        public bool IsAggroed { get; set; }
        public bool IsWithinStrikingDistance { get; set; }

        [Header("Components")]
        public Rigidbody2D rb { get; private set; }

        // ===== Unity Events =====

        void Awake() {
            // Initialize State Machine
            StateMachine = new EnemyStateMachine();
            // Initialize Concrete States
            IdleState = new EnemyIdleState(this, StateMachine);
            ChaseState = new EnemyChaseState(this, StateMachine);
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {
            CurrentHealth = MaxHealth;
            rb = GetComponent<Rigidbody2D>();
            StateMachine.Initialize(IdleState);
        }

        // Update is called once per frame
        void Update() {
            StateMachine.State.FrameUpdate();
        }

        void FixedUpdate() {
            StateMachine.State.PhysicsUpdate();
        }

        // ===== IDamageable Methods =====
        public void Damage(float damage) {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0) {
                CurrentHealth = 0;
                Die();
            }
        }
        public void Die() {
            Destroy(gameObject);
        }

        // ===== IEnemyMoveable Methods =====
        public void MoveEnemy(Vector2 velocity) {
            rb.velocity = velocity;
            CheckForLeftOrRightFacing(velocity);
        }
        public void CheckForLeftOrRightFacing(Vector2 velocity) {
            if (IsFacingRight && velocity.x < 0) {
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180, transform.rotation.z));
                IsFacingRight = false;
            }
            else if (!IsFacingRight && velocity.x > 0) {
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0, transform.rotation.z));
                IsFacingRight = true;
            }
        }
    }
}
