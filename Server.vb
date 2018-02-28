Imports System.Text
Imports System.Net
Imports System.Net.Sockets
Module Program
    Dim serverSocket As TcpListener
    Dim address As IPAddress
    Dim port As New Integer
    Sub Main(args As String())
        address = IPAddress.Parse("127.0.0.1")
        port = 8007
        serverSocket = New TcpListener(address, port)
        serverSocket.Start()
        Dim client As TcpClient
        client = serverSocket.AcceptTcpClient()
        While True
            Dim nwStream As NetworkStream
            nwStream = client.GetStream
            Dim buffer(client.ReceiveBufferSize) As Byte

            Dim dataReceived As String
            dataReceived = Encoding.ASCII.GetString(buffer, 0, nwStream.Read(buffer, 0, client.ReceiveBufferSize))
            Console.WriteLine(dataReceived)
        End While
    End Sub
End Module
