using IL2X64.Error;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;
//disable CS8625
#pragma warning disable CS8625
#pragma warning disable CS8602
#pragma warning disable CS8620
#pragma warning disable CS8618
namespace IL2X64.IL.Syntax
{
    public enum ILOpCodes
    {
        // NOP and Break
        Nop,
        Break,

        // Load argument and local variables
        Ldarg_0,
        Ldarg_1,
        Ldarg_2,
        Ldarg_3,
        Ldloc_0,
        Ldloc_1,
        Ldloc_2,
        Ldloc_3,
        Stloc_0,
        Stloc_1,
        Stloc_2,
        Stloc_3,
        Ldarg_S,
        Ldarga_S,
        Starg_S,
        Ldloc_S,
        Ldloca_S,
        Stloc_S,

        // Load constants
        Ldnull,
        Ldc_I4_M1,
        Ldc_I4_0,
        Ldc_I4_1,
        Ldc_I4_2,
        Ldc_I4_3,
        Ldc_I4_4,
        Ldc_I4_5,
        Ldc_I4_6,
        Ldc_I4_7,
        Ldc_I4_8,
        Ldc_I4_S,
        Ldc_I4,
        Ldc_I8,
        Ldc_R4,
        Ldc_R8,

        // Stack operations
        Dup,
        Pop,

        // Control flow
        Jmp,
        Call,
        Calli,
        Ret,
        Br_S,
        Brfalse_S,
        Brtrue_S,
        Beq_S,
        Bge_S,
        Bgt_S,
        Ble_S,
        Blt_S,
        Bne_Un_S,
        Bge_Un_S,
        Bgt_Un_S,
        Ble_Un_S,
        Blt_Un_S,
        Br,
        Brfalse,
        Brtrue,
        Beq,
        Bge,
        Bgt,
        Ble,
        Blt,
        Bne_Un,
        Bge_Un,
        Bgt_Un,
        Ble_Un,
        Blt_Un,
        Switch,

        // Arithmetic
        Add,
        Sub,
        Mul,
        Div,
        Div_Un,
        Rem,
        Rem_Un,
        And,
        Or,
        Xor,
        Shl,
        Shr,
        Shr_Un,
        Neg,
        Not,

        // Object operations
        Newobj,
        Initobj,
        Castclass,
        Isinst,
        Box,
        Unbox,
        Unbox_Any,

        // Array operations
        Newarr,
        Ldind_I1,
        Ldind_U1,
        Ldind_I2,
        Ldind_U2,
        Ldind_I4,
        Ldind_U4,
        Ldind_I8,
        Ldind_I,
        Ldind_R4,
        Ldind_R8,
        Ldind_Ref,
        Stind_Ref,
        Stind_I1,
        Stind_I2,
        Stind_I4,
        Stind_I8,
        Stind_R4,
        Stind_R8,

        Ldlen,
        Ldelema,
        Ldelem_I1,
        Ldelem_U1,
        Ldelem_I2,
        Ldelem_U2,
        Ldelem_I4,
        Ldelem_U4,
        Ldelem_I8,
        Ldelem_I,
        Ldelem_R4,
        Ldelem_R8,
        Ldelem_Ref,
        Stelem_I,
        Stelem_I1,
        Stelem_I2,
        Stelem_I4,
        Stelem_I8,
        Stelem_R4,
        Stelem_R8,
        Stelem_Ref,

        // Miscellaneous conversions
        Conv_I1,
        Conv_I2,
        Conv_I4,
        Conv_I8,
        Conv_R4,
        Conv_R8,
        Conv_U4,
        Conv_U8,
        Conv_R_Un,
        Conv_Ovf_I1_Un,
        Conv_Ovf_I2_Un,
        Conv_Ovf_I4_Un,
        Conv_Ovf_I8_Un,
        Conv_Ovf_U1_Un,
        Conv_Ovf_U2_Un,
        Conv_Ovf_U4_Un,
        Conv_Ovf_U8_Un,
        Conv_Ovf_I1,
        Conv_Ovf_I2,
        Conv_Ovf_I4,
        Conv_Ovf_I8,
        Conv_Ovf_U1,
        Conv_Ovf_U2,
        Conv_Ovf_U4,
        Conv_Ovf_U8,

        // Exception handling
        Throw,
        Rethrow,
        Leave,
        Leave_S,
        Endfinally,
        Endfilter,

        // Field and method operations
        Ldfld,
        Ldflda,
        Stfld,
        Ldsfld,
        Ldsflda,
        Stsfld,
        Ldtoken,
        Callvirt,

        // Type information
        Ldftn,
        Ldvirtftn,
        Constrained,
        Readonly,
        Volatile,

        // Memory management
        Cpblk,
        Initblk,

        // No operation
        Tailcall,
        No,
        Unaligned,

        // Additional Opcodes
        Ldarg,
        Starg,
        Ldind_R,
        Stind_I,
        Stind_R,
        Ldstr,
        Ldind_U8,
        Cpobj,
        Ldobj,
        Stobj,
        Mkrefany,
        Refanytype,
        Refanyval,
        Sizeof,
        Localloc,
        Conv_Ovf_I_Un,
        Conv_Ovf_U_Un,
        Ldelem,
        Stelem,
        Tail,
        Ckfinite,
        Conv_U1,
        Conv_U2,
        Conv_I,
        Conv_Ovf_I,
        Conv_Ovf_U,
        Add_Ovf,
        Add_Ovf_Un,
        Mul_Ovf,
        Mul_Ovf_Un,
        Sub_Ovf,
        Sub_Ovf_Un,
        Conv_U,
        Ceq,
        Arglist,
        Cgt,
        Cgt_Un,
        Clt,
        Clt_Un,
        Ldarga,
        EndFault
    }

    public struct ILOperand
    {
        public string Name;
        public byte Value;
    }
    public struct ILInstruction
    {
        public string Name;
        public ILOpCodes OpCode;
        public byte[] Operands;
        public uint TotalOperands;
    }
    public struct ILField
    {
        public string Name;
        public string Type;

        //!= operator
        public static bool operator !=(ILField a, ILField b)
        {
            return a.Name != b.Name;
        }
        public static bool operator ==(ILField a, ILField b)
        {
            return a.Name == b.Name;
        }
    }
    [Flags]
    public enum ILProperties
    {
        HideBySig = 0x00000010,    // Method is not shown in the signature
        Public = 0x00000006,        // Public visibility
        Private = 0x00000007,       // Private visibility
        Instance = 0x00000000,      // Instance member
        Static = 0x00000010,        // Static member

        Final = 0x00000100,         // Final method (can’t be overridden)
        Virtual = 0x00000200,       // Virtual method (can be overridden)
        Abstract = 0x00000400,      // Abstract method (requires overriding in derived classes)
        SpecialName = 0x00000800,   // Used for special methods (e.g., operators, indexers)
        PInvokeImpl = 0x00002000,   // Indicates the method is a P/Invoke method
        UnmanagedExport = 0x00004000, // Indicates the method is unmanaged (e.g., a native method)
        RTSpecialName = 0x00008000, // Special name, used for system methods
        HasSecurity = 0x00010000,   // Method has associated security requirements
        RequireSecObject = 0x00020000, // Method requires a security object

        // Flags used in method attributes:
        StaticConstructor = Static | SpecialName, // Special static constructor
        MethodImplementationFlags = 0x00000100 | 0x00000200 | 0x00000400 | 0x00000800, // Combination of method type flags
    }

    public struct ILMethod
    {
        public string Name;
        public string ReturnType;
        public string[] Parameters;
        public string[] Locals;
        public string[] Code;
        public ILProperties Properties;
    }

    public struct ILClass
    {
        public string Name;
        public ILField[] Fields;
        public ILMethod[] Methods;
        public ILProperties Properties;
    }

    public struct ILAssembly
    {
        public ILClass[] Classes;
        public ILField[] Fields;
        public ILMethod[] Methods;
    }

    public class GunnerIL
    {
        private List<ILClass> mClasses;
        bool mAllowComments;
        PEReader mPERdr;
        Assembly mAssembly;
        Module mModule;
        public GunnerIL()
        {
            mClasses = new List<ILClass>();
        }

        public void SetParameters(bool pAllowComments)
        {
            mAllowComments = pAllowComments;
        }

        public void Load(string pathToDll)
        {
            using var peStream = new FileStream(pathToDll, FileMode.Open, FileAccess.Read, FileShare.Read);
            using var peReader = new PEReader(peStream);
            mPERdr = peReader;
            mAssembly = Assembly.LoadFrom(pathToDll);
            mModule = mAssembly.GetModules()[0];

            if (!peReader.HasMetadata)
                throw new InvalidOperationException("The provided file does not contain .NET metadata.");

            var metadataReader = peReader.GetMetadataReader();
            ParseAssembly(metadataReader);
        }

        public ILInstruction ByteIL2ILOp(byte[] pByte, ulong pIndex, ref uint pSkipBytes)
        {
            pSkipBytes = 0;

            switch (pByte[pIndex])
            {
                case 0x00:
                    return new ILInstruction
                    {
                        Name = "nop",
                        OpCode = ILOpCodes.Nop,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x01:
                    return new ILInstruction
                    {
                        Name = "break",
                        OpCode = ILOpCodes.Break,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x02:
                    return new ILInstruction
                    {
                        Name = "ldarg.0",
                        OpCode = ILOpCodes.Ldarg_0,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x03:
                    return new ILInstruction
                    {
                        Name = "ldarg.1",
                        OpCode = ILOpCodes.Ldarg_1,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x04:
                    return new ILInstruction
                    {
                        Name = "ldarg.2",
                        OpCode = ILOpCodes.Ldarg_2,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x05:
                    return new ILInstruction
                    {
                        Name = "ldarg.3",
                        OpCode = ILOpCodes.Ldarg_3,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x06:
                    return new ILInstruction
                    {
                        Name = "ldloc.0",
                        OpCode = ILOpCodes.Ldloc_0,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x07:
                    return new ILInstruction
                    {
                        Name = "ldloc.1",
                        OpCode = ILOpCodes.Ldloc_1,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x08:
                    return new ILInstruction
                    {
                        Name = "ldloc.2",
                        OpCode = ILOpCodes.Ldloc_2,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x09:
                    return new ILInstruction
                    {
                        Name = "ldloc.3",
                        OpCode = ILOpCodes.Ldloc_3,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x0A:
                    return new ILInstruction
                    {
                        Name = "stloc.0",
                        OpCode = ILOpCodes.Stloc_0,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x0B:
                    return new ILInstruction
                    {
                        Name = "stloc.1",
                        OpCode = ILOpCodes.Stloc_1,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x0C:
                    return new ILInstruction
                    {
                        Name = "stloc.2",
                        OpCode = ILOpCodes.Stloc_2,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x0D:
                    return new ILInstruction
                    {
                        Name = "stloc.3",
                        OpCode = ILOpCodes.Stloc_3,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x0E:
                    return new ILInstruction
                    {
                        Name = "ldarg.s",
                        OpCode = ILOpCodes.Ldarg_S,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x0F:
                    pSkipBytes = 1;
                    return new ILInstruction
                    {
                        Name = "ldarga.s",
                        OpCode = ILOpCodes.Ldarga_S,
                        Operands = null,
                        TotalOperands = 1
                    };

                case 0x10:
                    pSkipBytes = 1;
                    return new ILInstruction
                    {
                        Name = "starg.s",
                        OpCode = ILOpCodes.Starg_S,
                        Operands = null,
                        TotalOperands = 1
                    };

                case 0x11:
                    pSkipBytes = 1;
                    return new ILInstruction
                    {
                        Name = "ldloc.s",
                        OpCode = ILOpCodes.Ldloc_S,
                        Operands = null,
                        TotalOperands = 1
                    };

                case 0x12:
                    pSkipBytes = 1;
                    return new ILInstruction
                    {
                        Name = "ldloca.s",
                        OpCode = ILOpCodes.Ldloca_S,
                        Operands = null,
                        TotalOperands = 1
                    };

                case 0x13:
                    pSkipBytes = 1;
                    return new ILInstruction
                    {
                        Name = "stloc.s",
                        OpCode = ILOpCodes.Stloc_S,
                        Operands = null,
                        TotalOperands = 1
                    };

                case 0x14:
                    return new ILInstruction
                    {
                        Name = "ldnull",
                        OpCode = ILOpCodes.Ldnull,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x15:
                    return new ILInstruction
                    {
                        Name = "ldc.i4.m1",
                        OpCode = ILOpCodes.Ldc_I4_M1,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x16:
                    return new ILInstruction
                    {
                        Name = "ldc.i4.0",
                        OpCode = ILOpCodes.Ldc_I4_0,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x17:
                    return new ILInstruction
                    {
                        Name = "ldc.i4.1",
                        OpCode = ILOpCodes.Ldc_I4_1,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x18:
                    return new ILInstruction
                    {
                        Name = "ldc.i4.2",
                        OpCode = ILOpCodes.Ldc_I4_2,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x19:
                    return new ILInstruction
                    {
                        Name = "ldc.i4.3",
                        OpCode = ILOpCodes.Ldc_I4_3,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x1A:
                    return new ILInstruction
                    {
                        Name = "ldc.i4.4",
                        OpCode = ILOpCodes.Ldc_I4_4,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x1B:
                    return new ILInstruction
                    {
                        Name = "ldc.i4.5",
                        OpCode = ILOpCodes.Ldc_I4_5,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x1C:
                    return new ILInstruction
                    {
                        Name = "ldc.i4.6",
                        OpCode = ILOpCodes.Ldc_I4_6,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x1D:
                    return new ILInstruction
                    {
                        Name = "ldc.i4.7",
                        OpCode = ILOpCodes.Ldc_I4_7,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x1E:
                    return new ILInstruction
                    {
                        Name = "ldc.i4.8",
                        OpCode = ILOpCodes.Ldc_I4_8,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x1F:
                    pSkipBytes = 1;
                    return new ILInstruction
                    {
                        Name = "ldc.i4.s",
                        OpCode = ILOpCodes.Ldc_I4_S,
                        Operands = null,
                        TotalOperands = 1
                    };

                case 0x20:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "ldc.i4",
                        OpCode = ILOpCodes.Ldc_I4,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0x21:
                    pSkipBytes = 8;
                    return new ILInstruction
                    {
                        Name = "ldc.i8",
                        OpCode = ILOpCodes.Ldc_I8,
                        Operands = pByte.Skip((int)pIndex + 1).Take(8).ToArray(),
                        TotalOperands = 8
                    };

                case 0x22:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "ldc.r4",
                        OpCode = ILOpCodes.Ldc_R4,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0x23:
                    pSkipBytes = 8;
                    return new ILInstruction
                    {
                        Name = "ldc.r8",
                        OpCode = ILOpCodes.Ldc_R8,
                        Operands = pByte.Skip((int)pIndex + 1).Take(8).ToArray(),
                        TotalOperands = 8
                    };

                case 0x24:
                    return new ILInstruction
                    {
                        Name = "dup",
                        OpCode = ILOpCodes.Dup,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x25:
                    return new ILInstruction
                    {
                        Name = "dup",
                        OpCode = ILOpCodes.Dup,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x26:
                    return new ILInstruction
                    {
                        Name = "pop",
                        OpCode = ILOpCodes.Pop,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x27:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "jmp",
                        OpCode = ILOpCodes.Jmp,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0x28:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "call",
                        OpCode = ILOpCodes.Call,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0x29:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "calli",
                        OpCode = ILOpCodes.Calli,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0x2A:
                    return new ILInstruction
                    {
                        Name = "ret",
                        OpCode = ILOpCodes.Ret,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x2B:
                    pSkipBytes = 1;
                    return new ILInstruction
                    {
                        Name = "br.s",
                        OpCode = ILOpCodes.Br_S,
                        Operands = pByte.Skip((int)pIndex + 1).Take(1).ToArray(),
                        TotalOperands = 1
                    };

                case 0x2C:
                    pSkipBytes = 1;
                    return new ILInstruction
                    {
                        Name = "brfalse.s",
                        OpCode = ILOpCodes.Brfalse_S,
                        Operands = pByte.Skip((int)pIndex + 1).Take(1).ToArray(),
                        TotalOperands = 1
                    };

                case 0x2D:
                    pSkipBytes = 1;
                    return new ILInstruction
                    {
                        Name = "brtrue.s",
                        OpCode = ILOpCodes.Brtrue_S,
                        Operands = pByte.Skip((int)pIndex + 1).Take(1).ToArray(),
                        TotalOperands = 1
                    };

                case 0x2E:
                    pSkipBytes = 1;
                    return new ILInstruction
                    {
                        Name = "beq.s",
                        OpCode = ILOpCodes.Beq_S,
                        Operands = pByte.Skip((int)pIndex + 1).Take(1).ToArray(),
                        TotalOperands = 1
                    };

                case 0x2F:
                    pSkipBytes = 1;
                    return new ILInstruction
                    {
                        Name = "bge.s",
                        OpCode = ILOpCodes.Bge_S,
                        Operands = pByte.Skip((int)pIndex + 1).Take(1).ToArray(),
                        TotalOperands = 1
                    };

                case 0x30:
                    pSkipBytes = 1;
                    return new ILInstruction
                    {
                        Name = "bgt.s",
                        OpCode = ILOpCodes.Bgt_S,
                        Operands = pByte.Skip((int)pIndex + 1).Take(1).ToArray(),
                        TotalOperands = 1
                    };

                case 0x31:
                    pSkipBytes = 1;
                    return new ILInstruction
                    {
                        Name = "ble.s",
                        OpCode = ILOpCodes.Ble_S,
                        Operands = pByte.Skip((int)pIndex + 1).Take(1).ToArray(),
                        TotalOperands = 1
                    };

                case 0x32:
                    pSkipBytes = 1;
                    return new ILInstruction
                    {
                        Name = "blt.s",
                        OpCode = ILOpCodes.Blt_S,
                        Operands = pByte.Skip((int)pIndex + 1).Take(1).ToArray(),
                        TotalOperands = 1
                    };

                case 0x33:
                    pSkipBytes = 1;
                    return new ILInstruction
                    {
                        Name = "bne.un.s",
                        OpCode = ILOpCodes.Bne_Un_S,
                        Operands = pByte.Skip((int)pIndex + 1).Take(1).ToArray(),
                        TotalOperands = 1
                    };

                case 0x34:
                    pSkipBytes = 1;
                    return new ILInstruction
                    {
                        Name = "bge.un.s",
                        OpCode = ILOpCodes.Bge_Un_S,
                        Operands = pByte.Skip((int)pIndex + 1).Take(1).ToArray(),
                        TotalOperands = 1
                    };

                case 0x35:
                    pSkipBytes = 1;
                    return new ILInstruction
                    {
                        Name = "bgt.un.s",
                        OpCode = ILOpCodes.Bgt_Un_S,
                        Operands = pByte.Skip((int)pIndex + 1).Take(1).ToArray(),
                        TotalOperands = 1
                    };

                case 0x36:
                    pSkipBytes = 1;
                    return new ILInstruction
                    {
                        Name = "ble.un.s",
                        OpCode = ILOpCodes.Ble_Un_S,
                        Operands = pByte.Skip((int)pIndex + 1).Take(1).ToArray(),
                        TotalOperands = 1
                    };

                case 0x37:
                    pSkipBytes = 1;
                    return new ILInstruction
                    {
                        Name = "blt.un.s",
                        OpCode = ILOpCodes.Blt_Un_S,
                        Operands = pByte.Skip((int)pIndex + 1).Take(1).ToArray(),
                        TotalOperands = 1
                    };

                case 0x38:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "br",
                        OpCode = ILOpCodes.Br,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0x39:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "brfalse",
                        OpCode = ILOpCodes.Brfalse,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0x3A:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "brtrue",
                        OpCode = ILOpCodes.Brtrue,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0x3B:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "beq",
                        OpCode = ILOpCodes.Beq,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0x3C:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "bge",
                        OpCode = ILOpCodes.Bge,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0x3D:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "bgt",
                        OpCode = ILOpCodes.Bgt,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0x3E:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "ble",
                        OpCode = ILOpCodes.Ble,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0x3F:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "blt",
                        OpCode = ILOpCodes.Blt,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0x40:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "bne.un",
                        OpCode = ILOpCodes.Bne_Un,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0x41:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "bge.un",
                        OpCode = ILOpCodes.Bge_Un,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0x42:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "bgt.un",
                        OpCode = ILOpCodes.Bgt_Un,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0x43:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "ble.un",
                        OpCode = ILOpCodes.Ble_Un,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0x44:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "blt.un",
                        OpCode = ILOpCodes.Blt_Un,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0x45:
                    // skip bytes based on num of cases
                    pSkipBytes = (uint)BitConverter.ToInt32(pByte, (int)pIndex + 1) * 4 + 4;
                    return new ILInstruction
                    {
                        Name = "switch",
                        OpCode = ILOpCodes.Switch,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0x46:
                    return new ILInstruction
                    {
                        Name = "ldind.i1",
                        OpCode = ILOpCodes.Ldind_I1,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x47:
                    return new ILInstruction
                    {
                        Name = "ldind.u1",
                        OpCode = ILOpCodes.Ldind_U1,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x48:
                    return new ILInstruction
                    {
                        Name = "ldind.i2",
                        OpCode = ILOpCodes.Ldind_I2,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x49:
                    return new ILInstruction
                    {
                        Name = "ldind.u2",
                        OpCode = ILOpCodes.Ldind_U2,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x4A:
                    return new ILInstruction
                    {
                        Name = "ldind.i4",
                        OpCode = ILOpCodes.Ldind_I4,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x4B:
                    return new ILInstruction
                    {
                        Name = "ldind.u4",
                        OpCode = ILOpCodes.Ldind_U4,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x4C:
                    return new ILInstruction
                    {
                        Name = "ldind.i8",
                        OpCode = ILOpCodes.Ldind_I8,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x4D:
                    return new ILInstruction
                    {
                        Name = "ldind.i",
                        OpCode = ILOpCodes.Ldind_I,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x4E:
                    return new ILInstruction
                    {
                        Name = "ldind.r4",
                        OpCode = ILOpCodes.Ldind_R4,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x4F:
                    return new ILInstruction
                    {
                        Name = "ldind.r8",
                        OpCode = ILOpCodes.Ldind_R8,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x50:
                    return new ILInstruction
                    {
                        Name = "ldind.ref",
                        OpCode = ILOpCodes.Ldind_Ref,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x51:
                    return new ILInstruction
                    {
                        Name = "stind.ref",
                        OpCode = ILOpCodes.Stind_Ref,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x52:
                    return new ILInstruction
                    {
                        Name = "stind.i1",
                        OpCode = ILOpCodes.Stind_I1,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x53:
                    return new ILInstruction
                    {
                        Name = "stind.i2",
                        OpCode = ILOpCodes.Stind_I2,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x54:
                    return new ILInstruction
                    {
                        Name = "stind.i4",
                        OpCode = ILOpCodes.Stind_I4,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x55:
                    return new ILInstruction
                    {
                        Name = "stind.i8",
                        OpCode = ILOpCodes.Stind_I8,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x56:
                    return new ILInstruction
                    {
                        Name = "stind.r4",
                        OpCode = ILOpCodes.Stind_R4,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x57:
                    return new ILInstruction
                    {
                        Name = "stind.r8",
                        OpCode = ILOpCodes.Stind_R8,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x58:
                    return new ILInstruction
                    {
                        Name = "add",
                        OpCode = ILOpCodes.Add,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x59:
                    return new ILInstruction
                    {
                        Name = "sub",
                        OpCode = ILOpCodes.Sub,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x5A:
                    return new ILInstruction
                    {
                        Name = "mul",
                        OpCode = ILOpCodes.Mul,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x5B:
                    return new ILInstruction
                    {
                        Name = "div",
                        OpCode = ILOpCodes.Div,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x5C:
                    return new ILInstruction
                    {
                        Name = "div.un",
                        OpCode = ILOpCodes.Div_Un,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x5D:
                    return new ILInstruction
                    {
                        Name = "rem",
                        OpCode = ILOpCodes.Rem,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x5E:
                    return new ILInstruction
                    {
                        Name = "rem.un",
                        OpCode = ILOpCodes.Rem_Un,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x5F:
                    return new ILInstruction
                    {
                        Name = "and",
                        OpCode = ILOpCodes.And,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x60:
                    return new ILInstruction
                    {
                        Name = "or",
                        OpCode = ILOpCodes.Or,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x61:
                    return new ILInstruction
                    {
                        Name = "xor",
                        OpCode = ILOpCodes.Xor,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x62:
                    return new ILInstruction
                    {
                        Name = "shl",
                        OpCode = ILOpCodes.Shl,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x63:
                    return new ILInstruction
                    {
                        Name = "shr",
                        OpCode = ILOpCodes.Shr,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x64:
                    return new ILInstruction
                    {
                        Name = "shr.un",
                        OpCode = ILOpCodes.Shr_Un,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x65:
                    return new ILInstruction
                    {
                        Name = "neg",
                        OpCode = ILOpCodes.Neg,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x66:
                    return new ILInstruction
                    {
                        Name = "not",
                        OpCode = ILOpCodes.Not,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x67:
                    return new ILInstruction
                    {
                        Name = "conv.i1",
                        OpCode = ILOpCodes.Conv_I1,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x68:
                    return new ILInstruction
                    {
                        Name = "conv.i2",
                        OpCode = ILOpCodes.Conv_I2,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x69:
                    return new ILInstruction
                    {
                        Name = "conv.i4",
                        OpCode = ILOpCodes.Conv_I4,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x6A:
                    return new ILInstruction
                    {
                        Name = "conv.i8",
                        OpCode = ILOpCodes.Conv_I8,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x6B:
                    return new ILInstruction
                    {
                        Name = "conv.r4",
                        OpCode = ILOpCodes.Conv_R4,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x6C:
                    return new ILInstruction
                    {
                        Name = "conv.r8",
                        OpCode = ILOpCodes.Conv_R8,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x6D:
                    return new ILInstruction
                    {
                        Name = "conv.u4",
                        OpCode = ILOpCodes.Conv_U4,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x6E:
                    return new ILInstruction
                    {
                        Name = "conv.u8",
                        OpCode = ILOpCodes.Conv_U8,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x6F:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "callvirt",
                        OpCode = ILOpCodes.Callvirt,
                        Operands = null,
                        TotalOperands = 4
                    };

                case 0x70:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "cpobj",
                        OpCode = ILOpCodes.Cpobj,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0x71:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "ldobj",
                        OpCode = ILOpCodes.Ldobj,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0x72:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "ldstr",
                        OpCode = ILOpCodes.Ldstr,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0x73:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "newobj",
                        OpCode = ILOpCodes.Newobj,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0x74:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "castclass",
                        OpCode = ILOpCodes.Castclass,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0x75:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "isinst",
                        OpCode = ILOpCodes.Isinst,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0x76:
                    return new ILInstruction
                    {
                        Name = "conv.r.un",
                        OpCode = ILOpCodes.Conv_R_Un,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x79:
                    return new ILInstruction
                    {
                        Name = "unbox",
                        OpCode = ILOpCodes.Unbox,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x7A:
                    return new ILInstruction
                    {
                        Name = "throw",
                        OpCode = ILOpCodes.Throw,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x7B:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "ldfld",
                        OpCode = ILOpCodes.Ldfld,
                        Operands = null,
                        TotalOperands = 4
                    };

                case 0x7C:
                    return new ILInstruction
                    {
                        Name = "ldflda",
                        OpCode = ILOpCodes.Ldflda,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x7D:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "stfld",
                        OpCode = ILOpCodes.Stfld,
                        Operands = null,
                        TotalOperands = 4
                    };

                case 0x7E:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "ldsfld",
                        OpCode = ILOpCodes.Ldsfld,
                        Operands = null,
                        TotalOperands = 4
                    };

                case 0x7F:
                    return new ILInstruction
                    {
                        Name = "ldsflda",
                        OpCode = ILOpCodes.Ldsflda,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x80:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "stsfld",
                        OpCode = ILOpCodes.Stsfld,
                        Operands = null,
                        TotalOperands = 4
                    };

                case 0x81:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "stobj",
                        OpCode = ILOpCodes.Stobj,
                        Operands = null,
                        TotalOperands = 4
                    };

                case 0x82:
                    return new ILInstruction
                    {
                        Name = "conv.ovf.i1.un",
                        OpCode = ILOpCodes.Conv_Ovf_I1_Un,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x83:
                    return new ILInstruction
                    {
                        Name = "conv.ovf.i2.un",
                        OpCode = ILOpCodes.Conv_Ovf_I2_Un,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x84:
                    return new ILInstruction
                    {
                        Name = "conv.ovf.i4.un",
                        OpCode = ILOpCodes.Conv_Ovf_I4_Un,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x85:
                    return new ILInstruction
                    {
                        Name = "conv.ovf.i8.un",
                        OpCode = ILOpCodes.Conv_Ovf_I8_Un,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x86:
                    return new ILInstruction
                    {
                        Name = "conv.ovf.u1.un",
                        OpCode = ILOpCodes.Conv_Ovf_U1_Un,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x87:
                    return new ILInstruction
                    {
                        Name = "conv.ovf.u2.un",
                        OpCode = ILOpCodes.Conv_Ovf_U2_Un,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x88:
                    return new ILInstruction
                    {
                        Name = "conv.ovf.u4.un",
                        OpCode = ILOpCodes.Conv_Ovf_U4_Un,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x89:
                    return new ILInstruction
                    {
                        Name = "conv.ovf.u8.un",
                        OpCode = ILOpCodes.Conv_Ovf_U8_Un,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x8A:
                    return new ILInstruction
                    {
                        Name = "conv.ovf.i.un",
                        OpCode = ILOpCodes.Conv_Ovf_I_Un,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x8B:
                    return new ILInstruction
                    {
                        Name = "conv.ovf.u.un",
                        OpCode = ILOpCodes.Conv_Ovf_U_Un,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x8C:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "box",
                        OpCode = ILOpCodes.Box,
                        Operands = null,
                        TotalOperands = 4
                    };

                case 0x8D:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "newarr",
                        OpCode = ILOpCodes.Newarr,
                        Operands = null,
                        TotalOperands = 4
                    };

                case 0x8E:
                    return new ILInstruction
                    {
                        Name = "ldlen",
                        OpCode = ILOpCodes.Ldlen,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x8F:
                    return new ILInstruction
                    {
                        Name = "ldelema",
                        OpCode = ILOpCodes.Ldelema,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x90:
                    return new ILInstruction
                    {
                        Name = "ldelem.i1",
                        OpCode = ILOpCodes.Ldelem_I1,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x91:
                    return new ILInstruction
                    {
                        Name = "ldelem.u1",
                        OpCode = ILOpCodes.Ldelem_U1,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x92:
                    return new ILInstruction
                    {
                        Name = "ldelem.i2",
                        OpCode = ILOpCodes.Ldelem_I2,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x93:
                    return new ILInstruction
                    {
                        Name = "ldelem.u2",
                        OpCode = ILOpCodes.Ldelem_U2,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x94:
                    return new ILInstruction
                    {
                        Name = "ldelem.i4",
                        OpCode = ILOpCodes.Ldelem_I4,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x95:
                    return new ILInstruction
                    {
                        Name = "ldelem.u4",
                        OpCode = ILOpCodes.Ldelem_U4,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x96:
                    return new ILInstruction
                    {
                        Name = "ldelem.i8",
                        OpCode = ILOpCodes.Ldelem_I8,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x97:
                    return new ILInstruction
                    {
                        Name = "ldelem.i",
                        OpCode = ILOpCodes.Ldelem_I,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x98:
                    return new ILInstruction
                    {
                        Name = "ldelem.r4",
                        OpCode = ILOpCodes.Ldelem_R4,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x99:
                    return new ILInstruction
                    {
                        Name = "ldelem.r8",
                        OpCode = ILOpCodes.Ldelem_R8,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x9A:
                    return new ILInstruction
                    {
                        Name = "ldelem.ref",
                        OpCode = ILOpCodes.Ldelem_Ref,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x9B:
                    return new ILInstruction
                    {
                        Name = "stelem.i",
                        OpCode = ILOpCodes.Stelem_I,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x9C:
                    return new ILInstruction
                    {
                        Name = "stelem.i1",
                        OpCode = ILOpCodes.Stelem_I1,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x9D:
                    return new ILInstruction
                    {
                        Name = "stelem.i2",
                        OpCode = ILOpCodes.Stelem_I2,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x9E:
                    return new ILInstruction
                    {
                        Name = "stelem.i4",
                        OpCode = ILOpCodes.Stelem_I4,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0x9F:
                    return new ILInstruction
                    {
                        Name = "stelem.i8",
                        OpCode = ILOpCodes.Stelem_I8,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0xA0:
                    return new ILInstruction
                    {
                        Name = "stelem.r4",
                        OpCode = ILOpCodes.Stelem_R4,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0xA1:
                    return new ILInstruction
                    {
                        Name = "stelem.r8",
                        OpCode = ILOpCodes.Stelem_R8,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0xA2:
                    return new ILInstruction
                    {
                        Name = "stelem.ref",
                        OpCode = ILOpCodes.Stelem_Ref,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0xA3:
                    return new ILInstruction
                    {
                        Name = "ldelem",
                        OpCode = ILOpCodes.Ldelem,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0xA4:
                    return new ILInstruction
                    {
                        Name = "stelem",
                        OpCode = ILOpCodes.Stelem,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0xA5:
                    return new ILInstruction
                    {
                        Name = "unbox.any",
                        OpCode = ILOpCodes.Unbox_Any,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0xA6:
                    return new ILInstruction
                    {
                        Name = "conv.ovf.i1",
                        OpCode = ILOpCodes.Conv_Ovf_I1,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0xA7:
                    return new ILInstruction
                    {
                        Name = "conv.ovf.u1",
                        OpCode = ILOpCodes.Conv_Ovf_U1,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0xA8:
                    return new ILInstruction
                    {
                        Name = "conv.ovf.i2",
                        OpCode = ILOpCodes.Conv_Ovf_I2,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0xA9:
                    return new ILInstruction
                    {
                        Name = "conv.ovf.u2",
                        OpCode = ILOpCodes.Conv_Ovf_U2,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0xAA:
                    return new ILInstruction
                    {
                        Name = "conv.ovf.i4",
                        OpCode = ILOpCodes.Conv_Ovf_I4,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0xAB:
                    return new ILInstruction
                    {
                        Name = "conv.ovf.u4",
                        OpCode = ILOpCodes.Conv_Ovf_U4,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0xAC:
                    return new ILInstruction
                    {
                        Name = "conv.ovf.i8",
                        OpCode = ILOpCodes.Conv_Ovf_I8,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0xAD:
                    return new ILInstruction
                    {
                        Name = "conv.ovf.u8",
                        OpCode = ILOpCodes.Conv_Ovf_U8,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0xAF:
                    return new ILInstruction
                    {
                        Name = "ckfinite",
                        OpCode = ILOpCodes.Ckfinite,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0xB0:
                    return new ILInstruction
                    {
                        Name = "mkrefany",
                        OpCode = ILOpCodes.Mkrefany,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0xB1:
                    return new ILInstruction
                    {
                        Name = "ldtoken",
                        OpCode = ILOpCodes.Ldtoken,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0xB3:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "conv.u1",
                        OpCode = ILOpCodes.Conv_U1,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0xB4:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "conv.i",
                        OpCode = ILOpCodes.Conv_I,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0xB5:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "conv.ovf.i",
                        OpCode = ILOpCodes.Conv_Ovf_I,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0xB6:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "conv.ovf.u",
                        OpCode = ILOpCodes.Conv_Ovf_U,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0xB7:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "add.ovf",
                        OpCode = ILOpCodes.Add_Ovf,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0xB8:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "add.ovf.un",
                        OpCode = ILOpCodes.Add_Ovf_Un,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0xB9:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "mul.ovf",
                        OpCode = ILOpCodes.Mul_Ovf,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0xBA:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "mul.ovf.un",
                        OpCode = ILOpCodes.Mul_Ovf_Un,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0xBB:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "sub.ovf",
                        OpCode = ILOpCodes.Sub_Ovf,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0xBC:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "sub.ovf.un",
                        OpCode = ILOpCodes.Sub_Ovf_Un,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0xBD:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "endfinally",
                        OpCode = ILOpCodes.Endfinally,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0xBE:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "leave",
                        OpCode = ILOpCodes.Leave,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0xBF:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "leave.s",
                        OpCode = ILOpCodes.Leave_S,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0xC0:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "stind.i",
                        OpCode = ILOpCodes.Stind_I,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0xC1:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "conv.u",
                        OpCode = ILOpCodes.Conv_U,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0xC2:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "refanyval",
                        OpCode = ILOpCodes.Refanyval,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0xC6:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "readonly.",
                        OpCode = ILOpCodes.Readonly,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0xD0:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "tail.",
                        OpCode = ILOpCodes.Tail,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0xD1:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "conv.u2",
                        OpCode = ILOpCodes.Conv_U2,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0xD2:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "constrained.",
                        OpCode = ILOpCodes.Constrained,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0xD3:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "cpblk",
                        OpCode = ILOpCodes.Cpblk,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0xD4:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "initblk",
                        OpCode = ILOpCodes.Initblk,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0xD5:
                    return new ILInstruction
                    {
                        Name = "no.",
                        OpCode = ILOpCodes.No,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0xD6:
                    return new ILInstruction
                    {
                        Name = "rethrow",
                        OpCode = ILOpCodes.Rethrow,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0xD7:
                    return new ILInstruction
                    {
                        Name = "sizeof",
                        OpCode = ILOpCodes.Sizeof,
                        Operands = null,
                        TotalOperands = 0
                    };

                case 0xD8:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "refanytype",
                        OpCode = ILOpCodes.Refanytype,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0xD9:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "readonly.",
                        OpCode = ILOpCodes.Readonly,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };
                case 0xDC:
                    return new ILInstruction
                    {
                        Name = "endfault",
                        OpCode = ILOpCodes.EndFault,
                        Operands = null,
                        TotalOperands = 0
                    };
                case 0xDD: // leave
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "leave",
                        OpCode = ILOpCodes.Leave,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };
                case 0xDE: //leave.s
                    pSkipBytes = 1;
                    return new ILInstruction
                    {
                        Name = "leave.s",
                        OpCode = ILOpCodes.Leave_S,
                        Operands = pByte.Skip((int)pIndex + 1).Take(1).ToArray(),
                        TotalOperands = 1
                    };


                case 0xE0:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "calli",
                        OpCode = ILOpCodes.Calli,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0xE1:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "break",
                        OpCode = ILOpCodes.Break,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0xE2:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "ldarg.0",
                        OpCode = ILOpCodes.Ldarg_0,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0xE3:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "ldarg.1",
                        OpCode = ILOpCodes.Ldarg_1,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };


                case 0xF3:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "ldarg.s",
                        OpCode = ILOpCodes.Ldarg_S,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0xF7:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "calli",
                        OpCode = ILOpCodes.Calli,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };

                case 0xFE:
                    //get the next byte and determine the opcode
                    pSkipBytes = 1;
                    switch (pByte[(int)pIndex + 1])
                    {
                        
                        case 0x00:
                            return new ILInstruction
                            {
                                Name = "arglist",
                                OpCode = ILOpCodes.Arglist,
                                Operands = null,
                                TotalOperands = 0
                            };
                        case 0x01:
                            return new ILInstruction
                            {
                                Name = "ceq",
                                OpCode = ILOpCodes.Ceq,
                                Operands = null,
                                TotalOperands = 0
                            };
                        case 0x02:
                            return new ILInstruction
                            {
                                Name = "cgt",
                                OpCode = ILOpCodes.Cgt,
                                Operands = null,
                                TotalOperands = 0
                            };
                        case 0x03:
                            return new ILInstruction
                            {
                                Name = "cgt.un",
                                OpCode = ILOpCodes.Cgt_Un,
                                Operands = null,
                                TotalOperands = 0
                            };
                        case 0x04:
                            return new ILInstruction
                            {
                                Name = "clt",
                                OpCode = ILOpCodes.Clt,
                                Operands = null,
                                TotalOperands = 0
                            };
                        case 0x05:
                            return new ILInstruction
                            {
                                Name = "clt.un",
                                OpCode = ILOpCodes.Clt_Un,
                                Operands = null,
                                TotalOperands = 0
                            };
                        case 0x06:
                            pSkipBytes = 4;
                            return new ILInstruction
                            {
                                Name = "ldftn",
                                OpCode = ILOpCodes.Ldftn,
                                Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                                TotalOperands = 4
                            };
                        case 0x07:
                            pSkipBytes = 4;
                            return new ILInstruction
                            {
                                Name = "ldvirtftn",
                                OpCode = ILOpCodes.Ldvirtftn,
                                Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                                TotalOperands = 4
                            };
                        case 0x09:
                            return new ILInstruction
                            {
                                Name = "ldarg",
                                OpCode = ILOpCodes.Ldarg,
                                Operands = null,
                                TotalOperands = 0
                            };
                        case 0x0A:
                            return new ILInstruction
                            {
                                Name = "ldarga",
                                OpCode = ILOpCodes.Ldarga,
                                Operands = null,
                                TotalOperands = 0
                            };
                        case 0x0B:
                            return new ILInstruction
                            {
                                Name = "starg",
                                OpCode = ILOpCodes.Starg,
                                Operands = null,
                                TotalOperands = 0
                            };
                        case 0x0C:
                            pSkipBytes = 4;
                            return new ILInstruction
                            {
                                Name = "unaligned.",
                                OpCode = ILOpCodes.Unaligned,
                                Operands = null,
                                TotalOperands = 1
                            };
                        case 0x15:
                            pSkipBytes = 4;
                            return new ILInstruction
                            {
                                Name = "initobj",
                                OpCode = ILOpCodes.Initobj,
                                Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                                TotalOperands = 4
                            };
                        case 0x16:
                            pSkipBytes = 4;
                            return new ILInstruction
                            {
                                Name = "constrained.",
                                OpCode = ILOpCodes.Constrained,
                                Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                                TotalOperands = 4
                            };
                    }
                    break;


                case 0xFF:
                    pSkipBytes = 4;
                    return new ILInstruction
                    {
                        Name = "volatile.",
                        OpCode = ILOpCodes.Volatile,
                        Operands = pByte.Skip((int)pIndex + 1).Take(4).ToArray(),
                        TotalOperands = 4
                    };
            }

            return new ILInstruction
            {
                Name = "UNKNOWN",
                OpCode = ILOpCodes.Nop,
                Operands = null,
                TotalOperands = 0
            };
        }



        private void ParseAssembly(MetadataReader metadataReader)
        {
            foreach (var typeDefHandle in metadataReader.TypeDefinitions)
            {
                var typeDef = metadataReader.GetTypeDefinition(typeDefHandle);
                string typeName = metadataReader.GetString(typeDef.Name);
                string typeNamespace = metadataReader.GetString(typeDef.Namespace);

                var fields = ParseFields(metadataReader, typeDef);
                var methods = ParseMethods(metadataReader, typeDef);

                mClasses.Add(new ILClass
                {
                    Name = $"{typeNamespace}.{typeName}",
                    Fields = fields,
                    Methods = methods
                });
            }
        }

        private ILField[] ParseFields(MetadataReader metadataReader, TypeDefinition typeDef)
        {
            var fields = new List<ILField>();

            foreach (var fieldHandle in typeDef.GetFields())
            {
                var field = metadataReader.GetFieldDefinition(fieldHandle);
                string fieldName = metadataReader.GetString(field.Name);
                string fieldType = field.DecodeSignature(new TypeNameDecoder(metadataReader), null);

                fields.Add(new ILField
                {
                    Name = fieldName,
                    Type = fieldType
                });
            }

            return fields.ToArray();
        }
        private ILMethod[] ParseMethods(MetadataReader metadataReader, TypeDefinition typeDef)
        {
            var methods = new List<ILMethod>();

            foreach (var methodHandle in typeDef.GetMethods())
            {
                var method = metadataReader.GetMethodDefinition(methodHandle);
                string methodName = metadataReader.GetString(method.Name);

                // Decode the method signature
                var signature = method.DecodeSignature(new TypeNameDecoder(metadataReader), null);
                var parameters = new List<string>();
                foreach (var parameter in signature.ParameterTypes)
                {
                    parameters.Add(parameter);
                }

                string returnType = signature.ReturnType;
                var locals = new List<string>();
                var code = new List<string>();
                MethodBodyBlock body = mPERdr.GetMethodBody(method.RelativeVirtualAddress);

                // Print out each byte
                foreach (var b in body.GetILBytes())
                {
                    code.Add(b.ToString("X2"));
                }

                // Extracting method flags
                ILProperties properties = (ILProperties)method.Attributes;

                // Add the method information to the list
                methods.Add(new ILMethod
                {
                    Name = methodName,
                    ReturnType = returnType,
                    Parameters = parameters.ToArray(),
                    Locals = locals.ToArray(),
                    Code = code.ToArray(),
                    Properties = properties // Add the extracted properties to the ILMethod
                });
            }

            return methods.ToArray();
        }


        public ILClass[] GetClasses()
        {
            return mClasses.ToArray();
        }
        FileStream fs;
        void WriteLine(string text)
        {
            if (fs != null)
            {
                byte[] info = new UTF8Encoding(true).GetBytes(text + "\n");
                fs.Write(info, 0, info.Length);
            }
            else
            {
                Console.WriteLine(text);
            }
        }
        void Write(string text)
        {
            if (fs != null)
            {
                byte[] info = new UTF8Encoding(true).GetBytes(text);
                fs.Write(info, 0, info.Length);
            }
            else
            {
                Console.Write(text);
            }
        }
        bool useVerbose = false;
        private void VerboseWrite(string text)
        {
            if (useVerbose)
            {
                Console.WriteLine(text);
            }
        }
        public void PrintILInfo(string outfile = "", bool CLike = false, bool Verbose = false)
        {
            useVerbose = Verbose;
            ulong closeparen = 0;
            if (outfile != "")
            {
                fs = new FileStream(outfile, FileMode.Create);
                VerboseWrite("Opened file for writing output to: " + outfile);
            }
            else
            {
                fs = null;
                VerboseWrite("No file specified for output. Output will be written to the console.");
            }

            // Iterating over classes
            foreach (var ilClass in mClasses)
            {
                VerboseWrite($"Processing class: {ilClass.Name}");

                if (CLike)
                {
                    closeparen++;
                    bool isEnum = false;

                    // Check if the class is an Enum (based on its first field being 'value__')
                    if (ilClass.Methods.Length == 0)
                    {
                        if (ilClass.Fields.Length >= 1 && ilClass.Fields[0].Name == "value__")
                        {
                            isEnum = true;
                            VerboseWrite($"Detected Enum: {ilClass.Name}");
                        }
                    }

                    // Handle Enum or Class
                    if (!isEnum)
                    {
                        VerboseWrite($"Class detected: {ilClass.Name}");
                        WriteLine($"class {ilClass.Name}");
                        WriteLine("{");
                        foreach (var field in ilClass.Fields)
                        {
                            VerboseWrite($"Field: {field.Name} ({field.Type})");
                            WriteLine($"  {field.Type} {field.Name}; ");
                        }
                    }
                    else
                    {
                        VerboseWrite($"Enum detected: {ilClass.Name}");
                        WriteLine($"enum {ilClass.Name}");
                        WriteLine("{");
                        foreach (var field in ilClass.Fields)
                        {
                            VerboseWrite($"Field: {field.Name} ({field.Type})");
                            WriteLine(field != ilClass.Fields[ilClass.Fields.Length - 1]
                                ? $"  {field.Name}, "
                                : $"  {field.Name}");
                        }
                    }

                }
                else
                {
                    WriteLine($"Class: {ilClass.Name}");
                    foreach (var field in ilClass.Fields)
                    {
                        VerboseWrite($"Field: {field.Name} ({field.Type})");
                        WriteLine($"  Field: {field.Name} ({field.Type})");
                    }
                }

                // Iterating over methods
                foreach (var method in ilClass.Methods)
                {
                    VerboseWrite($"Processing method: {method.Name} with return type {method.ReturnType}");

                    if (CLike)
                    {
                        Write("  ");
                        if (method.Properties.HasFlag(ILProperties.Static)) Write("static ");
                        if (method.Properties.HasFlag(ILProperties.Public)) Write("public ");
                        if (method.Properties.HasFlag(ILProperties.Private)) Write("private ");
                        if (method.Properties.HasFlag(ILProperties.Final)) Write("final ");
                        if (method.Properties.HasFlag(ILProperties.Virtual)) Write("virtual ");
                        if (method.Properties.HasFlag(ILProperties.Abstract)) Write("abstract ");
                        if (method.Properties.HasFlag(ILProperties.SpecialName)) Write("specialname ");

                        if (method.Name == ".ctor" || method.Name == ".cctor")
                        {
                            WriteLine($"Void {ilClass.Name}()");
                        }
                        else
                        {
                            Write($"{method.ReturnType} {method.Name}(");
                        }
                    }
                    else
                    {
                        WriteLine($"  Method: {method.Name} ({method.ReturnType}) [{method.Properties}]");
                    }

                    // Iterate over parameters
                    uint paramcount = 0;
                    foreach (var parameter in method.Parameters)
                    {
                        VerboseWrite($"Processing parameter: {parameter}");
                        if (CLike)
                        {
                            Write($"{parameter} param_{paramcount.ToString()}");
                            if (paramcount < method.Parameters.Length - 1)
                            {
                                Write(", ");
                            }
                            else
                            {
                                WriteLine(")");
                            }
                        }
                        else
                        {
                            WriteLine($"    Parameter: {parameter}");
                        }
                        paramcount++;
                    }

                    if (paramcount == 0 && CLike)
                    {
                        WriteLine(")");
                    }

                    if (CLike)
                    {
                        WriteLine("  {");
                    }

                    // Iterate over locals
                    uint loccount = 0;
                    foreach (var local in method.Locals)
                    {
                        VerboseWrite($"Processing local: {local}");
                        if (CLike)
                        {
                            WriteLine($"  {local} local_{loccount.ToString()}; ");
                            loccount++;
                        }
                        else
                        {
                            WriteLine($"    Local: {local}");
                        }
                    }

                    // Process method bytecode
                    byte[] code = new byte[method.Code.Length];
                    for (int i = 0; i < method.Code.Length; i++)
                    {
                        code[i] = Convert.ToByte(method.Code[i], 16);
                    }

                    // Parsing bytecode
                    for (ulong i = 0; i < (ulong)code.Length; i++)
                    {
                        uint skipBytes = 0;
                        ILInstruction instr = ByteIL2ILOp(code, i, ref skipBytes);
                        Write($"    IL_{i.ToString("X2")}: {instr.Name}");
                        VerboseWrite($"Parsing IL instruction: {instr.Name} at index {i}");

                        // Handle specific opcodes (branch, call, load, etc.)
                        if (instr.Name == "call" || instr.Name == "callvirt")
                        {
                            uint metadataToken = BitConverter.ToUInt32(code, (int)(i + 1));
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            WriteLine($" [{ResolveMethodNameFromToken(metadataToken)}]");
                            Console.ResetColor();
                        }
                        else if (instr.Name == "ldstr")
                        {
                            uint metadataToken = BitConverter.ToUInt32(code, (int)(i + 1));
                            Console.ForegroundColor = ConsoleColor.Green;
                            try
                            {
                                WriteLine($" \"{CleanStr(mModule.ResolveString((int)metadataToken))}\"");
                            }
                            catch
                            {
                                WriteLine($" [0x{metadataToken.ToString("X2")}]");
                            }
                            Console.ResetColor();
                        }
                        else if (instr.Name == "newobj" || instr.Name == "initobj")
                        {
                            uint metadataToken = BitConverter.ToUInt32(code, (int)(i + 1));
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            WriteLine($" [{ResolveMethodNameFromToken(metadataToken)}]");
                            Console.ResetColor();
                        }
                        else if (instr.Name == "switch")
                        {
                            uint numCases = BitConverter.ToUInt32(code, (int)(i + 1));
                            VerboseWrite($"Switch instruction with {numCases} cases.");
                            int totalBytes = 4 + (int)numCases * 4;
                            if ((uint)i + totalBytes > code.Length)
                            {
                                throw new Exception("Invalid switch instruction: Not enough bytes in the code array.");
                            }

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            WriteLine($"\n\t{{\n");
                            for (int j = 0; j < numCases; j++)
                            {
                                uint caseOffset = BitConverter.ToUInt32(code, (int)((uint)i + 5 + j * 4));
                                uint caseAddress = (uint)(i + 5 + caseOffset);
                                WriteLine($"\t\tIL_{caseAddress.ToString("X2")},");
                            }
                            WriteLine("\t}");
                            Console.ResetColor();
                        }
                        else if (instr.TotalOperands > 0)
                        {
                            Write(" (");
                            for (uint j = 0; j < instr.TotalOperands; j++)
                            {
                                Write(code[i + 1 + j].ToString("X2"));
                                if (j < instr.TotalOperands - 1)
                                {
                                    Write(", ");
                                }
                            }
                            WriteLine(")");
                        }
                        else
                        {
                            WriteLine("");
                        }

                        i += skipBytes;
                    }

                    if (CLike)
                    {
                        WriteLine("  }");
                    }
                }

                if (CLike)
                {
                    WriteLine("}");
                }
            }
        }


        private string ResolveObjectNameFromToken(uint metadataToken)
        {
            //use the Module to find the object
            try
            {
                var obj = mModule.ResolveType((int)metadataToken);
                if (obj != null)
                {
                    return obj.FullName;
                }
                else return "null";
            }
            catch
            {
                return "null";
            }
        }

        private string ResolveFieldNameFromToken(uint metadataToken)
        {
            //use the Module to find the field
            try
            {
                var field = mModule.ResolveField((int)metadataToken);
                if (field != null)
                {
                    string fullPath = field.DeclaringType.FullName + "::" + field.Name;
                    return fullPath;
                }
                else return "null";
            }
            catch
            {
                return "null";
            }
        }

        private string CleanStr(string pStr)
        {
            string output = pStr.Replace("\n", "\\n");
            output = output.Replace("\r", "\\r");
            output = output.Replace("\t", "\\t");
            return output;
        }
        private string ResolveMethodNameFromToken(uint metadataToken)
        {
            //use the Module to find the method
            try
            {
                var method = mModule.ResolveMethod((int)metadataToken);
                if (method != null)
                {
                    string fullPath = method.DeclaringType.FullName + "::" + method.Name;
                    return fullPath;
                }
                else return "null";
            }
            catch
            {
                return "null";
            }
        }

        public ILMethod CleanILMethod(ILMethod pMethod)
        {
            pMethod.Name = pMethod.Name.Replace(".", "_");
            return pMethod;
        }
        public string ILOpcode2Nasm(ILOpCodes pOpCode)
        {
            switch (pOpCode)
            {

            }
            return "";
        }
        public string ILMethod2Nasm(ILClass pClass, ILMethod pMethod)
        {
            NasmEmitter emitter = new NasmEmitter(mAllowComments);
            emitter.Emit($"; Method: {pMethod.Name}"); // MethodName from class ClassName
            emitter.Emit($"; Return Type: {pMethod.ReturnType}"); // Int32
            emitter.Emit($"; Parameters: {string.Join(", ", pMethod.Parameters)}"); // Int32, Int32
            emitter.Emit($"; Locals: {string.Join(", ", pMethod.Locals)}"); // Int32, Int32, R8
            emitter.Emit($"{pClass.Name}_m{CleanILMethod(pMethod).Name}_p{pMethod.Parameters.Length.ToString()}:"); // ClassName_mMethodName_p2:
            foreach (var il in pMethod.Code)
            {
                emitter.Emit(ILOpcode2Nasm((ILOpCodes)Enum.Parse(typeof(ILOpCodes), il.Split(' ')[0])));
            }
            return emitter.GetNasmCode();
        }
    }

    public class NasmEmitter
    {
        string[] mNasmCode;
        ulong mLineInfo;
        bool mAllowComments;

        public NasmEmitter(bool pAllowComments)
        {
            mNasmCode = new string[1024];
            mLineInfo = 0;
            mAllowComments = pAllowComments;
        }

        public void Emit(string code)
        {
            //if comments arent allowed, remove them
            if (!mAllowComments)
                code = code.Split(';')[0];
            if (mAllowComments)
                mNasmCode[mLineInfo++] = code;
        }

        public void RemoveEmptyLines()
        {
            mNasmCode = mNasmCode.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            mLineInfo = (ulong)mNasmCode.Length;
        }

        public void RemoveLast()
        {
            mNasmCode[mLineInfo - 1] = string.Empty;
            mLineInfo--;
        }

        public string GetNasmCode()
        {
            return string.Join("\n", mNasmCode);
        }

        public void SaveToFile(string path)
        {
            File.WriteAllLines(path, mNasmCode);
        }
    }

    public class TypeNameDecoder : ISignatureTypeProvider<string, object>
    {
        private MetadataReader _metadataReader;

        public TypeNameDecoder(MetadataReader metadataReader)
        {
            _metadataReader = metadataReader;
        }

        public string GetArrayType(string elementType, ArrayShape shape) => $"{elementType}[]";
        public string GetByReferenceType(string elementType) => $"{elementType}&";
        public string GetFunctionPointerType(MethodSignature<string> signature) => "fnptr";
        public string GetGenericInstantiation(string genericType, ImmutableArray<string> typeArguments) => $"{genericType}<{string.Join(", ", typeArguments)}>";
        public string GetGenericMethodParameter(object genericContext, int index) => $"!{index}";
        public string GetGenericTypeParameter(object genericContext, int index) => $"!{index}";
        public string GetModifiedType(string modifier, string unmodifiedType, bool isRequired) => $"{modifier} {unmodifiedType}";
        public string GetPinnedType(string elementType) => $"pinned {elementType}";
        public string GetPointerType(string elementType) => $"{elementType}*";
        public string GetPrimitiveType(PrimitiveTypeCode typeCode) => typeCode.ToString();
        public string GetSZArrayType(string elementType) => $"{elementType}[]";
        public string GetTypeFromDefinition(MetadataReader reader, TypeDefinitionHandle handle, byte rawTypeKind) => _metadataReader.GetString(_metadataReader.GetTypeDefinition(handle).Name);
        public string GetTypeFromReference(MetadataReader reader, TypeReferenceHandle handle, byte rawTypeKind) => _metadataReader.GetString(_metadataReader.GetTypeReference(handle).Name);
        public string GetTypeFromSpecification(MetadataReader reader, object genericContext, TypeSpecificationHandle handle, byte rawTypeKind) => throw new NotImplementedException();
    }
}
