using System;
using System.Collections.Generic;
using System.IO;

using System.Net;
using System.Text;
using System.Windows.Forms;

namespace miniConf {
    public class FileUploader {

        public static string UserAgent = "miniConf/" + Application.ProductVersion;
        public static string ApplicationUrl = "https://mediacru.sh";

        public static long uploadMax, uploadProgress;

        /// <summary>
        /// Return a KeyValuePair with the response status as the key and another
        /// KeyValuePair as the value. The second KeyValuePair has the file hash as the key 
        /// (when the response status is UploadFileStatus.Success or UploadFileStatus.AlreadyUploaded),
        /// and the value is the HashInfo only when the response status is UploadFileStatus.AlreadyUploaded.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static KeyValuePair<UploadFileStatus, String> UploadFile(string filename) {
            FileInfo fi;

            uploadProgress = 0;

            if (File.Exists(filename)) {
                fi = new FileInfo(filename);
            } else {
                throw new Exception("Invalid file path or the file does not exist");
            }

            uploadMax = fi.Length;

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(string.Format("{0}/api/upload/file", ApplicationUrl));

            wr.Headers.Add("X-CORS-Status", "1");
            wr.UserAgent = UserAgent;
            wr.Method = "POST";

            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x", System.Globalization.NumberFormatInfo.InvariantInfo);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            boundary = "--" + boundary;

            using (Stream requestStream = wr.GetRequestStream()) {
                var buffer = Encoding.ASCII.GetBytes(boundary + Environment.NewLine);
                requestStream.Write(buffer, 0, buffer.Length);

                buffer = Encoding.UTF8.GetBytes(string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"{2}", "file", fi.Name, Environment.NewLine));
                requestStream.Write(buffer, 0, buffer.Length);

                buffer = Encoding.ASCII.GetBytes(string.Format("Content-Type: {0}{1}{1}", "application/octet-stream", Environment.NewLine));
                requestStream.Write(buffer, 0, buffer.Length);

                using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read)) {
                   CopyStream(fs, requestStream, Int32.MaxValue);
                            // fs.CopyTo(requestStream);
                }

                buffer = Encoding.ASCII.GetBytes(Environment.NewLine);
                requestStream.Write(buffer, 0, buffer.Length);

                buffer = Encoding.ASCII.GetBytes(boundary + "--");
                requestStream.Write(buffer, 0, buffer.Length);
            }

            string response_text;

            using (WebResponse response = wr.GetResponse()) {
                using (Stream responseStream = response.GetResponseStream()) {
                    using (MemoryStream stream = new MemoryStream()) {
                        {
                            CopyStream(responseStream, stream, Int32.MaxValue);
                            //responseStream.CopyTo(stream);
                            response_text = System.Text.Encoding.UTF8.GetString(stream.ToArray());
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(response_text)) {
                //JObject json = JsonConvert.DeserializeObject<JObject>(response_text);

                UploadFileStatus ufs = UploadFileStatus.Unknown;

                //if (json["x-status"] != null) {
                    //ufs = parse_uploadfile_status(Convert.ToString(json["x-status"]));

                    //if (ufs == UploadFileStatus.Success || ufs == UploadFileStatus.AlreadyUploaded) {
                        //string hash = Convert.ToString(json["hash"]);
                        /*
                        HashInfo hi = null;

                        if (json[hash] != null) {
                            hi = parse_hashinfo((JObject)json[hash]);
                        }
                        */
                        return new KeyValuePair<UploadFileStatus, string>(UploadFileStatus.Success, response_text);
                    //}
                //}
            } else {
                return new KeyValuePair<UploadFileStatus, string>(UploadFileStatus.NoResponse, "");
            }

            return new KeyValuePair<UploadFileStatus, string>(UploadFileStatus.Unknown, "");
        }


        /// <summary>
        /// Copies the contents of input to output. Doesn't close either stream.
        /// </summary>
        public static void CopyStream(Stream input, Stream output, int maxBytes) {
            byte[] buffer = new byte[8 * 1024];
            int len;
            while (maxBytes > 0 && (len = input.Read(buffer, 0, Math.Min(maxBytes, buffer.Length))) > 0) {
                output.Write(buffer, 0, len);
                maxBytes -= len;
                uploadProgress += len;
            }
        }

        /*
        private static HashInfo parse_hashinfo(JObject json) {
            if (json["blob_type"] != null) {
                HashInfo hs = new HashInfo(Convert.ToString(json["hash"]));
                switch (Convert.ToString(json["blob_type"])) {
                    case "image":
                        hs.Type = HashInfo.BlobType.Image;
                        break;
                    case "audio":
                        hs.Type = HashInfo.BlobType.Audio;
                        break;
                    case "video":
                        hs.Type = HashInfo.BlobType.Video;
                        break;
                    default:
                        break;
                }
                if (json["compression"] != null) {
                    hs.CompressionRatio = Convert.ToDouble(json["compression"]);
                }
                if (json["files"] != null) {
                    hs.Files = parse_files((Newtonsoft.Json.Linq.JArray)json["files"]);
                }
                if (json["extras"] != null) {
                    hs.ExtraFiles = parse_files((Newtonsoft.Json.Linq.JArray)json["extras"]);
                }
                if (json["metadata"] != null && json["metadata"].Type != JTokenType.Null) {
                    hs.Metadata = parse_meta((Newtonsoft.Json.Linq.JObject)json["metadata"]);
                }
                if (json["original"] != null) {
                    hs.Original = Convert.ToString(json["original"]);
                }
                if (json["type"] != null) {
                    hs.OriginalMimeType = Convert.ToString(json["type"]);
                }
                if (hs.Type == HashInfo.BlobType.Video) {
                    if (json["flags"] != null) {
                        hs.Flags = parse_video_flags((Newtonsoft.Json.Linq.JObject)json["flags"]);
                    }
                }
                return hs;
            }
            return null;
        }*/

        public enum UploadFileStatus {
            /// <summary>
            /// The file was uploaded correctly.
            /// Http code: 200
            /// </summary>
            Success,
            /// <summary>
            /// The URL is invalid.
            /// Http code: 400
            /// </summary>
            InvalidURL,
            /// <summary>
            /// The requested file does not exist.
            /// Http code: 404
            /// </summary>
            URLNotFound,
            /// <summary>
            /// The file was already uploaded.
            /// Http code: 409
            /// </summary>
            AlreadyUploaded,
            /// <summary>
            /// The file extension is not acceptable.
            /// Http code: 415
            /// </summary>
            UnacceptableFileExtension,
            /// <summary>
            /// The rate limit was exceeded. Enhance your calm.
            /// Http code: 420
            /// </summary>
            RateLimitExceeded,
            NoResponse,
            Unknown
        }

        private static UploadFileStatus parse_uploadfile_status(string status) {
            switch (status) {
                case "200":
                    return UploadFileStatus.Success;
                case "409":
                    return UploadFileStatus.AlreadyUploaded;
                case "400":
                    return UploadFileStatus.InvalidURL;
                case "420":
                    return UploadFileStatus.RateLimitExceeded;
                case "415":
                    return UploadFileStatus.UnacceptableFileExtension;
                case "404":
                    return UploadFileStatus.URLNotFound;
                default:
                    return UploadFileStatus.Unknown;
            }
        }

    }
}
