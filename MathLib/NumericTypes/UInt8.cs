namespace MathLib
{
	public struct UInt8
		: INumericType<UInt8>
		, IConvertable<UInt8, UInt16>
		, IConvertable<UInt8, UInt32>
		, IConvertable<UInt8, UInt64>
		, IConvertable<UInt8, Int16>
		, IConvertable<UInt8, Int32>
		, IConvertable<UInt8, Int64>
		, IConvertable<UInt8, Float32>
		, IConvertable<UInt8, Float64>
	{
		byte value;

		public static ScalarType Type => ScalarType.Integer;

		public static UInt8 One => 1;

		public static UInt8 Zero => 0;

		public static UInt8 Two => 2;

		public static int Size => 1;

		public UInt8(byte value)
		{
			this.value = value;
		}

		public override string ToString()
			=> value.ToString();

		public static UInt8 operator +(UInt8 value)
			=> value.value;

		public static UInt8 operator +(UInt8 left, UInt8 right)
			=> (byte)(left.value + right.value);

		public static UInt8 operator -(UInt8 value)
			=> (byte)-value.value;

		public static UInt8 operator -(UInt8 left, UInt8 right)
			=> (byte)(left.value - right.value);

		public static UInt8 operator ++(UInt8 value)
			=> value.value++;

		public static UInt8 operator --(UInt8 value)
			=> value.value--;

		public static UInt8 operator *(UInt8 left, UInt8 right)
			=> (byte)(left.value * right.value);

		public static UInt8 operator /(UInt8 left, UInt8 right)
			=> (byte)(left.value / right.value);

		public static bool operator ==(UInt8 left, UInt8 right)
			=> left.value == right.value;

		public static bool operator !=(UInt8 left, UInt8 right)
			=> left.value != right.value;

		public static implicit operator byte(UInt8 i) => i.value;
		public static implicit operator UInt8(byte i) => new UInt8(i);

		public static UInt8 Abs(UInt8 self)
		{
			throw new NotImplementedException();
		}

		public static bool IsClose(UInt8 self, UInt8 num)
		{
			throw new NotImplementedException();
		}

		public static UInt8 FromInteger(int number)
			=> new((byte)number);

		public static UInt8 FromInteger(uint number)
			=> new((byte)number);

		#region Unit conversions

		static UInt16 IConvertable<UInt8, UInt16>.Convert(UInt8 self)
			=> self.value;

		static UInt32 IConvertable<UInt8, UInt32>.Convert(UInt8 self)
			=> self.value;

		static UInt64 IConvertable<UInt8, UInt64>.Convert(UInt8 self)
			=> self.value;

		static Int16 IConvertable<UInt8, Int16>.Convert(UInt8 self)
			=> self.value;

		static Int32 IConvertable<UInt8, Int32>.Convert(UInt8 self)
			=> self.value;

		static Int64 IConvertable<UInt8, Int64>.Convert(UInt8 self)
			=> self.value;

		static Float32 IConvertable<UInt8, Float32>.Convert(UInt8 self)
			=> self.value;

		static Float64 IConvertable<UInt8, Float64>.Convert(UInt8 self)
			=> self.value;

		#endregion
	}
}
