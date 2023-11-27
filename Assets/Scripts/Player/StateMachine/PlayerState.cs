using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

    public abstract class PlayerState

    {
        // Fields to be assigned during the Construct() methods
        protected PlayerMotor motor;
        protected PlayerInputActions playerInputActions;

        /// <summary>
        /// Setup state, e.g. starting animations.
        /// Consider this the "Start" method of this state.
        /// </summary>
        public abstract void Construct(PlayerMotor currentMotor);

        /// <summary>
        /// State-Cleanup.
        /// </summary>
        public abstract void Destruct();

        /// <summary>
        /// This method is called once every frame while this state is active.
        /// Consider this the "Update" method of this state.
        /// </summary>
        public abstract void UpdateState();

        /// <summary>
        /// This method is called once every physics frame while this state is active.
        /// Consider this the "FixedUpdate" method of this state.
        /// </summary>
        public abstract void FixedUpdateState();



        //Consider adding core functionalities here
        // Ex: GroundedCheck

    }

