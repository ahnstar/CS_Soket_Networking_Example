using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

//서버 소켓 프로그래밍
namespace CS_Socket_Ex02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server Socket prog is starting !!!");
            Socket server_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint s_iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            server_socket.Bind(s_iep); // 소켓에 바인딩을 해준다.

            server_socket.Listen(10); //1번에 최대 몇 개 받을 수 있는지 지정 한다.
            Socket client_socket = server_socket.Accept(); // 소켓이 연결됬을때 다른 소켓에 연결 된다.
            //client_socket에 있는 소켓의 내용을 읽는다.
            if (client_socket.Connected)
            {
                Console.WriteLine("클라이언트가 서버에 접속 하였습니다.");
            }
            TcpListener 

            while (!Console.KeyAvailable)
            {
                byte[] buff = new byte[2048]; //버퍼용 배열 생성
                int n = client_socket.Receive(buff); // 버퍼의 길이를 확인 하기 위해서 
                // 소켓에서 받은 내용을 버퍼에 저장 한다 그 길이는 n에 저장 된다.
                string result = Encoding.UTF8.GetString(buff, 0, n);
                // 스트링을 추출 해서 리절트에 넣어준다
               
                Console.WriteLine(result);
            }
        }
    }
}