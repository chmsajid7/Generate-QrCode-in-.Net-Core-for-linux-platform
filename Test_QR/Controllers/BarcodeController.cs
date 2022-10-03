using Microsoft.AspNetCore.Mvc;
using Net.Codecrete.QrCodeGenerator;
using SkiaSharp;
using SkiaSharp.QrCode;
using SkiaSharp.QrCode.Models;
using System.Net;

namespace Test_QR.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BarcodeController : ControllerBase
{
    [HttpGet]
    public string Get(string text)
    {
        var qrCode = QrCode.EncodeText(text, QrCode.Ecc.High);

        using SKBitmap bitmap = qrCode.ToBitmap(10, 0);

        using SKData data = bitmap.Encode(SKEncodedImageFormat.Png, 100);

        var res = Convert.ToBase64String(data.ToArray());

        return res;
    }

    [HttpGet("Logo")]
    public async Task<string> GetLogo(string text)
    {
        string someUrl = "http://www.google.com/images/logos/ps_logo2.png";
        var client = new HttpClient();

        using var response = await client.GetAsync(someUrl);
        byte[] imageBytes = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);

        var icon = new IconData
        {
            Icon = SKBitmap.Decode(imageBytes),
            IconSizePercent = 20,
        };

        using var generator = new QRCodeGenerator();
        var qr = generator.CreateQrCode(text, ECCLevel.H);
        var info = new SKImageInfo(300, 300);
        using var surface = SKSurface.Create(info);
        var canvas = surface.Canvas;
        canvas.Render(qr, info.Width, info.Height, SKColor.Parse("ffffff"), SKColor.Parse("000000"), icon);
        using var image = surface.Snapshot();
        using var data = image.Encode(SKEncodedImageFormat.Png, 100);

        var res = Convert.ToBase64String(data.ToArray());

        return res;
    }

}
// https://github.com/guitarrapc/SkiaSharp.QrCode#linux-support
// https://github.com/manuelbl/QrCodeGenerator#raster-images--bitmaps

//https://gist.github.com/guitarrapc/bc11f8d7c2ae3ce4e481aa391b5e0c88