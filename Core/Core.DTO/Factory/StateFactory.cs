using Core.Domain;

namespace Core.DTO.Factory
{
    public class StateFactory
    {
        public StateDTO Create(State state)
        {
            return new StateDTO()
            {
                StateID = state.StateID,
                Name = state.Name,
            };
        }
        public State Create(StateDTO state)
        {
            return new State()
            {
                StateID = state.StateID,
                Name = state.Name,
            };
        }
    }
}
