namespace Aprillz.MewUI.Rendering;

public interface IExternalGpuWriteScope : IDisposable
{
    int PixelWidth { get; }

    int PixelHeight { get; }

    bool YFlipped { get; }

    void Flush();
}

public interface IGlExternalGpuWriteScope : IExternalGpuWriteScope
{
    uint FramebufferId { get; }

    uint TextureId { get; }
}

public interface IMetalExternalGpuWriteScope : IExternalGpuWriteScope
{
    nint Texture { get; }

    nint Device { get; }

    nint CommandQueue { get; }
}

public interface ID3D11ExternalGpuWriteScope : IExternalGpuWriteScope
{
    nint Device { get; }

    nint Texture2D { get; }

    nint DxgiSurface { get; }
}

public interface IExternalWritableGpuSurface : IRenderSurface
{
    IExternalGpuWriteScope BeginExternalWrite();

    void MarkExternalContentChanged();
}
