using System.Collections;
using _app.Scripts.Player;
using UnityEngine;

namespace _app.Scripts.Enemy.States.ConcreteStates {
    public class EnemyAttackState : EnemyState {
        // ===== Fields =====
        private PlayerController playerController;
        private bool isWaiting;

        // ===== Constructors =====
        public EnemyAttackState(Enemy enemy, EnemyStateMachine stateMachine) : base(enemy, stateMachine) {
            playerController = PlayerController.Instance;
        }

        // ===== EnemyState Overrides =====
        public override void EnterState(){
            base.EnterState();
            Debug.Log("Enemy entered the ATTACK STATE");
            _Enemy.sprite.color = Color.red;

            // Stop enemy movement
            _Enemy.MoveEnemy(Vector2.zero);
        }

        public override void FrameUpdate() {
            base.FrameUpdate();

            // If attack not in progress, start new attack
            if (!isWaiting)
                _Enemy.StartCoroutine(AttackPlayer());

            // If enemy no longer within striking range, return to chase state
            if (!_Enemy.IsWithinStrikingDistance)
                _StateMachine.ChangeState(_Enemy.ChaseState);
            // If player dead, return to idle state
            if (!playerController.gameObject.activeSelf)
                _StateMachine.ChangeState(_Enemy.IdleState);
        }

        // ===== Methods =====
        private IEnumerator AttackPlayer() {
            // Set is waiting to true
            isWaiting = true;
            // Wait 1 second
            yield return new WaitForSeconds(1);
            // If Enemy still within striking range, damage Player
            if (_Enemy.IsWithinStrikingDistance)
                playerController.Damage(_Enemy.DamagePerHit);
            // Set is waiting to false
            isWaiting = false;
        }
    }
}
