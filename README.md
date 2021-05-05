# gRpcOrnek

A simple example about gRPC technology developed with .Net Core 3 (v3.0.0-preview7).



There are two very good articles about gRPC technology, the first one and Burak Selim Şenyurt's article should be read.

It was created as a server and client console application because I got an error when using the template that comes with .Net Core 3.

Since gRPC technology is a very new technology, I made sure that the codes and contents are in Turkish.

SQLite was used in the project to keep data usage simple. (EF Core so that it doesn't make the project more complicated.)

When it comes to communication between different platforms, web services come to our mind directly. SOAP (xml based) services, Web Service (.asmx) WCF technologies on .Net side. JSON-based RESTfull services such as Web API and GraphQL. (Developed by Facebook).

The gRPC technology is the most up-to-date structure developed by Google. Basically it reminded me of SOAP services. If we remember, we had a wsdl address in SOAP services. We could create a proxy class from this file and call our methods.

In gRPC technology, we have a .proto file instead of our wsdl address. We call our methods or functions by creating proxy classes from this file. The problem here was that our wsdl file was located at an address. I could not find a good way to share our proto file. Because the update of the .proto file is very important for the client application.

## Project Development

### Server Application

In the project development part, let's start by creating our * .proto * file.

(In this project, convenience is provided for both server and client applications by keeping the **. Proto ** file in the ** protos ** folder.)

While creating the proto files, we must pay attention to the guidelines found at <a href="https://developers.google.com/protocol-buffers/docs/proto3" target="_blank"> this address </a>.

It's actually very simple; The methods, parameters, return types and general data types are well explained. I have not been able to define a method without parameters in this section.
As a result of my research, a parameter called Empty was created and the hollow was passed. I used it that way in one of the methods.

After writing our proto file, we create the ** (libraryServer) ** console application in a folder for our server application. After installing the necessary packages (Google.Protobuf-Grpc-Grpc.Tools-Microsoft.Data.Sqlite.Core-Microsoft.EntityFrameworkCore.Sqlite), we give the address of our proto file to our .csproj file.

> Protobuf Include = "../ protos / library.proto" Link = "library.proto"

When we compile the project, our proxy class will be automatically created from our .proto file. By creating the services folder, we can fill in the services we have defined in the .proto file. (Service Implementation) In this project, we are doing simple book addition and deletion operations to db with sqlite (Helper class).

Finally, we start the server by giving parameters to our Server object in our ** program.cs ** file.

### Client Applications

We can test our services (such as SoapUI or Postman) using <a href="https://github.com/uw-labs/bloomrpc/releases" target="_blank"> BloomRPC </a> without writing client applications. By choosing only the BloomRPC open source and beautifully written proto file, we can do all the operations easily.

** .net Core Console Application **

In client applications, after loading the required packages (Google.Protobuf-Grpc-Grpc.Tools), we give the address of our .proto file to our .csproj file and compile the project. We create a client in our **. program.cs ** file and make our method calls.

** NodeJS Application **

For the NodeJS client application, method calls can be made in a simple way using the ** (grpc-kit) ** package.

Finally, gRPC is a very new technology and there are very few Turkish resources. As far as I understand, I tried to explain something in this project. There are probably parts I skipped or misunderstood. I would be glad if anyone fixes it.







