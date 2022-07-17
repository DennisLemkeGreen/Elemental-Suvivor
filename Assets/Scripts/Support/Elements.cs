using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter.Scripts.Support
{
	public enum Elements
	{
		FIRE, WATER, GRASS, STEAM, POISON, ICE
	}

	public class ElementalEffectiveness
	{
		static float N = 0.5f;
		static float V = 2.0f;
		static float S = 1.0f;

		static float[][] values = new float[6][]
		{
			new float[6] { S, V, S, S, S, S },
			new float[6] { N, N, S, S, S, S },
			new float[6] { V, N, S, S, S, S },
			new float[6] { S, S, S, S, S, S },
			new float[6] { S, S, S, S, S, S },
			new float[6] { S, S, S, S, S, S },
		};

		public static float Effectiveness(Elements left, Elements right)
		{
			return values[(int)right][(int)left];
		}
	}
}
