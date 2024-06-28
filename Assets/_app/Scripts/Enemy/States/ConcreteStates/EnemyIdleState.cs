using UnityEngine;

namespace _app.Scripts.Enemy.States.ConcreteStates {
    public class EnemyIdleState : EnemyState {
        // ===== Fields =====
        private Vector3 TargetPosition;

        // ===== Constructors =====
        public EnemyIdleState(Enemy enemy, EnemyStateMachine stateMachine) : base(enemy, stateMachine) {}

        // ===== EnemyState Overrides =====
        public override void EnterState() {
            base.EnterState();

            TargetPosition = GetRandomPointInCircle();
        }

        public override void FrameUpdate() {
            base.FrameUpdate();

            // If enemy aggroed, change to chase state

            // Calculate relative position of target
            Vector2 relativePosition = TargetPosition - _Enemy.transform.position;
            // Move enemy in target direction
            _Enemy.MoveEnemy(relativePosition.normalized * _Enemy.MovementSpeed);

            // If enemy position is close enough to target position, randomize target position
            if (relativePosition.sqrMagnitude < 0.01f)
                TargetPosition = GetRandomPointInCircle();
        }

        // ===== Methods =====
        public Vector3 GetRandomPointInCircle() =>
            _Enemy.transform.position + (Vector3)Random.insideUnitCircle * _Enemy.RandomMovementRange;
    }
}
