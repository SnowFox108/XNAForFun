using Microsoft.Xna.Framework;
using ShooterForFunLibraries.Graphics;
using ShooterForFunLibraries.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShooterForFunLibraries.Intelligents
{
    public class SimpleFireLogic : IFireLogic
    {
        public float FireRate { get; set; }

        private float elapsedTime;

        public SimpleFireLogic()
        {
            FireRate = 3.0f;
        }

        public void Fire(GameTime gameTime, Vector2 position, IWeapon weapon)
        {
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (elapsedTime > FireRate)
            {
                weapon.Fire(position);
                elapsedTime = 0;
            }
        }
    }
}
