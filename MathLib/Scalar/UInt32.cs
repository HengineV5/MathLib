namespace MathLib
{
	public struct UInt32
		: IScalar<UInt32>
		, IConvertable<UInt32, UInt8>
		, IConvertable<UInt32, UInt16>
		, IConvertable<UInt32, UInt64>
		, IConvertable<UInt32, Int16>
		, IConvertable<UInt32, Int32>
		, IConvertable<UInt32, Int64>
		, IConvertable<UInt32, Float32>
		, IConvertable<UInt32, Float64>
	{
		uint value;

		public static ScalarType Type => ScalarType.Integer;

		public static UInt32 One => 1;

		public static UInt32 Zero => 0;

		public static UInt32 Two => 2;

		public static UInt32 PI => throw new NotImplementedException();

		public static int Size => 4;

		public UInt32(uint value)
		{
			this.value = value;
		}

		public override string ToString()
			=> value.ToString();

		public static UInt32 operator +(UInt32 value)
			=> value.value;

		public static UInt32 operator +(UInt32 left, UInt32 right)
			=> (uint)(left.value + right.value);

		public static UInt32 operator -(UInt32 value)
			=> (uint)-value.value;

		public static UInt32 operator -(UInt32 left, UInt32 right)
			=> (uint)(left.value - right.value);

		public static UInt32 operator ++(UInt32 value)
			=> value.value++;

		public static UInt32 operator --(UInt32 value)
			=> value.value--;

		public static UInt32 operator *(UInt32 left, UInt32 right)
			=> (uint)(left.value * right.value);

		public static UInt32 operator /(UInt32 left, UInt32 right)
			=> (uint)(left.value / right.value);

		public static bool operator ==(UInt32 left, UInt32 right)
			=> left.value == right.value;

		public static bool operator !=(UInt32 left, UInt32 right)
			=> left.value != right.value;

		public static implicit operator uint(UInt32 i) => i.value;
		public static implicit operator UInt32(uint i) => new UInt32(i);

		public static UInt32 Sqrt(UInt32 self)
		{
			throw new NotImplementedException();
		}

		public static UInt32 Cos(UInt32 self)
		{
			throw new NotImplementedException();
		}

		public static UInt32 Sin(UInt32 self)
		{
			throw new NotImplementedException();
		}

		public static UInt32 Tan(UInt32 self)
		{
			throw new NotImplementedException();
		}

		public static UInt32 ACos(UInt32 self)
		{
			throw new NotImplementedException();
		}

		public static UInt32 ASin(UInt32 self)
		{
			throw new NotImplementedException();
		}

		public static (UInt32 sin, UInt32 cos) SinCos(UInt32 self)
		{
			throw new NotImplementedException();
		}

		public static UInt32 Abs(UInt32 self)
		{
			throw new NotImplementedException();
		}

		public static bool IsClose(UInt32 self, UInt32 num)
		{
			throw new NotImplementedException();
		}

		#region Unit conversions

		static UInt8 IConvertable<UInt32, UInt8>.Convert(UInt32 self)
			=> (byte)self.value;

		static UInt16 IConvertable<UInt32, UInt16>.Convert(UInt32 self)
			=> (ushort)self.value;

		static UInt64 IConvertable<UInt32, UInt64>.Convert(UInt32 self)
			=> self.value;

		static Int16 IConvertable<UInt32, Int16>.Convert(UInt32 self)
			=> (short)self.value;

		static Int32 IConvertable<UInt32, Int32>.Convert(UInt32 self)
			=> (int)self.value;

		static Int64 IConvertable<UInt32, Int64>.Convert(UInt32 self)
			=> self.value;

		static Float32 IConvertable<UInt32, Float32>.Convert(UInt32 self)
			=> self.value;

		static Float64 IConvertable<UInt32, Float64>.Convert(UInt32 self)
			=> self.value;

		#endregion
	}
}
