using AnimalMarketEngine.Attributes;
using AnimalMarketEngine.DataAccess;
using AnimalMarketEngine.Engine;
using AnimalMarketEngine.Model;

namespace AnimalMarketEngine.Managers
{
    [LifecycleSingleton]
    public class GameManager : IGameManager
    {
        private readonly IEventListData _eventListData;
        private readonly IValueGenerator _valueGenerator;

        private Iteration _iterationLastValue;

        public GameManager(IEventListData eventListData, IValueGenerator valueGenerator)
        {
            _eventListData = eventListData;
            _valueGenerator = valueGenerator;
            InitGame();
        }

        private void InitGame()
        {
            _iterationLastValue = new Iteration
            {
                Calf = new IterationEventItemData {Cost = Calf.MeanCost, Name = Calf.Name},
                Pig = new IterationEventItemData {Cost = Pig.MeanCost, Name = Pig.Name},
                Lamb = new IterationEventItemData {Cost = Lamb.MeanCost, Name = Lamb.Name}
            };
        }

        public Iteration GetNextIteration()
        {
            var iteration = new Iteration
            {
                Calf = SetNextIterationForType(_iterationLastValue.Calf, _eventListData.GetCalfEvent(), Calf.MeanCost),
                Pig = SetNextIterationForType(_iterationLastValue.Pig, _eventListData.GetPigEvent(), Pig.MeanCost),
                Lamb = SetNextIterationForType(_iterationLastValue.Lamb, _eventListData.GetLambEvent(), Lamb.MeanCost)
            };
            _iterationLastValue = iteration;
            return iteration;
        }

        private IterationEventItemData SetNextIterationForType(IterationEventItemData animal, EventData data, double  meanValueTarget)
        {
            return new IterationEventItemData
            {
                Cost = _valueGenerator.GetNextValue(animal.Cost, data.Factor, data.FixChange, meanValueTarget),
                MessageText = data.StringTestId,
                Name = animal.Name
            };
        }

    }
}