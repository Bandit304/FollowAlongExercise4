using UnityEngine;

namespace _app.Scripts.Enemy.States {
    public class EnemyState {
        // ===== Fields =====
        protected Enemy _Enemy;
        protected EnemyStateMachine _StateMachine;

        // ===== Constructors =====
        public EnemyState(Enemy enemy, EnemyStateMachine stateMachine) {
            _Enemy = enemy;
            _StateMachine = stateMachine;
        }

        // ===== Methods =====
        public virtual void EnterState() {}

        public virtual void ExitState() {}

        public virtual void FrameUpdate() {}

        public virtual void PhysicsUpdate() {}
    }
}
