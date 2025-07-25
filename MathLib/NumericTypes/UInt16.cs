﻿namespace MathLib
{
	public struct UInt16
		: INumericType<UInt16>
		, IConvertable<UInt16, UInt8>
		, IConvertable<UInt16, UInt32>
		, IConvertable<UInt16, UInt64>
		, IConvertable<UInt16, Int16>
		, IConvertable<UInt16, Int32>
		, IConvertable<UInt16, Int64>
		, IConvertable<UInt16, Float32>
		, IConvertable<UInt16, Float64>
	{
		public ushort _value;

		public static ScalarType Type => ScalarType.Integer;

		public static UInt16 One => 1;

		public static UInt16 Zero => 0;

		public static UInt16 Two => 2;

		public static int Size => 2;

		public UInt16(ushort value)
		{
			this._value = value;
		}

		public override string ToString()
			=> _value.ToString();

		public static UInt16 operator +(UInt16 value)
			=> value._value;

		public static UInt16 operator +(UInt16 left, UInt16 right)
			=> (ushort)(left._value + right._value);

		public static UInt16 operator -(UInt16 value)
			=> (ushort)-value._value;

		public static UInt16 operator -(UInt16 left, UInt16 right)
			=> (ushort)(left._value - right._value);

		public static UInt16 operator ++(UInt16 value)
			=> value._value++;

		public static UInt16 operator --(UInt16 value)
			=> value._value--;

		public static UInt16 operator *(UInt16 left, UInt16 right)
			=> (ushort)(left._value * right._value);

		public static UInt16 operator /(UInt16 left, UInt16 right)
			=> (ushort)(left._value / right._value);

		public static bool operator ==(UInt16 left, UInt16 right)
			=> left._value == right._value;

		public static bool operator !=(UInt16 left, UInt16 right)
			=> left._value != right._value;

		public static bool operator <(UInt16 left, UInt16 right)
			=> left._value < right._value;

		public static bool operator <=(UInt16 left, UInt16 right)
			=> left._value <= right._value;

		public static bool operator >(UInt16 left, UInt16 right)
			=> left._value > right._value;

		public static bool operator >=(UInt16 left, UInt16 right)
			=> left._value >= right._value;

		public static implicit operator ushort(UInt16 i) => i._value;
		public static implicit operator UInt16(ushort i) => new UInt16(i);

		public static UInt16 Abs(UInt16 self)
		{
			throw new NotImplementedException();
		}

		public static bool IsClose(UInt16 self, UInt16 num)
		{
			throw new NotImplementedException();
		}

		public static UInt16 FromInteger(int number)
			=> new((ushort)number);

		public static UInt16 FromInteger(uint number)
			=> new((ushort)number);

		#region Unit conversions

		static UInt8 IConvertable<UInt16, UInt8>.Convert(UInt16 self)
			=> (byte)self._value;

		static UInt32 IConvertable<UInt16, UInt32>.Convert(UInt16 self)
			=> self._value;

		static UInt64 IConvertable<UInt16, UInt64>.Convert(UInt16 self)
			=> self._value;

		static Int16 IConvertable<UInt16, Int16>.Convert(UInt16 self)
			=> (short)self._value;

		static Int32 IConvertable<UInt16, Int32>.Convert(UInt16 self)
			=> self._value;

		static Int64 IConvertable<UInt16, Int64>.Convert(UInt16 self)
			=> self._value;

		static Float32 IConvertable<UInt16, Float32>.Convert(UInt16 self)
			=> self._value;

		static Float64 IConvertable<UInt16, Float64>.Convert(UInt16 self)
			=> self._value;

		#endregion
	}
}
