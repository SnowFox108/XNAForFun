using Microsoft.Xna.Framework;
using ShooterForFunLibraries.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterForFunLibraries.Intelligents
{
    public interface IFireLogic
    {
        float FireRate { get; set; }
        void Fire(GameTime gameTime, Vector2 position, IWeapon weapon);
    }
}
