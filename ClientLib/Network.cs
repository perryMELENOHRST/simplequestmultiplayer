using System.Net;
using System.Net.Sockets;

//All networking code to be included in client packages
namespace ClientLib.Networking
{
    public class BasicNetworkTcpClient
    {
        public static BasicNetworkTcpClient instance;
        public static int dataBufferSize = 4096;

        public string ip = "127.0.0.1";
        public int port = 26950;
        public int myId = 0;
        public TCP tcp;

        public void Init()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Console.WriteLine("Instance already exists, destroying object! if this happens there is a bug");
            }
        }

        public void Start()
        {
            tcp = new TCP();
        }

        public void ConnectToServer()
        {
            tcp.Connect();
        }

        public class TCP
        {
            public TcpClient socket;

            private NetworkStream stream;
            private byte[] receiveBuffer;

            public void Connect()
            {
                socket = new TcpClient
                {
                    ReceiveBufferSize = dataBufferSize,
                    SendBufferSize = dataBufferSize
                };

                receiveBuffer = new byte[dataBufferSize];
                socket.BeginConnect(instance.ip, instance.port, ConnectCallback, socket);
            }

            private void ConnectCallback(IAsyncResult _result)
            {
                socket.EndConnect(_result);

                if (!socket.Connected)
                {
                    return;
                }

                stream = socket.GetStream();

                stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
            }

            private void ReceiveCallback(IAsyncResult _result)
            {
                try
                {
                    int _byteLength = stream.EndRead(_result);
                    if (_byteLength <= 0)
                    {
                        // TODO: disconnect
                        return;
                    }

                    byte[] _data = new byte[_byteLength];
                    Array.Copy(receiveBuffer, _data, _byteLength);

                    // TODO: handle data
                    stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
                }
                catch
                {
                    // TODO: disconnect
                }
            }
        }
    }
}
