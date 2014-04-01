﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survivor
{
    public class HealthSpawner
    {
        public void Spawn(Arena arena)
        {
            if (arena.HealthPacks.Count < 10)
            {
                int x, y;

                do
                {
                    x = random.Next(80);
                    y = random.Next(25);
                } while (IsCloseTo(arena.Creatures, x, y));

                var healthPack = new HealthPack(x, y);
                arena.HealthPacks.Add(healthPack);
            }
        }

        private bool IsCloseTo(List<Creature> creatures, int x, int y)
        {
            foreach (var creature in creatures)
            {
                if (IsCloseTo(creature, x, y))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsCloseTo(Creature creature, int x, int y)
        {
            int xDistance = Math.Abs(creature.X - x);
            int yDistance = Math.Abs(creature.Y - y);

            return xDistance + yDistance < 10;
        }

        private Random random = new Random();
    }
}