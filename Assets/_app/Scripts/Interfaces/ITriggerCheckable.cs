using UnityEngine;

namespace _app.Scripts.Interfaces {
    public interface ITriggerCheckable {
        public bool IsAggroed { get; set; }
        public bool IsWithinStrikingDistance { get; set; }
    }
}
