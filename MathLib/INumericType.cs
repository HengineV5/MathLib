using System.Numerics;

namespace MathLib
{
	public enum ScalarType
	{
		Integer,
		Fixed,
		Floating
	}

	public interface INumericType<TSelf>
		  : IAdditionOperators<TSelf, TSelf, TSelf>,
			ISubtractionOperators<TSelf, TSelf, TSelf>,
			IDivisionOperators<TSelf, TSelf, TSelf>,
			IMultiplyOperators<TSelf, TSelf, TSelf>,
			IIncrementOperators<TSelf>,
			IDecrementOperators<TSelf>,
			IUnaryNegationOperators<TSelf, TSelf>,
			IUnaryPlusOperators<TSelf, TSelf>
		where TSelf : unmanaged, INumericType<TSelf>
	{
		static abstract ScalarType Type { get; }

		static abstract TSelf One { get; }

		static abstract TSelf Zero { get; }

		static abstract TSelf Two { get; }

		static abstract int Size { get; }

		static abstract TSelf Abs(TSelf self);

		static abstract bool IsClose(TSelf self, TSelf num);

		static abstract TSelf FromInteger(int number);

		static abstract TSelf FromInteger(uint number);
	}

	public interface IFloatingNumericType<TSelf>
		where TSelf : unmanaged, INumericType<TSelf>, IFloatingNumericType<TSelf>
	{
		static abstract TSelf PI { get; }

		static abstract TSelf Sqrt(TSelf self);

		static abstract TSelf Cos(TSelf self);

		static abstract TSelf ACos(TSelf self);

		static abstract TSelf Sin(TSelf self);

		static abstract TSelf ASin(TSelf self);

		static abstract TSelf Tan(TSelf self);

		static abstract (TSelf sin, TSelf cos) SinCos(TSelf self);

		static abstract TSelf FromFloat(float number);

		static abstract TSelf FromFloat(double number);
	}
}
