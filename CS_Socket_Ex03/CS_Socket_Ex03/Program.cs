using System;
using System.Net.Sockets;
using System.Text;

// 클라이언트 소켓 프로그래밍
namespace CS_Socket_Ex03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client Socket prog is starting !!!");
            Socket client_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client_socket.Connect("127.0.0.1", 9999);

            if (client_socket.Connected)
            {
                Console.WriteLine("Client Socket 연결 되었습니다.");
            }

            string message = string.Empty;

            while((message = Console.ReadLine()) != "X")
            {
                byte[] buff = Encoding.UTF8.GetBytes(message);
                // 메세지 변수에서 바이트 배열에 담는다

                client_socket.Send(buff);
                // 그 다음에 서버로 보낸다.

                //스트링을 입력 받는다. 바이트로 바꾸고 이를 배열에 저장한다음 서버로 소켓을 보낸다ㅣ.
            }
        }
    }
}