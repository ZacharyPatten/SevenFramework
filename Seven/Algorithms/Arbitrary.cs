// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Algorithms
{
	/// <summary>
	/// 
	/// </summary>
	/// <citation>
	/// This code has been adapted from the Math.Net Numerics project. Here is their license and plugs:
	/// 
	/// Math.NET Numerics, part of the Math.NET Project
	/// http://numerics.mathdotnet.com
	/// http://github.com/mathnet/mathnet-numerics
	/// http://mathnetnumerics.codeplex.com
	///
	/// Copyright (c) 2009-2014 Math.NET
	///
	/// Permission is hereby granted, free of charge, to any person
	/// obtaining a copy of this software and associated documentation
	/// files (the "Software"), to deal in the Software without
	/// restriction, including without limitation the rights to use,
	/// copy, modify, merge, publish, distribute, sublicense, and/or sell
	/// copies of the Software, and to permit persons to whom the
	/// Software is furnished to do so, subject to the following
	/// conditions:
	///
	/// The above copyright notice and this permission notice shall be
	/// included in all copies or substantial portions of the Software.
	///
	/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
	/// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
	/// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
	/// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
	/// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
	/// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
	/// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
	/// OTHER DEALINGS IN THE SOFTWARE.
	/// </citation>
	public class Arbitrary : System.Random
	{
		// fields
		private System.Func<int> _next;
		private System.Func<int, int> _nextMax;
		private System.Func<int, int, int> _nextMinMax;
		private System.Action<byte[]> _nextBytes;
		private System.Func<double> _nextDouble;
		private System.Func<double> _sample;
		// delegates
		/// <summary>Algorithm for generating a random integer value.</summary>
		/// <returns>The next random integer value produced by the algorithm.</returns>
		public delegate int ArbitraryIntegerGenerator();
		/// <summary>Algorithm for generating a random double values between 0.0 and 1.0.</summary>
		/// <returns>The next random double value produced by the algorithm.</returns>
		public delegate double ArbitraryDoubleGenerator_0to1();
		// algorithms
		#region MultiplicativeCongruentGenerator
		public static ArbitraryDoubleGenerator_0to1 MultiplicativeCongruentGenerator(int seed, ulong modulus, ulong multiplier)
		{
			double reciprocal = 1.0d / modulus;
			ulong xn = (uint) seed % modulus;

			return () =>
			{
				double ret = xn * reciprocal;
				xn = (xn * multiplier) % modulus;
				return ret;
			};
		}
		#endregion
		#region MultiplicativeCongruentGenerator_Modulus2power31minus1_Multiplier1132489760
		public static ArbitraryDoubleGenerator_0to1 MultiplicativeCongruentGenerator_Modulus2power31minus1_Multiplier1132489760()
		{
			return MultiplicativeCongruentGenerator_Modulus2power31minus1_Multiplier1132489760(System.Environment.TickCount);
		}
		public static ArbitraryDoubleGenerator_0to1 MultiplicativeCongruentGenerator_Modulus2power31minus1_Multiplier1132489760(int seed)
		{
			return MultiplicativeCongruentGenerator(seed, 2147483647, 1132489760);
		}
		#endregion
		#region MultiplicativeCongruentGenerator_Modulus2power59_Multiplier13power13
		public static ArbitraryDoubleGenerator_0to1 MultiplicativeCongruentGenerator_Modulus2power59_Multiplier13power13()
		{
			return MultiplicativeCongruentGenerator_Modulus2power59_Multiplier13power13(System.Environment.TickCount);
		}
		public static ArbitraryDoubleGenerator_0to1 MultiplicativeCongruentGenerator_Modulus2power59_Multiplier13power13(int seed)
		{
			return MultiplicativeCongruentGenerator(seed, 576460752303423488, 302875106592253);
		}
		#endregion
		#region MersenneTwister
		public static ArbitraryIntegerGenerator MersenneTwister()
		{
			return MersenneTwister(System.Environment.TickCount);
		}
		public static ArbitraryIntegerGenerator MersenneTwister(int seed)
		{
			// algorithm constants
			const uint LowerMask = 0x7fffffff;
			const int M = 397;
			const uint MatrixA = 0x9908b0df;
			const int N = 624;
			const uint UpperMask = 0x80000000;
			uint[] Mag01 = { 0x0U, MatrixA };
			uint[] _mt = new uint[N];
			int _mti = N + 1;
			// initialization
			_mt[0] = (uint)seed & 0xffffffff;
			for (_mti = 1; _mti < N; _mti++)
			{
				_mt[_mti] = 1812433253 * (_mt[_mti - 1] ^ (_mt[_mti - 1] >> 30)) + (uint)_mti;
				_mt[_mti] &= 0xffffffff;
			}
			// algorithm
			return () =>
				{
					int integer;
					do {
						uint y;
						if (_mti >= N)
						{
							int kk;
							for (kk = 0; kk < N - M; kk++)
							{
								y = (_mt[kk] & UpperMask) | (_mt[kk + 1] & LowerMask);
								_mt[kk] = _mt[kk + M] ^ (y >> 1) ^ Mag01[y & 0x1];
							}
							for (; kk < N - 1; kk++)
							{
								y = (_mt[kk] & UpperMask) | (_mt[kk + 1] & LowerMask);
								_mt[kk] = _mt[kk + (M - N)] ^ (y >> 1) ^ Mag01[y & 0x1];
							}
							y = (_mt[N - 1] & UpperMask) | (_mt[0] & LowerMask);
							_mt[N - 1] = _mt[M - 1] ^ (y >> 1) ^ Mag01[y & 0x1];

							_mti = 0;
						}
						y = _mt[_mti++];
						y ^= y >> 11;
						y ^= (y << 7) & 0x9d2c5680;
						y ^= (y << 15) & 0xefc60000;
						y ^= y >> 18;
						integer = (int)(y >> 1);
					} while (integer == int.MaxValue);
					return integer;
				};
		}
		#endregion
		#region CombinedMultipleRecursiveGenerator32bit_components2_order3
		public static ArbitraryDoubleGenerator_0to1 CombinedMultipleRecursiveGenerator32bit_components2_order3()
		{
			return CombinedMultipleRecursiveGenerator32bit_components2_order3(System.Environment.TickCount);
		}
		public static ArbitraryDoubleGenerator_0to1 CombinedMultipleRecursiveGenerator32bit_components2_order3(int seed)
		{
			const double A12 = 1403580;
			const double A13 = 810728;
			const double A21 = 527612;
			const double A23 = 1370589;
			const double Modulus1 = 4294967087;
			const double Modulus2 = 4294944443;
			const double Reciprocal = 1.0 / Modulus1;
			double _xn1 = 1;
			double _xn2 = 1;
			double _xn3 = (uint)seed;
			double _yn1 = 1;
			double _yn2 = 1;
			double _yn3 = 1;
			return () =>
				{
					double xn = A12 * _xn2 - A13 * _xn3;
					double k = (long)(xn / Modulus1);
					xn -= k * Modulus1;
					if (xn < 0)
						xn += Modulus1;
					double yn = A21 * _yn1 - A23 * _yn3;
					k = (long)(yn / Modulus2);
					yn -= k * Modulus2;
					if (yn < 0)
						yn += Modulus2;
					_xn3 = _xn2;
					_xn2 = _xn1;
					_xn1 = xn;
					_yn3 = _yn2;
					_yn2 = _yn1;
					_yn1 = yn;
					if (xn <= yn)
						return (xn - yn + Modulus1) * Reciprocal;
					return (xn - yn) * Reciprocal;
				};
		}
		#endregion
		#region WichmannHills1982_CombinedMultiplicativeCongruentialGenerator
		public static ArbitraryDoubleGenerator_0to1 WichmannHills1982_CombinedMultiplicativeCongruentialGenerator()
		{
			return WichmannHills1982_CombinedMultiplicativeCongruentialGenerator(System.Environment.TickCount);
		}
		public static ArbitraryDoubleGenerator_0to1 WichmannHills1982_CombinedMultiplicativeCongruentialGenerator(int seed)
		{
			const uint Modx = 30269;
			const double ModxRecip = 1.0 / Modx;
			const uint Mody = 30307;
			const double ModyRecip = 1.0 / Mody;
			const uint Modz = 30323;
			const double ModzRecip = 1.0 / Modz;
			uint _xn = (uint)seed % Modx;
			uint _yn = 1;
			uint _zn = 1;
			return () =>
				{
					_xn = (171 * _xn) % Modx;
					_yn = (172 * _yn) % Mody;
					_zn = (170 * _zn) % Modz;
					double w = _xn * ModxRecip + _yn * ModyRecip + _zn * ModzRecip;
					w -= (int)w;
					return w;
				};
		}
		#endregion
		#region WichmannHills2006_CombinedMultiplicativeCongruentialGenerator
		public static ArbitraryDoubleGenerator_0to1 WichmannHills2006_CombinedMultiplicativeCongruentialGenerator()
		{
			return WichmannHills2006_CombinedMultiplicativeCongruentialGenerator(System.Environment.TickCount);
		}
		public static ArbitraryDoubleGenerator_0to1 WichmannHills2006_CombinedMultiplicativeCongruentialGenerator(int seed)
		{
			const uint Modw = 2147483123;
			const double ModwRecip = 1.0 / Modw;
			const uint Modx = 2147483579;
			const double ModxRecip = 1.0 / Modx;
			const uint Mody = 2147483543;
			const double ModyRecip = 1.0 / Mody;
			const uint Modz = 2147483423;
			const double ModzRecip = 1.0 / Modz;
			ulong _wn = 1;
			ulong _xn = (uint)seed % Modx;
			ulong _yn = 1;
			ulong _zn = 1;
			return () =>
				{
					_xn = 11600 * _xn % Modx;
					_yn = 47003 * _yn % Mody;
					_zn = 23000 * _zn % Modz;
					_wn = 33000 * _wn % Modw;

					double u = _xn * ModxRecip + _yn * ModyRecip + _zn * ModzRecip + _wn * ModwRecip;
					u -= (int)u;
					return u;
				};
		}
		#endregion
		#region MultiplyWithCarryXorshiftGenerator
		public static ArbitraryIntegerGenerator MultiplyWithCarryXorshiftGenerator()
		{
			return MultiplyWithCarryXorshiftGenerator(System.Environment.TickCount);
		}
		public static ArbitraryIntegerGenerator MultiplyWithCarryXorshiftGenerator(int seed)
		{
			return MultiplyWithCarryXorshiftGenerator(seed, 916905990, 13579, 362436069, 77465321);
		}
		public static ArbitraryIntegerGenerator MultiplyWithCarryXorshiftGenerator(int seed, long a, long c, long x1, long x2)
		{
			ulong _x; // Seed or last but three unsigned random number
			ulong _y; // Last but two unsigned random number
			ulong _z; // Last but one unsigned random number
			ulong _c; // The value of the carry over
			ulong _a; // The multiplier
			if (seed == 0)
				seed = 1;
			if (a <= c)
				throw new System.ArgumentOutOfRangeException("c", "c must be greater than or equal to a");
			_x = (uint)seed;
			_y = (ulong)x1;
			_z = (ulong)x2;
			_a = (ulong)a;
			_c = (ulong)c;
			return () =>
				{
					int int31;
					do
					{
						var t = (_a * _x) + _c;
						_x = _y;
						_y = _z;
						_c = t >> 32;
						_z = t & 0xffffffff;
						uint uint32 = (uint)_z;
						int31 = (int)(uint32 >> 1);
					} while (int31 == int.MaxValue);
					return int31;
				};
		}

		#endregion
		// constructors
		public Arbitrary(ArbitraryIntegerGenerator integerGenerator)
		{
			this._next = new System.Func<int>(integerGenerator);
			this._nextMax = (int max) => { return integerGenerator() % max; };
			this._nextMinMax = (int min, int max) => { return integerGenerator() % (max - min) + min; };
			this._nextBytes = (byte[] buffer) => { throw new System.NotImplementedException(); };
			this._nextDouble = () => { return 1.0D / (double)integerGenerator(); };
			this._sample = () => { return 1.0D / (double)integerGenerator(); };
		}
		public Arbitrary(ArbitraryDoubleGenerator_0to1 doubleGenerator_0to1)
		{
			this._next = () => { return (int)(int.MaxValue * doubleGenerator_0to1()); };
			this._nextMax = (int max) => { return (int)(doubleGenerator_0to1() * max); };
			this._nextMinMax = (int min, int max) => { return (int)(doubleGenerator_0to1() * (max - min)+ min); };
			this._nextBytes = (byte[] buffer) => { throw new System.NotImplementedException(); };
			this._nextDouble = new System.Func<double>(doubleGenerator_0to1);
			this._sample = new System.Func<double>(doubleGenerator_0to1);
		}
		// methods
		public override int Next() { return this._next(); }
		public override int Next(int maxValue) { return this._nextMax(maxValue); }
		public override int Next(int minValue, int maxValue) { return this._nextMinMax(minValue, maxValue); }
		public override void NextBytes(byte[] buffer) { this._nextBytes(buffer); }
		public override double NextDouble() { return this._nextDouble(); }
		protected override double Sample() { return this._sample(); }
		// operators
		public static implicit operator Arbitrary(ArbitraryIntegerGenerator arbitraryIntegerGenerator)
		{
			return new Arbitrary(arbitraryIntegerGenerator);
		}
		public static implicit operator Arbitrary(ArbitraryDoubleGenerator_0to1 arbitraryDoubleGenerator_0to1)
		{
			return new Arbitrary(arbitraryDoubleGenerator_0to1);
		}
	}
}
