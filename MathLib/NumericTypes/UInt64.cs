namespace MathLib
{
	public struct UInt64
		: INumericType<UInt64>
		, IConvertable<UInt64, UInt8>
		, IConvertable<UInt64, UInt16>
		, IConvertable<UInt64, UInt32>
		, IConvertable<UInt64, Int16>
		, IConvertable<UInt64, Int32>
		, IConvertable<UInt64, Int64>
		, IConvertable<UInt64, Float32>
		, IConvertable<UInt64, Float64>
	{
		ulong value;

		public static ScalarType Type => ScalarType.Integer;

		public static UInt64 One => 1;

		public static UInt64 Zero => 0;

		public static UInt64 Two => 2;

		public static int Size => 8;

		public UInt64(ulong value)
		{
			this.value = value;
		}

		public override string ToString()
			=> value.ToString();

		public static UInt64 operator +(UInt64 value)
			=> value.value;

		public static UInt64 operator +(UInt64 left, UInt64 right)
			=> (ulong)(left.value + right.value);

		public static UInt64 operator -(UInt64 value)
			=> throw new NotImplementedException();

		public static UInt64 operator -(UInt64 left, UInt64 right)
			=> (ulong)(left.value - right.value);

		public static UInt64 operator ++(UInt64 value)
			=> value.value++;

		public static UInt64 operator --(UInt64 value)
			=> value.value--;

		public static UInt64 operator *(UInt64 left, UInt64 right)
			=> (ulong)(left.value * right.value);

		public static UInt64 operator /(UInt64 left, UInt64 right)
			=> (ulong)(left.value / right.value);

		public static bool operator ==(UInt64 left, UInt64 right)
			=> left.value == right.value;

		public static bool operator !=(UInt64 left, UInt64 right)
			=> left.value != right.value;

		public static implicit operator ulong(UInt64 i) => i.value;
		public static implicit operator UInt64(ulong i) => new UInt64(i);

		public static UInt64 Abs(UInt64 self)
		{
			throw new NotImplementedException();
		}

		public static bool IsClose(UInt64 self, UInt64 num)
		{
			throw new NotImplementedException();
		}

		public static UInt64 FromInteger(int number)
			=> new((ulong)number);

		public static UInt64 FromInteger(uint number)
			=> new(number);

		#region Unit conversions

		static UInt8 IConvertable<UInt64, UInt8>.Convert(UInt64 self)
			=> (byte)self.value;

		static UInt16 IConvertable<UInt64, UInt16>.Convert(UInt64 self)
			=> (ushort)self.value;

		static UInt32 IConvertable<UInt64, UInt32>.Convert(UInt64 self)
			=> (uint)self.value;

		static Int16 IConvertable<UInt64, Int16>.Convert(UInt64 self)
			=> (short)self.value;

		static Int32 IConvertable<UInt64, Int32>.Convert(UInt64 self)
			=> (int)self.value;

		static Int64 IConvertable<UInt64, Int64>.Convert(UInt64 self)
			=> (long)self.value;

		static Float32 IConvertable<UInt64, Float32>.Convert(UInt64 self)
			=> self.value;

		static Float64 IConvertable<UInt64, Float64>.Convert(UInt64 self)
			=> self.value;

		#endregion
	}
}
