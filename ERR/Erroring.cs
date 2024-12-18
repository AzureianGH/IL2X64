using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IL2X64.Error
{
    public enum ILErrorType
    {
        // IL Errors
        IL_UNKNOWN_OPCODE = 0x0001,
        IL_ARBITRARY_LIMIT_REACHED = 0x0002,
        IL_INVALID_ARGUMENT = 0x0003,
        IL_INVALID_TYPE = 0x0004,
        IL_INVALID_METHOD = 0x0005,
        IL_INVALID_FIELD = 0x0006,
        IL_INVALID_SIGNATURE = 0x0007,
        IL_INVALID_TOKEN = 0x0008,
        IL_INVALID_LOCAL = 0x0009,
        IL_INVALID_LABEL = 0x000A,
        IL_INVALID_SWITCH = 0x000B,
        IL_UNRECOGNIZED_INSTRUCTION_FORMAT = 0x000C,
        IL_STACK_OVERFLOW = 0x000D,
        IL_STACK_UNDERFLOW = 0x000E,
        IL_INVALID_STACK_OPERATION = 0x000F,
        IL_UNEXPECTED_END_OF_STREAM = 0x0010,

        // Parsing Errors
        PARSING_SYNTAX_ERROR = 0x1000,
        PARSING_INVALID_TOKEN = 0x1001,
        PARSING_UNEXPECTED_CHARACTER = 0x1002,
        PARSING_UNEXPECTED_EOF = 0x1003,
        PARSING_MISSING_DELIMITER = 0x1004,
        PARSING_TYPE_MISMATCH = 0x1005,

        // Runtime Errors
        RUNTIME_DIVIDE_BY_ZERO = 0x2000,
        RUNTIME_NULL_REFERENCE = 0x2001,
        RUNTIME_OUT_OF_MEMORY = 0x2002,
        RUNTIME_ILLEGAL_OPERATION = 0x2003,
        RUNTIME_OVERFLOW = 0x2004,
        RUNTIME_UNDERFLOW = 0x2005,
        RUNTIME_INDEX_OUT_OF_BOUNDS = 0x2006,
        RUNTIME_UNHANDLED_EXCEPTION = 0x2007,

        // Validation Errors
        VALIDATION_TYPE_MISMATCH = 0x3000,
        VALIDATION_ILLEGAL_CAST = 0x3001,
        VALIDATION_CONSTRAINT_VIOLATION = 0x3002,
        VALIDATION_MISSING_METADATA = 0x3003,
        VALIDATION_UNRESOLVED_REFERENCE = 0x3004,
        VALIDATION_CIRCULAR_DEPENDENCY = 0x3005,

        // Metadata Errors
        METADATA_MISSING_TYPE_DEFINITION = 0x4000,
        METADATA_INVALID_SIGNATURE = 0x4001,
        METADATA_UNRESOLVED_MEMBER_REFERENCE = 0x4002,
        METADATA_DUPLICATE_TOKEN = 0x4003,
        METADATA_CORRUPTION_DETECTED = 0x4004,

        // Debugging Errors
        DEBUG_INVALID_BREAKPOINT = 0x5000,
        DEBUG_INVALID_STEP_OPERATION = 0x5001,
        DEBUG_SYMBOLS_NOT_FOUND = 0x5002,

        // Miscellaneous Errors
        MISC_OPERATION_NOT_SUPPORTED = 0x6000,
        MISC_RESOURCE_NOT_FOUND = 0x6001,
        MISC_FILE_IO_ERROR = 0x6002,
        MISC_INVALID_CONFIGURATION = 0x6003,
        MISC_UNKNOWN_ERROR = 0x6004
    }

    public class IL2X64RuntimeException : Exception
    {
        public ILErrorType iType;
        public IL2X64RuntimeException? iChild; // Nesting for deeper error handling. E.g. IL_INVALID_SWITCH is called with a deeper error of IL_ARBITRARY_LIMIT_REACHED (aka. switch case limit reached)
        public IL2X64RuntimeException(ILErrorType type, string message) : base(message)
        {
            iType = type;
        }
        public IL2X64RuntimeException(ILErrorType type, string message, IL2X64RuntimeException child) : base(message)
        {
            iType = type;
            iChild = child;
        }
    }
}
