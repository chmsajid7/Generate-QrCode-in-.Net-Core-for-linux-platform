using Microsoft.AspNetCore.Mvc;
using Net.Codecrete.QrCodeGenerator;
using SkiaSharp;

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
}
// https://github.com/guitarrapc/SkiaSharp.QrCode#linux-support
// https://github.com/manuelbl/QrCodeGenerator#raster-images--bitmaps