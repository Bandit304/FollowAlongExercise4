using UnityEngine;

namespace _app.Scripts.Interfaces {
    public interface IEnemyMovable {
        public void MoveEnemy(Vector2 velocity);
        public void CheckForLeftOrRightFacing(Vector2 velocity);
    }
}
