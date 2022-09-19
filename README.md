# Serialization Benchmark

## What's it?
 Console application for serialization and deserialization benchmark using most common protocols
* JSON
* Protobuf
* MessagePack

## How to run?
Use **RELEASE** option into your IDE and choose between **0** - Deserialize and **1** - Serialize in your terminal

## Serialize Benchmark Sample

|                             Method |      Mean |     Error |    StdDev |   Gen0 |   Gen1 | Allocated |
|----------------------------------- |----------:|----------:|----------:|-------:|-------:|----------:|
|                  JsonSerialization | 19.350 us | 0.3765 us | 0.6393 us | 1.8616 | 0.0305 |  15.37 KB |
|             JsonBytesSerialization | 18.488 us | 0.3613 us | 0.5517 us | 1.0071 |      - |   8.26 KB |
|              ProtobufSerialization | 14.430 us | 0.2811 us | 0.4121 us | 2.1057 |      - |  17.28 KB |
| ProtobufSerializationWithProtoFile | 10.919 us | 0.2134 us | 0.2371 us | 0.6714 |      - |   5.55 KB |
|           MessagePackSerialization |  6.911 us | 0.1290 us | 0.1207 us | 0.6638 |      - |   5.44 KB |

## Deserialize Benchmark Sample

|                               Method |     Mean |    Error |   StdDev |   Gen0 |   Gen1 |   Gen2 | Allocated |
|------------------------------------- |---------:|---------:|---------:|-------:|-------:|-------:|----------:|
|                  JsonDeserialization | 33.64 us | 0.655 us | 0.940 us | 2.1973 | 0.1831 | 0.0610 |  18.02 KB |
|             JsonBytesDeserialization | 32.72 us | 0.643 us | 1.238 us | 2.1973 | 0.1221 |      - |  18.02 KB |
|              ProtobufDeserialization | 16.90 us | 0.326 us | 0.423 us | 1.9226 | 0.0916 |      - |   15.9 KB |
| ProtobufDeserializationWithProtoFile | 10.99 us | 0.218 us | 0.470 us | 2.0905 | 0.1221 |      - |  17.13 KB |
|           MessagePackDeserialization | 11.74 us | 0.234 us | 0.279 us | 1.9226 | 0.1068 |      - |  15.81 KB |