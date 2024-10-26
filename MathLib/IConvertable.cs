namespace MathLib
{
	public interface IConvertable<TSelf, TOther>
		where TSelf : unmanaged, IScalar<TSelf>
		where TOther : unmanaged, IScalar<TOther>
	{
		static abstract TOther Convert(TSelf self);
	}
}
