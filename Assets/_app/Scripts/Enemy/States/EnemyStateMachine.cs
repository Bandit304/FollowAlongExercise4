using UnityEngine;

namespace _app.Scripts.Enemy.States {
    public class EnemyStateMachine {
        // ===== Fields =====
        public EnemyState State;

        // ===== Methods =====
        public void Initialize(EnemyState initialState) {
            State = initialState;
            State.EnterState();
        }

        public void ChangeState(EnemyState newState) {
            State.ExitState();
            State = newState;
            State.EnterState();
        }
    }
}
