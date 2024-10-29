namespace MathLib
{
	public interface IConvertable<TSelf, TOther>
		where TSelf : unmanaged, INumericType<TSelf>
		where TOther : unmanaged, INumericType<TOther>
	{
		static abstract TOther Convert(TSelf self);
	}
}
