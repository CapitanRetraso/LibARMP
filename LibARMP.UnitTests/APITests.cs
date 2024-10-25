﻿using LibARMP.Exceptions;
using LibARMP.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LibARMP.UnitTests
{
    [TestClass]
    public class APITests
    {
        ///// ArmpEntry /////
        #region ArmpEntry

        [TestMethod]
        public void ArmpEntry_ID()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            uint id = armp.MainTable.GetEntry("value").ID;
            Assert.AreEqual((uint)1, id);
        }


        [TestMethod]
        public void ArmpEntry_Name()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            string name = armp.MainTable.GetEntry(1).Name;
            Assert.AreEqual("value", name);
        }


        [TestMethod]
        public void ArmpEntry_Index()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            int index = armp.MainTable.GetEntry("value").Index;
            Assert.AreEqual(1, index);
        }


        [TestMethod]
        public void ArmpEntry_IsValid()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            bool valid = armp.MainTable.GetEntry("value").IsValid;
            Assert.IsTrue(valid);
        }


        [TestMethod]
        public void ArmpEntry_Flags()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v1AllTypes);
            bool[] flags = armp.MainTable.GetEntry("value").Flags;
            Assert.IsFalse(flags[0]);
            Assert.IsTrue(flags[1]);
            Assert.IsTrue(flags[2]);
            Assert.IsFalse(flags[3]);
            Assert.IsFalse(flags[4]);
            Assert.IsFalse(flags[5]);
            Assert.IsFalse(flags[6]);
            Assert.IsFalse(flags[7]);
        }


        [TestMethod]
        public void ArmpEntry_Copy()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            ArmpEntry entry = armp.MainTable.GetEntry("value");
            ArmpEntry copy = entry.Copy(armp.MainTable);
            Assert.AreEqual(entry.GetValueFromColumn<Int32>("s32_"), copy.GetValueFromColumn<Int32>("s32_"));
            Assert.AreEqual(entry.GetValueFromColumn<double>("f64_"), copy.GetValueFromColumn<double>("f64_"));
            Assert.AreEqual(entry.GetValueFromColumn<string>("string"), copy.GetValueFromColumn<string>("string"));
        }


        [TestMethod]
        public void ArmpEntry_GetValueFromColumn()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            ArmpEntry entry = armp.MainTable.GetEntry("value");
            ArmpTableColumn column = armp.MainTable.GetColumn("u16_");
            Assert.AreEqual((UInt16)800, entry.GetValueFromColumn<UInt16>("u16_"));
            Assert.AreEqual((UInt16)800, entry.GetValueFromColumn<UInt16>(2));
            Assert.AreEqual((UInt16)800, entry.GetValueFromColumn<UInt16>(column));
            Assert.AreEqual((UInt16)800, entry.GetValueFromColumn("u16_"));
            Assert.AreEqual((UInt16)800, entry.GetValueFromColumn(2));
            Assert.AreEqual((UInt16)800, entry.GetValueFromColumn(column));
        }


        [TestMethod]
        public void ArmpEntry_SetValueFromColumn()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            ArmpEntry entry = armp.MainTable.GetEntry("value");
            UInt64 expected1 = (UInt64)77777777777;
            UInt32 expected2 = (UInt32)666666666;
            UInt16 expected3 = (UInt16)55555;
            entry.SetValueFromColumn("u64_", expected1);
            entry.SetValueFromColumn(3, expected2); // u32_
            entry.SetValueFromColumn(armp.MainTable.GetColumn("u16_"), (Int64)expected3);
            var result1 = entry.GetValueFromColumn("u64_");
            var result2 = entry.GetValueFromColumn("u32_");
            var result3 = entry.GetValueFromColumn("u16_");
            Assert.AreEqual(expected1, result1);
            Assert.AreEqual(expected2, result2);
            Assert.AreEqual(expected3, result3);
        }
        #endregion



        ///// ArmpTableColumn /////
        #region ArmpTableColumn

        [TestMethod]
        public void ArmpTableColumn_ID()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            uint id = armp.MainTable.GetColumn("u32_").ID;
            Assert.AreEqual((uint)3, id);
        }


        [TestMethod]
        public void ArmpTableColumn_Name()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            string name = armp.MainTable.GetColumn("u32_").Name;
            Assert.AreEqual("u32_", name);
        }


        [TestMethod]
        public void ArmpTableColumn_Index()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            int index = armp.MainTable.GetColumn("u32_").Index;
            Assert.AreEqual((int)4, index);
        }


        [TestMethod]
        public void ArmpTableColumn_IsValid()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            bool valid = (bool)armp.MainTable.GetColumn("u32_").IsValid;
            Assert.AreEqual(true, valid);
        }


        [TestMethod]
        public void ArmpTableColumn_GetDataType()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            ArmpTableColumn c1 = armp.MainTable.GetColumn("u32_");
            ArmpTableColumn c2 = armp.MainTable.GetColumn("s64_");
            ArmpTableColumn c3 = armp.MainTable.GetColumn("f32_");
            ArmpTableColumn c4 = armp.MainTable.GetColumn("bool_");

            Assert.AreEqual(typeof(uint), c1.GetDataType());
            Assert.AreEqual(typeof(Int64), c2.GetDataType());
            Assert.AreEqual(typeof(float), c3.GetDataType());
            Assert.AreEqual(typeof(bool), c4.GetDataType());
        }


        [TestMethod]
        public void ArmpTableColumn_Copy()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            ArmpTableColumn column = armp.MainTable.GetColumn("u32_");
            ArmpTableColumn copy = column.Copy();
            Assert.AreEqual(column.Name, copy.Name);
            Assert.AreEqual(column.Index, copy.Index);
            Assert.AreEqual(column.IsValid, copy.IsValid);
            Assert.AreEqual(column.GetDataType(), copy.GetDataType());
        }
        #endregion



        ///// ArmpTable /////
        #region ArmpTable

        [TestMethod]
        public void ArmpTable_Copy()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            ArmpTable table = armp.MainTable.GetEntry("value").GetValueFromColumn<ArmpTable>("table");
            ArmpTable copy = table.Copy(true);
            Assert.AreEqual(table.GetEntry(1).Name, copy.GetEntry(1).Name);
            Assert.AreEqual(table.GetEntry(2).Name, copy.GetEntry(2).Name);
            Assert.AreEqual(table.GetEntry(1).GetValueFromColumn<byte>("u8"), copy.GetEntry(1).GetValueFromColumn<byte>("u8"));
            Assert.AreEqual(table.GetEntry(2).GetValueFromColumn<byte>("u8"), copy.GetEntry(2).GetValueFromColumn<byte>("u8"));
            Assert.AreEqual(table.GetEntry(1).IsValid, copy.GetEntry(1).IsValid);
            Assert.AreEqual(table.GetEntry(2).IsValid, copy.GetEntry(2).IsValid);
        }


        [TestMethod]
        public void ArmpTable_GetAllEntries()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            List<ArmpEntry> entries = armp.MainTable.GetAllEntries();
            Assert.AreEqual(4, entries.Count);
            Assert.AreEqual("", entries[0].Name);
            Assert.AreEqual("value", entries[1].Name);
            Assert.AreEqual("min_value", entries[2].Name);
            Assert.AreEqual("max_value", entries[3].Name);
        }


        [TestMethod]
        public void ArmpTable_GetEntry()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            ArmpEntry entry = armp.MainTable.GetEntry(1);
            Assert.AreEqual("value", entry.Name);
            entry = armp.MainTable.GetEntry("value");
            Assert.AreEqual((uint)1, entry.ID);
        }


        [TestMethod]
        public void ArmpTable_TryGetEntry()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            ArmpEntry resultEntry;
            bool resultBool = armp.MainTable.TryGetEntry(1, out resultEntry);
            Assert.IsTrue(resultBool);
            Assert.AreEqual("value", resultEntry.Name);
            resultEntry = null;
            resultBool = armp.MainTable.TryGetEntry("value", out resultEntry);
            Assert.IsTrue(resultBool);
            Assert.AreEqual("value", resultEntry.Name);
            resultEntry = null;
            resultBool = armp.MainTable.TryGetEntry("does_not_exist", out resultEntry);
            Assert.IsFalse(resultBool);
            Assert.AreEqual(null, resultEntry);
            resultEntry = null;
            resultBool = armp.MainTable.TryGetEntry(12345, out resultEntry);
            Assert.IsFalse(resultBool);
            Assert.AreEqual(null, resultEntry);
        }


        [TestMethod]
        public void ArmpTable_GetEntryNames()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            List<string> names = armp.MainTable.GetEntryNames();
            Assert.AreEqual(4, names.Count);
            Assert.AreEqual("", names[0]);
            Assert.AreEqual("value", names[1]);
            Assert.AreEqual("min_value", names[2]);
            Assert.AreEqual("max_value", names[3]);
        }


        [TestMethod]
        public void ArmpTable_GetEntryName()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            string name = armp.MainTable.GetEntryName(1);
            Assert.AreEqual("value", name);
        }


        [TestMethod]
        public void ArmpTable_GetAllColumns()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            List<ArmpTableColumn> columns = armp.MainTable.GetAllColumns();
            Assert.AreEqual(70, columns.Count);
            Assert.AreEqual("", columns[0].Name);
            Assert.AreEqual("u8_", columns[1].Name);
            Assert.AreEqual("u16_", columns[2].Name);
            Assert.AreEqual("u32_", columns[3].Name);
            Assert.AreEqual("table", columns[30].Name);
        }


        [TestMethod]
        public void ArmpTable_GetColumn()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            ArmpTableColumn column = armp.MainTable.GetColumn(4);
            Assert.AreEqual("u64_", column.Name);
            column = armp.MainTable.GetColumn("f32_");
            Assert.AreEqual((uint)9, column.ID);
        }


        [TestMethod]
        public void ArmpTable_GetColumnNames()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            List<string> names = armp.MainTable.GetColumnNames();
            Assert.AreEqual(70, names.Count);
            names = armp.MainTable.GetColumnNames(false);
            Assert.AreEqual(55, names.Count);
        }


        [TestMethod]
        public void ArmpTable_GetColumnName()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            string name = armp.MainTable.GetColumnName(4);
            Assert.AreEqual("u64_", name);
        }


        [TestMethod]
        public void ArmpTable_GetColumnDataType()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            Type type = armp.MainTable.GetColumnDataType("f64_");
            Assert.AreEqual(typeof(double), type);
        }


        [TestMethod]
        public void ArmpTable_GetColumnsByType()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            List<ArmpTableColumn> columns = armp.MainTable.GetColumnsByType(typeof(Int64));
            Assert.AreEqual(3, columns.Count);
            columns = armp.MainTable.GetColumnsByType<Int64>();
            Assert.AreEqual(3, columns.Count);
        }


        [TestMethod]
        public void ArmpTable_GetColumnNamesByType()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            List<string> names = armp.MainTable.GetColumnNamesByType(typeof(Int64));
            Assert.AreEqual(3, names.Count);
            names = armp.MainTable.GetColumnNamesByType<Int64>();
            Assert.AreEqual(3, names.Count);
        }


        [TestMethod]
        public void ArmpTable_GetColumnIDsByType()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            List<uint> indices = armp.MainTable.GetColumnIDsByType(typeof(Int64));
            Assert.AreEqual(3, indices.Count);
            Assert.AreEqual((uint)8, indices[0]);
            indices = armp.MainTable.GetColumnIDsByType<Int64>();
            Assert.AreEqual(3, indices.Count);
            Assert.AreEqual((uint)8, indices[0]);
        }


        [TestMethod]
        public void ArmpTable_GetColumnID()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            int index = (int)armp.MainTable.GetColumnID("s32_");
            Assert.AreEqual(7, index);
        }


        [TestMethod]
        public void ArmpTable_GetColumnIndex()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            int index = armp.MainTable.GetColumnIndex("s32_");
            Assert.AreEqual(8, index);
            index = armp.MainTable.GetColumnIndex(7);
            Assert.AreEqual(8, index);
        }


        [TestMethod]
        public void ArmpTable_SetColumnIndex()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            armp.MainTable.SetColumnIndex("s32_", 123);
            int index = armp.MainTable.GetColumnIndex("s32_");
            Assert.AreEqual(123, index);
            armp.MainTable.SetColumnIndex(7, 321);
            index = armp.MainTable.GetColumnIndex(7);
            Assert.AreEqual(321, index);
        }


        [TestMethod]
        public void ArmpTable_IsColumnValid()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            bool valid = armp.MainTable.IsColumnValid("f32_");
            Assert.IsTrue(valid);
            valid = armp.MainTable.IsColumnValid(0);
            Assert.IsFalse(valid);
        }


        [TestMethod]
        public void ArmpTable_SetColumnValidity()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            armp.MainTable.SetColumnValidity("s32_", false);
            ArmpTableColumn column = armp.MainTable.GetColumn("string");
            armp.MainTable.SetColumnValidity(column, false);
            armp.MainTable.SetColumnValidity(column, true);
            armp.MainTable.GetEntry(2).SetValueFromColumn("string", "test_string");
            byte[] buffer = ArmpFileWriter.WriteARMPToArray(armp);
            ARMP armp_new = ArmpFileReader.ReadARMP(buffer);
            Assert.IsFalse((bool)armp_new.MainTable.GetColumn("s32_").IsValid);
            string result = armp.MainTable.GetEntry(2).GetValueFromColumn<string>("string");
            string result2 = armp.MainTable.GetEntry(1).GetValueFromColumn<string>("string");
            Assert.IsTrue((bool)armp_new.MainTable.GetColumn("string").IsValid);
            Assert.AreEqual("test_string", result);
            Assert.AreEqual("", result2);

        }


        [TestMethod]
        public void ArmpTable_IsColumnSpecial()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            bool special = armp.MainTable.IsColumnSpecial("vf128_");
            Assert.IsTrue(special);
            special = armp.MainTable.IsColumnSpecial("f32_");
            Assert.IsFalse(special);
        }


        [TestMethod]
        public void ArmpTable_AddColumn()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            ArmpTableColumn c1 = armp.MainTable.AddColumn<Int64>("test_s64");
            ArmpTableColumn c2 = armp.MainTable.AddColumn<bool>("test_bool");
            //Before saving
            Assert.AreEqual(typeof(Int64), armp.MainTable.GetColumnDataType(c1.Name));
            Assert.AreEqual(typeof(bool), armp.MainTable.GetColumnDataType(c2.Name));
            //After saving
            byte[] temp = ArmpFileWriter.WriteARMPToArray(armp);
            ARMP armp_new = ArmpFileReader.ReadARMP(temp);
            Assert.AreEqual(typeof(Int64), armp_new.MainTable.GetColumnDataType(c1.Name));
            Assert.AreEqual(typeof(bool), armp_new.MainTable.GetColumnDataType(c2.Name));
        }


        [TestMethod]
        public void ArmpTable_DeleteColumn()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            string column = "s32_";
            bool result = armp.MainTable.DeleteColumn(column);
            //Before saving
            Assert.IsTrue(result);
            Assert.ThrowsException<ColumnNotFoundException>(() => armp.MainTable.GetColumn(column));
            //After saving
            byte[] temp = ArmpFileWriter.WriteARMPToArray(armp);
            ARMP armp_new = ArmpFileReader.ReadARMP(temp);
            Assert.ThrowsException<ColumnNotFoundException>(() => armp_new.MainTable.GetColumn(column));
        }


        [TestMethod]
        public void ArmpTable_SearchByName()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            List<ArmpEntry> entries = armp.MainTable.SearchByName("value");
            Assert.AreEqual(3, entries.Count);
            entries = armp.MainTable.SearchByName("min_");
            Assert.AreEqual(1, entries.Count);
        }


        [TestMethod]
        public void ArmpTable_SearchByValue()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            List<ArmpEntry> entries = armp.MainTable.SearchByValue("s16_", (Int16)32767);
            Assert.AreEqual(1, entries.Count);
            entries = armp.MainTable.SearchByValue("u64_array[0]", (UInt64)0);
            Assert.AreEqual(3, entries.Count);
        }


        [TestMethod]
        public void ArmpTable_AddEntry()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            armp.MainTable.AddEntry("test_entry");
            byte[] stream = ArmpFileWriter.WriteARMPToArray(armp);
            ARMP armp_new = ArmpFileReader.ReadARMP(stream);
            ArmpEntry entry = armp_new.MainTable.GetEntry("test_entry");
            Assert.AreEqual((uint)4, entry.ID);
            Assert.AreEqual((byte)0, entry.GetValueFromColumn<byte>("u8_"));
            Assert.AreEqual((UInt16)0, entry.GetValueFromColumn<UInt16>("u16_"));
            Assert.AreEqual((UInt32)0, entry.GetValueFromColumn<UInt32>("u32_"));
            Assert.AreEqual((UInt64)0, entry.GetValueFromColumn<UInt64>("u64_"));
            Assert.AreEqual((float)0, entry.GetValueFromColumn<float>("f32_"));
        }


        [TestMethod]
        public void ArmpTable_InsertEntry()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            armp.MainTable.InsertEntry(2, "test_entry");
            armp.MainTable.InsertEntry(4, "test_entry2");
            armp.MainTable.InsertEntry(6, "test_entry3");
            byte[] stream = ArmpFileWriter.WriteARMPToArray(armp);
            ARMP armp_new = ArmpFileReader.ReadARMP(stream);
            Assert.AreEqual((uint)2, armp_new.MainTable.GetEntry("test_entry").ID);
            Assert.AreEqual((uint)3, armp_new.MainTable.GetEntry("min_value").ID);
            Assert.AreEqual((uint)4, armp_new.MainTable.GetEntry("test_entry2").ID);
            Assert.AreEqual((uint)5, armp_new.MainTable.GetEntry("max_value").ID);
            Assert.AreEqual((uint)6, armp_new.MainTable.GetEntry("test_entry3").ID);
        }


        [TestMethod]
        public void ArmpTable_DeleteEntry()
        {
            ARMP armp = ArmpFileReader.ReadARMP(TestFiles.v2AllTypesModeColumn);
            armp.MainTable.DeleteEntry(0);
            armp.MainTable.DeleteEntry("min_value");
            Assert.AreEqual((uint)0, armp.MainTable.GetEntry("value").ID);
            Assert.AreEqual("max_value", armp.MainTable.GetEntry(1).Name);
            byte[] stream = ArmpFileWriter.WriteARMPToArray(armp);
            ARMP armp_new = ArmpFileReader.ReadARMP(stream);
            Assert.AreEqual((uint)0, armp_new.MainTable.GetEntry("value").ID);
            Assert.AreEqual("max_value", armp_new.MainTable.GetEntry(1).Name);
        }
        #endregion
    }
}
