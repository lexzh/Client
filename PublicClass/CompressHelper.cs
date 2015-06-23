namespace PublicClass
{
    using System;
    using System.Data;
    using System.IO;
    using System.IO.Compression;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Runtime.Serialization;

    public class CompressHelper
    {
        private static object ByteArrayToObject(byte[] b)
        {
            MemoryStream serializationStream = new MemoryStream(b, 0, b.Length);
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(serializationStream);
        }

        public static byte[] Compress(DataTable dt)
        {
            byte[] buffer = ObjectToByteArray(dt);
            MemoryStream stream = new MemoryStream();
            GZipStream stream2 = new GZipStream(stream, CompressionMode.Compress, true);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.Close();
            stream2.Dispose();
            byte[] buffer2 = stream.ToArray();
            stream.Close();
            stream.Dispose();
            return buffer2;
        }

        public static DataTable Decompress(byte[] data)
        {
            MemoryStream stream = new MemoryStream();
            stream.Write(data, 0, data.Length);
            stream.Position = 0L;
            GZipStream stream2 = new GZipStream(stream, CompressionMode.Decompress, true);
            byte[] buffer2 = new byte[0x400];
            MemoryStream stream3 = new MemoryStream();
            for (int i = stream2.Read(buffer2, 0, buffer2.Length); i > 0; i = stream2.Read(buffer2, 0, buffer2.Length))
            {
                stream3.Write(buffer2, 0, i);
            }
            stream2.Close();
            stream2.Dispose();
            stream.Close();
            stream.Dispose();
            byte[] b = stream3.ToArray();
            stream3.Close();
            stream3.Dispose();
            return (DataTable) ByteArrayToObject(b);
        }

        private static byte[] ObjectToByteArray(object o)
        {
            MemoryStream serializationStream = new MemoryStream();
            new BinaryFormatter().Serialize(serializationStream, o);
            serializationStream.Close();
            return serializationStream.ToArray();
        }

        public static byte[] CompressToSelf(object o)
        {
            byte[] buffer = ObjectToByteArrayToSelf(o);
            MemoryStream stream = new MemoryStream();
            GZipStream stream2 = new GZipStream(stream, CompressionMode.Compress, true);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.Close();
            stream2.Dispose();
            byte[] buffer2 = stream.ToArray();
            stream.Close();
            stream.Dispose();
            return buffer2;
        }

        private static byte[] ObjectToByteArrayToSelf(object o)
        {
            MemoryStream stream = new MemoryStream();
            new DataContractSerializer(o.GetType()).WriteObject(stream, o);
            byte[] buffer = stream.ToArray();
            stream.Close();
            return buffer;
        }
   
    }
}

