﻿using System;
using System.Collections.Generic;

namespace LibARMP
{
    internal class DataTypes
    {
        //TODO add v2 types here
        internal static IDictionary<string, Type> Types = new Dictionary<string, Type>
        {
            { "invalid", null }, // Invalid
            { "uint8", typeof(byte) }, // uint8
            { "uint16", typeof(UInt16) }, // uint16
            { "uint32", typeof(UInt32) }, // uint32
            { "uint64", typeof(UInt64) }, // uint64
            { "int8", typeof(sbyte) }, // int8
            { "int16", typeof(Int16) }, // int16
            { "int32", typeof(Int32) }, // int32
            { "int64", typeof(Int64) }, // int64
            { "float32", typeof(float) }, // float32
            { "float64", typeof(double) }, // float64
            { "boolean", typeof(bool) }, // boolean
            { "string", typeof(string) }, // string
            { "table", typeof(ArmpTableMain) }, // Table
            { "uint8_array", typeof(List<byte>) }, // uint8 array
            { "uint16_array", typeof(List<UInt16>) }, // uint16 array
            { "uint32_array", typeof(List<UInt32>) }, // uint32 array
            { "uint64_array", typeof(List<UInt64>) }, // uint64 array
            { "int8_array", typeof(List<sbyte>) }, // int8 array
            { "int16_array", typeof(List<Int16>) }, // int16 array
            { "int32_array", typeof(List<Int32>) }, // int32 array
            { "int64_array", typeof(List<Int64>) }, // int64 array
            { "string_array", typeof(List<string>) }, // string array
            { "table_array", typeof(List<ArmpTableMain>) }, // table array
            { "float32_array", typeof(List<float>) }, // float32 array
            { "float64_array", typeof(List<double>) }, // float64 array
            { "vf128_array", typeof(List<float>) }, // VF128
            { "bool_array", typeof(List<bool>) }, // bool array
        };


        /// <summary>
        /// Types for version 1.
        /// </summary>
        internal static IDictionary<sbyte, Type> TypesV1 = new Dictionary<sbyte, Type>
        {
            { -1, null }, // Invalid
            { 2, typeof(byte) }, // uint8
            { 1, typeof(UInt16) }, // uint16
            { 0, typeof(UInt32) }, // uint32
            { 8, typeof(UInt64) }, // uint64
            { 5, typeof(sbyte) }, // int8
            { 4, typeof(Int16) }, // int16
            { 3, typeof(Int32) }, // int32
            { 10, typeof(Int64) }, // int64
            { 7, typeof(float) }, // float32
            { 6, typeof(bool) }, // boolean
            //{ 0, typeof(string) }, // string
            { 9, typeof(ArmpTableMain) } // Table
        };


        /// <summary>
        /// Types for version 1. Reverse table for writes.
        /// </summary>
        internal static IDictionary<Type, sbyte> TypesV1Reverse = new Dictionary<Type, sbyte>
        {
            //{ null, -1 }, // Invalid
            { typeof(byte), 2 }, // uint8
            { typeof(UInt16), 1 }, // uint16
            { typeof(UInt32), 0 }, // uint32
            { typeof(UInt64), 8 }, // uint64
            { typeof(sbyte), 5 }, // int8
            { typeof(Int16), 4 }, // int16
            { typeof(Int32), 3 }, // int32
            { typeof(Int64), 10 }, // int64
            { typeof(float), 7 }, // float32
            { typeof(bool), 6 }, // boolean
            { typeof(string), 0 }, // string
            { typeof(ArmpTableMain), 9 } // Table
        };


        /// <summary>
        /// Types for version 1 (auxiliary table).
        /// </summary>
        internal static IDictionary<sbyte, Type> TypesV1Aux = new Dictionary<sbyte, Type>
        {
            { -1, null }, // Invalid
            { 0, typeof(byte) }, // uint8
            { 1, typeof(UInt16) }, // uint16
            { 2, typeof(UInt32) }, // uint32
            { 3, typeof(UInt64) }, // uint64
            { 4, typeof(sbyte) }, // int8
            { 5, typeof(Int16) }, // int16
            { 6, typeof(Int32) }, // int32
            { 7, typeof(Int64) }, // int64
            { 9, typeof(float) }, // float32
            { 11, typeof(bool) }, // boolean
            { 12, typeof(string) }, // string
            { 13, typeof(ArmpTableMain) } // Table
        };


        /// <summary>
        /// Types for version 1 (auxiliary table). Reverse table for writes.
        /// </summary>
        internal static IDictionary<Type, sbyte> TypesV1AuxReverse = new Dictionary<Type, sbyte>
        {
            //{ null, -1 }, // Invalid
            { typeof(byte), 0 }, // uint8
            { typeof(UInt16), 1 }, // uint16
            { typeof(UInt32), 2 }, // uint32
            { typeof(UInt64), 3 }, // uint64
            { typeof(sbyte), 4 }, // int8
            { typeof(Int16), 5 }, // int16
            { typeof(Int32), 6 }, // int32
            { typeof(Int64), 7 }, // int64
            { typeof(float), 9 }, // float32
            { typeof(bool), 11 }, // boolean
            { typeof(string), 12 }, // string
            { typeof(ArmpTableMain), 13 } // Table
        };


        /// <summary>
        /// Types for version 2.
        /// </summary>
        internal static IDictionary<sbyte, Type> TypesV2 = new Dictionary<sbyte, Type>
        {
            { -1, null }, // Invalid
            { 2, typeof(byte) }, // uint8
            { 1, typeof(UInt16) }, // uint16
            { 0, typeof(UInt32) }, // uint32
            { 8, typeof(UInt64) }, // uint64
            { 5, typeof(sbyte) }, // int8
            { 4, typeof(Int16) }, // int16
            { 3, typeof(Int32) }, // int32
            { 10, typeof(Int64) }, // int64
            { 7, typeof(float) }, // float32
            { 11, typeof(double) }, // float64
            { 6, typeof(bool) }, // boolean
            { 13, typeof(string) }, // string
            { 9, typeof(ArmpTableMain) }, // Table
            { 14, typeof(List<byte>) }, // uint8 array
            { 15, typeof(List<UInt16>) }, // uint16 array
            { 16, typeof(List<UInt32>) }, // uint32 array
            { 17, typeof(List<UInt64>) }, // uint64 array
            { 18, typeof(List<sbyte>) }, // int8 array
            { 19, typeof(List<Int16>) }, // int16 array
            { 20, typeof(List<Int32>) }, // int32 array
            { 21, typeof(List<Int64>) }, // int64 array
            { 22, typeof(List<string>) }, // string array
            { 23, typeof(List<ArmpTableMain>) }, // table array
            { 25, typeof(List<float>) }, // float32 array
            { 26, typeof(List<double>) }, // float64 array
            { 27, typeof(List<float>) }, // VF128 ?? TODO
            { 29, typeof(List<bool>) }, // bool array
        };



        /// <summary>
        /// Types for version 2. (auxiliary table)
        /// </summary>
        internal static IDictionary<sbyte, Type> TypesV2Aux = new Dictionary<sbyte, Type>
        {
            { -1, null }, // Invalid
            { 0, null }, // Invalid
            { 4, typeof(byte) }, // uint8
            { 3, typeof(UInt16) }, // uint16
            { 2, typeof(UInt32) }, // uint32
            { 1, typeof(UInt64) }, // uint64
            { 8, typeof(sbyte) }, // int8
            { 7, typeof(Int16) }, // int16
            { 6, typeof(Int32) }, // int32
            { 5, typeof(Int64) }, // int64
            { 10, typeof(float) }, // float32
            { 9, typeof(double) }, // float64
            //Note: booleans are stored as uint8
            //{ 4, typeof(bool) }, // boolean
            { 12, typeof(string) }, // string
            { 13, typeof(ArmpTableMain) }, // Table
            { 14, typeof(byte) }, // uint8 array
            { 15, typeof(UInt16) }, // uint16 array
            { 16, typeof(UInt32) }, // uint32 array
            { 17, typeof(UInt64) }, // uint64 array
            { 18, typeof(sbyte) }, // int8 array
            { 19, typeof(Int16) }, // int16 array
            { 20, typeof(Int32) }, // int32 array
            { 21, typeof(Int64) }, // int64 array
            { 25, typeof(string) }, // string array
            { 26, typeof(ArmpTableMain) }, // table array
            { 23, typeof(float) }, // float32 array
            { 24, typeof(double) }, // float64 array
            { 27, typeof(float) }, // VF128 ?? TODO
            { 29, typeof(bool) }, // bool array
        };


        internal static List<Type> TypesV2Specials = new List<Type>
        {
            typeof(List<byte>), // uint8 array
            typeof(List<UInt16>), // uint16 array
            typeof(List<UInt32>), // uint32 array
            typeof(List<UInt64>), // uint64 array
            typeof(List<sbyte>), // int8 array
            typeof(List<Int16>), // int16 array
            typeof(List<Int32>), // int32 array
            typeof(List<Int64>), // int64 array
            typeof(List<string>), // string array
            typeof(List<ArmpTableMain>), // table array
            typeof(List<float>), // float32 array
            typeof(List<double>), // float64 array
            typeof(List<float>), // VF128 ?? TODO
            typeof(List<bool>), // bool array
        };


        /// <summary>
        /// Types for Old Engine.
        /// </summary>
        internal static IDictionary<int, Type> TypesOE = new Dictionary<int, Type>
        {
            //TODO figure out type IDs
            { -1, null }, // Invalid
            { 2, typeof(sbyte) }, // int8
            { 1, typeof(Int16) }, // int16
            { 0, typeof(Int32) }, // int32
            { 5, typeof(byte) }, // uint8
            { 4, typeof(UInt16) }, // uint16
            { 3, typeof(UInt32) }, // uint32
            { 6, typeof(bool) }, // boolean
            //{ 8, typeof(??) }, // ??
        };


        /// <summary>
        /// Types for Old Engine. Reverse table for writes.
        /// </summary>
        internal static IDictionary<Type, int> TypesOEReverse = new Dictionary<Type, int>
        {
            //{ null, -1 }, // Invalid
            { typeof(sbyte), 2 }, // int8
            { typeof(Int16), 1 }, // int16
            { typeof(Int32), 0 }, // int32
            { typeof(byte), 5 }, // uint8
            { typeof(UInt16), 4 }, // uint16
            { typeof(UInt32), 3 }, // uint32
            { typeof(bool), 6 }, // boolean
            { typeof(string), 1 }, // string (indices as int16)
            //{ typeof(??), 8 }, // ??
        };
    }
}
