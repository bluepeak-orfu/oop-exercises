using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTravelCo.Managers;
using TrainTravelCo.Models;

namespace TrainTravelCo.Controllers
{
    [Route("train")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private TrainManager _trainManager;

        public TrainController()
        {
            _trainManager = new TrainManager();
        }

        [HttpGet]
        public List<Train> ListTrains()
        {
            return _trainManager.List();
        }

        [HttpPost]
        public Train CreateTrain(Train train)
        {
            return _trainManager.Save(train);
        }
    }
}
