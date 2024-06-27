using UnityEngine;

namespace _app.Scripts.Interfaces {
    public interface IDamageable {
        public float MaxHealth { get; set; }
        public float CurrentHealth { get; set; }

        public void Damage(float damage);
        public void Die();
    }
}
