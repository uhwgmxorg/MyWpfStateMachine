using System;
using System.Collections.Generic;

namespace MyWpfStateMachine.Tools
{
    public class MyStateMachine
    {
        public enum ProcessState
        {
            Start,
            State01,
            State02,
            State03,
            State04,
            End,
            InvalidTransition
        }

        public enum Command
        {
            Command01,
            Command21,
            Command22,
            Command02,
            Command03,
            Command04
        }

        Dictionary<StateTransition, ProcessState> transitions;
        public ProcessState CurrentState { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public MyStateMachine()
        {
            InitStateMachine();
        }

        private void InitStateMachine()
        {
            CurrentState = ProcessState.Start;
            transitions = new Dictionary<StateTransition, ProcessState>
                {
                    { new StateTransition(ProcessState.Start, Command.Command01),ProcessState.State01 },
                    { new StateTransition(ProcessState.State01, Command.Command02),ProcessState.State03 },
                    { new StateTransition(ProcessState.State01, Command.Command21),ProcessState.State02 },
                    { new StateTransition(ProcessState.State02, Command.Command22),ProcessState.State03 },
                    { new StateTransition(ProcessState.State03, Command.Command03),ProcessState.State04 },
                    { new StateTransition(ProcessState.State04, Command.Command04),ProcessState. End}
                };
        }

        private ProcessState GetNext(Command command)
        {
            StateTransition transition = new StateTransition(CurrentState, command);
            ProcessState nextState;
            if (!transitions.TryGetValue(transition, out nextState))
                throw new Exception("Invalid transition: " + CurrentState + " -> " + command);
            return nextState;
        }

        public ProcessState MoveNext(Command command)
        {
            CurrentState = GetNext(command);
            return CurrentState;
        }

        /// <summary>
        /// State-Machine Classes
        /// </summary>    
        #region State-Machine Classes
        private class StateTransition
        {
            readonly ProcessState CurrentState;
            readonly Command Command;

            public StateTransition(ProcessState currentState, Command command)
            {
                CurrentState = currentState;
                Command = command;
            }

            public override int GetHashCode()
            {
                return 17 + 32 * CurrentState.GetHashCode() + 31 * Command.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                StateTransition other = obj as StateTransition;
                return other != null && this.CurrentState == other.CurrentState && this.Command == other.Command;
            }

        }
        #endregion
    }
}
