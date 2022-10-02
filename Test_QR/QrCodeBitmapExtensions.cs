using Net.Codecrete.QrCodeGenerator;
using SkiaSharp;

namespace Test_QR;

public static class QrCodeBitmapExtensions
{
    public static SKBitmap ToBitmap(this QrCode qrCode, int scale, int border)
    {
        return qrCode.ToBitmap(scale, border, SKColors.Black, SKColors.White);
    }

    public static SKBitmap ToBitmap(this QrCode qrCode, int scale, int border, SKColor foreground, SKColor background)
    {
        if (scale <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(scale), "Value out of range");
        }
        if (border < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(border), "Value out of range");
        }

        int size = qrCode.Size;
        int dim = (size + border * 2) * scale;

        if (dim > short.MaxValue)
        {
            throw new ArgumentOutOfRangeException(nameof(scale), "Scale or border too large");
        }

        SKBitmap bitmap = new SKBitmap(dim, dim, SKColorType.Rgb888x, SKAlphaType.Opaque);

        using (SKCanvas canvas = new SKCanvas(bitmap))
        {
            using (SKPaint paint = new SKPaint { Color = background })
            {
                canvas.DrawRect(0, 0, dim, dim, paint);
            }
            
            using (SKPaint paint = new SKPaint { Color = foreground })
            {
                for (int y = 0; y < size; y++)
                {
                    for (int x = 0; x < size; x++)
                    {
                        if (qrCode.GetModule(x, y))
                        {
                            canvas.DrawRect((x + border) * scale, (y + border) * scale, scale, scale, paint);
                        }
                    }
                }
            }
        }
        return bitmap;
    }
}