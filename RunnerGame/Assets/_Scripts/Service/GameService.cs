using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdgeRunner
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        public PlayerService PlayerService { get; private set; }
        public EventService EventService { get; private set; }


        private void Start()
        {
            PlayerService = new PlayerService();
            EventService = new EventService();
        }
    }
}