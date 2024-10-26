
namespace MathLib
{
	public struct Int16
		: IScalar<Int16>
		, IConvertable<Int16, UInt8>
		, IConvertable<Int16, UInt16>
		, IConvertable<Int16, UInt32>
		, IConvertable<Int16, UInt64>
		, IConvertable<Int16, Int32>
		, IConvertable<Int16, Int64>
		, IConvertable<Int16, Float32>
		, IConvertable<Int16, Float64>
	{
		short value;

		public static ScalarType Type => ScalarType.Integer;

		public static Int16 One => 1;

		public static Int16 Zero => 0;

		public static Int16 Two => 2;

		public static Int16 PI => throw new NotImplementedException();

		public static int Size => 2;

		public Int16(short value)
		{
			this.value = value;
		}

		public override string ToString()
			=> value.ToString();

		public static Int16 operator +(Int16 value)
			=> value.value;

		public static Int16 operator +(Int16 left, Int16 right)
			=> (short)(left.value + right.value);

		public static Int16 operator -(Int16 value)
			=> (short)(-value.value);

		public static Int16 operator -(Int16 left, Int16 right)
			=> (short)(left.value - right.value);

		public static Int16 operator ++(Int16 value)
			=> value.value++;

		public static Int16 operator --(Int16 value)
			=> value.value--;

		public static Int16 operator *(Int16 left, Int16 right)
			=> (short)(left.value * right.value);

		public static Int16 operator /(Int16 left, Int16 right)
			=> (short)(left.value / right.value);

		public static bool operator ==(Int16 left, Int16 right)
			=> left.value == right.value;

		public static bool operator !=(Int16 left, Int16 right)
			=> left.value != right.value;

		public static implicit operator short(Int16 i) => i.value;
		public static implicit operator Int16(short i) => new Int16(i);

		public static Int16 Sqrt(Int16 self)
		{
			return (short)MathF.Sqrt(self.value);
		}

		public static Int16 Cos(Int16 self)
		{
			return (short)MathF.Cos(self.value);
		}

		public static Int16 Sin(Int16 self)
		{
			return (short)MathF.Sin(self.value);
		}

		public static Int16 Tan(Int16 self)
		{
			return (short)MathF.Tan(self.value);
		}

		public static Int16 ACos(Int16 self)
		{
			throw new NotImplementedException();
		}

		public static Int16 ASin(Int16 self)
		{
			throw new NotImplementedException();
		}

		public static (Int16 sin, Int16 cos) SinCos(Int16 self)
		{
			throw new NotImplementedException();
		}

		public static Int16 Abs(Int16 self)
		{
			throw new NotImplementedException();
		}

		public static bool IsClose(Int16 self, Int16 num)
		{
			throw new NotImplementedException();
		}

		#region Unit conversions

		static UInt8 IConvertable<Int16, UInt8>.Convert(Int16 self)
			=> (byte)self.value;

		static UInt16 IConvertable<Int16, UInt16>.Convert(Int16 self)
			=> (ushort)self.value;

		static UInt32 IConvertable<Int16, UInt32>.Convert(Int16 self)
			=> (uint)self.value;

		static UInt64 IConvertable<Int16, UInt64>.Convert(Int16 self)
			=> (ulong)self.value;

		static Int32 IConvertable<Int16, Int32>.Convert(Int16 self)
			=> self.value;

		static Int64 IConvertable<Int16, Int64>.Convert(Int16 self)
			=> self.value;

		static Float32 IConvertable<Int16, Float32>.Convert(Int16 self)
			=> self.value;

		static Float64 IConvertable<Int16, Float64>.Convert(Int16 self)
			=> self.value;

		#endregion
	}
}
