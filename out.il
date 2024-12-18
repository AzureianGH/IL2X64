class .<Module>
{
}
class Microsoft.CodeAnalysis.EmbeddedAttribute
{
  public specialname Void Microsoft.CodeAnalysis.EmbeddedAttribute()
)
  {
    IL_00: ldarg.0
    IL_01: call [System.Attribute::.ctor]
    IL_06: nop
    IL_07: ret
  }
}
class System.Runtime.CompilerServices.NullableAttribute
{
  Byte[] NullableFlags; 
  public specialname Void System.Runtime.CompilerServices.NullableAttribute()
Byte param_0)
  {
    IL_00: ldarg.0
    IL_01: call [System.Attribute::.ctor]
    IL_06: nop
    IL_07: ldarg.0
    IL_08: ldc.i4.1
    IL_09: newarr (1E, 00, 00, 01)
    IL_0E: dup
    IL_0F: ldc.i4.0
    IL_10: ldarg.1
    IL_11: stelem.i1
    IL_12: stfld (01, 00, 00, 04)
    IL_17: ret
  }
  public specialname Void System.Runtime.CompilerServices.NullableAttribute()
Byte[] param_0)
  {
    IL_00: ldarg.0
    IL_01: call [System.Attribute::.ctor]
    IL_06: nop
    IL_07: ldarg.0
    IL_08: ldarg.1
    IL_09: stfld (01, 00, 00, 04)
    IL_0E: ret
  }
}
class System.Runtime.CompilerServices.NullableContextAttribute
{
  Byte Flag; 
  public specialname Void System.Runtime.CompilerServices.NullableContextAttribute()
Byte param_0)
  {
    IL_00: ldarg.0
    IL_01: call [System.Attribute::.ctor]
    IL_06: nop
    IL_07: ldarg.0
    IL_08: ldarg.1
    IL_09: stfld (02, 00, 00, 04)
    IL_0E: ret
  }
}
class CosmosNTFS.Kernel
{
  CosmosVFS FS; 
  Void BeforeRun()
  {
    IL_00: nop
    IL_01: ldarg.0
    IL_02: newobj [null]
    IL_07: stfld (03, 00, 00, 04)
    IL_0C: ldarg.0
    IL_0D: ldfld (03, 00, 00, 04)
    IL_12: ldc.i4.1
    IL_13: ldc.i4.0
    IL_14: call [null]
    IL_19: nop
    IL_1A: ldarg.0
    IL_1B: ldfld (03, 00, 00, 04)
    IL_20: callvirt [null]
    IL_25: callvirt [null]
    IL_2A: stloc.0
    IL_2B: ldloc.0
    IL_2C: ldc.i4.0
    IL_2D: ldelem.ref
    IL_2E: ldfld (15, 00, 00, 0A)
    IL_33: call [CosmosNTFS.NTFS::PrintNTFSHeaderInfo]
    IL_38: nop
    IL_39: ret
  }
  Void Run()
  {
    IL_00: nop
    IL_01: ldstr "Input: "
    IL_06: call [System.Console::Write]
    IL_0B: nop
    IL_0C: call [System.Console::ReadLine]
    IL_11: stloc.0
    IL_12: ldstr "Text typed: "
    IL_17: call [System.Console::Write]
    IL_1C: nop
    IL_1D: ldloc.0
    IL_1E: call [System.Console::WriteLine]
    IL_23: nop
    IL_24: ret
  }
  public specialname Void CosmosNTFS.Kernel()
)
  {
    IL_00: ldarg.0
    IL_01: call [null]
    IL_06: nop
    IL_07: ret
  }
}
class CosmosNTFS.NTFS
{
  static public Byte[] ReadDiskSector(BlockDevice param_0, UInt64 param_1, Boolean param_2, PartInfo param_3)
  {
    IL_00: nop
    IL_01: ldarg.0
    IL_02: ldnull
    IL_03: ceq
    IL_05: stloc.0
    IL_06: ldloc.0
    IL_07: brfalse.s (08)
    IL_09: nop
    IL_0A: ldnull
    IL_0B: stloc.1
    IL_0C: br (DC, 00, 00, 00)
    IL_11: ldarg.2
    IL_12: stloc.2
    IL_13: ldloc.2
    IL_14: brfalse.s (73)
    IL_16: nop
    IL_17: ldarg.3
    IL_18: ldfld (1A, 00, 00, 0A)
    IL_1D: ldarg.1
    IL_1E: add
    IL_1F: ldarg.3
    IL_20: ldfld (1B, 00, 00, 0A)
    IL_25: clt.un
    IL_27: ldc.i4.0
    IL_28: ceq
    IL_2A: stloc.s (04)
    IL_2C: ldloc.s (04)
    IL_2E: brfalse.s (35)
    IL_30: nop
    IL_31: ldloca.s (05)
    IL_33: ldc.i4.s (16)
    IL_35: ldc.i4.1
    IL_36: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::.ctor]
    IL_3B: ldloca.s (05)
    IL_3D: ldstr "Sector out of bounds: "
    IL_42: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendLiteral]
    IL_47: nop
    IL_48: ldloca.s (05)
    IL_4A: ldarg.1
    IL_4B: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendFormatted]
    IL_50: nop
    IL_51: ldloca.s (05)
    IL_53: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::ToStringAndClear]
    IL_58: call [System.Console::WriteLine]
    IL_5D: nop
    IL_5E: ldnull
    IL_5F: stloc.1
    IL_60: br (88, 00, 00, 00)
    IL_65: ldarg.0
    IL_66: callvirt [null]
    IL_6B: conv.ovf.i.un
    IL_6C: newarr (1E, 00, 00, 01)
    IL_71: stloc.3
    IL_72: ldarg.0
    IL_73: ldarg.3
    IL_74: ldfld (1A, 00, 00, 0A)
    IL_79: ldarg.1
    IL_7A: add
    IL_7B: ldc.i4.1
    IL_7C: conv.i8
    IL_7D: ldloca.s (03)
    IL_7F: callvirt [null]
    IL_84: nop
    IL_85: ldloc.3
    IL_86: stloc.1
    IL_87: br.s (64)
    IL_89: nop
    IL_8A: ldarg.1
    IL_8B: ldarg.0
    IL_8C: callvirt [null]
    IL_91: clt.un
    IL_93: ldc.i4.0
    IL_94: ceq
    IL_96: stloc.s (07)
    IL_98: ldloc.s (07)
    IL_9A: brfalse.s (32)
    IL_9C: nop
    IL_9D: ldloca.s (05)
    IL_9F: ldc.i4.s (16)
    IL_A1: ldc.i4.1
    IL_A2: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::.ctor]
    IL_A7: ldloca.s (05)
    IL_A9: ldstr "Sector out of bounds: "
    IL_AE: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendLiteral]
    IL_B3: nop
    IL_B4: ldloca.s (05)
    IL_B6: ldarg.1
    IL_B7: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendFormatted]
    IL_BC: nop
    IL_BD: ldloca.s (05)
    IL_BF: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::ToStringAndClear]
    IL_C4: call [System.Console::WriteLine]
    IL_C9: nop
    IL_CA: ldnull
    IL_CB: stloc.1
    IL_CC: br.s (1F)
    IL_CE: ldarg.0
    IL_CF: callvirt [null]
    IL_D4: conv.ovf.i.un
    IL_D5: newarr (1E, 00, 00, 01)
    IL_DA: stloc.s (06)
    IL_DC: ldarg.0
    IL_DD: ldarg.1
    IL_DE: ldc.i4.1
    IL_DF: conv.i8
    IL_E0: ldloca.s (06)
    IL_E2: callvirt [null]
    IL_E7: nop
    IL_E8: ldloc.s (06)
    IL_EA: stloc.1
    IL_EB: br.s (00)
    IL_ED: ldloc.1
    IL_EE: ret
  }
  static public Void WriteSector(BlockDevice param_0, UInt64 param_1, Byte[] param_2, Boolean param_3, PartInfo param_4)
  {
    IL_00: nop
    IL_01: ldarg.0
    IL_02: ldnull
    IL_03: ceq
    IL_05: stloc.0
    IL_06: ldloc.0
    IL_07: brfalse.s (06)
    IL_09: nop
    IL_0A: br (4E, 01, 00, 00)
    IL_0F: ldarg.3
    IL_10: stloc.1
    IL_11: ldloc.1
    IL_12: brfalse (B0, 00, 00, 00)
    IL_17: nop
    IL_18: ldarg.s
    IL_19: ldarg.2
    IL_1A: ldfld (1A, 00, 00, 0A)
    IL_1F: ldarg.1
    IL_20: add
    IL_21: ldarg.s
    IL_22: ldarg.2
    IL_23: ldfld (1B, 00, 00, 0A)
    IL_28: clt.un
    IL_2A: ldc.i4.0
    IL_2B: ceq
    IL_2D: stloc.2
    IL_2E: ldloc.2
    IL_2F: brfalse.s (33)
    IL_31: nop
    IL_32: ldloca.s (03)
    IL_34: ldc.i4.s (16)
    IL_36: ldc.i4.1
    IL_37: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::.ctor]
    IL_3C: ldloca.s (03)
    IL_3E: ldstr "Sector out of bounds: "
    IL_43: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendLiteral]
    IL_48: nop
    IL_49: ldloca.s (03)
    IL_4B: ldarg.1
    IL_4C: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendFormatted]
    IL_51: nop
    IL_52: ldloca.s (03)
    IL_54: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::ToStringAndClear]
    IL_59: call [System.Console::WriteLine]
    IL_5E: nop
    IL_5F: br (F9, 00, 00, 00)
    IL_64: ldarg.2
    IL_65: ldlen
    IL_66: conv.i8
    IL_67: ldarg.0
    IL_68: callvirt [null]
    IL_6D: ceq
    IL_6F: ldc.i4.0
    IL_70: ceq
    IL_72: stloc.s (04)
    IL_74: ldloc.s (04)
    IL_76: brfalse.s (35)
    IL_78: nop
    IL_79: ldloca.s (03)
    IL_7B: ldc.i4.s (16)
    IL_7D: ldc.i4.1
    IL_7E: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::.ctor]
    IL_83: ldloca.s (03)
    IL_85: ldstr "Data length mismatch: "
    IL_8A: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendLiteral]
    IL_8F: nop
    IL_90: ldloca.s (03)
    IL_92: ldarg.2
    IL_93: ldlen
    IL_94: conv.i4
    IL_95: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendFormatted]
    IL_9A: nop
    IL_9B: ldloca.s (03)
    IL_9D: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::ToStringAndClear]
    IL_A2: call [System.Console::WriteLine]
    IL_A7: nop
    IL_A8: br (B0, 00, 00, 00)
    IL_AD: ldarg.0
    IL_AE: ldarg.s
    IL_AF: ldarg.2
    IL_B0: ldfld (1A, 00, 00, 0A)
    IL_B5: ldarg.1
    IL_B6: add
    IL_B7: ldc.i4.1
    IL_B8: conv.i8
    IL_B9: ldarga.s (02)
    IL_BB: callvirt [null]
    IL_C0: nop
    IL_C1: nop
    IL_C2: br (96, 00, 00, 00)
    IL_C7: nop
    IL_C8: ldarg.1
    IL_C9: ldarg.0
    IL_CA: callvirt [null]
    IL_CF: clt.un
    IL_D1: ldc.i4.0
    IL_D2: ceq
    IL_D4: stloc.s (05)
    IL_D6: ldloc.s (05)
    IL_D8: brfalse.s (30)
    IL_DA: nop
    IL_DB: ldloca.s (03)
    IL_DD: ldc.i4.s (16)
    IL_DF: ldc.i4.1
    IL_E0: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::.ctor]
    IL_E5: ldloca.s (03)
    IL_E7: ldstr "Sector out of bounds: "
    IL_EC: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendLiteral]
    IL_F1: nop
    IL_F2: ldloca.s (03)
    IL_F4: ldarg.1
    IL_F5: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendFormatted]
    IL_FA: nop
    IL_FB: ldloca.s (03)
    IL_FD: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::ToStringAndClear]
    IL_102: call [System.Console::WriteLine]
    IL_107: nop
    IL_108: br.s (53)
    IL_10A: ldarg.2
    IL_10B: ldlen
    IL_10C: conv.i8
    IL_10D: ldarg.0
    IL_10E: callvirt [null]
    IL_113: ceq
    IL_115: ldc.i4.0
    IL_116: ceq
    IL_118: stloc.s (06)
    IL_11A: ldloc.s (06)
    IL_11C: brfalse.s (32)
    IL_11E: nop
    IL_11F: ldloca.s (03)
    IL_121: ldc.i4.s (16)
    IL_123: ldc.i4.1
    IL_124: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::.ctor]
    IL_129: ldloca.s (03)
    IL_12B: ldstr "Data length mismatch: "
    IL_130: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendLiteral]
    IL_135: nop
    IL_136: ldloca.s (03)
    IL_138: ldarg.2
    IL_139: ldlen
    IL_13A: conv.i4
    IL_13B: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendFormatted]
    IL_140: nop
    IL_141: ldloca.s (03)
    IL_143: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::ToStringAndClear]
    IL_148: call [System.Console::WriteLine]
    IL_14D: nop
    IL_14E: br.s (0D)
    IL_150: ldarg.0
    IL_151: ldarg.1
    IL_152: ldc.i4.1
    IL_153: conv.i8
    IL_154: ldarga.s (02)
    IL_156: callvirt [null]
    IL_15B: nop
    IL_15C: nop
    IL_15D: ret
  }
  static public Void PrintNTFSHeaderInfo(BlockDevice param_0)
  {
    IL_00: nop
    IL_01: ldarg.0
    IL_02: ldc.i4.0
    IL_03: conv.i8
    IL_04: ldc.i4.1
    IL_05: ldarg.0
    IL_06: newobj [null]
    IL_0B: ldfld (25, 00, 00, 0A)
    IL_10: ldc.i4.0
    IL_11: callvirt [null]
    IL_16: call [CosmosNTFS.NTFS::ReadDiskSector]
    IL_1B: stloc.0
    IL_1C: ldloc.0
    IL_1D: newobj [System.IO.MemoryStream::.ctor]
    IL_22: newobj [System.IO.BinaryReader::.ctor]
    IL_27: stloc.1
    IL_28: ldloca.s (02)
    IL_2A: initobj [null]
    IL_2F: ldarg.0
    IL_30: ldloca.s (02)
    IL_32: ldloc.1
    IL_33: ldc.i4.3
    IL_34: callvirt [System.IO.BinaryReader::ReadBytes]
    IL_39: stfld (04, 00, 00, 04)
    IL_3E: ldloca.s (02)
    IL_40: ldloc.1
    IL_41: ldc.i4.8
    IL_42: callvirt [System.IO.BinaryReader::ReadBytes]
    IL_47: stfld (05, 00, 00, 04)
    IL_4C: ldloca.s (02)
    IL_4E: ldloc.1
    IL_4F: callvirt [System.IO.BinaryReader::ReadUInt16]
    IL_54: stfld (06, 00, 00, 04)
    IL_59: ldloca.s (02)
    IL_5B: ldloc.1
    IL_5C: callvirt [System.IO.BinaryReader::ReadByte]
    IL_61: stfld (07, 00, 00, 04)
    IL_66: ldloca.s (02)
    IL_68: ldloc.1
    IL_69: callvirt [System.IO.BinaryReader::ReadUInt16]
    IL_6E: stfld (08, 00, 00, 04)
    IL_73: ldloca.s (02)
    IL_75: ldloc.1
    IL_76: callvirt [System.IO.BinaryReader::ReadByte]
    IL_7B: stfld (09, 00, 00, 04)
    IL_80: ldloca.s (02)
    IL_82: ldloc.1
    IL_83: callvirt [System.IO.BinaryReader::ReadUInt16]
    IL_88: stfld (0A, 00, 00, 04)
    IL_8D: ldloca.s (02)
    IL_8F: ldloc.1
    IL_90: callvirt [System.IO.BinaryReader::ReadUInt16]
    IL_95: stfld (0B, 00, 00, 04)
    IL_9A: ldloca.s (02)
    IL_9C: ldloc.1
    IL_9D: callvirt [System.IO.BinaryReader::ReadByte]
    IL_A2: stfld (0C, 00, 00, 04)
    IL_A7: ldloca.s (02)
    IL_A9: ldloc.1
    IL_AA: callvirt [System.IO.BinaryReader::ReadUInt16]
    IL_AF: stfld (0D, 00, 00, 04)
    IL_B4: ldloca.s (02)
    IL_B6: ldloc.1
    IL_B7: callvirt [System.IO.BinaryReader::ReadUInt16]
    IL_BC: stfld (0E, 00, 00, 04)
    IL_C1: ldloca.s (02)
    IL_C3: ldloc.1
    IL_C4: callvirt [System.IO.BinaryReader::ReadUInt16]
    IL_C9: stfld (0F, 00, 00, 04)
    IL_CE: ldloca.s (02)
    IL_D0: ldloc.1
    IL_D1: callvirt [System.IO.BinaryReader::ReadUInt32]
    IL_D6: stfld (10, 00, 00, 04)
    IL_DB: ldloca.s (02)
    IL_DD: ldloc.1
    IL_DE: callvirt [System.IO.BinaryReader::ReadUInt32]
    IL_E3: stfld (11, 00, 00, 04)
    IL_E8: ldloca.s (02)
    IL_EA: ldloc.1
    IL_EB: callvirt [System.IO.BinaryReader::ReadUInt32]
    IL_F0: stfld (12, 00, 00, 04)
    IL_F5: ldloca.s (02)
    IL_F7: ldloc.1
    IL_F8: callvirt [System.IO.BinaryReader::ReadUInt64]
    IL_FD: stfld (13, 00, 00, 04)
    IL_102: ldstr "JMP: "
    IL_107: call [System.Text.Encoding::get_ASCII]
    IL_10C: ldloc.2
    IL_10D: ldfld (04, 00, 00, 04)
    IL_112: callvirt [System.Text.Encoding::GetString]
    IL_117: call [System.String::Concat]
    IL_11C: call [System.Console::WriteLine]
    IL_121: nop
    IL_122: ldstr "OEM ID: "
    IL_127: call [System.Text.Encoding::get_ASCII]
    IL_12C: ldloc.2
    IL_12D: ldfld (05, 00, 00, 04)
    IL_132: callvirt [System.Text.Encoding::GetString]
    IL_137: call [System.String::Concat]
    IL_13C: call [System.Console::WriteLine]
    IL_141: nop
    IL_142: ldloca.s (05)
    IL_144: ldc.i4.s (12)
    IL_146: ldc.i4.1
    IL_147: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::.ctor]
    IL_14C: ldloca.s (05)
    IL_14E: ldstr "Bytes per sector: "
    IL_153: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendLiteral]
    IL_158: nop
    IL_159: ldloca.s (05)
    IL_15B: ldloc.2
    IL_15C: ldfld (06, 00, 00, 04)
    IL_161: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendFormatted]
    IL_166: nop
    IL_167: ldloca.s (05)
    IL_169: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::ToStringAndClear]
    IL_16E: call [System.Console::WriteLine]
    IL_173: nop
    IL_174: ldloca.s (05)
    IL_176: ldc.i4.s (15)
    IL_178: ldc.i4.1
    IL_179: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::.ctor]
    IL_17E: ldloca.s (05)
    IL_180: ldstr "Sectors per cluster: "
    IL_185: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendLiteral]
    IL_18A: nop
    IL_18B: ldloca.s (05)
    IL_18D: ldloc.2
    IL_18E: ldfld (07, 00, 00, 04)
    IL_193: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendFormatted]
    IL_198: nop
    IL_199: ldloca.s (05)
    IL_19B: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::ToStringAndClear]
    IL_1A0: call [System.Console::WriteLine]
    IL_1A5: nop
    IL_1A6: ldloca.s (05)
    IL_1A8: ldc.i4.s (17)
    IL_1AA: ldc.i4.1
    IL_1AB: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::.ctor]
    IL_1B0: ldloca.s (05)
    IL_1B2: ldstr "Reserved sector count: "
    IL_1B7: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendLiteral]
    IL_1BC: nop
    IL_1BD: ldloca.s (05)
    IL_1BF: ldloc.2
    IL_1C0: ldfld (08, 00, 00, 04)
    IL_1C5: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendFormatted]
    IL_1CA: nop
    IL_1CB: ldloca.s (05)
    IL_1CD: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::ToStringAndClear]
    IL_1D2: call [System.Console::WriteLine]
    IL_1D7: nop
    IL_1D8: ldloca.s (05)
    IL_1DA: ldc.i4.s (0D)
    IL_1DC: ldc.i4.1
    IL_1DD: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::.ctor]
    IL_1E2: ldloca.s (05)
    IL_1E4: ldstr "Table count: "
    IL_1E9: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendLiteral]
    IL_1EE: nop
    IL_1EF: ldloca.s (05)
    IL_1F1: ldloc.2
    IL_1F2: ldfld (09, 00, 00, 04)
    IL_1F7: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendFormatted]
    IL_1FC: nop
    IL_1FD: ldloca.s (05)
    IL_1FF: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::ToStringAndClear]
    IL_204: call [System.Console::WriteLine]
    IL_209: nop
    IL_20A: ldloca.s (05)
    IL_20C: ldc.i4.s (12)
    IL_20E: ldc.i4.1
    IL_20F: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::.ctor]
    IL_214: ldloca.s (05)
    IL_216: ldstr "Root entry count: "
    IL_21B: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendLiteral]
    IL_220: nop
    IL_221: ldloca.s (05)
    IL_223: ldloc.2
    IL_224: ldfld (0A, 00, 00, 04)
    IL_229: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendFormatted]
    IL_22E: nop
    IL_22F: ldloca.s (05)
    IL_231: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::ToStringAndClear]
    IL_236: call [System.Console::WriteLine]
    IL_23B: nop
    IL_23C: ldloca.s (05)
    IL_23E: ldc.i4.s (0E)
    IL_240: ldc.i4.1
    IL_241: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::.ctor]
    IL_246: ldloca.s (05)
    IL_248: ldstr "Sector count: "
    IL_24D: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendLiteral]
    IL_252: nop
    IL_253: ldloca.s (05)
    IL_255: ldloc.2
    IL_256: ldfld (0B, 00, 00, 04)
    IL_25B: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendFormatted]
    IL_260: nop
    IL_261: ldloca.s (05)
    IL_263: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::ToStringAndClear]
    IL_268: call [System.Console::WriteLine]
    IL_26D: nop
    IL_26E: ldloca.s (05)
    IL_270: ldc.i4.s (0C)
    IL_272: ldc.i4.1
    IL_273: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::.ctor]
    IL_278: ldloca.s (05)
    IL_27A: ldstr "Media type: "
    IL_27F: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendLiteral]
    IL_284: nop
    IL_285: ldloca.s (05)
    IL_287: ldloc.2
    IL_288: ldfld (0C, 00, 00, 04)
    IL_28D: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendFormatted]
    IL_292: nop
    IL_293: ldloca.s (05)
    IL_295: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::ToStringAndClear]
    IL_29A: call [System.Console::WriteLine]
    IL_29F: nop
    IL_2A0: ldloca.s (05)
    IL_2A2: ldc.i4.s (13)
    IL_2A4: ldc.i4.1
    IL_2A5: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::.ctor]
    IL_2AA: ldloca.s (05)
    IL_2AC: ldstr "Sectors per table: "
    IL_2B1: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendLiteral]
    IL_2B6: nop
    IL_2B7: ldloca.s (05)
    IL_2B9: ldloc.2
    IL_2BA: ldfld (0D, 00, 00, 04)
    IL_2BF: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendFormatted]
    IL_2C4: nop
    IL_2C5: ldloca.s (05)
    IL_2C7: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::ToStringAndClear]
    IL_2CC: call [System.Console::WriteLine]
    IL_2D1: nop
    IL_2D2: ldloca.s (05)
    IL_2D4: ldc.i4.s (13)
    IL_2D6: ldc.i4.1
    IL_2D7: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::.ctor]
    IL_2DC: ldloca.s (05)
    IL_2DE: ldstr "Sectors per track: "
    IL_2E3: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendLiteral]
    IL_2E8: nop
    IL_2E9: ldloca.s (05)
    IL_2EB: ldloc.2
    IL_2EC: ldfld (0E, 00, 00, 04)
    IL_2F1: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendFormatted]
    IL_2F6: nop
    IL_2F7: ldloca.s (05)
    IL_2F9: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::ToStringAndClear]
    IL_2FE: call [System.Console::WriteLine]
    IL_303: nop
    IL_304: ldloca.s (05)
    IL_306: ldc.i4.s (0C)
    IL_308: ldc.i4.1
    IL_309: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::.ctor]
    IL_30E: ldloca.s (05)
    IL_310: ldstr "Head count: "
    IL_315: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendLiteral]
    IL_31A: nop
    IL_31B: ldloca.s (05)
    IL_31D: ldloc.2
    IL_31E: ldfld (0F, 00, 00, 04)
    IL_323: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendFormatted]
    IL_328: nop
    IL_329: ldloca.s (05)
    IL_32B: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::ToStringAndClear]
    IL_330: call [System.Console::WriteLine]
    IL_335: nop
    IL_336: ldloca.s (05)
    IL_338: ldc.i4.s (15)
    IL_33A: ldc.i4.1
    IL_33B: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::.ctor]
    IL_340: ldloca.s (05)
    IL_342: ldstr "Hidden sector count: "
    IL_347: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendLiteral]
    IL_34C: nop
    IL_34D: ldloca.s (05)
    IL_34F: ldloc.2
    IL_350: ldfld (10, 00, 00, 04)
    IL_355: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendFormatted]
    IL_35A: nop
    IL_35B: ldloca.s (05)
    IL_35D: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::ToStringAndClear]
    IL_362: call [System.Console::WriteLine]
    IL_367: nop
    IL_368: ldloca.s (05)
    IL_36A: ldc.i4.s (12)
    IL_36C: ldc.i4.1
    IL_36D: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::.ctor]
    IL_372: ldloca.s (05)
    IL_374: ldstr "x86 sector count: "
    IL_379: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendLiteral]
    IL_37E: nop
    IL_37F: ldloca.s (05)
    IL_381: ldloc.2
    IL_382: ldfld (11, 00, 00, 04)
    IL_387: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendFormatted]
    IL_38C: nop
    IL_38D: ldloca.s (05)
    IL_38F: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::ToStringAndClear]
    IL_394: call [System.Console::WriteLine]
    IL_399: nop
    IL_39A: ldloca.s (05)
    IL_39C: ldc.i4.s (0A)
    IL_39E: ldc.i4.1
    IL_39F: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::.ctor]
    IL_3A4: ldloca.s (05)
    IL_3A6: ldstr "Reserved: "
    IL_3AB: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendLiteral]
    IL_3B0: nop
    IL_3B1: ldloca.s (05)
    IL_3B3: ldloc.2
    IL_3B4: ldfld (12, 00, 00, 04)
    IL_3B9: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendFormatted]
    IL_3BE: nop
    IL_3BF: ldloca.s (05)
    IL_3C1: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::ToStringAndClear]
    IL_3C6: call [System.Console::WriteLine]
    IL_3CB: nop
    IL_3CC: ldloca.s (05)
    IL_3CE: ldc.i4.s (12)
    IL_3D0: ldc.i4.1
    IL_3D1: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::.ctor]
    IL_3D6: ldloca.s (05)
    IL_3D8: ldstr "x64 sector count: "
    IL_3DD: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendLiteral]
    IL_3E2: nop
    IL_3E3: ldloca.s (05)
    IL_3E5: ldloc.2
    IL_3E6: ldfld (13, 00, 00, 04)
    IL_3EB: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendFormatted]
    IL_3F0: nop
    IL_3F1: ldloca.s (05)
    IL_3F3: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::ToStringAndClear]
    IL_3F8: call [System.Console::WriteLine]
    IL_3FD: nop
    IL_3FE: ldc.i4.s (30)
    IL_400: conv.i8
    IL_401: stloc.3
    IL_402: ldloc.1
    IL_403: callvirt [System.IO.BinaryReader::get_BaseStream]
    IL_408: ldloc.3
    IL_409: ldc.i4.0
    IL_40A: callvirt [System.IO.Stream::Seek]
    IL_40F: pop
    IL_410: ldloca.s (04)
    IL_412: initobj [null]
    IL_417: ldarg.0
    IL_418: ldloca.s (04)
    IL_41A: ldloc.1
    IL_41B: callvirt [System.IO.BinaryReader::ReadUInt64]
    IL_420: stfld (14, 00, 00, 04)
    IL_425: ldloca.s (04)
    IL_427: ldloc.1
    IL_428: callvirt [System.IO.BinaryReader::ReadUInt64]
    IL_42D: stfld (15, 00, 00, 04)
    IL_432: ldloca.s (04)
    IL_434: ldloc.1
    IL_435: callvirt [System.IO.BinaryReader::ReadSByte]
    IL_43A: stfld (16, 00, 00, 04)
    IL_43F: ldloca.s (04)
    IL_441: ldc.i4.3
    IL_442: newarr (28, 00, 00, 01)
    IL_447: stfld (17, 00, 00, 04)
    IL_44C: ldc.i4.0
    IL_44D: stloc.s (06)
    IL_44F: br.s (18)
    IL_451: nop
    IL_452: ldloc.s (04)
    IL_454: ldfld (17, 00, 00, 04)
    IL_459: ldloc.s (06)
    IL_45B: ldloc.1
    IL_45C: callvirt [System.IO.BinaryReader::ReadSByte]
    IL_461: stelem.i1
    IL_462: nop
    IL_463: ldloc.s (06)
    IL_465: ldc.i4.1
    IL_466: add
    IL_467: stloc.s (06)
    IL_469: ldloc.s (06)
    IL_46B: ldc.i4.3
    IL_46C: clt
    IL_46E: stloc.s (07)
    IL_470: ldloc.s (07)
    IL_472: brtrue.s (DD)
    IL_474: ldloca.s (04)
    IL_476: ldloc.1
    IL_477: callvirt [System.IO.BinaryReader::ReadSByte]
    IL_47C: stfld (18, 00, 00, 04)
    IL_481: ldloca.s (04)
    IL_483: ldc.i4.3
    IL_484: newarr (28, 00, 00, 01)
    IL_489: stfld (19, 00, 00, 04)
    IL_48E: ldc.i4.0
    IL_48F: stloc.s (08)
    IL_491: br.s (18)
    IL_493: nop
    IL_494: ldloc.s (04)
    IL_496: ldfld (19, 00, 00, 04)
    IL_49B: ldloc.s (08)
    IL_49D: ldloc.1
    IL_49E: callvirt [System.IO.BinaryReader::ReadSByte]
    IL_4A3: stelem.i1
    IL_4A4: nop
    IL_4A5: ldloc.s (08)
    IL_4A7: ldc.i4.1
    IL_4A8: add
    IL_4A9: stloc.s (08)
    IL_4AB: ldloc.s (08)
    IL_4AD: ldc.i4.3
    IL_4AE: clt
    IL_4B0: stloc.s (09)
    IL_4B2: ldloc.s (09)
    IL_4B4: brtrue.s (DD)
    IL_4B6: ldloca.s (04)
    IL_4B8: ldloc.1
    IL_4B9: callvirt [System.IO.BinaryReader::ReadUInt64]
    IL_4BE: stfld (1A, 00, 00, 04)
    IL_4C3: ldloca.s (04)
    IL_4C5: ldloc.1
    IL_4C6: callvirt [System.IO.BinaryReader::ReadUInt32]
    IL_4CB: stfld (1B, 00, 00, 04)
    IL_4D0: ldc.i4.s (0A)
    IL_4D2: call [System.Console::set_ForegroundColor]
    IL_4D7: nop
    IL_4D8: ldloca.s (05)
    IL_4DA: ldc.i4.s (0D)
    IL_4DC: ldc.i4.1
    IL_4DD: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::.ctor]
    IL_4E2: ldloca.s (05)
    IL_4E4: ldstr "MFT Cluster: "
    IL_4E9: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendLiteral]
    IL_4EE: nop
    IL_4EF: ldloca.s (05)
    IL_4F1: ldloc.s (04)
    IL_4F3: ldfld (14, 00, 00, 04)
    IL_4F8: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendFormatted]
    IL_4FD: nop
    IL_4FE: ldloca.s (05)
    IL_500: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::ToStringAndClear]
    IL_505: call [System.Console::WriteLine]
    IL_50A: nop
    IL_50B: ldloca.s (05)
    IL_50D: ldc.i4.s (14)
    IL_50F: ldc.i4.1
    IL_510: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::.ctor]
    IL_515: ldloca.s (05)
    IL_517: ldstr "MFT Mirror Cluster: "
    IL_51C: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendLiteral]
    IL_521: nop
    IL_522: ldloca.s (05)
    IL_524: ldloc.s (04)
    IL_526: ldfld (15, 00, 00, 04)
    IL_52B: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendFormatted]
    IL_530: nop
    IL_531: ldloca.s (05)
    IL_533: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::ToStringAndClear]
    IL_538: call [System.Console::WriteLine]
    IL_53D: nop
    IL_53E: ldloca.s (05)
    IL_540: ldc.i4.s (15)
    IL_542: ldc.i4.1
    IL_543: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::.ctor]
    IL_548: ldloca.s (05)
    IL_54A: ldstr "Clusters per record: "
    IL_54F: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendLiteral]
    IL_554: nop
    IL_555: ldloca.s (05)
    IL_557: ldloc.s (04)
    IL_559: ldfld (16, 00, 00, 04)
    IL_55E: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendFormatted]
    IL_563: nop
    IL_564: ldloca.s (05)
    IL_566: call [System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::ToStringAndClear]
    IL_5