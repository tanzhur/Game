using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingSurvival
{
    public class GameEngine
    {
        private GameRenderer renderer;
        private GameController controller;

        public GameEngine(GameRenderer renderer, GameController controller)
        {
            // TODO: Complete member initialization
            this.renderer = renderer;
            this.controller = controller;
        }


        internal void StartGame()
        {
            throw new NotImplementedException();
        }
    }
}
