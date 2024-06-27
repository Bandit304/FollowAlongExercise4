using UnityEngine;

namespace _app.Scripts.Enemy.States {
    public class EnemyState {
        // ===== Fields =====
        protected Enemy Enemy;
        protected EnemyStateMachine StateMachine;

        // ===== Constructors =====
        public EnemyState(Enemy enemy, EnemyStateMachine stateMachine) {
            Enemy = enemy;
            StateMachine = stateMachine;
        }

        // ===== Methods =====
        public virtual void EnterState() {}

        public virtual void ExitState() {}

        public virtual void FrameUpdate() {}

        public virtual void PhysicsUpdate() {}
    }
}
