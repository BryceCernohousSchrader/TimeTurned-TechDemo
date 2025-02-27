using UnityEngine;
// Original Authors - Wyatt Senalik

namespace TimeTurned
{
    /// <summary>
    /// Implementation of <see cref="ITimedComponent"/> that can be extended to get 
    /// some easy references to the <see cref="ITimedObject"/> that this script is
    /// attached to.
    /// </summary>
    [RequireComponent(typeof(TimedObject))]
    public class TimedComponent : MonoBehaviour, ITimedComponent
    {
        public ITimedObject timedObject { get; private set; } = null;
        public bool isRecording => timedObject.isRecording;


        // Domestic Initialization
        protected virtual void Awake()
        {
            timedObject = GetComponent<ITimedObject>();
            #region Asserts
            CustomDebug.AssertIComponentIsNotNull(timedObject, this);
            #endregion Asserts
        }
    }
}