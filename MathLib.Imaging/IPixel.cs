using System;

namespace MathLib
{
	public interface IPixel<TSelf>
		where TSelf : unmanaged, IPixel<TSelf>
	{
		static abstract ScalarType ChannelType { get; }

		static abstract int Channels { get; }

		static abstract int BitDepth { get; }
	}

	public struct PixelFormat
	{
		public ScalarType channelType;
		public int channels;
		public int bytesPerChannel;

		public PixelFormat(ScalarType type, int channels, int bytesPerChannel)
		{
			this.channelType = type;
			this.channels = channels;
			this.bytesPerChannel = bytesPerChannel;
		}

		public static PixelFormat FromPixel<TPixel>() where TPixel : unmanaged, IPixel<TPixel>
		{
			return new(TPixel.ChannelType, TPixel.Channels, TPixel.BitDepth / 8);
		}
	}
}
