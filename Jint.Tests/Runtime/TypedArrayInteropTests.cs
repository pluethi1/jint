using Xunit;

namespace Jint.Tests.Runtime
{
    public class TypedArrayInteropTests
    {
        [Fact]
        public void CanInteropWithInt8()
        {
            var engine = new Engine();
            var source = new sbyte[] { 42, 12 };
            engine.SetValue("testSubject", engine.Realm.Intrinsics.Int8Array.Construct(source));
            ValidateCreatedTypeArray(engine, "Int8Array");

            var fromEngine = engine.GetValue("testSubject");
            Assert.True(fromEngine.IsInt8Array());
            Assert.Equal(source, fromEngine.AsInt8Array());
        }

        [Fact]
        public void CanInteropWithUint8()
        {
            var engine = new Engine();
            var source = new byte[] { 42, 12 };
            engine.SetValue("testSubject", engine.Realm.Intrinsics.Uint8Array.Construct(source));
            ValidateCreatedTypeArray(engine, "Uint8Array");

            var fromEngine = engine.GetValue("testSubject");
            Assert.True(fromEngine.IsUint8Array());
            Assert.Equal(source, fromEngine.AsUint8Array());
        }

        [Fact]
        public void CanInteropWithUint8Clamped()
        {
            var engine = new Engine();
            var source = new byte[] { 42, 12 };
            engine.SetValue("testSubject", engine.Realm.Intrinsics.Uint8ClampedArray.Construct(source));
            ValidateCreatedTypeArray(engine, "Uint8ClampedArray");

            var fromEngine = engine.GetValue("testSubject");
            Assert.True(fromEngine.IsUint8ClampedArray());
            Assert.Equal(source, fromEngine.AsUint8ClampedArray());
        }

        [Fact]
        public void CanInteropWithInt16()
        {
            var engine = new Engine();
            var source = new short[] { 42, 12 };
            engine.SetValue("testSubject", engine.Realm.Intrinsics.Int16Array.Construct(source));
            ValidateCreatedTypeArray(engine, "Int16Array");

            var fromEngine = engine.GetValue("testSubject");
            Assert.True(fromEngine.IsInt16Array());
            Assert.Equal(source, fromEngine.AsInt16Array());
        }

        [Fact]
        public void CanInteropWithUint16()
        {
            var engine = new Engine();
            var source = new ushort[] { 42, 12 };
            engine.SetValue("testSubject", engine.Realm.Intrinsics.Uint16Array.Construct(source));
            ValidateCreatedTypeArray(engine, "Uint16Array");

            var fromEngine = engine.GetValue("testSubject");
            Assert.True(fromEngine.IsUint16Array());
            Assert.Equal(source, fromEngine.AsUint16Array());
        }

        [Fact]
        public void CanInteropWithInt32()
        {
            var engine = new Engine();
            var source = new int[] { 42, 12 };
            engine.SetValue("testSubject", engine.Realm.Intrinsics.Int32Array.Construct(source));
            ValidateCreatedTypeArray(engine, "Int32Array");

            var fromEngine = engine.GetValue("testSubject");
            Assert.True(fromEngine.IsInt32Array());
            Assert.Equal(source, fromEngine.AsInt32Array());
        }

        [Fact]
        public void CanInteropWithUint32()
        {
            var engine = new Engine();
            var source = new uint[] { 42, 12 };

            engine.SetValue("testSubject", engine.Realm.Intrinsics.Uint32Array.Construct(source));
            ValidateCreatedTypeArray(engine, "Uint32Array");

            var fromEngine = engine.GetValue("testSubject");
            Assert.True(fromEngine.IsUint32Array());
            Assert.Equal(source, fromEngine.AsUint32Array());
        }

        [Fact(Skip = "BigInt not implemented")]
        public void CanInteropWithBigInt64()
        {
            var engine = new Engine();
            var source = new long[] { 42, 12 };
            engine.SetValue("testSubject", engine.Realm.Intrinsics.BigInt64Array.Construct(source));
            ValidateCreatedTypeArray(engine, "BigInt64Array");

            var fromEngine = engine.GetValue("testSubject");
            Assert.True(fromEngine.IsBigInt64Array());
            Assert.Equal(source, fromEngine.AsBigInt64Array());
        }

        [Fact(Skip = "BigInt not implemented")]
        public void CanInteropWithBigUint64()
        {
            var engine = new Engine();
            var source = new ulong[] { 42, 12 };
            engine.SetValue("testSubject", engine.Realm.Intrinsics.BigUint64Array.Construct(source));
            ValidateCreatedTypeArray(engine, "BigUint64Array");

            var fromEngine = engine.GetValue("testSubject");
            Assert.True(fromEngine.IsBigUint64Array());
            Assert.Equal(source, fromEngine.AsBigUint64Array());
        }

        private static void ValidateCreatedTypeArray(Engine engine, string arrayName)
        {
            Assert.Equal(arrayName, engine.Evaluate("testSubject.constructor.name").AsString());
            Assert.Equal(2, engine.Evaluate("testSubject.length").AsNumber());
            Assert.Equal(42, engine.Evaluate("testSubject[0]").AsNumber());
            Assert.Equal(12, engine.Evaluate("testSubject[1]").AsNumber());
        }
    }
}