using System.Web.Http;
using AnimalMarketEngine.Managers;
using AnimalMarketEngine.Model;

namespace AnimalMarketEngine.Controllers
{
  [RoutePrefix("api")] 
    public class GameController : ApiController
    {
        private readonly IGameManager _gameManager;

        public GameController(IGameManager gameManager)
        {
            _gameManager = gameManager;
        }
        // Test method
        [Route("game")]
        [AcceptVerbs("GET")]
        public Iteration Get()
        {
            return _gameManager.GetNextIteration();
        }
    }
}