using System.CodeDom.Compiler;
using System.IO;
using System.Text.Json;
using BenchmarkDotNet.Attributes;
using Google.Protobuf;
using MessagePack;
using ProtoBuf;
using SerializationBenchmarkApp.Models;
using SerializationBenchmarkApp.Utils;

namespace SerializationBenchmarkApp.Benchmarks
{
    [MemoryDiagnoser]
    public class SerializationBenchmark
    {
        private readonly SpotifyAlbum _model;
        private readonly SpotifyAlbumProto _modelProto;

        private readonly string _schema;

        public SerializationBenchmark()
        {
            _model = ModelGenerator.GenerateTestModel();
            _modelProto = ModelGenerator.GenerateTestModelProto();
        }

        [Benchmark]
        public void JsonSerialization()
        {
            var json = JsonSerializer.Serialize(_model);
        }

        [Benchmark]
        public void JsonBytesSerialization()
        {
            var jsonBytes = JsonSerializer.SerializeToUtf8Bytes(_model);
        }

        [Benchmark]
        public void ProtobufSerialization()
        {
            using var memoryStream = new MemoryStream();

            Serializer.Serialize(memoryStream, _model);
        }

        [Benchmark]
        public void ProtobufSerializationWithProtoFile()
        {
            var bytes = _modelProto.ToByteArray();
        }

        [Benchmark]
        public void MessagePackSerialization()
        {
            var bytes = MessagePackSerializer.Serialize(_model);
        }
    }
}