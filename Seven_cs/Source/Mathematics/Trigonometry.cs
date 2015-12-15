// Seven
// https://github.com/53V3N1X/SevenFramework
// LISCENSE: See "LISCENSE.md" in th root project directory.
// SUPPORT: See "SUPPORT.md" in the root project directory.

namespace Seven.Mathematics
{
	/// <summary>Contains generic mathematics trigonometry operations.</summary>
	public static class Trigonometry<T>
	{
		#region Delegates

		public static class delegates
		{

			public delegate T sin(T angle);
			public delegate T cos(T angle);
			public delegate T tan(T angle);
			public delegate T sec(T angle);
			public delegate T csc(T angle);
			public delegate T cot(T angle);
			public delegate T asin(T ratio);
			public delegate T acos(T ratio);
			public delegate T atan(T ratio);
			public delegate T acsc(T ratio);
			public delegate T asec(T ratio);
			public delegate T acot(T ratio);
			public delegate T sinh(T angle);
			public delegate T cosh(T angle);
			public delegate T tanh(T angle);
			public delegate T sech(T angle);
			public delegate T csch(T angle);
			public delegate T coth(T angle);
			public delegate T asinh(T ratio);
			public delegate T acosh(T ratio);
			public delegate T atanh(T ratio);
			public delegate T acsch(T ratio);
			public delegate T asech(T ratio);
			public delegate T acoth(T ratio);

		}

		#endregion

		#region Implementations
			


		#endregion

		#region generic

		//public static generic toRadians(generic angle)
		//{
		//		return (generic)((double)angle * Constants<generic>.pi_double / 180d);
		//}

		//public static generic toDegrees(generic angle)
		//{
		//		return (generic)((double)angle * 180d / Constants<generic>.pi_double);
		//}

		//public static generic sin(generic angle)
		//{
		//		return (generic)System.Math.Sin((double)angle);

		//		// THE FOLLOWING IS PERSONAL SIN FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
		//		// THE SYSTEM FUNCTION IN ITS CURRENT STATE
		//		#region Custom Sin Function
		//		//// get the angle to be within the unit circle
		//		//angle = angle % (TwoPi);

		//		//// if the angle is negative, inverse it against the full unit circle
		//		//if (angle < 0)
		//		//	angle = TwoPi + angle;

		//		//// adjust for quadrants
		//		//// NOTE: if you want more accuracy, you can follow this pattern
		//		//// sin(x) = x - x^3/3! + x^5/5! - x^7/7! ...
		//		//// the more terms you include the more accurate it is
		//		//float angleCubed;
		//		//float angleToTheFifth;
		//		//// quadrant 1
		//		//if (angle <= HalfPi)
		//		//{
		//		//	angleCubed = angle * angle * angle;
		//		//	angleToTheFifth = angleCubed * angle * angle;
		//		//	return angle
		//		//		- ((angleCubed) / 6)
		//		//		+ ((angleToTheFifth) / 120);
		//		//}
		//		//// quadrant 2
		//		//else if (angle <= Pi)
		//		//{
		//		//	angle = HalfPi - (angle % HalfPi);
		//		//	angleCubed = angle * angle * angle;
		//		//	angleToTheFifth = angleCubed * angle * angle;
		//		//	return angle
		//		//		- ((angleCubed) / 6)
		//		//		+ ((angleToTheFifth) / 120);
		//		//}
		//		//// quadrant 3
		//		//else if (angle <= ThreeHalvesPi)
		//		//{
		//		//	angle = angle % Pi;
		//		//	angleCubed = angle * angle * angle;
		//		//	angleToTheFifth = angleCubed * angle * angle;
		//		//	return -(angle
		//		//			- ((angleCubed) / 6)
		//		//			+ ((angleToTheFifth) / 120));
		//		//}
		//		//// quadrant 4	
		//		//else
		//		//{
		//		//	angle = HalfPi - (angle % HalfPi);
		//		//	angleCubed = angle * angle * angle;
		//		//	angleToTheFifth = angleCubed * angle * angle;
		//		//	return -(angle
		//		//			- ((angleCubed) / 6)
		//		//			+ ((angleToTheFifth) / 120));
		//		//}
		//		#endregion
		//}

		//public static generic cos(generic angle)
		//{
		//		return (generic)System.Math.Cos((double)angle);

		//		// THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
		//		// THE SYSTEM FUNCTION IN ITS CURRENT STATE
		//		#region Custom Cos Function
		//		//// If you wanted to be cheap, you could just use the following commented line...
		//		//// return Sin(angle + (Pi / 2));

		//		//// get the angle to be within the unit circle
		//		//angle = angle % (TwoPi);

		//		//// if the angle is negative, inverse it against the full unit circle
		//		//if (angle < 0)
		//		//	angle = TwoPi + angle;

		//		//// adjust for quadrants
		//		//// NOTE: if you want more accuracy, you can follow this pattern
		//		//// cos(x) = 1 - x^2/2! + x^4/4! - x^6/6! ...
		//		//// the terms you include the more accuracy it is
		//		//float angleSquared;
		//		//float angleToTheFourth;
		//		//float angleToTheSixth;
		//		//// quadrant 1
		//		//if (angle <= HalfPi)
		//		//{
		//		//	angleSquared = angle * angle;
		//		//	angleToTheFourth = angleSquared * angle * angle;
		//		//	angleToTheSixth = angleToTheFourth * angle * angle;
		//		//	return 1
		//		//		- (angleSquared / 2)
		//		//		+ (angleToTheFourth / 24)
		//		//		- (angleToTheSixth / 720);
		//		//}
		//		//// quadrant 2
		//		//else if (angle <= Pi)
		//		//{
		//		//	angle = HalfPi - (angle % HalfPi);
		//		//	angleSquared = angle * angle;
		//		//	angleToTheFourth = angleSquared * angle * angle;
		//		//	angleToTheSixth = angleToTheFourth * angle * angle;
		//		//	return -(1
		//		//		- (angleSquared / 2)
		//		//		+ (angleToTheFourth / 24)
		//		//		- (angleToTheSixth / 720));
		//		//}
		//		//// quadrant 3
		//		//else if (angle <= ThreeHalvesPi)
		//		//{
		//		//	angle = angle % Pi;
		//		//	angleSquared = angle * angle;
		//		//	angleToTheFourth = angleSquared * angle * angle;
		//		//	angleToTheSixth = angleToTheFourth * angle * angle;
		//		//	return -(1
		//		//		- (angleSquared / 2)
		//		//		+ (angleToTheFourth / 24)
		//		//		- (angleToTheSixth / 720));
		//		//}
		//		//// quadrant 4	
		//		//else
		//		//{
		//		//	angle = HalfPi - (angle % HalfPi);
		//		//	angleSquared = angle * angle;
		//		//	angleToTheFourth = angleSquared * angle * angle;
		//		//	angleToTheSixth = angleToTheFourth * angle * angle;
		//		//	return 1
		//		//		- (angleSquared / 2)
		//		//		+ (angleToTheFourth / 24)
		//		//		- (angleToTheSixth / 720);
		//		//}
		//		#endregion
		//}

		//public static generic tan(generic angle)
		//{
		//		return (generic)System.Math.Tan((double)angle);

		//		// THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
		//		// THE SYSTEM FUNCTION IN ITS CURRENT STATE
		//		#region Custom Tan Function
		//		//// "sin / cos" results in "opposite side / adjacent side", which is equal to tangent
		//		//return Sin(angle) / Cos(angle);
		//		#endregion
		//}

		//public static generic sec(generic angle)
		//{
		//		return (generic)(1d / System.Math.Cos((double)angle));

		//		// THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
		//		// THE SYSTEM FUNCTION IN ITS CURRENT STATE
		//		#region Custom Sec Function
		//		//// by definition, sec is the reciprical of cos
		//		//return 1 / Cos(angle);
		//		#endregion
		//}

		//public static generic csc(generic angle)
		//{
		//		return (generic)(1d / System.Math.Sin((double)angle));

		//		// THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
		//		// THE SYSTEM FUNCTION IN ITS CURRENT STATE
		//		#region Custom Csc Function
		//		//// by definition, csc is the reciprical of sin
		//		//return 1 / Sin(angle);
		//		#endregion
		//}

		//public static generic cot(generic angle)
		//{
		//		return (generic)(1.0d / System.Math.Tan((double)angle));

		//		// THE FOLLOWING IS MY PERSONAL FUNCTION. IT WORKS BUT IT IS NOT AS FAST AS
		//		// THE SYSTEM FUNCTION IN ITS CURRENT STATE
		//		#region Custom Cot Function
		//		//// by definition, cot is the reciprical of tan
		//		//return 1 / Tan(angle);
		//		#endregion
		//}

		//public static generic arcsin(generic sinRatio)
		//{
		//		return (generic)System.Math.Asin((double)sinRatio);
		//		//I haven't made a custom ArcSin function yet...
		//}

		//public static generic arccos(generic cosRatio)
		//{
		//		return (generic)System.Math.Acos((double)cosRatio);
		//		//I haven't made a custom ArcCos function yet...
		//}

		//public static generic arctan(generic tanRatio)
		//{
		//		return (generic)System.Math.Atan((double)tanRatio);
		//		//I haven't made a custom ArcTan function yet...
		//}

		//public static generic arccsc(generic cscRatio)
		//{
		//		return (generic)System.Math.Asin(1.0d / (double)cscRatio);
		//		//I haven't made a custom ArcCsc function yet...
		//}

		//public static generic arcsec(generic secRatio)
		//{
		//		return (generic)System.Math.Acos(1.0d / (double)secRatio);
		//		//I haven't made a custom ArcSec function yet...
		//}

		//public static generic arccot(generic cotRatio)
		//{
		//		return (generic)System.Math.Atan(1.0d / (double)cotRatio);
		//		//I haven't made a custom ArcCot function yet...
		//}

		#endregion
	}
}
