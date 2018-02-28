Imports System.Text
Imports System.Net
Imports System.IO
Imports System.Net.Sockets
Module Program
    Dim Cliente As New TcpClient
    Dim address As IPAddress
    Dim port As New Integer
    Sub Main(args As String())
        address = IPAddress.Parse("127.0.0.1")
        port = 8007
        Cliente.Connect(address, port)
        While True
            Dim Stream As Stream
            Dim msg As String
            msg = Console.ReadLine + Environment.NewLine

            Stream = Cliente.GetStream
            Dim by As Byte()
            by = Encoding.UTF8.GetBytes(msg.ToCharArray(), 0, msg.Length)
            Stream.Write(by, 0, by.Length)
            Stream.Flush()
        End While
    End Sub
End Module
