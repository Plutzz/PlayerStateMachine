using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachines.Player
{
    public abstract class BaseState
    {
        // Fields to be assigned during the Construct() methods
        protected PlayerMotor motor;


        /// <summary>
        /// Setup state, e.g. starting animations.
        /// Consider this the "Start" method of this state.
        /// </summary>
        public abstract void Construct();

        /// <summary>
        /// State-Cleanup.
        /// </summary>
        public abstract void Destruct();

        /// <summary>
        /// This method is called once every frame while this state is active.
        /// Consider this the "Update" method of this state.
        /// </summary>
        public abstract void UpdateState();



        //Consider adding core functionalities here
        // Ex: GroundedCheck

    }
}

