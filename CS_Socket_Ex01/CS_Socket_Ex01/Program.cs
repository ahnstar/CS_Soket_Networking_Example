using System;
using System.Net;
using System.Net.Sockets;
using System.Text; // 32line encoding을 사용 하기 위해서

namespace CS_Socket_Ex01 //서버쪽 네트워크
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!"); //걍 무시

            //Creates the Socket to send data over a TCP connection.
            Socket server_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999); //IP주소를 설정하는 곳인가 보네?
            server_socket.Bind(ep); //소켓과 IPendPoint와 바인딩을 한다(IP, 포트)

            server_socket.Listen(10); //1번에 최대 몇 개 받을 수 있는지를 설정

            Socket client_socket= server_socket.Accept();
            // client 가 값을 읽어 온다
            

            //클라언트로 부터 값을 받아 들인다.

            while (!Console.KeyAvailable) // 아무키나 눌리면 중지한다
            {
                byte[] buff = new byte[2048]; //데이터 받기 위해서 버퍼 선언
                int n = client_socket.Receive(buff);   //소켓의 내용을 버퍼에 담는 코드    //버퍼의 길이를 확인하기 위해서
                string result = Encoding.UTF8.GetString(buff, 0, n);          //0~n 만큼 값을 읽어서 result 라는 스트링 변수에 넣는다.

                Console.WriteLine(result); //최종 받은 결과를 출력
            }
        }
    }
}


//https://youtu.be/ki3fb995l2E
//Git에 올리기