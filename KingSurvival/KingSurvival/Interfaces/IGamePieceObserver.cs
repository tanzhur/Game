﻿namespace KingSurvival.Interfaces
{
    public interface IGamePieceObserver //observer from behaviour design pattern
    {
        void Notify(char ID, ICoordinates newPosition);
    }
}