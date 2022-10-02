// See https://aka.ms/new-console-template for more information
using System.Drawing;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.QrCode.Internal;

Console.WriteLine("Hello, World!");

ABC();


static string ABC()
{
    BarcodeWriter barcodeWriter = new BarcodeWriter();
    EncodingOptions encodingOptions = new EncodingOptions() { Width = 300, Height = 300, Margin = 0, PureBarcode = false };
    encodingOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
    barcodeWriter.Renderer = new BitmapRenderer();

    barcodeWriter.Options = encodingOptions;
    barcodeWriter.Format = BarcodeFormat.QR_CODE;
    Bitmap bitmap = barcodeWriter.Write("lll");
    Bitmap logo = new Bitmap("https://s0.2mdn.net/simgad/2829461782624784180");
    Graphics g = Graphics.FromImage(bitmap);
    g.DrawImage(logo, new Point((bitmap.Width - logo.Width) / 2, (bitmap.Height - logo.Height) / 2));
    
    pictureBox1.Image = bitmap;


    BarcodeWriter barcodeWriter = new BarcodeWriter()





    var options = new QrCodeEncodingOptions
    {
        Height = 400,
        Width = 400,
        Margin = 0,
        PureBarcode = true
    };

    var writer = new QRCodeWriter();
    var aaa = writer.encode("132", ZXing.BarcodeFormat.QR_CODE, 400, 400);

    var bbb = aaa.ToString();



    //{
    //    Format = BarcodeFormat.QR_CODE,
    //    Options = options
    //};

    //// Generate bitmap
    //var bitmap = writer.Write("132");
    //if (bitmap != null)
    //{
    //    // Get bytes from bitmap
    //    using (var stream = new MemoryStream())
    //    {
    //        bitmap.Compress(Bitmap.CompressFormat.Png, 100, stream);
    //        return stream.ToArray();
    //    }
    //}


    return "";
}

