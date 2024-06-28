using TMPro;
using UnityEngine;

namespace _app.Scripts.Managers {
    public class UIManager : MonoBehaviour {
        // ===== Fields =====

        [Header("Singleton Reference")]
        public static UIManager Instance { get; private set; }

        [Header("UI Text")]
        [SerializeField] private TMP_Text HealthText;
        [SerializeField] private TMP_Text GameOverText;

        // ===== Unity Events =====

        // Awake is called once before the first execution of Start after the MonoBehaviour is created
        void Awake() {
            if (!Instance)
                Instance = this;
            else
                Destroy(this);
        }

        void Start() {
            // Hide Game Over message on start
            GameOverText.enabled = false;
        }

        // ===== Methods =====

        public void DisplayHealth(float health) {
            HealthText.text = $"Health: {health}";
        }

        public void DisplayGameOver() {
            GameOverText.enabled = true;
        }
    }
}
