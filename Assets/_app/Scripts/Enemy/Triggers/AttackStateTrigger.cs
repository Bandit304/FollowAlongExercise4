using UnityEngine;

namespace _app.Scripts.Enemy.Triggers {
    [RequireComponent(typeof(Collider2D))]
    public class AttackStateTrigger : MonoBehaviour {
        // ===== Fields =====

        [Header("Parent Components")]
        private Enemy _Enemy;

        // ===== Unity Events =====

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {
            _Enemy = GetComponentInParent<Enemy>();
        }

        // ===== Trigger Events =====
        public void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player"))
                _Enemy.IsWithinStrikingDistance = true;
        }
        
        public void OnTriggerExit2D(Collider2D other) {
            if (other.CompareTag("Player"))
                _Enemy.IsWithinStrikingDistance = false;
        }
    }
}
