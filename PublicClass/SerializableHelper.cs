namespace PublicClass
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    public class SerializableHelper
    {
        public static T DeSerialize<T>(string fi)
        {
            try
            {
                return DeSerialize<T>(Convert.FromBase64String(fi));
            }
            catch
            {
                return default(T);
            }
        }

        public static T DeSerialize<T>(byte[] fi)
        {
            T local;
            if (fi == null)
            {
                return default(T);
            }
            MemoryStream serializationStream = new MemoryStream(fi);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                local = (T) formatter.Deserialize(serializationStream);
            }
            finally
            {
                serializationStream.Close();
            }
            return local;
        }

        public static byte[] SerializeToBytes<T>(T t)
        {
            try
            {
                MemoryStream serializationStream = new MemoryStream();
                new BinaryFormatter().Serialize(serializationStream, t);
                return serializationStream.ToArray();
            }
            catch
            {
                return null;
            }
        }

        public static string SerializeToString<T>(T t)
        {
            try
            {
                return Convert.ToBase64String(SerializeToBytes<T>(t));
            }
            catch
            {
                return "";
            }
        }
    }
}

