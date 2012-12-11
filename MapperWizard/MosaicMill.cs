using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MapperWizard
{
    public class MosaicMill
    {
        public static void Generate(string path, HashSet<string> imagePaths, Dictionary<string, TaggedData> imagetags)
        {
            int counter = 1;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("#Line\tFrame\tLongitude\tLatitude\tAltitude\tHeading\tDate\tTime\tYear\tYaw\tPitch\tRoll\tTilt");
            sb.AppendLine("#Id\tId\tDec. deg.\tDec. deg.\tm\tdeg\tUTC\tdeg\tdeg\tdeg\ttag");

            foreach (string fn in imagePaths)
            {
                FileInfo fi = new FileInfo(fn);
                string name = fi.Name.ToUpper();
                if (imagetags.ContainsKey(name))
                {
                    sb.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,
                        "1\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}",
                        counter++,
                        imagetags[name].Lng,
                        imagetags[name].Lat,
                        imagetags[name].AltM,
                        imagetags[name].Yaw,
                        fi.CreationTimeUtc.ToString("MMMM dd", System.Globalization.CultureInfo.InvariantCulture), fi.CreationTimeUtc.ToString("HH:mm:ss"), fi.CreationTimeUtc.Year,
                        imagetags[name].Yaw,
                        imagetags[name].Pitch,
                        imagetags[name].Roll,
                        "ypr"));
                }
            }

            string file = path + "\\MosaicMill.GPS";
            StreamWriter sw = new StreamWriter(new FileStream(file, FileMode.Create));
            sw.Write(sb.ToString());
            sw.Close();




            sb.Clear();
            sb.AppendLine("# Created " + DateTime.Now + " by Gluon mapping wizard (http://www.gluonpilot.com)");
 
            sb.AppendLine("Projection: NUTM 27 WGS84 NoDatTra");
            //sb.AppendLine("Calibration_file: C:\EnsoMOSAIC\Camera\NikonD1_14mm.cal raw");
            //sb.AppendLine("Ground_control_point_file: .\Kirkko_UTM.gcp");
            sb.AppendLine("Approximate_terrain_altitude: 33.0");
            sb.AppendLine("Camera_rotation: 0");
            sb.AppendLine("Map_files: 0");

            counter = 1;
            foreach (string fn in imagePaths)
            {
                FileInfo fi = new FileInfo(fn);
                string name = fi.Name.ToUpper();
                if (imagetags.ContainsKey(name))
                {
                    sb.AppendLine(String.Format(System.Globalization.CultureInfo.InvariantCulture,
                        " 1 {0} {1} {2}",
                        counter,
                        fi.Name,
                        counter == 1 ? fi.DirectoryName : ""));
                    counter++;
                }
            }
            file = path + "\\MosaicMill.TRP";
            sw = new StreamWriter(new FileStream(file, FileMode.Create));
            sw.Write(sb.ToString());
            sw.Close();
        }
    }
}
