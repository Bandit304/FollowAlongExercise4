using UnityEngine;

namespace _app.Scripts.Enemy.States {
    public class EnemyStateMachine {
        // ===== Fields =====
        public EnemyState State;

        // ===== Constructors =====
        public EnemyStateMachine(EnemyState initialState) {
            State = initialState;
            State.EnterState();
        }

        // ===== Methods =====
        public void ChangeState(EnemyState newState) {
            State.ExitState();
            State = newState;
            State.EnterState();
        }
    }
}
