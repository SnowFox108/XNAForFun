using Microsoft.Xna.Framework;
using System;

namespace ShooterForFunLibraries.GameLevels
{
    public class Level1 : IGameLevel
    {
        private float elapsedTime, stageElapsedTime, nextStageTime;
        private float intervalTime;

        private bool stage1, stage2, stage3;
        private Random random = new Random();

        public Level1()
        {
            intervalTime = 5.0f;
            nextStageTime = 10.0f;
        }

        public void Update(GameTime gameTime)
        {
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            stageElapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (stageElapsedTime > nextStageTime)
                RefreshStage();

            if (elapsedTime > intervalTime)
            {
                CreateEnemy();
                if (stage1)
                    CreateEnemy();
                if (stage2)
                    CreateEnemy();
                if (stage3)
                    CreateEnemy();
                elapsedTime = 0;
            }
        }

        public void RefreshStage()
        {
            if (stage2)
            {
                stage3 = true;
            }
            if (stage1)
            {
                stage2 = true;
                //nextStageTime += 20.0f;
            }
            stage1 = true;
            stageElapsedTime = 0;
            nextStageTime += 5.0f;
            if (nextStageTime > 10.0f && intervalTime > 1.0f)
                intervalTime -= 0.5f;
        }

        private void CreateEnemy()
        {
            EnemyManager.Instance.CreateEnemy(new Ballon(new Vector2(GameSettings.TargetScreenWidth + random.Next(500), random.Next(GameSettings.TargetScreenHeight - 61))));
        }
    }
}
