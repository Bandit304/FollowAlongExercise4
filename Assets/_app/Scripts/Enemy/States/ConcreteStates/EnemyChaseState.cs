using _app.Scripts.Player;
using UnityEngine;

namespace _app.Scripts.Enemy.States.ConcreteStates {
    public class EnemyChaseState : EnemyState {
        // ===== Fields =====
        private Transform PlayerTransform;

        // ===== Constructors =====
        public EnemyChaseState(Enemy enemy, EnemyStateMachine stateMachine) : base(enemy, stateMachine) {
            PlayerTransform = PlayerController.Instance.transform;
        }

        // ===== EnemyState Overrides =====
        public override void EnterState(){
            base.EnterState();
            Debug.Log("Enemy entered the CHASE STATE");
        }

        public override void FrameUpdate() {
            base.FrameUpdate();

            // If enemy is no longer aggroed, return to idle state
            if (!_Enemy.IsAggroed)
                _StateMachine.ChangeState(_Enemy.IdleState);
            // If player within striking distance, change to attack state

            // Calculate direction to move
            Vector2 direction = (PlayerTransform.position - _Enemy.transform.position).normalized;
            // Move enemy towards player
            _Enemy.MoveEnemy(direction * _Enemy.MovementSpeed);
        }
    }
}
