using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdgeRunner
{
    public class PlayerController 
    {
        private PlayerModel playerModel;
        private PlayerView playerView;

        public PlayerController(PlayerModel _playerModel, PlayerView _playerView)
        {
            playerModel = _playerModel;
            playerView = _playerView;
        }
    }
}