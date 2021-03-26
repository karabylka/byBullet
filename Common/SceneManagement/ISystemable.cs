using Microsoft.Xna.Framework;
using DefaultEcs.System;

namespace Common.SceneManagement
{
    public interface ISystemable
    {
        ISystem<GameTime> UpdateSystems { get; set; }
        ISystem<GameTime> DrawSystems  { get; set; }
        void SetEntities();
        void SetSystems();
    }
}