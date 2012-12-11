using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Media.Imaging;

namespace MapperWizard
{
    public class Geotagger
    {

        private static UInt32[] getExifCoordinate(double coordinate)
        {
            //if (coordinate < 0)
            //    coordinate = -coordinate;

            //UInt32 Deg = (uint)Math.Floor(coordinate);
            //UInt32 Min = (uint)Math.Floor((coordinate - Deg) * 60 * 100);
            //return new UInt32[] { Deg, 1, Min, 100, 0, 1 };

            double sf = Math.Round(Math.Abs(coordinate) * 360000);       //bb
            double m = Math.Floor(sf / 6000) % 60;      //ª
            double d = Math.Floor(sf / 360000);          //x
            double s = ((Math.Abs(coordinate) - d) * 60.0 - m) * 60.0;
            return new UInt32[] { Convert.ToUInt32(d), 1, Convert.ToUInt32(m), 1, Convert.ToUInt32(s * 100), 100 };
        }

        public static void Geotag(string imagepath, string imagename, double lat, double lng, double alt)
        {
            BitmapCreateOptions createOptions = BitmapCreateOptions.PreservePixelFormat | BitmapCreateOptions.IgnoreColorProfile;

            uint paddingAmount = 2048; // 2Kb padding for this example, but really this can be any value. 
            // Our recommendation is to keep this between 1Kb and 5Kb as most metadata updates are not large.

            // High level overview:
            //   1. Perform a lossles transcode on the JPEG
            //   2. Add appropriate padding
            //   3. Optionally add whatever metadata we need to add initially
            //   4. Save the file
            //   5. For sanity, we verify that we really did a lossless transcode
            //   6. Open the new file and add metadata in-place

            using (Stream originalFile = File.Open(imagepath, FileMode.Open, FileAccess.Read))
            {
                BitmapDecoder original = BitmapDecoder.Create(originalFile, createOptions, BitmapCacheOption.None);

                if (!original.CodecInfo.FileExtensions.Contains("jpg"))
                {
                    Console.WriteLine("The file you passed in is not a JPEG.");
                    return;
                }

                JpegBitmapEncoder output = new JpegBitmapEncoder();

                // If you're just interested in doing a lossless transcode without adding metadata, just do this:
                //output.Frames = original.Frames;

                // If you want to add metadata to the image using the InPlaceBitmapMetadataWriter, first add padding:
                if (original.Frames[0] != null && original.Frames[0].Metadata != null)
                {
                    BitmapMetadata metadata = original.Frames[0].Metadata.Clone() as BitmapMetadata;

                    // Of the metadata handlers that we ship in WIC, padding can only exist in IFD, EXIF, and XMP.
                    // Third parties implementing their own metadata handler may wish to support IWICFastMetadataEncoder
                    // and hence support padding as well.
                    metadata.SetQuery("/app1/ifd/PaddingSchema:Padding", paddingAmount);
                    metadata.SetQuery("/app1/ifd/exif/PaddingSchema:Padding", paddingAmount);
                    metadata.SetQuery("/xmp/PaddingSchema:Padding", paddingAmount);


                    bool north = (lat > 0);
                    bool west = (lng < 0);

                    if (north)
                    {
                        metadata.SetQuery("/app1/ifd/gps/subifd:{char=1}", "N");
                        metadata.SetQuery("/app1/ifd/gps/subifd:{ulong=2}", getExifCoordinate(lat));
                    }
                    else
                    {
                        metadata.SetQuery("/app1/ifd/gps/subifd:{char=1}", "S");
                        metadata.SetQuery("/app1/ifd/gps/subifd:{ulong=2}", getExifCoordinate(lat));
                    }

                    if (west)
                    {
                        metadata.SetQuery("/app1/ifd/gps/subifd:{char=3}", "W");
                        metadata.SetQuery("/app1/ifd/gps/subifd:{ulong=4}", getExifCoordinate(lng));
                    }
                    else
                    {
                        metadata.SetQuery("/app1/ifd/gps/subifd:{char=3}", "E");
                        metadata.SetQuery("/app1/ifd/gps/subifd:{ulong=4}", getExifCoordinate(lng));
                    }

                    metadata.SetQuery("/app1/ifd/gps/subifd:{ulong=6}", Convert.ToUInt32(alt));


                    // Create a new frame identical to the one from the original image, except the metadata will have padding.
                    // Essentially we want to keep this as close as possible to:
                    //     output.Frames = original.Frames;
                    output.Frames.Add(BitmapFrame.Create(original.Frames[0], original.Frames[0].Thumbnail, metadata, original.Frames[0].ColorContexts));
                }

                using (Stream outputFile = File.Open(imagepath + ".temp", FileMode.Create, FileAccess.ReadWrite))
                {

                    output.Save(outputFile);
                }
                originalFile.Close();
                File.Delete(imagepath);
                File.Move(imagepath + ".temp", imagepath);
            }


            //Bitmap theImage = new Bitmap(fn);


            //double lng = double.Parse(image_tags[name].Lng, System.Globalization.CultureInfo.InvariantCulture);
            //double sf = Math.Round(lng * 360000);       //bb
            //double m = Math.Floor(sf / 6000) % 60;      //ª
            //double d = Math.Floor(sf / 360000);          //x
            //double s = ((lng - d) * 60.0 - m) * 60.0;


            //// Set longitude
            //PropertyItem pi = theImage.PropertyItems[0];
            //pi.Id = 0x0004; // lng;
            //pi.Type = 5;
            //pi.Len = 24;
            //pi.Value = coord(d, m, s);
            //theImage.SetPropertyItem(pi);

            //// Set longitude reference
            //PropertyItem pi2 = theImage.PropertyItems[0];
            //pi2.Id = 0x0003; // lngref;
            //pi2.Type = 2; //ascii
            //pi2.Len = 2;
            //pi2.Value = lng > 0 ? new byte[] { 69, 0 } : new byte[] { 87, 0 };
            //theImage.SetPropertyItem(pi2);

            //// Latitude
            //double lat = double.Parse(image_tags[name].Lat, System.Globalization.CultureInfo.InvariantCulture);
            //sf = Math.Round(lat * 360000);       //bb
            //m = Math.Floor(sf / 6000) % 60;      //ª
            //d = Math.Floor(sf / 360000);          //x
            //s = ((lat - d) * 60.0 - m) * 60.0;

            //// Set latitude
            //PropertyItem pi6 = theImage.PropertyItems[0];
            //pi6.Id = 0x0002; // lat;
            //pi6.Type = 5;
            //pi6.Len = 24;
            //pi6.Value = coord(d, m, s);
            //theImage.SetPropertyItem(pi6);

            //// Set latitude reference
            //PropertyItem pi5 = theImage.PropertyItems[0];
            //pi5.Id = 0x0001; // latref;
            //pi5.Type = 2; //ascii
            //pi5.Len = 2;
            //pi5.Value = lat > 0 ? new byte[] { 78, 0 } : new byte[] { 83, 0 };
            //theImage.SetPropertyItem(pi5);

            //// Set altitude
            //PropertyItem pi3 = theImage.PropertyItems[0];
            //pi3.Id = 0x0006; // alt;
            //pi3.Type = 4; //PropertyTagTypeRational;
            //pi3.Len = 4;
            //pi3.Value = BitConverter.GetBytes((UInt32)UInt32.Parse(image_tags[name].AltM));
            //theImage.SetPropertyItem(pi3); ;

            //// Try to write lossless
            //System.Drawing.Imaging.Encoder Enc = System.Drawing.Imaging.Encoder.Transformation;
            //EncoderParameters EncParms = new EncoderParameters(1);
            //EncoderParameter EncParm;
            //ImageCodecInfo CodecInfo = GetEncoderInfo("image/jpeg");
            //EncParm = new EncoderParameter(Enc, (long)EncoderValue.TransformRotate90);
            //EncParms.Param[0] = EncParm;

            //// now write the rotated image with new description
            //theImage.Save(fn + "tagged90.jpg", CodecInfo, EncParms);

            //// for computers with low memory and large pictures: release memory now
            //theImage.Dispose();
            //theImage = null;
            //GC.Collect();

            //// now must rotate back the written picture
            //theImage = new Bitmap(fn + "tagged90.jpg");
            //EncParm = new EncoderParameter(Enc, (long)EncoderValue.TransformRotate270);
            //EncParms.Param[0] = EncParm;
            //theImage.Save(fn + "tagged.jpg", CodecInfo, EncParms);

            //System.IO.File.Delete(fn + "tagged90.jpg");

            //// release memory now
            //theImage.Dispose();
            //theImage = null;
            //GC.Collect();

            
        //private byte[] coord(double degrees, double minutes, double seconds)
        //{
        //    //     MessageBox.Show(words[2], "words[2]");
        //    UInt32 x = Convert.ToUInt32(degrees);
        //    byte[] xa = BitConverter.GetBytes(x);
        //    UInt32 x2 = 1;
        //    byte[] xb = BitConverter.GetBytes(x2);

        //    UInt32 y = Convert.ToUInt32(minutes);
        //    byte[] ya = BitConverter.GetBytes(y);
        //    UInt32 y2 = 1;
        //    byte[] yb = BitConverter.GetBytes(y2);

        //    UInt32 z = Convert.ToUInt32(seconds * 100);
        //    byte[] za = BitConverter.GetBytes(z);
        //    UInt32 z2 = 100;
        //    byte[] zb = BitConverter.GetBytes(z2);


        //    byte[] res = { xa[0], xa[1], xa[2], xa[3], xb[0], xb[1], xb[2], xb[3],
        //                   ya[0], ya[1], ya[2], ya[3], yb[0], yb[1], yb[2], yb[3],
        //                   za[0], za[1], za[2], za[3], zb[0], zb[1], zb[2], zb[3]};
        //    return res;
        //}
        //private static ImageCodecInfo GetEncoderInfo(String mimeType)
        //{
        //    int j;
        //    ImageCodecInfo[] encoders;
        //    encoders = ImageCodecInfo.GetImageEncoders();
        //    for (j = 0; j < encoders.Length; ++j)
        //    {
        //        if (encoders[j].MimeType == mimeType)
        //            return encoders[j];
        //    } return null;
        //}
        }
    }
}
